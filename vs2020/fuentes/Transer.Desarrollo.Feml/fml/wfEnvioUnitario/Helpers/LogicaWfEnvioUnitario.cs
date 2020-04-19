using EntityMinisterio;
using fml.Ministerio;
using infrastructure;
using System;
using System.Data;
using System.Xml;

namespace fml.wfEnvioUnitario
{
    public partial class LogicaWfEnvioUnitario
    {
        public DataTable consultarRegistro(string llave, int transaccion)
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_LLAVE", ":LRMI_TRANSACCION" };
            _vParametros = new object[2] { llave, transaccion };
            DataTable dtReturn = new DataTable();
            dtReturn.Columns.Add("Secuencia", typeof(double));
            dtReturn.Columns.Add("Oficina", typeof(int));
            dtReturn.Columns.Add("Transaccion", typeof(string));
            dtReturn.Columns.Add("Llave", typeof(string));
            dtReturn.Columns.Add("Fecha", typeof(DateTime));
            dtReturn.Columns.Add("Estado", typeof(string));
            dtReturn.Columns.Add("Id", typeof(double));
            dtReturn.Columns.Add("Descripcion", typeof(string));
            dtReturn.Columns.Add("Envio", typeof(DateTime));
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt = data.getTable("wfEnvioUnitario", "getLogReporteMinisterioUnitario", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        LogReporteMinisterio p = new LogReporteMinisterio();
                        foreach (DataRow item in dt.Rows)
                        {
                            try
                            {
                                /*dtReturn.Rows.Add(double.Parse(item["LRMI_SECUENCIA_NB"].ToString()),
                                    int.Parse(item["LRMI_OFICINA_NB"].ToString()),
                                    item["LRMI_TRANSACCION_NB"].ToString(),
                                    item["LRMI_LLAVE_V2"].ToString(),
                                    DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString()),
                                    item["LRMI_ESTADO_V2"].ToString(),                                    
                                    item["LRMI_CAMPO2_V2"].ToString(),
                                    DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString()));*/


                                p.LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                                p.LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                                p.LRMI_TRANSACCION_NB = int.Parse(item["LRMI_TRANSACCION_NB"].ToString());
                                p.LRMI_LLAVE_V2 = item["LRMI_LLAVE_V2"].ToString();
                                p.LRMI_FECREGISTRO_DT = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
                                p.LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
                                try
                                {
                                    p.LRMI_CAMPO1_NB = double.Parse(item["LRMI_CAMPO1_NB"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    p.LRMI_CAMPO1_NB = -1;
                                    manejoErrores(ex);
                                }
                                p.LRMI_CAMPO2_V2 = item["LRMI_CAMPO2_V2"].ToString();
                                try
                                {
                                    p.LRMI_CAMPO3_DT = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    p.LRMI_CAMPO3_DT = DateTime.Now;
                                    manejoErrores(ex);
                                }
                                
                                dtReturn.Rows.Add(p.LRMI_SECUENCIA_NB,p.LRMI_OFICINA_NB,p.LRMI_TRANSACCION_NB,p.LRMI_LLAVE_V2,p.LRMI_FECREGISTRO_DT,p.LRMI_ESTADO_V2,p.LRMI_CAMPO1_NB,p.LRMI_CAMPO2_V2,p.LRMI_CAMPO3_DT);

                                pLogReporteMinisterio = p;
                                procesarRegistro(p);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                                dtReturn.Rows.Add(-1, -1, "Error Consulta", "Error Convercion", DateTime.Now, ex.Message, -1, ex.Message, DateTime.Now);
                            }

                        }
                    }
                    else
                    {
                        dtReturn.Rows.Add(-1, -1, "Sin Registro", "Sin Registro", DateTime.Now, "Sin Registro",-1, "Sin Registro", DateTime.Now);
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
            return dtReturn;
        }

        private void procesarRegistro(LogReporteMinisterio p)
        {
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
                        foreach (DataRow drw in dt_datos.Rows)
                        {
                            procesarFuncion(funcion, drw, p);
                        }
                    }
                    else
                    {
                        GenerarXml gxml = new GenerarXml();
                        string xml_sinValores = gxml.SelectSinValores(funcion + " No devolvio Valores", p);
                        procesarEnvioMinisterio(funcion, xml_sinValores, " ", p);
                    }
                }
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }
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
                try
                {
                    /*using (WsRndc srRndc = new WsRndc())
                    {
                        xml_recibido = srRndc.enviar(xml_envio);
                    }*/
                    _xml_envio = xml_envio;
                    _funtion = funcion;
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }

