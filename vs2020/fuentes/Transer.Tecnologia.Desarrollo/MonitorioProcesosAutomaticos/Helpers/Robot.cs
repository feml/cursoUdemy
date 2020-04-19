using executionreports;
using infrastructure;
using System;
using System.Data;
using System.IO;

namespace MonitorioProcesosAutomaticos.Helpers
{
    public class Robot
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Ambiente { get; set; }
        public Consola consola { get; set; }
        public Robot()
        {
            DateTime fecIni = DateTime.Now;
            #region Definicion del bloque de seguridad
            string usuario = string.Empty;
            string password = string.Empty;
            string usuEmail = string.Empty;
            string passEmail = string.Empty;
            string ambiente = string.Empty;
            SecurityPrvt security = new SecurityPrvt();
            try
            {
                usuario = security.Decode("fmontoya");
            }
            catch (System.Exception)
            {
                usuario = security.Decode("usuario");
            }
            try
            {
                password = security.Decode("f935cjm9262");
            }
            catch (System.Exception)
            {
                password = security.Decode("password");
            }
            try
            {
                usuEmail = security.Decode("robotcorreo");
            }
            catch (System.Exception)
            {
                usuEmail = security.Decode("usuEmail");
            }
            try
            {
                passEmail = security.Decode("Tys860504882");
            }
            catch (System.Exception)
            {
                passEmail = security.Decode("passEmail");
            }
            try
            {
                ambiente = security.Decode("produccion");
            }
            catch (System.Exception)
            {
                ambiente = security.Decode("desarrollo");
            }
            #endregion fin de la Definicion del bloque de seguridad
            Usuario = usuario;
            Password = password;
            Ambiente = ambiente;
        }

        internal DataTable getEstadosProcesos()
        {
            DataTable dtTmp = new DataTable();
            dtTmp.Columns.Add("NOMBRE_PROCESO", typeof(string));
            dtTmp.Columns.Add("CODIGO_PROCESO", typeof(int));
            dtTmp.Rows.Add("TODOS LOS PROCESOS", 0);
            dtTmp.Rows.Add("MINISTERIO DE TRANSPORTE", 1);
            dtTmp.Rows.Add("DESTINO SEGURO", 2);
            dtTmp.Rows.Add("OSP", 3);
            dtTmp.Rows.Add("BAVARIA", 4);
            return dtTmp;
        }

