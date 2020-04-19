using EntityMinisterio;
using fml.Ministerio;
using infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Xml;

namespace fml
{
    public partial class LogicaCaMinTraV1
    {
        public LogReporteMinisterio logReporteMinisterio { get; set; }

        /// <summary>
        /// public string Inicio(DateTime fecini)
        /// </summary>
        /// <param name="fecini"></param>
        /// <returns></returns>
        public string Inicio(DateTime fecini)
        {
            try
            {
                int registro = SeleccionRegistrosPendientesPorProcesar();
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }
            try
            {
                ProcesarRegistros();
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }
            try
            {

            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }
            return LogAplication;
        }

        /// <summary>
        /// private int SeleccionRegistrosPendientesPorProcesar()
        /// </summary>
        /// <returns></returns>
        private int SeleccionRegistrosPendientesPorProcesar()
        {
            int registro = 0;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_ESTADO" };
            _vParametros = new object[1] { "P" };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Ministerio", "getLogReporteMinisterio", _nParametros, _vParametros);
                    registro = dt.Rows.Count;
                    if (registro > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            regTotal++;
                            try
                            {
                                addLogReporteMinisterio(item);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
            return registro;
        }

        private void manejoErrores(Exception ex)
        {
            LogAplication += ex.Message;
        }

        /// <summary>
        /// private void addLogReporteMinisterio(DataRow item)
        /// </summary>
        /// <param name="item"></param>
        private void addLogReporteMinisterio(DataRow item)
        {
            string mensaje = string.Empty;
            mensaje += "Preparando archivos para Enviar  " + incsigno() + "\r\n\r\nRegistros procesados ==> " + regTotal + "\r\n\r\n";
            LogReporteMinisterio logReporteMinisterio = new LogReporteMinisterio();
            try
            {
                logReporteMinisterio.LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                mensaje += "Secuencia   : " + logReporteMinisterio.LRMI_SECUENCIA_NB + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                mensaje += "Oficina     : " + logReporteMinisterio.LRMI_OFICINA_NB + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_TRANSACCION_NB = int.Parse(item["LRMI_TRANSACCION_NB"].ToString());
                mensaje += "Transaccion : " + logReporteMinisterio.LRMI_TRANSACCION_NB + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_LLAVE_V2 = item["LRMI_LLAVE_V2"].ToString();
                mensaje += "Llave       : " + logReporteMinisterio.LRMI_LLAVE_V2 + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_FECREGISTRO_DT = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
                mensaje += "Fecha       : " + logReporteMinisterio.LRMI_FECREGISTRO_DT + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
                mensaje += "Estado      : " + logReporteMinisterio.LRMI_ESTADO_V2 + "\r\n";
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = double.Parse(item["LRMI_CAMPO1_NB"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO1_NB = 0;
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = item["LRMI_CAMPO2_V2"].ToString();
                mensaje += "Campo2      : " + logReporteMinisterio.LRMI_CAMPO2_V2 + "\r\n";
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO2_V2 = string.Empty;
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            try
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
            }
            catch (Exception ex)
            {
                logReporteMinisterio.LRMI_CAMPO3_DT = DateTime.UtcNow;
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            lLogReporteMinisterio.Add(logReporteMinisterio);
            log.procesando(tituloAplicacion, mensaje);
            //Thread.Sleep(100);
        }

        private string incsigno()
        {
            string s = string.Empty;
            Random r = new Random();
            switch (r.Next(0, 10))
            {
                case 0:
                    {
                        s = "*";
                        break;
                    }
                case 1:
                    {
                        s = "-";
                        break;
                    }
                case 2:
                    {
                        s = "/";
                        break;
                    }
                case 3:
                    {
                        s = "\\";
                        break;
                    }
                case 4:
                    {
                        s = "+";
                        break;
                    }
                case 5:
                    {
                        s = "-";
                        break;
                    }
                case 6:
                    {
                        s = "*";
                        break;
                    }
                case 7:
                    {
                        s = "/";
                        break;
                    }
                case 8:
                    {
                        s = "-";
                        break;
                    }
                case 9:
                    {
                        s = "+";
                        break;
                    }
                default:
                    {
                        s = "*";
                        break;
                    }
            }
            return s;
        }

        /// <summary>
        /// private void ProcesarRegistros()
        /// </summary>
        private void ProcesarRegistros()
        {
            regTotal = lLogReporteMinisterio.Count;
            regPendientes = regTotal;
            for (int i = 1; i < 32; i++)
            {
                switch (i)
                {
                    case 1:
                        {
                            List<LogReporteMinisterio> propietarioNit = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 10);
                            foreach (var item in propietarioNit)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 2:
                        {
                            List<LogReporteMinisterio> propietarioCedula = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 11);
                            foreach (var item in propietarioCedula)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 3:
                        {
                            List<LogReporteMinisterio> conductores = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 12);
                            foreach (var item in conductores)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 4:
                        {
                            List<LogReporteMinisterio> vehiculos = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 15);
                            foreach (var item in vehiculos)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 5:
                        {
                            List<LogReporteMinisterio> trailers = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 16);
                            foreach (var item in trailers)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 6:
                        {
                            List<LogReporteMinisterio> clientesNit = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 13);
                            foreach (var item in clientesNit)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 7:
                        {
                            List<LogReporteMinisterio> clientesCedula = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 14);
                            foreach (var item in clientesCedula)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 8:
                        {
                            List<LogReporteMinisterio> ordenCargue = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 3);
                            foreach (var item in ordenCargue)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 9:
                        {
                            List<LogReporteMinisterio> planilla = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 4);
                            foreach (var item in planilla)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 10:
                        {
                            List<LogReporteMinisterio> cumplidoRemesa = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 5);
                            foreach (var item in cumplidoRemesa)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 11:
                        {
                            List<LogReporteMinisterio> cumplirManifiesto = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 6);
                            foreach (var item in cumplirManifiesto)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 12:
                        {
                            List<LogReporteMinisterio> anularOrden = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 9);
                            foreach (var item in anularOrden)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    case 13:
                        {
                            List<LogReporteMinisterio> anularManifiesto = lLogReporteMinisterio.FindAll(x => x.LRMI_TRANSACCION_NB == 32);
                            foreach (var item in anularManifiesto)
                            {
                                procesarRegistro(item);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            //Console.ReadKey();
        }
        /// <summary>
        /// private void procesarRegistro(LogReporteMinisterio p)
        /// </summary>
        /// <param name="p"></param>
        private void procesarRegistro(LogReporteMinisterio p)
        {
            regPendientes--;
            MensajeCicloVidapCabecera = string.Empty;
            MensajeCicloVidaCuerpo = string.Empty;
            MensajeCicloVidaResumen = string.Empty;
            ColorMensajeCicloVida = "Normal";
            //MensajeCicloVida += "Total : " + regTotal + " Pendientes : " + regPendientes + " Exitosos : " + regExitosos + " Duplicados : " + regDuplicados + " Rechazados : " + regRechazados;
            //MensajeCicloVida += "\r\nProcesando el registro\r\n";
            MensajeCicloVidapCabecera += "\r\nSecuencia   : " + p.LRMI_SECUENCIA_NB;
            MensajeCicloVidapCabecera += "\r\nOficina     : " + p.LRMI_OFICINA_NB;
            MensajeCicloVidapCabecera += "\r\nTransaccion : " + p.LRMI_TRANSACCION_NB;
            MensajeCicloVidapCabecera += "\r\nLlave       : " + p.LRMI_LLAVE_V2;
            MensajeCicloVidapCabecera += "\r\nFecha       : " + p.LRMI_FECREGISTRO_DT;
            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
            DataTable dt_datos = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_LLAVE" };
            _vParametros = new object[1] { p.LRMI_LLAVE_V2 };
            string funcion = string.Empty;
            try
            {
                switch (p.LRMI_TRANSACCION_NB)
                {
                    case 3:
                        {
                            funcion = "PK_MINISTERIO_XML_REMESA";
                            break;
                        }
                    case 4:
                        {
                            funcion = "PK_MINISTERIO_XML_MANIFIESTO_CARGA";
                            break;
                        }
                    case 5:
                        {
                            funcion = "PK_MINISTERIO_XML_CUMPLIDO_REMESA";
                            break;
                        }
                    case 6:
                        {
                            funcion = "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO";
                            break;
                        }
                    case 9:
                        {
                            funcion = "PK_MINISTERIO_XML_ANULAR_REMESA";
                            break;
                        }

                    case 10:
                        {
                            funcion = "PK_MINISTERIO_XML_PROPIETARIOS_NIT";
                            break;
                        }
                    case 11:
                        {
                            funcion = "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA";
                            break;
                        }
                    case 12:
                        {
                            funcion = "PK_MINISTERIO_XML_CONDUCTORES";
                            break;
                        }
                    case 13:
                        {
                            funcion = "PK_MINISTERIO_XML_CLIENTES_NIT";
                            break;
                        }
                    case 14:
                        {
                            funcion = "PK_MINISTERIO_XML_CLIENTES_CEDULA";
                            break;
                        }
                    case 15:
                        {
                            funcion = "PK_MINISTERIO_XML_VEHICULOS";
                            break;
                        }
                    case 16:
                        {
                            funcion = "PK_MINISTERIO_XML_TRAILERS";
                            break;
                        }
                    case 32:
                        {
                            funcion = "PK_MINISTERIO_XML_ANULAR_MANIFIESTO";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }

            try
            {
                using (Factory data = new Factory(usuario, password, ambiente))
                {
                    dt_datos = data.getTable("Ministerio", funcion, _nParametros, _vParametros);
                    if (dt_datos.Rows.Count > 0)
                    {
                        //MensajeCicloVidapCabecera += "\r\n=> Ejecucion exitosa funcion => " + funcion;
                        //log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                        MensajeLineaColor = string.Empty;
                        MensajeLineaColor += "\r\n=> Ejecucion exitosa funcion => " + funcion;
                        log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeLineaColor, MensajeCicloVidaResumen, "Verde");
                        MensajeCicloVidapCabecera += MensajeLineaColor;
                        //Thread.Sleep(10);
                        foreach (DataRow drw in dt_datos.Rows)
                        {
                            procesarFuncion(funcion, drw, p);
                        }
                    }
                    else
                    {
                        //MensajeCicloVidapCabecera += "\r\n\r\n=> " + funcion + " No devolvio valores";
                        //ColorMensajeCicloVida = "Rojo";
                        //log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                        //procesarSelectSinValores(funcion, p);

                        MensajeLineaColor = string.Empty;
                        MensajeLineaColor += "\r\n\r\n=> " + funcion + " No devolvio valores";
                        log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeLineaColor, MensajeCicloVidaResumen, "Rojo");
                        MensajeCicloVidapCabecera += MensajeLineaColor;
                        //Thread.Sleep(10);
                        GenerarXml gxml = new GenerarXml();
                        string xml_sinValores = gxml.SelectSinValores(funcion + " No devolvio Valores", p);
                        procesarEnvioMinisterio(funcion, xml_sinValores, " ", p);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeCicloVidaCuerpo += "\r\nSe presento un error durante la consulta a la base de datos\r\nDetalle del error : " + ex.Message;
                ColorMensajeCicloVida = "Rojo";
                log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                //log.deterner(0);
                manejoErrores(ex);
                //LogAplication += ex.Message;
            }
            //try
            //{
            /*MensajeCicloVidaResumen += "\r\nTotal : " + regTotal + " Pendientes : " + regPendientes + " Exitosos : " + regExitosos + " Duplicados : " + regDuplicados + " Rechazados : " + regRechazados;
            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, "Normal");*/
            //log.deterner(3000);
            //}
            /*catch (Exception ex)
            {
                manejoErrores(ex);
            }*/
        }

        private void procesarFuncion(string funcion, DataRow drw, LogReporteMinisterio p)
        {
            //string mensaje = string.Empty;
            string rutaArchivo = @"c:\transer\ws\web_ministerio\XML_" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + p.LRMI_OFICINA_NB + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            switch (funcion)
            {
                case "PK_MINISTERIO_XML_REMESA"://3
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA"://4
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_manifiesto_carga(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA"://5
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_cumplido_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO"://6
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_cumplir_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT"://10
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_propietarios_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA"://11
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_propietarios_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES"://12
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_conductores(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT"://13
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_clientes_nit(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA"://14
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_clientes_cedula(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS"://16
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_vehiculos(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS"://17
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_trailers(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }

                case "PK_MINISTERIO_XML_ANULAR_REMESA"://9
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_anular_remesa(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO"://32
                    {
                        try
                        {
                            using (GenerarXml gxml = new GenerarXml())
                            {
                                xml_envio = gxml.procesar_anular_manifiesto(drw, rutaArchivo + ".xml", p.LRMI_OFICINA_NB);
                            }
                        }
                        catch (Exception ex)
                        {
                            MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                            MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                            ColorMensajeCicloVida = "Rojo";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            log.deterner(0);
                            manejoErrores(ex);
                            xml_recibido = ex.Message;
                            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);
                        }
                        break;
                    }
                default:
                    break;
            }
            if (xml_envio.Length > 0)
            {
                ColorMensajeCicloVida = "Normal";
                MensajeLineaColor = string.Empty;
                MensajeLineaColor += "\r\n=> Se genero el XML de la transaccion : " + funcion;
                log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeLineaColor, MensajeCicloVidaResumen, "Verde");
                MensajeCicloVidapCabecera += MensajeLineaColor;
                //log.avance(MensajeCicloVida);
                try
                {
                    using (WsRndc srRndc = new WsRndc())
                    {
                        xml_recibido = srRndc.enviar(xml_envio);
                        //MensajeCicloVidapCabecera += "\r\n=> Se obtuvo respuesta del Ministerio de Transporte";
                        //log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                        MensajeLineaColor = string.Empty;
                        MensajeLineaColor += "\r\n=> Se obtuvo respuesta del Ministerio de Transporte";
                        log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeLineaColor, MensajeCicloVidaResumen, "Verde");
                        MensajeCicloVidapCabecera += MensajeLineaColor;
                        //Thread.Sleep(10);

                        //log.avance(MensajeCicloVida);
                    }
                }
                catch (Exception ex)
                {
                    MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de consumir el Web Services del ministerio" + "\r\n";
                    MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                    MensajeCicloVidaCuerpo += "\r\nSe presento un error al momento de ejecutar la funcion : " + funcion + "\r\n";
                    MensajeCicloVidaCuerpo += "\r\nDetalle del error : " + ex.Message;
                    ColorMensajeCicloVida = "Rojo";
                    log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                    log.deterner(0);
                    manejoErrores(ex);
                }
            }

            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);

        }
        private void procesarEnvioMinisterio(string v, string xml_envio, string xml_recibido, LogReporteMinisterio p)
        {
            string ruta = @"c:\transer\ws\web_ministerio\" + p.LRMI_TRANSACCION_NB + "_" + p.LRMI_LLAVE_V2 + "_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".xml";
            bool continuar = false;
            GenerarXml gxml = new GenerarXml();
            double DELM_IDMINISTERIO = -1234567890;
            #region Definicion de carga del documento XmlDocument xmlReturn

            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
                continuar = true;
            }
            catch (XmlException ex)
            {
                MensajeCicloVidaCuerpo += "\r\nLa respuesta del Ministerio no corresponde a un archivo XML Valido";
                MensajeCicloVidaCuerpo += "\r\nDetalle del Error : " + ex.Message;
                ColorMensajeCicloVida = "Rojo";
                log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                manejoErrores(ex);
                try
                {
                    MensajeCicloVidaCuerpo += "\r\nSe realiza maquetado manual";
                    //log.avance(MensajeCicloVida);

                    xml_recibido = gxml.maquetarXMLError(xml_recibido, -2, "P", p);
                    xmlReturn.LoadXml(xml_recibido);
                    continuar = true;
                }
                catch (Exception exx)
                {
                    MensajeCicloVidaCuerpo += "\r\nDetalle del Error : " + ex.Message;
                    //log.avance(MensajeCicloVida);
                    manejoErrores(exx);
                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                MensajeCicloVidaCuerpo += "\r\nDetalle del Error : " + ex.Message;
                //log.avance(MensajeCicloVida);
                manejoErrores(ex);
                continuar = false;
            }
            #endregion fin de la Definicion de carga del documento XmlDocument xmlReturn
            #region Definicion del bloque procesar respuesta
            while (continuar)
            {
                XmlElement root = xmlReturn.DocumentElement;
                //try
                //{
                //    //MensajeCicloVida += "\r\nRegistro en Disco de la respuesta del Ministerio \r\nruta => " + ruta;
                //    //log.avance(MensajeCicloVida);
                //    xmlReturn.Save(ruta);
                //}
                //catch (Exception ex)
                //{
                //    MensajeCicloVidaCuerpo += "\r\nDetalle del Error : " + ex.Message;
                //    //log.avance(MensajeCicloVida);
                //    manejoErrores(ex);
                //}
                if (continuar)
                {
                    XmlNodeList elemListErrorTYS = root.GetElementsByTagName("ErrorTYS");
                    if (elemListErrorTYS.Count > 0)
                    {
                        /*console.Cblue();
                        console.Ih(" ", false);
                        console.Ih("==> XML Recibido ", true);
                        console.Ih("    *** " + xml_recibido, false);*/
                        //MensajeCicloVida += "\r\nError del tipo : ErrorTYS";
                        //log.avance(MensajeCicloVida);
                        XmlNodeList elemListEstadoRegistro = root.GetElementsByTagName("EstadoRegistro");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListEstadoRegistro.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            //httpwebrequestFunction._status = elemListErrorTYS[i].InnerXml;
                            p.LRMI_ESTADO_V2 = elemListEstadoRegistro[i].InnerXml;
                            continuar = false;
                            break;
                        }
                        XmlNodeList elemListCodigoError = root.GetElementsByTagName("CodigoError");
#pragma warning disable CS0162 // Se detectó código inaccesible
                        for (int i = 0; i < elemListCodigoError.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                        {
                            p.LRMI_ESTADO_V2 = "S";
                            DELM_IDMINISTERIO = double.Parse(elemListCodigoError[i].InnerXml.ToString());
                            continuar = false;
                            break;
                        }
                        //console.CYellow();
                        //detalleRegistro(p, "errorTys", xml_envio, xml_recibido);
                        //SendCorreoRegistroRechazado("Registro Rechazado", p, xml_envio, xml_recibido, v);
                    }
                }

                if (continuar)
                {
                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                      <root>
                      <ErrorMSG>Error TER225: La fecha de Vencimiento de la Licencia de Conducción no puede ser mayor a 3 años. Usuario: 4961</ErrorMSG>
                      </root>
                    */

                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                        <root>
                        <ErrorMSG>DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
                         Usuario: 4961</ErrorMSG>
                        </root>
                        */
                    XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        if (elemListErrorMSG[i].InnerXml.ToString().Contains("DUPLICADO"))
                        {
                            MensajeCicloVidaCuerpo += "\r\n                                     DUPLICADO ";
                            MensajeCicloVidaCuerpo += "\r\n                                    ***********";

                            regDuplicados++;

                            MensajeCicloVidaResumen += "\r\nTotal : " + regTotal + " Pendientes : " + regPendientes + " Exitosos : " + regExitosos + " Duplicados : " + regDuplicados + " Rechazados : " + regRechazados;
                            ColorMensajeCicloVida = "Azul-Blanco";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(60);
                            p.LRMI_ESTADO_V2 = "E";
                            DELM_IDMINISTERIO = getId(elemListErrorMSG[i].InnerXml.ToString());

                            //console.Cblue();
                            //SendCorreoRegistroDuplicado("Registro Duplicado", p, xml_envio, xml_recibido, DELM_IDMINISTERIO);
                            //Thread.Sleep(30000);
                            //console.Ih(" ", false);
                            //console.Ih("==> Id Ministerio : " + DELM_IDMINISTERIO, false);
                            //console.Ih("==> XML Recibido Registro DUPLICADO", true);
                            //detalleRegistro(p, "duplicado", xml_envio, xml_recibido);
                        }
                        else
                        {
                            p.LRMI_ESTADO_V2 = "R";
                            DELM_IDMINISTERIO = -1;
                            MensajeCicloVidaCuerpo += "\r\n                                      RECHAZADO ";
                            MensajeCicloVidaCuerpo += "\r\n                                    ! ! ! ! ! ! !";
                            //MensajeCicloVida += "\r\n"+xml_recibido;
                            regRechazados++;
                            MensajeCicloVidaResumen += "\r\nTotal : " + regTotal + " Pendientes : " + regPendientes + " Exitosos : " + regExitosos + " Duplicados : " + regDuplicados + " Rechazados : " + regRechazados;
                            ColorMensajeCicloVida = "Rojo-Blanco";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                            //log.deterner(10);
                            //console.CRed();
                            
                            
                            SendCorreoRegistroRechazado("Registro Rechazado", p, xml_envio, xml_recibido, v);
                            
                            
                            //console.Ih(" ", false);
                            //console.Ih("==> XML Recibido <ErrorMSG>", true);
                            //detalleRegistro(p, "rechazo", xml_envio, xml_recibido);
                        }
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    /*<?xml version="1.0" encoding="ISO-8859-1" ?>
                      <root>
                      <ingresoid>55574021</ingresoid>
                      </root>
                    */
                    XmlNodeList elemListingresoid = root.GetElementsByTagName("ingresoid");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListingresoid.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        MensajeCicloVidaCuerpo += "\r\n                               E N V I O  E X I T O S O ";
                        MensajeCicloVidaCuerpo += "\r\n                               = = = = = = = = = = = = = =";

                        MensajeCicloVidaCuerpo += "\r\n" + xml_recibido;
                        regExitosos++;
                        MensajeCicloVidaResumen += "\r\nTotal : " + regTotal + " Pendientes : " + regPendientes + " Exitosos : " + regExitosos + " Duplicados : " + regDuplicados + " Rechazados : " + regRechazados;
                        ColorMensajeCicloVida = "Verde";
                        log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);

                        log.deterner(120);
                        p.LRMI_ESTADO_V2 = "E";
                        try
                        {
                            DELM_IDMINISTERIO = double.Parse(elemListingresoid[i].InnerXml);
                        }
                        catch (Exception ex)
                        {
                            manejoErrores(ex);
                            DELM_IDMINISTERIO = -123456;
                        }
                        //console.Cgreen();
                        //SendCorreoRegistroExitoso("Registro Aceptado por el Ministerio", p, xml_envio, xml_recibido, DELM_IDMINISTERIO);
                        //console.Ih(" ", false);
                        //console.Ih("==> Id Ministerio : " + DELM_IDMINISTERIO, false);
                        //console.Ih("==> XML Recibido ", true);
                        //console.Ih("    *** " + xml_recibido, false);
                        //detalleRegistro(p, "envio", xml_envio, xml_recibido);
                        continuar = false;
                        break;
                    }
                }
            }

            if (DELM_IDMINISTERIO == -1234567890)
            {
                continuar = false;
            }
            else
            {
                continuar = true;
            }

            #endregion fin de la Definicion del bloque procesar respuesta

            if (continuar && p.LRMI_ESTADO_V2 != "P")
            {
                /*console.Ih("    !! Actualizando Tablas LogReporteMinisterio y DetLogMinisterio !!! ", false);
                console.Ih("==> SECUENCIA : " + p.LRMI_SECUENCIA_NB, false);
                console.Ih("==> OFICINA   : " + p.LRMI_OFICINA_NB, false);
                console.Ih("==> TRANSA.   : " + p.LRMI_TRANSACCION_NB, false);
                console.Ih("==> LLAVE     : " + p.LRMI_LLAVE_V2, false);
                console.Ih("==> ESTADO    : " + p.LRMI_ESTADO_V2, false);   
                console.Ih("==> CAMPO1    : " + p.LRMI_CAMPO1_NB, false);*/
                using (Factory data = new Factory(usuario, password, ambiente))
                {
                    string[] _nParametros;
                    object[] _vParametros;
                    //if (p.LRMI_OFICINA_NB == 39)
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_campo2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                        if (p.LRMI_ESTADO_V2=="E")
                        {
                            _vParametros = new object[4] { p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        }
                        else
                        {
                            _vParametros = new object[4] { "F", DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        }
                        try
                        {
                            MensajeCicloVidaCuerpo += "\r\n* Actualizacion de la tabla Log_reporte_ministerio";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                            data.executeCommand("Ministerio", "UpdateLogReporteMinisterio", _nParametros, _vParametros);
                        }
                        catch (Exception ex)
                        {
                            manejoErrores(ex);
                            continuar = false;
                        }
                    }
                    else
                    {
                        if (p.LRMI_ESTADO_V2 != "R")
                        {
                            if (p.LRMI_CAMPO1_NB == 1)
                            {
                                p.LRMI_CAMPO1_NB = 2;
                                _nParametros = new string[5] { ":LRMI_ESTADO", ":LRMI_CAMPO1", ":LRMI_campo2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[5] { p.LRMI_ESTADO_V2, p.LRMI_CAMPO1_NB, DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    MensajeCicloVidaCuerpo += "\r\n* Actualizacion de la tabla Log_reporte_ministerio";
                                    log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                                    data.executeCommand("Ministerio", "UpdateLogReporteMinisterioCampo1", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    manejoErrores(ex);
                                    continuar = false;
                                }
                            }
                            else
                            {
                                //p.LRMI_CAMPO1_NB = 0;
                                _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_campo2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[4] { p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
                                    MensajeCicloVidaCuerpo += "\r\n* Actualizacion de la tabla Log_reporte_ministerio";
                                    log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                                    data.executeCommand("Ministerio", "UpdateLogReporteMinisterio", _nParametros, _vParametros);
                                }
                                catch (Exception ex)
                                {
                                    manejoErrores(ex);
                                    continuar = false;
                                }
                            }
                        }
                        else
                        {
                            /*string campo2 = string.Empty;
                            try
                            {
                                campo2 = xml_recibido.Substring(1, xml_recibido.Length-1);
                            }
                            catch (Exception ex)
                            {
                                campo2 = ex.Message;
                            }*/

                            _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_CAMPO2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                            _vParametros = new object[4] { p.LRMI_ESTADO_V2, xml_recibido, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                            try
                            {
                                MensajeCicloVidaCuerpo += "\r\n* Actualizacion de la tabla Log_reporte_ministerio";
                                log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                                data.executeCommand("Ministerio", "UpdateLogReporteMinisterio", _nParametros, _vParametros);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                                continuar = false;
                            }
                        }
                    }
                }
            }
            if (continuar)
            {
                using (Factory data = new Factory(usuario, password, ambiente))
                {
                    //console.Ih("    !! Insertando Registro en la Tabla DetLogMinisterio         ");
                    string[] _nParametros;
                    object[] _vParametros;
                    _nParametros = new string[9] { ":secuencia", ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB", ":LRMI_TRANSACCION_NB", ":LRMI_LLAVE_V2", ":LRMI_ESTADO_V2", ":DELM_IDMINISTERIO_NB", ":DELM_XMLENVIADO_XML", ":DELM_XMLRECIBIDO_XML" };
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, gxml.getXmlEnvioFletx(xml_envio, p), gxml.getXmlRecibidoFletx(xml_recibido, p) };
                    }
                    else
                    {
                        _vParametros = new object[9] { getSecuenciaDetLogMinisterio(p), p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB, p.LRMI_TRANSACCION_NB, p.LRMI_LLAVE_V2, p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, xml_envio, xml_recibido };
                    }
                    try
                    {
                        /*
                        console.Cgreen();
                        console.Ih("    !! Insertando Registro en la Tabla DetLogMinisterio !! ", true);
                        console.Ih("==> SECUENCIA : " + p.LRMI_SECUENCIA_NB, false);
                        console.Ih("==> OFICINA   : " + p.LRMI_OFICINA_NB, false);
                        console.Ih("==> LLAVE     : " + p.LRMI_LLAVE_V2, false);
                        console.Ih("==> ESTADO    : " + p.LRMI_ESTADO_V2, false);
                        console.Ih("==> ID MINIST : " + DELM_IDMINISTERIO, false);
                        console.Ih("==> Xml        : " + xml_recibido);
                        */
                        if (p.LRMI_ESTADO_V2 != "R")
                        {
                            MensajeCicloVidaCuerpo += "\r\n** Insertar registro en la Tabla det_log_ministerio";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                            data.executeCommand("Ministerio", "InsertDetLogMinisterio", _nParametros, _vParametros);
                            //detalleRegistro(p, "envios", xml_envio, xml_recibido);
                        }
                        else
                        {
                            MensajeCicloVidaCuerpo += "\r\n** Insertar registro en la Tabla det_log_ministerio";
                            log.avance(tituloAplicacion, MensajeCicloVidapCabecera, MensajeCicloVidaCuerpo, MensajeCicloVidaResumen, ColorMensajeCicloVida);
                            data.executeCommand("Ministerio", "InsertDetLogMinisterio", _nParametros, _vParametros);
                        }
                    }
                    catch (Exception ex)
                    {
                        manejoErrores(ex);
                        continuar = false;
                    }
                }
            }
            //log.deterner(3000);
            //Thread.Sleep(4000);
        }

        private double getId(string xmlElement)
        {
            //DUPLICADO:42542601 Error CMA030: El Manifiesto de Carga que intenta cumplir ya fue cumplido anteriormente.
            double DELM_IDMINISTERIO_NB = -1;
            bool bid = false;
            string tid = string.Empty;
            for (int i = 9; i < xmlElement.Length; i++)
            {
                if (xmlElement.Substring(i, 1) == " ")
                {
                    DELM_IDMINISTERIO_NB = int.Parse(tid);
                    break;
                }
                if (bid)
                {
                    tid += xmlElement.Substring(i, 1);
                }
                if (xmlElement.Substring(i, 1) == ":")
                {
                    bid = true;
                }
            }
            return DELM_IDMINISTERIO_NB;
        }

        private double getSecuenciaDetLogMinisterio(LogReporteMinisterio p)
        {
            double delm_secuencia = 0;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_SECUENCIA_NB", ":LRMI_OFICINA_NB" };
            _vParametros = new object[2] { p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
            Factory data = new Factory(usuario, password, ambiente);
            var dtDetLogMinisterio = data.getTable("Ministerio", "getDetLogMinisterio", _nParametros, _vParametros);
            if (dtDetLogMinisterio.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetLogMinisterio.Rows)
                {
                    try
                    {
                        delm_secuencia = double.Parse(dr["DELM_SECUENCIA_NB"].ToString());
                    }
                    catch (Exception ex)
                    {
                        manejoErrores(ex);
                        delm_secuencia = 0;
                    }
                }
                delm_secuencia++;
            }
            else
            {
                delm_secuencia = 1;
            }

            return delm_secuencia;
        }
        private void procesarSelectSinValores(string funcion, LogReporteMinisterio pLogReporteMinisterio)
        {
            string xml_envio = string.Empty;
            string xml_recibido = string.Empty;
            GenerarXml gxml = new GenerarXml();
            xml_envio = gxml.SelectSinValores(funcion, pLogReporteMinisterio);
            xml_recibido = gxml.ReturnSinValores(funcion, -3, "R", pLogReporteMinisterio);
            procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, pLogReporteMinisterio);
            SendCorreoSelectSinValores("Select sin Valores", funcion, pLogReporteMinisterio, xml_envio, xml_recibido);
        }


        private void SendCorreoSelectSinValores(string asunto, string funcion, LogReporteMinisterio p, string xml_envio, string xml_recibido)
        {
            string para = "lcubillos@transer.com.co";
            string copia = "soporte@transer.com.co";
            string copiaOculta = "fmontoya@transer.com.co";
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = usuEmail;
            cfEmail.password = passEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            SELECT SIN VALORES ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("!!! La funcion : " + funcion + "  no devolvio valores.\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine("");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =======");
            sb.AppendLine(" ");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }
        private void SendCorreoRegistroDuplicado(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, double IdMinisterio)
        {
            string para = "fmontoya@transer.com.co";
            string copia = "lcubillos@transer.com.co";
            string copiaOculta = string.Empty;

            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = usuEmail;
            cfEmail.password = passEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            REGISTRO DUPLICADO ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  proceso un registro duplicado. Id de aprobacion por parte del Ministerio de Transporte  ==> " + IdMinisterio + "\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine("");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }
        private void SendCorreoRegistroRechazado(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, string funcion)
        {
            string para = string.Empty;

            switch (p.LRMI_OFICINA_NB)
            {
                case 1: //OF.PRINCIPAL
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
                case 2: //OF.B / VENTURA
                    {
                        para = "buenaventura@transer.com.co";
                        break;
                    }
                case 3: //OF.BUGA
                    {
                        para = "buga@transer.com.co";
                        break;
                    }
                case 4: //OF.CARTAGENA
                    {
                        para = "cartagena@transer.com.co";
                        break;
                    }
                case 5: //OF.IPIALES
                    {
                        para = "ipiales@transer.com.co";
                        break;
                    }
                case 8: //OF.YUMBO
                    {
                        para = "yumbo@transer.com.co";
                        break;
                    }
                case 11: //OF.TOCANCIPA
                    {
                        para = "tocancipa@transer.com.co";
                        break;
                    }
                case 15: //OF.TECHO
                    {
                        para = "techo@transer.com.co";
                        break;
                    }
                case 16: //OF.BARRANQUILLA
                    {
                        para = "barranquilla@transer.com.co";
                        break;
                    }
                case 17: //OF.OPERATIVO
                    {
                        para = "tocancipa@transer.com.co";
                        break;
                    }
                case 18: //OF.BUCARAMANGA
                    {
                        para = "bucaramanga@transer.com.co";
                        break;
                    }
                case 19: //OF.DUITAMA
                    {
                        para = "duitama@transer.com.co";
                        break;
                    }
                case 20: //OF.ITAGUI
                    {
                        para = "itagui@transer.com.co";
                        break;
                    }
                case 29: //OF.SANTA MARTA
                    {
                        para = "santamarta@transer.com.co";
                        break;
                    }
                case 30: //OF.VILLAVICENCIO
                    {
                        para = "villavicencio@transer.com.co";
                        break;
                    }
                case 31: //OF.DOSQUEBRADAS
                    {
                        para = "pereira@transer.com.co";
                        break;
                    }
                case 32: //OF.UBATE
                    {
                        para = "ubate@transer.com.co";
                        break;
                    }
                case 33: //OF.IBAGUE
                    {
                        para = "ibague@transer.com.co";
                        break;
                    }
                case 34: //OF.OPERA COMERCIAL
                    {
                        para = "comercial@transer.com.co";
                        break;
                    }
                case 35: //OF.MANIZALES
                    {
                        para = "manizales@transer.com.co";
                        break;
                    }
                case 36: //OF.CUCUTA
                    {
                        para = "cucuta@transer.com.co";
                        break;
                    }
                case 37: //OF.PALERMO
                    {
                        para = "palermo@transer.com.co";
                        break;
                    }
                case 38: //OF.CERETE
                    {
                        para = "cerete@transer.com.co";
                        break;
                    }
                case 39: //OF.FLETX
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
                default:
                    {
                        para = "fmontoya@transer.com.co";
                        break;
                    }
            }
            string copia = "lcubillos@transer.com.co";
            string copiaOculta = "soporte@transer.com.co";
            //string copia = string.Empty;
            //string copiaOculta = string.Empty;

            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = usuEmail;
            cfEmail.password = passEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                            REGISTRO RECHAZADO ");
            sb.AppendLine("                                            ======== ========= ");
            sb.AppendLine(" ");
            sb.AppendLine("Se informa a la Oficina que el Ministerio de Transporte Rechazo la recepcion de la transaccion => " + funcion.Substring(18, funcion.Length - 18));
            sb.AppendLine("A continuacion se adjunta el detalle y se invita a tomar las medidas necesarias para dar solucion lo antes posible.");
            sb.AppendLine("En caso de requerir informacion adicional sobre este error en particular por favor comunicarse con el Departamento de Sistemas (SOPORTE) y reenviar este correo con el fin de tener a mano toda la informacion necesaria.");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  fue rechazada por el ministerio .\r\n");
            sb.AppendLine("");
            sb.AppendLine("                      DETALLE DEL ERROR        ");
            sb.AppendLine("                      ======= === =====");
            sb.AppendLine(detalleError(xml_recibido));
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine(" ");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB + "  => " + funcion.Substring(0, 18));
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("==> XML Recibido");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine(" ");
            sb.AppendLine("==> XML Enviado");
            sb.AppendLine(" ");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }

        private string detalleError(string xml_recibido)
        {
            string detalleError = string.Empty;
            XmlDocument xmlReturn = new XmlDocument();

            try
            {
                xmlReturn.LoadXml(xml_recibido);
            }
            catch (XmlException ex)
            {

            }
            catch (Exception ex)
            {
            }
            XmlElement root = xmlReturn.DocumentElement;
            XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
            string tmp = string.Empty;
#pragma warning disable CS0162 // Se detectó código inaccesible
            for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
            {
                tmp = elemListErrorMSG[i].InnerXml;
                break;
            }
            StringBuilder sb = new StringBuilder();
            /*
                Error REM135: El tipo y/ó identificación del Propietario de la Carga no coinciden con los reportados en la tabla de Terceros. Está enviando una identificación del Propietario de la Carga de la Remesa Terrestre de Carga no válida o que no existe como Tercero en la base de datos.
                Error REM150: El tipo de identificación del Destinatario no corresponde a los códigos establecidos.
                Error REM150: El tipo y/ó identificación del Remitente no coinciden con los reportados en la tabla de Terceros. Está enviando una identificación del Remitente de la Remesa Terrestre de Carga no válida o que no existe como Tercero en la base de datos.
                Usuario: 4961             
            */
            bool blinea = false;
            if (tmp.Contains("Usuario:"))
            {
                for (int i = 0; i < tmp.Length; i++)
                {
                    try
                    {
                        if (tmp.Substring(i, 5).Contains("Error"))
                        {
                            detalleError += "\r\n* ";
                            blinea = true;
                            sb.Append(detalleError);
                            detalleError = string.Empty;
                        }
                        else
                        {
                            try
                            {
                                if (tmp.Substring(i, 8).Contains("Usuario:"))
                                {
                                    //detalleError += "\r\n* ";
                                    blinea = false;
                                    sb.Append(detalleError);
                                    detalleError = string.Empty;
                                    break;
                                }
                                else
                                {
                                    if (blinea)
                                    {
                                        detalleError += tmp.Substring(i - 1, 1);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        manejoErrores(ex);
                    }
                }
            }
            else
            {
                sb.Append("\r\n* " + tmp);
            }
            detalleError = sb.ToString();
            return detalleError;
        }

        private void SendCorreoRegistroExitoso(string asunto, LogReporteMinisterio p, string xml_envio, string xml_recibido, double IdMinisterio)
        {
            string para = "fmontoya@transer.com.co";
            //string copia = "soporte@transer.com.co";
            //string copiaOculta = "francisco.montoya.l@gmail.com";
            string copia = string.Empty;
            string copiaOculta = string.Empty;
            ConfiguracionEmail cfEmail = new ConfiguracionEmail();
            cfEmail.Asunto = asunto;
            cfEmail.host = "192.168.30.8";
            cfEmail.enableSsl = false;
            cfEmail.port = 25;
            cfEmail.user = usuEmail;
            cfEmail.password = passEmail;
            cfEmail.Para = para;
            cfEmail.Copia = copia;
            cfEmail.CopiaOculta = copiaOculta;
            cfEmail.cuentaCorreo = "robotcorreo@transer.com.co";
            cfEmail.Titulo = "Robot Correo Automatizacion";
            CorreoElectronico Correo = new CorreoElectronico();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("                        TRANSPORTES Y SERVICIOS TRANSER S.A   Robot Ministerio v1.0.1");
            sb.AppendLine(" ");
            sb.AppendLine("                                                   ENVIO EXITOSO ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("");
            sb.AppendLine("!!! La transaccion : " + p.LRMI_TRANSACCION_NB + "  fue aceptada por el ministerio. ID de aprobacion ==> " + IdMinisterio + "\r\n");
            sb.AppendLine("");
            sb.AppendLine("Adjunto detalles de la transaccion.");
            sb.AppendLine(" ");
            sb.AppendLine("Secuencia    : " + p.LRMI_SECUENCIA_NB);
            sb.AppendLine("Oficina      : " + p.LRMI_OFICINA_NB);
            sb.AppendLine("Transaccion  : " + p.LRMI_TRANSACCION_NB);
            sb.AppendLine("Llave        : " + p.LRMI_LLAVE_V2);
            sb.AppendLine("Fecha        : " + p.LRMI_FECREGISTRO_DT);
            sb.AppendLine("Estado       : " + p.LRMI_ESTADO_V2);
            sb.AppendLine("Campo1       : " + p.LRMI_CAMPO1_NB);
            sb.AppendLine("Campo2       : " + p.LRMI_CAMPO2_V2);
            sb.AppendLine("Fecha       : " + p.LRMI_CAMPO3_DT);
            sb.AppendLine(" ");
            sb.AppendLine("\r\n\r\n");
            sb.AppendLine("Se generan los siguientes Objetos XML para completar el registro.\r\n");
            sb.AppendLine("        ! ! !         XML Enviado        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_envio);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("        ! ! !         XML Recibido        ! ! !");
            sb.AppendLine("                      === =========");
            sb.AppendLine(xml_recibido);
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine(" ");
            sb.AppendLine("Saludos Cordiales, ");
            sb.AppendLine(" ");
            sb.AppendLine("Francisco Montoya L.");
            sb.AppendLine("Jefe de Soporte");
            sb.AppendLine("Oficina Transer Pereira");
            sb.AppendLine("Cel: 316-6917374");
            cfEmail.Mensaje = sb.ToString();
            Correo.SendMail(cfEmail);
        }



    }
}