            //procesarEnvioMinisterio(xml_envio);

            //procesarEnvioMinisterio(funcion, xml_envio, xml_recibido, p);

        }

        public string enviarMinisterio(string xml_envio)
        {
            string xml_recibido = string.Empty;
            if (xml_envio.Length > 0)
            {
                try
                {
                    using (WsRndc srRndc = new WsRndc())
                    {
                        xml_recibido = srRndc.enviar(xml_envio);
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
            return xml_recibido;
        }

        public void procesarEnvioMinisterio(string v, string xml_envio, string xml_recibido, LogReporteMinisterio p)
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

                manejoErrores(ex);
                try
                {
                    xml_recibido = gxml.maquetarXMLError(xml_recibido, -2, "P", p);
                    xmlReturn.LoadXml(xml_recibido);
                    continuar = true;
                }
                catch (Exception exx)
                {
                    manejoErrores(exx);
                    continuar = false;
                }
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
                continuar = false;
            }
            #endregion fin de la Definicion de carga del documento XmlDocument xmlReturn
            #region Definicion del bloque procesar respuesta
            while (continuar)
            {
                XmlElement root = xmlReturn.DocumentElement;
                if (continuar)
                {
                    XmlNodeList elemListErrorTYS = root.GetElementsByTagName("ErrorTYS");
                    if (elemListErrorTYS.Count > 0)
                    {
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
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListErrorMSG = root.GetElementsByTagName("ErrorMSG");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListErrorMSG.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
                        if (elemListErrorMSG[i].InnerXml.ToString().Contains("DUPLICADO"))
                        {
                            p.LRMI_ESTADO_V2 = "E";
                            DELM_IDMINISTERIO = getId(elemListErrorMSG[i].InnerXml.ToString());
                        }
                        else
                        {
                            p.LRMI_ESTADO_V2 = "R";
                            DELM_IDMINISTERIO = -1;
                        }
                        continuar = false;
                        break;
                    }
                }

                if (continuar)
                {
                    XmlNodeList elemListingresoid = root.GetElementsByTagName("ingresoid");
#pragma warning disable CS0162 // Se detectó código inaccesible
                    for (int i = 0; i < elemListingresoid.Count; i++)
#pragma warning restore CS0162 // Se detectó código inaccesible
                    {
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
                using (Factory data = new Factory(usuario, password, ambiente))
                {
                    string[] _nParametros;
                    object[] _vParametros;
                    //if (p.LRMI_OFICINA_NB == 39)
                    if (p.LRMI_OFICINA_NB == 39)
                    {
                        _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_campo2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                        if (p.LRMI_ESTADO_V2 == "E")
                        {
                            _vParametros = new object[4] { p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        }
                        else
                        {
                            _vParametros = new object[4] { "F", DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                        }
                        try
                        {
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
                                _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_campo2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                                _vParametros = new object[4] { p.LRMI_ESTADO_V2, DELM_IDMINISTERIO, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                                try
                                {
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
                            _nParametros = new string[4] { ":LRMI_ESTADO", ":LRMI_CAMPO2", ":LRMI_SECUENCIA", ":LRMI_OFICINA" };
                            _vParametros = new object[4] { p.LRMI_ESTADO_V2, xml_recibido, p.LRMI_SECUENCIA_NB, p.LRMI_OFICINA_NB };
                            try
                            {
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
                        if (p.LRMI_ESTADO_V2 != "R")
                        {
                            data.executeCommand("Ministerio", "InsertDetLogMinisterio", _nParametros, _vParametros);
                        }
                        else
                        {
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



        private void manejoErrores(Exception ex)
        {
            LogAplication += ex.Message;
        }

    }
}
