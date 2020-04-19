using System;
using System.Data;
using System.IO;
using Oracle.DataAccess.Client;

namespace caOspAdminsatV1
{
    class wsJSONsV2
    {
        private static string token;
        private static string respuesta;
        private static tysEnvioJSON envioJSON;
        private static tysToken mt;
        private static Datos datos;
        //private static ccorreo correo;

        static string objJsonEnvio;

        public wsJSONsV2()
        {

        }
        public void procesar()
        {
            infociclo("Inicia Proceso wsJSONv2_1 : " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
            int lpad_transaccion = 0;
            string mensajeEnvio = string.Empty;
            //correo = new ccorreo();
            datos = new Datos();
            envioJSON = new tysEnvioJSON();
            mt = new tysToken();
            mt.getToken();
            token = mt.Token;
            if (token.Length > 30)
            {
                DataTable dtReporte = new DataTable("log_adminsat");
                string select = @"select LPAD_LLAVE_V2 llave,
LPAD_SECUENCIA_NB secuencia,
LPAD_OFICINA_NB oficina,
LPAD_TRANSACCION_NB transaccion
from log_plan_adminsat
where LPAD_ESTADO_V2='P'
--and trunc(LPAD_FECHA_DT) between trunc(sysdate-7) and trunc(sysdate)
order by LPAD_FECHA_DT,LPAD_TRANSACCION_NB";
                dtReporte = datos.getDataTable(select);
                if (dtReporte.Rows.Count > 0)
                {
                    //System.Threading.Thread.Sleep(5000);
                    Console.Clear();
                    foreach (DataRow dr in dtReporte.Rows)
                    {
                        Console.Clear();
                        try
                        {
                            lpad_transaccion = int.Parse(dr["transaccion"].ToString());
                            switch (lpad_transaccion)
                            {
                                case 3:
                                    {
                                        string orden = dr["llave"].ToString();
                                        long secuencia = long.Parse(dr["secuencia"].ToString());
                                        int oficina = int.Parse(dr["oficina"].ToString());
                                        Console.WriteLine("Orden : " + orden);
                                        Console.WriteLine("secuencia : " + secuencia);
                                        Console.WriteLine("oficina : " + oficina);
                                        informeOrden(orden, secuencia, oficina);
                                        break;
                                    }
                                case 4:
                                    {
                                        string planilla = dr["llave"].ToString();
                                        long secuencia = long.Parse(dr["secuencia"].ToString());
                                        int oficina = int.Parse(dr["oficina"].ToString());
                                        Console.WriteLine("planilla : " + planilla);
                                        Console.WriteLine("secuencia : " + secuencia);
                                        Console.WriteLine("oficina : " + oficina);

                                        informeDespacho(planilla, secuencia, oficina);
                                        break;
                                    }
                                case 5:
                                    {
                                        /*string orden = dr["llave"].ToString();
                                        long secuencia = long.Parse(dr["secuencia"].ToString());
                                        int oficina = int.Parse(dr["oficina"].ToString());
                                        anularOrden(orden, secuencia, oficina);
                                        break;*/
                                        string orden = dr["llave"].ToString();
                                        long secuencia = long.Parse(dr["secuencia"].ToString());
                                        int oficina = int.Parse(dr["oficina"].ToString());
                                        Console.WriteLine("Anular orden : " + orden);
                                        Console.WriteLine("secuencia : " + secuencia);
                                        Console.WriteLine("oficina : " + oficina);
                                        anularOrden(orden, secuencia, oficina);
                                        break;

                                    }
                                default:
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            mensajeError(ex);
                            Console.WriteLine(ex.Message);
                        }
                        //System.Threading.Thread.Sleep(3000);
                    }
                }
            }
            else
            {
                mensajeError("wsJSONv2_1 Se presento un error el momento de solicitar el TOKEN. Se cancela la operacion.");
            }
        }

        private static void anularOrden(string orden, long secuencia, int oficina)
        {
            string getJSON = construirObjetoJSONOrdenAnulada(orden);
            objetosJSON("Token : " + token + "/r/n" + "JSON : " + getJSON);
            actualizarRegistroOrdenAnulada(getJSON, orden, secuencia, oficina);

        }

        private static string construirObjetoJSONOrdenAnulada(string orden)
        {
            string getJSON = string.Empty;
            cdocJSONOrdenAnulada myJSONOrdenAnulada = new cdocJSONOrdenAnulada();
            myJSONOrdenAnulada.orden_cargue = orden;
            string json = string.Empty;
            try
            {
                json += Newtonsoft.Json.JsonConvert.SerializeObject(myJSONOrdenAnulada);
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/milenio/");
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/");//

                objJsonEnvio = json;

                //ccorreo correo = new ccorreo();
                //correo.envioCorreoDesarrolador("Objeto JSON Adminsat-OSP", token + "\r\n" + json);
                //envioJSON.sendJSON(token, json, "https://api.adminsat.com/rutas/integracion/" + orden + "/?type=cancel/");//
                envioJSON.sendJSONPUT(token, json, "https://api.adminsat.com/rutas/integracion/" + orden + "/?type=cancel");//

                registroEnvio(token, json);

                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/");

                respuesta = envioJSON.Respuesta;
                Console.WriteLine("respuesta : " + respuesta);
                System.Threading.Thread.Sleep(2000);
                getJSON = respuesta;

                using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\construirObjetoJSONOrdenAnulada.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(token);
                    writer.WriteLine(json);
                    writer.WriteLine(respuesta);
                    writer.WriteLine("*");
                }
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            return getJSON;
        }

        private static void informeOrden(string orden, long secuencia, int oficina)
        {
            int tipoPropietario = 0;
            DataTable dtLogPlanAdminsat = new DataTable("log_pla_adminsat");
            string select = @"select distinct ORCA_CAMINO_NB,
CAMI_SECUENCIA_NB,
ORCA_PLACA_CH activonombre,
ORCA_PLACA_CH activoplaca,
COND_NOMBRE_V2 actornombre,
COND_APELLIDO_V2 actorapellido,
to_char(COND_CEDULA_NB) actordocumento,
'0' actortipo,
to_char(COND_TELEFONO_NB) actortelefono,
to_char(ORCA_CELULAR_NB) actorcelular,
cond.CIUD_DESCRIPCION_V2 actorciudad,
RUTA_CODIGO_NB rutacodigo,
vO.CIUD_DESCRIPCION_V2 viajeorigen,
vD.CIUD_DESCRIPCION_V2 viajedestino,
CAMI_NOMBRE_V2 viajevia,
--to_char(ORCA_FECCREA_DT,'YYYY-MM-DD')||'T'||to_char(ORCA_FECCREA_DT,'hh24:mi:ss') rutafecha,
--to_char(ORCA_FECCREA_DT,'YYYY-MM-DD')||'T'||to_char(ORCA_FECCREA_DT+(1/24)*5,'HH24:MI:SS')||'.'||round(dbms_random.value(100000,999999))||'Z' rutafecha,
--to_char(ORCA_FECCREA_DT+(1/24)*5,'YYYY-MM-DD')||'T'||to_char(ORCA_FECCREA_DT+(1/24)*5,'HH24:MI:SS')||'.'||round(dbms_random.value(100000,999999))||'Z' rutafecha,
to_char(ORCA_FECCREA_DT+(1/24)*5,'YYYY-MM-DD')||'T'||to_char(ORCA_FECCREA_DT+(1/24)*5,'HH24:MI:SS')||'.000000Z' rutafecha,
CLIE_CODIGO_NB rutaidcliente,
CLIE_NOMBRE_V2 rutacliente,
--'2' rutafinalizacion,
'1' inicializacion,
'2' finalizacion,
RUTA_ORIGEN_NB adicionalorigen,
RUTA_DESTINO_NB adicionaldestino,
PROD_NOMBRE_V2 adicionalproducto,
ORCA_NUMERO_NB adicionalorden,
decode(ORCA_ESTADO_V2,'D','despachado','A','Anulado',ORCA_ESTADO_V2) adicionalestado,
ORCA_TRAILER_CH adicionaltipotrailer,
decode(VEHI_PROPIETARIO_NB,0,'propio',1,'propio',2,'tercero',3,'propio',4,'propio',VEHI_PROPIETARIO_NB) adicionalafiliacion,
RUTA_CODIGO_NB adicionalruta,
CAMI_SECUENCIA_NB adicionalcamino,
RUTA_CODIGO_NB adicionalrutaterceros,
CAMI_SECUENCIA_NB adicionalcaminoterceros,
GENE_DESCRIPCION_V2 adicionallatitud,
GENE_DESCRIPCION2_V2 adicionallongitud,
CLVE_DESCRIP_V2 adicionalclase,
PROP_NOMBRE_V2||' '||PROP_APELLIDO_V2 adicionalposeedor,
PROP_TELEFONO_NB adicionaltelefono,
pro.CIUD_DESCRIPCION_V2 adicionalciudad,
' ' adicionalobservaciones,
MARC_DESCRIPCION_V2 adicionalmarca,
COLO_DESCRIPCION_V2 adicionalcolor,
OFIC_NOMBRE_V2 adicionaloficina,
vO.CIUD_DIVIPOLA_CH divipola,
'null' planilla,
VEHI_PROPIETARIO_NB tipopropietario
from log_plan_adminsat,conductores,ciudades cond,ordenes_cargue,rutas,
ciudades vO, ciudades vD,caminos,negocios,clientes,productos,
vehiculos,clase_vehiculo,enlace,propietarios, ciudades pro,
marcas,colores,oficinas,genericas
where ORCA_CONDUCTOR_NB=COND_CEDULA_NB
and cond.CIUD_CODIGO_NB= COND_CIUDAD_NB
and ORCA_RUTA_NB=RUTA_CODIGO_NB
and RUTA_ORIGEN_NB=vO.CIUD_CODIGO_NB
and RUTA_DESTINO_NB=vD.CIUD_CODIGO_NB
and ORCA_CAMINO_NB=CAMI_SECUENCIA_NB
and CAMI_RUTA_NB=RUTA_CODIGO_NB
and ORCA_NEGOCIO_NB=NEGO_NRONEGOCIO_NB
and NEGO_CLIENTENEGO_NB=CLIE_CODIGO_NB
and ORCA_PRODUCTO_NB=PROD_CODIGO_NB
and ORCA_PLACA_CH=VEHI_PLACA_CH
and VEHI_CLASE_NB=CLVE_SECUENCIA_NB
and ENLA_POSEEDOR_NB=PROP_CEDULA_NB
and ENLA_PLACA_CH=ORCA_PLACA_CH
and pro.CIUD_CODIGO_NB=PROP_CIUDRES_NB
and VEHI_MARCA_V2=MARC_SECUENCIA_NB
and VEHI_COLOR_V2=COLO_CODIGO_NB
and ORCA_OFICDESP_NB=OFIC_CODOFIC_NB
and LPAD_ESTADO_V2='P'
and LPAD_LLAVE_V2=to_char(ORCA_NUMERO_NB)
and GENE_NOMBRE_V2='POSICION OFICINA'
and GENE_CODIGO_NB=OFIC_CODOFIC_NB
and ORCA_OFICDESP_NB=OFIC_CODOFIC_NB
and ORCA_NUMERO_NB='" + orden + "'";
            dtLogPlanAdminsat = datos.getDataTable(select);
            if (dtLogPlanAdminsat.Rows.Count > 0)
            {
                foreach (DataRow dr in dtLogPlanAdminsat.Rows)
                {
                    try
                    {
                        tipoPropietario = int.Parse(dr["tipopropietario"].ToString());
                        if (tipoPropietario == 2)
                        {
                            Console.WriteLine("Tercero actualizarRegistroTercero");
                            actualizarRegistroTercero(orden, secuencia, oficina);
                        }
                        else
                        {
                            string getJSON = construirObjetoJSONOrden(dr);
                            objetosJSON("Token : " + token + "/r/n" + "JSON : " + getJSON);
                            Console.WriteLine("actualizarRegistroOrden");
                            actualizarRegistroOrden(getJSON, orden, secuencia, oficina);
                        }
                    }
                    catch (Exception ex)
                    {
                        mensajeError(ex);
                    }
                }
            }
            else
            {
                mensajeError("La orden : " + orden + "  no devolvio valores!!!");
            }
        }
        private static void informeDespacho(string planilla, long secuencia, int oficina)
        {
            int tipoPropietario = 0;
            DataTable dtLogPlanAdminsat = new DataTable("log_pla_adminsat");
            string select = @"select VIAJ_PLACA_CH activoplaca,
VIAJ_ORDCARGUE_NB orden,
VIAJ_NOPLANILLA_V2 planilla,
VEHI_PROPIETARIO_NB tipopropietario
from viajes,vehiculos
where VIAJ_PLACA_CH=VEHI_PLACA_CH
and VIAJ_NOPLANILLA_V2='" + planilla + "'";
            dtLogPlanAdminsat = datos.getDataTable(select);
            if (dtLogPlanAdminsat.Rows.Count > 0)
            {
                foreach (DataRow dr in dtLogPlanAdminsat.Rows)
                {
                    try
                    {
                        tipoPropietario = int.Parse(dr["tipopropietario"].ToString());
                        if (tipoPropietario == 2)
                        {
                            actualizarRegistroTercero(planilla, secuencia, oficina);
                        }
                        else
                        {
                            string getJSON = construirObjetoJSONPlanilla(dr);
                            objetosJSON("Token : " + token + "/r/n" + "JSON : " + getJSON);
                            actualizarRegistroPlanilla(getJSON, planilla, secuencia, oficina);
                        }
                    }
                    catch (Exception ex)
                    {
                        mensajeError(ex);
                    }
                }
            }
            else
            {
                mensajeError("La planilla : " + planilla + "  no devolvio valores!!!");
            }
        }
        private static void actualizarRegistroOrdenAnulada(string getJSON, string orden, long secuencia, int oficina)
        {
            //{"orden_cargue":"1784049"}
            int ordenC = -1;
            dynamic xJSON = Newtonsoft.Json.JsonConvert.DeserializeObject(getJSON);

            try
            {

                ordenC = (int)xJSON.orden_cargue;

                if (ordenC > 0)
                {
                    ejecutarUpdateAnularOrden(ordenC, secuencia, oficina, getJSON, orden);
                    string mensajeEnvio = "Version Programa : wsJSONv2_1  -   Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    envioExitoso(mensajeEnvio);
                    //ccorreo correo = new ccorreo();
                    //correo.envioCorreoDesarrolador("Envio Exitoso. Aplicativo wsJSONv2_1", "Objeto creado : \r\n " + objJsonEnvio + "\r\n Objeto Devuelto : " + getJSON);
                }
                else
                {
                    string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    registroError(mensaje);
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                registroError(ex.Message + "/r/n" + mensaje);
                ccorreo c = new ccorreo();
                //c.envioCorreoDesarrolador("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
                c.envioCorreo("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
            }
        }

        private static void actualizarRegistroOrden(string getJSON, string orden, long secuencia, int oficina)
        {
            string actorVial = "-1";
            string activo = "-1";
            string rut = ""; ;
            try
            {
                dynamic xJSON = Newtonsoft.Json.JsonConvert.DeserializeObject(getJSON);

                actorVial = xJSON.actor_vial;
                activo = xJSON.activo;
                rut = xJSON.enturne;

                if (int.Parse(actorVial) > 0 && int.Parse(activo) > 0)
                {
                    ejecutarUpdateOrden(int.Parse(rut), int.Parse(actorVial), int.Parse(activo), orden, secuencia, oficina, getJSON);
                    string mensajeEnvio = "Version Programa : wsJSONv2_1  -   Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    envioExitoso(mensajeEnvio);
                    //ccorreo correo = new ccorreo();
                    //correo.envioCorreoDesarrolador("Envio Exitoso. Aplicativo wsJSONv2_1", "Objeto creado : \r\n " + objJsonEnvio + "\r\n Objeto Devuelto : " + getJSON);
                }
                else
                {
                    string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    registroError(mensaje);
                }
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                registroError(ex.Message + "/r/n" + mensaje);
                ccorreo c = new ccorreo();
                //c.envioCorreoDesarrolador("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
                //c.envioCorreo("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Orden:" + orden + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                registroError(ex.Message + "/r/n" + mensaje);
                ccorreo c = new ccorreo();
                Console.WriteLine(mensaje);
                //c.envioCorreoDesarrolador("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
                //c.envioCorreo("Version Programa : wsJSONv2_1  - Error al momento de procesar el envio JSON", mensaje);
            }
        }
        private static void actualizarRegistroPlanilla(string getJSON, string planilla, long secuencia, int oficina)
        {
            string pla = string.Empty;
            string ord = string.Empty;
            try
            {
                dynamic xJSON = Newtonsoft.Json.JsonConvert.DeserializeObject(getJSON);
                pla = xJSON.planilla;
                ord = xJSON.orden_cargue;
                if (pla.Length > 5)
                {
                    ejecutarUpdatePlanilla(pla, ord, getJSON);
                    string mensajeEnvio = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Planilla:" + planilla + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    envioExitoso(mensajeEnvio);
                    //ccorreo correo = new ccorreo();
                    //correo.envioCorreoDesarrolador("Envio Exitoso. Aplicativo wsJSONv2_1", "Objeto creado : \r\n " + objJsonEnvio + "\r\n Objeto Devuelto : " + getJSON);
                }
                else
                {
                    string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Planilla:" + planilla + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                    registroError(mensaje);
                }
            }
            catch (Exception ex)
            {
                string mensaje = "Version Programa : wsJSONv2_1  - Secuencia:" + secuencia + ";Planilla:" + planilla + ";Oficina:" + oficina + ";Fecha:" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ";Respuesta:" + getJSON;
                registroError(mensaje);
                //ccorreo c = new ccorreo();
                //c.envioCorreoDesarrolador("Error al momento de procesar el envio JSON", mensaje);
                //ejecutarUpdateRutaNoExiste(-1, -1, -1, planilla, secuencia, oficina, getJSON);
            }
        }
        private static void ejecutarUpdatePlanilla(string planilla, string orden, string mycontent)
        {
            string select = string.Empty;
            select = @"update log_plan_adminsat set
LPAD_ESTADO_V2='E',
LPAD_IDADMINSAT_V2='" + orden + @"',
LPAD_FECENVIO_DT=sysdate,
LPAD_RESPUESTA_V2='" + mycontent + @"'
where LPAD_LLAVE_V2='" + planilla + @"'
and LPAD_ESTADO_V2='P'
and LPAD_TRANSACCION_NB=4";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static void ejecutarUpdateAnularOrden(int Oc, long secuencia, int oficina, string getJSON, string orden)
        {
            Console.WriteLine("Respuesta : " + Oc);
            string select = string.Empty;
            select = @"update log_plan_adminsat set
LPAD_ESTADO_V2='E',
LPAD_IDADMINSAT_V2='" + Oc + @"',
LPAD_FECENVIO_DT=sysdate,
LPAD_RESPUESTA_V2='" + getJSON + @"'
where LPAD_SECUENCIA_NB=" + secuencia + @"
and LPAD_OFICINA_NB=" + oficina + @"
and LPAD_LLAVE_V2='" + orden + @"'
and LPAD_ESTADO_V2='P'";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static void ejecutarUpdateOrden(int ruta, int actorVial, int activo, string planilla, long secuencia, int oficina, string mycontent)
        {
            string select = string.Empty;

            string rapidin = ruta.ToString() + actorVial.ToString() + activo.ToString();

            if (rapidin.Length > 13)
            {
                rapidin = rapidin.Substring(0, 13);
            }
            select = @"update log_plan_adminsat set
LPAD_ESTADO_V2='E',
LPAD_IDADMINSAT_V2='" + rapidin + @"',
LPAD_FECENVIO_DT=sysdate,
LPAD_RESPUESTA_V2='" + mycontent + @"'
where LPAD_SECUENCIA_NB=" + secuencia + @"
and LPAD_OFICINA_NB=" + oficina + @"
and LPAD_LLAVE_V2='" + planilla + @"'
and LPAD_ESTADO_V2='P'";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static void ejecutarUpdateRutaNoExiste(int ruta, int actorVial, int activo, string planilla, long secuencia, int oficina, string mycontent)
        {
            string select = string.Empty;
            select = @"update log_plan_adminsat set
LPAD_ESTADO_V2='R',
LPAD_IDADMINSAT_V2='" + ruta + actorVial + activo + @"',
LPAD_FECENVIO_DT=sysdate,
LPAD_RESPUESTA_V2='" + mycontent + @"'
where LPAD_SECUENCIA_NB=" + secuencia + @"
and LPAD_OFICINA_NB=" + oficina + @"
and LPAD_LLAVE_V2='" + planilla + @"'
and LPAD_ESTADO_V2='P'";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static void actualizarRegistroTercero(string planilla, long secuencia, int oficina)
        {
            string select = string.Empty;
            select = @"update log_plan_adminsat set
LPAD_ESTADO_V2='T',
LPAD_FECENVIO_DT=sysdate,
LPAD_RESPUESTA_V2='Vehiculo Tercero'
where LPAD_SECUENCIA_NB=" + secuencia + @"
and LPAD_OFICINA_NB=" + oficina + @"
and LPAD_LLAVE_V2='" + planilla + @"'
and LPAD_ESTADO_V2='P'";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static string construirObjetoJSONOrden(DataRow dr)
        {
            string getJSON = string.Empty;
            string adicionaltipotrailer = string.Empty;
            if (dr["adicionaltipotrailer"].ToString().Length > 0)
            {
                adicionaltipotrailer = tipoTrailer(dr["adicionaltipotrailer"].ToString());
            }
            else
            {
                adicionaltipotrailer = "Rigido";
            }
            cdocJSON myJSON = new cdocJSON();

            #region Definicion del bloque activo

            try
            {
                cactivo activo = new cactivo();
                activo.nombre = dr["activonombre"].ToString();
                activo.placa = dr["activoplaca"].ToString();
                myJSON.activo = activo;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque activo

            #region Definicion del bloque actor vial

            try
            {
                cactor_vial actor_vial = new cactor_vial();
                actor_vial.nombre = dr["actornombre"].ToString();
                actor_vial.apellidos = dr["actorapellido"].ToString();
                actor_vial.numero_documento_identidad = dr["actordocumento"].ToString();
                actor_vial.tipo_documento_identidad = dr["actortipo"].ToString();
                actor_vial.telefono = dr["actortelefono"].ToString();
                if (dr["actorcelular"].ToString().Length < 10)
                {
                    actor_vial.celular = dr["actorcelular"].ToString().Substring(0, dr["actorcelular"].ToString().Length);
                }
                else
                {
                    actor_vial.celular = dr["actorcelular"].ToString().Substring(0, 10);
                }
                actor_vial.ciudad = dr["actorciudad"].ToString();
                myJSON.actor_vial = actor_vial;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque actor vial

            #region Definicion del bloque ruta.rutas[0]

            cruta rutae = new cruta();
            try
            {
                rutae.origen = dr["viajeorigen"].ToString();
                rutae.destino = dr["viajedestino"].ToString();
                rutae.via = dr["viajevia"].ToString();
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque ruta.rutas[0]

            #region Definicion del bloque ruta.myJSON
            cvarios_json varios_json = new cvarios_json();
            try
            {
                Random r = new Random();

                varios_json.od = dr["adicionaloficina"].ToString();
                varios_json.cc = dr["rutaidcliente"].ToString();
                varios_json.nc = dr["rutacliente"].ToString();
                varios_json.tt = adicionaltipotrailer;
                varios_json.foc = dr["rutafecha"].ToString();// +".492540Z";//to_char(VIAJ_FECVIAJE_DT,'DD/MM/YYYY')||'T'||to_char( VIAJ_FECVIAJE_DT+(1/24)*5,'HH24:MI:SS')||'.'||round(dbms_random.value(100000,999999))||'Z'
                //ruta.varios_json = varios_json;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }

            #endregion fin de la Definicion del bloque ruta.myJSON

            centurne enturn = new centurne();
            enturn.ruta = rutae;
            enturn.orden_cargue = dr["adicionalorden"].ToString();
            enturn.planilla = dr["planilla"].ToString();
            enturn.producto = dr["adicionalproducto"].ToString();
            enturn.fecha_hora_inicio = dr["rutafecha"].ToString();// +".492540Z";//to_char(VIAJ_FECVIAJE_DT,'DD/MM/YYYY')||'T'||to_char( VIAJ_FECVIAJE_DT+(1/24)*5,'HH24:MI:SS')||'.'||round(dbms_random.value(100000,999999))||'Z'
            enturn.inicializacion = dr["inicializacion"].ToString();
            enturn.finalizacion = dr["finalizacion"].ToString();
            enturn.varios_json = varios_json;

            myJSON.enturne = enturn;
            #region Definicion del bloque adiciona

            try
            {
                cadicional adicional = new cadicional();
                adicional.tipo_afiliacion = dr["adicionalafiliacion"].ToString();
                adicional.poseedor = dr["adicionalposeedor"].ToString();
                adicional.telefono_poseedor = dr["adicionaltelefono"].ToString();
                adicional.ciudad_poseedor = dr["adicionalciudad"].ToString();
                adicional.marca_vehiculo = dr["adicionalmarca"].ToString();
                adicional.color_vehiculo = dr["adicionalcolor"].ToString();
                myJSON.adicional = adicional;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque adiciona

            string json = string.Empty;
            try
            {
                json += Newtonsoft.Json.JsonConvert.SerializeObject(myJSON);
                string tmp = string.Empty;
                tmp = json.Replace("ruta\":{\"rutas\":{", "ruta\":{\"rutas\":[{");
                string mtp = tmp.Replace("\"},\"varios_json\":", "\"}],\"varios_json\":");
                json = mtp;
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/milenio/");
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/");//

                objJsonEnvio = mtp;

                //ccorreo correo = new ccorreo();
                //correo.envioCorreoDesarrolador("Objeto JSON Adminsat-OSP", token + "\r\n" + json);
                envioJSON.sendJSON(token, json, "https://api.adminsat.com/rutas/integracion/");//

                registroEnvio(token, json);

                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/");

                respuesta = envioJSON.Respuesta;

                //{"non_field_errors":["Los campos cliente_id, orden_cargue deben formar un conjunto único."]}
                if (respuesta.Contains("Los campos cliente_id, orden_cargue deben formar un conjunto único"))
                {
                    ejecutarUpdateOrdenRepetida(dr["adicionalorden"].ToString());
                }


                getJSON = respuesta;

                using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\construirObjetoJSONOrden.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(token);
                    writer.WriteLine(json);
                    writer.WriteLine(respuesta);
                    writer.WriteLine("*");
                }
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            return getJSON;
        }

        private static void ejecutarUpdateOrdenRepetida(string orden)
        {
            string select = string.Empty;
            select = @"update log_plan_adminsat set LPAD_ESTADO_V2='E' where LPAD_LLAVE_V2='" + orden + @"' and LPAD_ESTADO_V2='P'";
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                try
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    mensajeError(ex);
                }
                catch (Exception ex)
                {
                    mensajeError(ex);
                }
            }
        }
        private static void registroEnvio(string token, string json)
        {
            using (StreamWriter writer =
            new StreamWriter(@"c:\transer\ws\adminsat\JsonEnviado.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(token);
                writer.WriteLine("*******************************");
                writer.WriteLine(json);
                writer.WriteLine("*******************************");
                writer.WriteLine(" ");
            }

        }

        private static string construirObjetoJSONPlanilla(DataRow dr)
        {
            string getJSON = string.Empty;

            cdocJSONActualizacion myJSONActuliza = new cdocJSONActualizacion();

            #region Definicion del bloque activo

            try
            {
                cAactivo activo = new cAactivo();
                activo.placa = dr["activoplaca"].ToString();
                myJSONActuliza.activo = activo;
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque activo

            #region Definicion del bloque actor vial

            try
            {
                myJSONActuliza.orden_cargue = dr["orden"].ToString();
                myJSONActuliza.planilla = dr["planilla"].ToString();
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            #endregion fin de la Definicion del bloque actor vial

            string json = string.Empty;
            try
            {
                json += Newtonsoft.Json.JsonConvert.SerializeObject(myJSONActuliza);
                //string tmp = string.Empty;
                //tmp = json.Replace("ruta\":{\"rutas\":{", "ruta\":{\"rutas\":[{");
                //string mtp = tmp.Replace("\"},\"varios_json\":", "\"}],\"varios_json\":");
                //json = mtp;
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/milenio/");
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/");//

                //envioJSON.sendJSON(token, json, "https://api.adminsat.com/rutas/integracion/" + dr["orden"].ToString() + "/");
                envioJSON.sendJSONPUT(token, json, "https://api.adminsat.com/rutas/integracion/" + dr["orden"].ToString() + "/");//sendJSONPUT
                //envioJSON.sendJSON(token, json, "http://api-development.adminsat.com/rutas/integracion/orden_cargue");
                //envioJSON.sendJSONPUT(token, json, "http://api-development.adminsat.com/rutas/integracion/" + dr["orden"].ToString() + "/");


                respuesta = envioJSON.Respuesta;
                getJSON = respuesta;

                using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\construirObjetoJSONPlanilla.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                    writer.WriteLine(token);
                    writer.WriteLine(json);
                    writer.WriteLine(dr["orden"].ToString());
                    writer.WriteLine(respuesta);
                    writer.WriteLine("*");
                }
            }
            catch (Exception ex)
            {
                mensajeError(ex);
            }
            return getJSON;
        }

        private static string tipoTrailer(string p)
        {
            string tipotrailer = string.Empty;
            DataTable dttipotrailer = new DataTable("tipotrailer");
            string select = @"select GENE_DESCRIPCION_V2 tipo
from trailers,genericas
where TRAI_TIPO_NB=GENE_CODIGO_NB
and GENE_NOMBRE_V2='TIPO CARROCERIA'
and TRAI_PLACA_CH='" + p + "'";
            dttipotrailer = datos.getDataTable(select);
            if (dttipotrailer.Rows.Count > 0)
            {
                foreach (DataRow dr in dttipotrailer.Rows)
                {
                    try
                    {
                        tipotrailer = dr["tipo"].ToString();
                    }
                    catch (Exception ex)
                    {
                        mensajeError(ex);
                    }
                }
            }
            return tipotrailer;
        }

        private static void mensajeError(Exception ex)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logError.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(ex.Message);
                writer.WriteLine("*");
            }
        }
        private static void mensajeError(string mensaje)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logError.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(mensaje);
                writer.WriteLine("*");
            }
        }
        private static void infociclo(string mensaje)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\logciclo.txt", true))
            {
                writer.WriteLine(mensaje);
            }
        }
        private static void envioExitoso(string mensaje)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\envioExitoso.txt", true))
            {
                writer.WriteLine(mensaje);
            }
        }
        private static void registroError(string mensaje)
        {
            if (mensaje.Contains("\"ruta\":\"La ruta con origen:"))
            {
                ccorreo correo = new ccorreo();
                correo.envioCorreo("La ruta no existe. APLICATIVO OSP ADMINSAT", mensaje);
            }
            else
            {
                ccorreo correo = new ccorreo();
                //correo.envioCorreoDesarrolador("La ruta no existe. APLICATIVO OSP ADMINSAT", mensaje);
            }
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\registroError.txt", true))
            {
                writer.WriteLine(mensaje);
            }
        }
        private static void objetosJSON(string mensaje)
        {
            using (StreamWriter writer =
                        new StreamWriter(@"c:\transer\ws\adminsat\ObjetosJson.txt", true))
            {
                writer.WriteLine(" ");
                writer.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(mensaje);
                writer.WriteLine("*");
            }
        }
    }








    class Datos
    {
        public DataTable getDataTable(string select)
        {
            DataTable dttmp = new DataTable("dttmp");
            string cadena = @"User Id=fmontoya;Password=f935cjm9262;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.30.119)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=DBMILE)(FAILOVER_MODE=(TYPE=select)(METHOD=basic)(RETRIES=20)(DELAY=15))));";
            using (OracleConnection con = new OracleConnection(cadena))
            {
                OracleCommand cmd = new OracleCommand(select, con);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                try
                {
                    da.Fill(dttmp);
                }
                catch (OracleException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dttmp;
        }
    }

    class cdocJSONActualizacion
    {
        public cAactivo activo { get; set; }
        public string orden_cargue { get; set; }
        public string planilla { get; set; }
    }
    class cAactivo
    {
        public string placa { get; set; }
    }


    class cdocJSON
    {
        public cactivo activo { get; set; }
        public cactor_vial actor_vial { get; set; }
        public centurne enturne { get; set; }
        public cadicional adicional { get; set; }
    }
    class cdocJSONOrdenAnulada
    {
        public string orden_cargue { get; set; }
    }
    class cactivo
    {
        public string nombre { get; set; }
        public string placa { get; set; }
    }
    class cactor_vial
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string numero_documento_identidad { get; set; }
        public string tipo_documento_identidad { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string ciudad { get; set; }
    }
    class cadicional
    {
        public string tipo_afiliacion { get; set; }
        public string poseedor { get; set; }
        public string telefono_poseedor { get; set; }
        public string ciudad_poseedor { get; set; }
        public string marca_vehiculo { get; set; }
        public string color_vehiculo { get; set; }


        //public string id_ruta_transer { get; set; }
        //public string id_camino { get; set; }
        //public string id_ruta_terceros { get; set; }
        //public string id_camino_terceros { get; set; }
        //public string clase_vehiculo { get; set; }
        //public string numero_viajes_milenio { get; set; }
        //public string observaciones_despacho { get; set; }
    }
    class centurne
    {
        public cruta ruta { get; set; }
        public string orden_cargue { get; set; }
        public string planilla { get; set; }
        public string producto { get; set; }
        public string fecha_hora_inicio { get; set; }
        public string inicializacion { get; set; }
        public string finalizacion { get; set; }
        public cvarios_json varios_json { get; set; }
    }
    class cruta
    {
        public string origen { get; set; }
        public string destino { get; set; }
        public string via { get; set; }


        //public crutas rutas { get; set; }
    }
    class crutas
    {
        public string divipola { get; set; }
    }
    class cvarios_json
    {
        public string od { get; set; }
        public string nc { get; set; }
        public string cc { get; set; }
        public string tt { get; set; }
        public string foc { get; set; }
    }
    class cgetJSON
    {
        //{"rutas":[16372],"actor_vial":1670,"activo":2637}
        public string[] rt { get; set; }
        public string av { get; set; }
        public string ac { get; set; }
    }
























}