        internal DataTable getOficinas()
        {
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtTmp = data.getTable("getOficinas", _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }

            return dtTmp;
        }
        internal DataTable getEstadosRobots()
        {
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtTmp = data.getTable("getEstadosRobots", _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtTmp;
        }

        private void ManejoError(Exception ex, string texto)
        {
            using (StreamWriter writer = new StreamWriter("Robots.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString());
                writer.WriteLine("Se Produjo un error de tipo Exception:");
                writer.WriteLine(ex.Message);
            }
            consola.ReadKey("Se presento un error ...!!!!\r\n\r\n\r\n" + texto + ex.Message, true);
        }

        private class SecurityPrvt
        {
            public SecurityPrvt()
            {

            }
            public string Decode(string texto)
            {
                string codigo = string.Empty;
                switch (texto)
                {
                    case "usuario":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "password":
                        {
                            codigo = Base64Decode("SOPORTE");
                            break;
                        }
                    case "usuEmail":
                        {
                            codigo = Base64Decode("robotcorreo");
                            break;
                        }
                    case "passEmail":
                        {
                            codigo = Base64Decode("Tys860504882");
                            break;
                        }
                    default:
                        {
                            codigo = Base64Decode(texto);
                            break;
                        }
                }
                return codigo;
            }

            private string Base64Decode(string base64EncodedData)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(base64EncodedData);
                //string encodedText = Convert.ToBase64String(plainTextBytes);
                return Convert.ToBase64String(plainTextBytes);
                //return System.Text.Encoding.UTF8.GetString(plainTextBytes);
            }
        }

        internal DataTable ExecuteQuery(DateTime fecIni, DateTime fecFin, int codOficina, int codEstado, int codProceso)
        {
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            //_nParametros = new string[5] { ":fecIni", ":fecFin", ":codOficina", ":codEstado", ":codProceso" };
            //_vParametros = new object[5] { fecIni , fecFin , codOficina , codEstado , codProceso };
            _nParametros = new string[3] { ":fecIni", ":fecFin", ":codOficina" };
            _vParametros = new object[3] { fecIni, fecFin, codOficina };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                DataTable dtTmpViajes = new DataTable();
                dtTmpViajes = data.getTable("getViajesEntreFechas", _nParametros, _vParametros);
                if (dtTmpViajes.Rows.Count > 0)
                {
                    dtTmp = procesarRegistrosViaje(dtTmpViajes);
                    //dtTmp = dtTmpViajes;
                }
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtTmp;
        }

        private DataTable procesarRegistrosViaje(DataTable dtTmpViajes)
        {
            #region Definicion construccion tabla
            DataTable dtConsulta = new DataTable();
            dtConsulta.Columns.Add("OFICINA", typeof(string));
            string OFICINA = string.Empty;
            dtConsulta.Columns.Add("PLANILLA", typeof(string));
            string PLANILLA = string.Empty;
            dtConsulta.Columns.Add("FEC_CREA", typeof(DateTime));
            DateTime FEC_CREA = DateTime.Now;
            dtConsulta.Columns.Add("ESTADO_MINISTERIO", typeof(string));
            string ESTADO_MINISTERIO = string.Empty;
            dtConsulta.Columns.Add("ENVIO_MINISTERIO", typeof(DateTime));
            DateTime ENVIO_MINISTERIO = DateTime.Now;
            dtConsulta.Columns.Add("ID_MINISTERIO", typeof(string));
            string ID_MINISTERIO = "NO APLICA";
            dtConsulta.Columns.Add("TIEMPO_MINISTERIO", typeof(string));
            string TIEMPO_MINISTERIO = string.Empty;
            dtConsulta.Columns.Add("ESTADO_DESEGURO", typeof(string));
            string ESTADO_DESEGURO = string.Empty;
            dtConsulta.Columns.Add("ENVIO_DESEGURO", typeof(DateTime));
            DateTime ENVIO_DESEGURO = DateTime.Now;
            dtConsulta.Columns.Add("ID_DESEGURO", typeof(string));
            string ID_DESEGURO = "NO APLICA";
            dtConsulta.Columns.Add("TIEMPO_DESEGURO", typeof(string));
            string TIEMPO_DESEGURO = string.Empty;
            dtConsulta.Columns.Add("ESTADO_OSP", typeof(string));
            string ESTADO_OSP = string.Empty;
            dtConsulta.Columns.Add("ENVIO_OSP", typeof(DateTime));
            DateTime ENVIO_OSP = DateTime.Now;
            dtConsulta.Columns.Add("ID_OSP", typeof(string));
            string ID_OSP = "NO APLICA";
            dtConsulta.Columns.Add("TIEMPO_OSP", typeof(string));
            string TIEMPO_OSP = string.Empty;
            dtConsulta.Columns.Add("ESTADO_BAVARIA", typeof(string));
            string ESTADO_BAVARIA = string.Empty;
            dtConsulta.Columns.Add("ENVIO_BAVARIA", typeof(DateTime));
            DateTime ENVIO_BAVARIA = DateTime.Now;
            dtConsulta.Columns.Add("ID_BAVARIA", typeof(string));
            string ID_BAVARIA = "NO APLICA";
            dtConsulta.Columns.Add("TIEMPO_BAVARIA", typeof(string));
            string TIEMPO_BAVARIA = string.Empty;
            #endregion fin de la Definicion construccion tabla
            DataTable dtMinisterio = new DataTable();
            DataTable dtDeseguro = new DataTable();
            DataTable dtOsp = new DataTable();
            DataTable dtBavaria = new DataTable();
            foreach (DataRow drItem in dtTmpViajes.Rows)
            {
                OFICINA = drItem["OFIC_NOMBRE_V2"].ToString();
                PLANILLA = drItem["VIAJ_NOPLANILLA_V2"].ToString();
                FEC_CREA = DateTime.Parse(drItem["VIAJ_FECVIAJE_DT"].ToString());
                #region Definicion del bloque Ministerio

                dtMinisterio = getInfoDataTable(drItem, "getInfoMilenio");
                if (dtMinisterio.Rows.Count > 0)
                {
                    foreach (DataRow drMinisterio in dtMinisterio.Rows)
                    {
                        ESTADO_MINISTERIO = drMinisterio["LRMI_ESTADO_V2"].ToString();
                        ENVIO_MINISTERIO = DateTime.Parse(drMinisterio["DELM_FECENVIO_DT"].ToString());
                        ID_MINISTERIO = drMinisterio["DELM_IDMINISTERIO_NB"].ToString();
                        TimeSpan tTIEMPO_MINISTERIO = ENVIO_MINISTERIO - FEC_CREA;
                        TIEMPO_MINISTERIO = tTIEMPO_MINISTERIO.Days+"_" + tTIEMPO_MINISTERIO.Hours + ":" + tTIEMPO_MINISTERIO.Minutes + ":" + tTIEMPO_MINISTERIO.Seconds;
                    }
                }
                else
                {
                    ESTADO_MINISTERIO = "N/A";
                    ENVIO_MINISTERIO = DateTime.Now;
                    ID_MINISTERIO = "N/A";
                    TIEMPO_MINISTERIO = "N/A";

                }
                #endregion fin de la Definicion del bloque Ministerio

                #region Definicion del bloque Destino Seguro

                dtDeseguro = getInfoDataTable(drItem, "getInfoDeseguro");
                if (dtDeseguro.Rows.Count > 0)
                {
                    foreach (DataRow drDeseguro in dtDeseguro.Rows)
                    {
                        ESTADO_DESEGURO = drDeseguro["REDE_ESTADO_V2"].ToString();
                        ENVIO_DESEGURO = DateTime.Parse(drDeseguro["DESE_FECPROCESA_DT"].ToString());
                        ID_DESEGURO = drDeseguro["DESE_NUMACEPTA_NB"].ToString();
                        TimeSpan tTIEMPO_DESEGURO = ENVIO_DESEGURO - FEC_CREA;
                        TIEMPO_DESEGURO = tTIEMPO_DESEGURO.Days + "_" + tTIEMPO_DESEGURO.Hours + ":" + tTIEMPO_DESEGURO.Minutes + ":" + tTIEMPO_DESEGURO.Seconds;
                    }
                }
                else
                {
                    ESTADO_DESEGURO = "N/A";
                    ENVIO_DESEGURO = DateTime.Now;
                    ID_DESEGURO = "N/A";
                    TIEMPO_DESEGURO = "N/A";

                }
                #endregion fin de la Definicion del bloque Destino Seguro

                #region Definicion del bloque OSP

                dtOsp = getInfoDataTable(drItem, "getInfoOsp");
                if (dtOsp.Rows.Count > 0)
                {
                    foreach (DataRow drOsp in dtOsp.Rows)
                    {
                        ESTADO_OSP = drOsp["LPAD_ESTADO_V2"].ToString();
                        ENVIO_OSP = DateTime.Parse(drOsp["LPAD_FECENVIO_DT"].ToString());
                        ID_OSP = drOsp["LPAD_IDADMINSAT_V2"].ToString();
                        TimeSpan tTIEMPO_OSP = ENVIO_OSP - FEC_CREA;
                        TIEMPO_OSP = tTIEMPO_OSP.Days + "_" + tTIEMPO_OSP.Hours + ":" + tTIEMPO_OSP.Minutes + ":" + tTIEMPO_OSP.Seconds;
                    }
                }
                else
                {
                    ESTADO_DESEGURO = "N/A";
                    ENVIO_DESEGURO = DateTime.Now;
                    ID_DESEGURO = "N/A";
                    TIEMPO_DESEGURO = "N/A";

                }
                #endregion fin de la Definicion del bloque OSP

                #region Definicion del bloque BAVARIA

                dtBavaria = getInfoDataTable(drItem, "getInfoAutBavaria");
                if (dtBavaria.Rows.Count > 0)
                {
                    foreach (DataRow drBavaria in dtBavaria.Rows)
                    {
                        ESTADO_BAVARIA = drBavaria["DEBA_ESTADO_V2"].ToString();
                        ENVIO_BAVARIA = DateTime.Parse(drBavaria["DEBA_FECPROCESA_DT"].ToString());
                        ID_BAVARIA = drBavaria["DEBA_NUMACEPTA_NB"].ToString();
                        TimeSpan tTIEMPO_BAVARIA = ENVIO_BAVARIA - FEC_CREA;
                        TIEMPO_BAVARIA = tTIEMPO_BAVARIA.Days + "_" + tTIEMPO_BAVARIA.Hours + ":" + tTIEMPO_BAVARIA.Minutes + ":" + tTIEMPO_BAVARIA.Seconds;
                    }
                }
                else
                {
                    ESTADO_DESEGURO = "N/A";
                    ENVIO_DESEGURO = DateTime.Now;
                    ID_DESEGURO = "N/A";
                    TIEMPO_DESEGURO = "N/A";

                }
                #endregion fin de la Definicion del bloque BAVARIA

                try
                {
                    avance(OFICINA, PLANILLA, FEC_CREA,
                        ESTADO_MINISTERIO,
                        ENVIO_MINISTERIO,
                        ID_MINISTERIO,
                        TIEMPO_MINISTERIO,
                        ESTADO_DESEGURO,
                        ENVIO_DESEGURO,
                        ID_DESEGURO,
                        TIEMPO_DESEGURO,
                        ESTADO_OSP,
                        ENVIO_OSP,
                        ID_OSP,
                        TIEMPO_OSP,
                        ESTADO_BAVARIA,
                        ENVIO_BAVARIA,
                        ID_BAVARIA,
                        TIEMPO_BAVARIA);
                    dtConsulta.Rows.Add(OFICINA, PLANILLA, FEC_CREA,
                        ESTADO_MINISTERIO,
                        ENVIO_MINISTERIO,
                        ID_MINISTERIO,
                        TIEMPO_MINISTERIO,
                        ESTADO_DESEGURO,
                        ENVIO_DESEGURO,
                        ID_DESEGURO,
                        TIEMPO_DESEGURO,
                        ESTADO_OSP,
                        ENVIO_OSP,
                        ID_OSP,
                        TIEMPO_OSP,
                        ESTADO_BAVARIA,
                        ENVIO_BAVARIA,
                        ID_BAVARIA,
                        TIEMPO_BAVARIA);

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }



            }
            return dtConsulta;
        }

        private void avance(string oFICINA, string pLANILLA, DateTime fEC_CREA, string eSTADO_MINISTERIO, DateTime eNVIO_MINISTERIO, string iD_MINISTERIO, string tIEMPO_MINISTERIO, string eSTADO_DESEGURO, DateTime eNVIO_DESEGURO, string iD_DESEGURO, string tIEMPO_DESEGURO, string eSTADO_OSP, DateTime eNVIO_OSP, string iD_OSP, string tIEMPO_OSP, string eSTADO_BAVARIA, DateTime eNVIO_BAVARIA, string iD_BAVARIA, string tIEMPO_BAVARIA)
        {
            using (StreamWriter writer = new StreamWriter(@"D:\traces\avanceRobots.txt", true))
            {
                writer.WriteLine("Fecha : " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + ";" + oFICINA + ";" + pLANILLA + ";" + fEC_CREA + ";" + eSTADO_MINISTERIO + ";" + eNVIO_MINISTERIO + ";" + iD_MINISTERIO + ";" + tIEMPO_MINISTERIO + ";" + eSTADO_DESEGURO + ";" + eNVIO_DESEGURO + ";" + iD_DESEGURO + ";" + tIEMPO_DESEGURO + ";" + eSTADO_OSP + ";" + eNVIO_OSP + ";" + iD_OSP + ";" + tIEMPO_OSP + ";" + eSTADO_BAVARIA + ";" + eNVIO_BAVARIA + ";" + iD_BAVARIA + ";" + tIEMPO_BAVARIA);
            }
        }

        private DataTable getInfoMinisterio(DataRow drItem)
        {
            string llave = drItem["VIAJ_NOPLANILLA_V2"].ToString();
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":llave" };
            _vParametros = new object[1] { llave };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtTmp = data.getTable("getInfoMilenio", _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtTmp;
        }
        private DataTable getInfoDeseguro(DataRow drItem)
        {
            string llave = drItem["VIAJ_NOPLANILLA_V2"].ToString();
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":llave" };
            _vParametros = new object[1] { llave };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtTmp = data.getTable("getInfoDeseguro", _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtTmp;
        }        
        private DataTable getInfoDataTable(DataRow drItem, string select)
        {
            string llave = drItem["VIAJ_NOPLANILLA_V2"].ToString();
            DataTable dtTmp = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":llave" };
            _vParametros = new object[1] { llave };
            Factory data = new Factory(Usuario, Password, Ambiente);
            try
            {
                dtTmp = data.getTable(select, _nParametros, _vParametros);
            }
            catch (Exception ex)
            {
                ManejoError(ex, "var dtLogReporteDian = data.getTable(\"getLogReporteDian\", _nParametros, _vParametros);");
            }
            return dtTmp;
        }
    }
}
