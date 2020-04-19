using EntityMilenio;
using infrastructure;
using System;
using System.Data;

namespace fml.Varios
{
    public partial class LogicaCaVarios
    {
        private void ValidarOrdenesCargue(DateTime fecIni, DateTime fecFin)
        {
            cicloVida.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n");
            cicloVida.Append("Inicio Metodo => private bool ValidarOrdenesCargue()" + "\r\n");

            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":fecini", ":fecfin" };
            _vParametros = new object[2] { fecIni, fecFin };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "getOrdenesCarguexReporteVarios", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            try
                            {
                                addOrdenesCargue(item);
                                addRowReporte();
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
        }

        private void addRowReporte()
        {
            ReelacionViajesEntreFechas RreelacionViajesEntreFechas = new ReelacionViajesEntreFechas();
            RreelacionViajesEntreFechas.Oficina = Rpt_Oficina;
            RreelacionViajesEntreFechas.Orden = Rpt_Orden;
            RreelacionViajesEntreFechas.FechaOrden = Rpt_FechaOrden;
            RreelacionViajesEntreFechas.EstadoOrden = Rpt_EstadoOrden;
            RreelacionViajesEntreFechas.EstadoLogMinOrden = Rpt_EstadoLogMinOrden;
            RreelacionViajesEntreFechas.DescripcionLogMinOrden = Rpt_DescripcionLogMinOrden;
            RreelacionViajesEntreFechas.FecLogMinOrden = Rpt_FecLogMinOrden;
            RreelacionViajesEntreFechas.IdMinisterioOrden = Rpt_IdMinisterioOrden;
            RreelacionViajesEntreFechas.FecDetLogMinOrden = Rpt_FecDetLogMinOrden;
            RreelacionViajesEntreFechas.Planilla = Rpt_Planilla;
            RreelacionViajesEntreFechas.FecViaje = Rpt_FecViaje;
            RreelacionViajesEntreFechas.EstadoPlanilla = Rpt_EstadoPlanilla;
            RreelacionViajesEntreFechas.EstadoLogMinPlanilla = Rpt_EstadoLogMinPlanilla;
            RreelacionViajesEntreFechas.DescripcionLogMinPlanilla = Rpt_DescripcionLogMinPlanilla;
            RreelacionViajesEntreFechas.FecLogMinPlanilla = Rpt_FecLogMinPlanilla;
            RreelacionViajesEntreFechas.IdMinisterioPlanilla = Rpt_IdMinisterioPlanilla;
            RreelacionViajesEntreFechas.FecDetLogMinPlanilla = Rpt_FecDetLogMinPlanilla;

            RreelacionViajesEntreFechas.FecAnulaOrden = Rpt_FecAnulaOrden;
            RreelacionViajesEntreFechas.FecAnulaPlanilla = Rpt_FecAnulaPlanilla;
            /*
            RreelacionViajesEntreFechas.Negocio=Rpt_Negocio;
            RreelacionViajesEntreFechas.Placa=Rpt_Placa;
            RreelacionViajesEntreFechas.Cedula=Rpt_Cedula;
            RreelacionViajesEntreFechas.Nombre=Rpt_Nombre;
            RreelacionViajesEntreFechas.Apellido=Rpt_Apellido;
            RreelacionViajesEntreFechas.Ruta=Rpt_Ruta;
            RreelacionViajesEntreFechas.CodigoOrigen=Rpt_CodigoOrigen;
            RreelacionViajesEntreFechas.CodigoDestino=Rpt_CodigoDestino;
            RreelacionViajesEntreFechas.Origen=Rpt_Origen;
            RreelacionViajesEntreFechas.Destino=Rpt_Destino;
            RreelacionViajesEntreFechas.Oficina=Rpt_Oficina;
            RreelacionViajesEntreFechas.Producto=Rpt_Producto;
            RreelacionViajesEntreFechas.PlantaOrigen=Rpt_PlantaOrigen;
            RreelacionViajesEntreFechas.PlantaDestino=Rpt_PlantaDestino;
            RreelacionViajesEntreFechas.ClientePaga=Rpt_ClientePaga;
            RreelacionViajesEntreFechas.ClienteRecibe=Rpt_ClienteRecibe;
            */
            ListReelacionViajesEntreFechas.Add(RreelacionViajesEntreFechas);
            inicializarVariablesConsulta();

        }
        private void addOrdenesCargue(DataRow item)
        {
            #region Bloque Informacion Orden de Cargue

            Ordenes_Cargue logOrdenes_Cargue = new Ordenes_Cargue();
            try
            {
                logOrdenes_Cargue.ORCA_NUMERO_NB = double.Parse(item["ORCA_NUMERO_NB"].ToString());//  { get; set; } //  NOT NULL NUMBER(12)

            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_NUMERO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_NEGOCIO_NB = double.Parse(item["ORCA_NEGOCIO_NB"].ToString());//  { get; set; } //  NUMBER(10)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_NEGOCIO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_FECCREA_DT = DateTime.Parse(item["ORCA_FECCREA_DT"].ToString());//  { get; set; } //  NOT NULL DATE
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_FECCREA_DT = DateTime.Now;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_PLACA_CH = item["ORCA_PLACA_CH"].ToString();//  { get; set; } //  NOT NULL CHAR(6)

            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_PLACA_CH = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CONDUCTOR_NB = double.Parse(item["ORCA_CONDUCTOR_NB"].ToString());//  { get; set; } //  NOT NULL NUMBER(13)

            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CONDUCTOR_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_NITREM_NB = double.Parse(item["ORCA_NITREM_NB"].ToString());//  { get; set; } //  NOT NULL NUMBER(9)

            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_NITREM_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_RUTA_NB = double.Parse(item["ORCA_RUTA_NB"].ToString());//  { get; set; } //  NOT NULL NUMBER(10)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_RUTA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_OFICDESP_NB = int.Parse(item["ORCA_OFICDESP_NB"].ToString());//   { get; set; } //  NOT NULL NUMBER(3)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_OFICDESP_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_PRODUCTO_NB = int.Parse(item["ORCA_PRODUCTO_NB"].ToString());//  { get; set; } //  NOT NULL NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_PRODUCTO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_OBSERVACIONES_V2 = item["ORCA_OBSERVACIONES_V2"].ToString();//   { get; set; } //  VARCHAR2(250)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_OBSERVACIONES_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_TIPOEMPAQUE_NB = int.Parse(item["ORCA_TIPOEMPAQUE_NB"].ToString());// { get; set; } //  NOT NULL NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_TIPOEMPAQUE_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CANTIDAD_NB = int.Parse(item["ORCA_CANTIDAD_NB"].ToString());// { get; set; } //  NOT NULL NUMBER(7)

            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CANTIDAD_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_VOLUMEN_NB = item["ORCA_VOLUMEN_NB"].ToString();//  { get; set; } //  VARCHAR2(1)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_VOLUMEN_NB = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_PESOKGS_NB = int.Parse(item["ORCA_PESOKGS_NB"].ToString());// { get; set; } //  NOT NULL NUMBER(7,2)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_PESOKGS_NB = -321.0M;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_ESTADO_V2 = item["ORCA_ESTADO_V2"].ToString();//  { get; set; } //  NOT NULL VARCHAR2(1)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_ESTADO_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_TRAILER_CH = item["ORCA_TRAILER_CH"].ToString();// { get; set; } //  CHAR(6)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_TRAILER_CH = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAMINO_NB = int.Parse(item["ORCA_CAMINO_NB"].ToString());// { get; set; } //  NOT NULL NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAMINO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_SECUENCIA_NB = int.Parse(item["ORCA_SECUENCIA_NB"].ToString());// { get; set; } //  NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_SECUENCIA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_PLANTAREMITE_NB = int.Parse(item["ORCA_PLANTAREMITE_NB"].ToString());// { get; set; } //  NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_PLANTAREMITE_NB = -321;

                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_PLANTARECIBE_NB = int.Parse(item["ORCA_PLANTARECIBE_NB"].ToString());// { get; set; } //  NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_PLANTARECIBE_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CEDRELEVO_NB = double.Parse(item["ORCA_CEDRELEVO_NB"].ToString());//  { get; set; } //  NUMBER(13)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CEDRELEVO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_TIPOVIAJE_V2 = item["ORCA_TIPOVIAJE_V2"].ToString();//  { get; set; } //  VARCHAR2(1)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_TIPOVIAJE_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_USUCREA_NB = double.Parse(item["ORCA_USUCREA_NB"].ToString());//  { get; set; } //  NUMBER(13)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_USUCREA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_FECANULA_DT = DateTime.Parse(item["ORCA_FECANULA_DT"].ToString());// { get; set; } //  DATE
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_FECANULA_DT = DateTime.Now;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_USUANULA_NB = double.Parse(item["ORCA_USUANULA_NB"].ToString());//  { get; set; } //  NUMBER(13)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_USUANULA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAUSANULA_NB = int.Parse(item["ORCA_CAUSANULA_NB"].ToString());// { get; set; } //  NUMBER(3)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAUSANULA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CLIENTEPAGA_NB = int.Parse(item["ORCA_CLIENTEPAGA_NB"].ToString());// { get; set; } //  NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CLIENTEPAGA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CELULAR_NB = double.Parse(item["ORCA_CELULAR_NB"].ToString());//  { get; set; } //  NUMBER(15)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CELULAR_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAMPO1_NB = double.Parse(item["ORCA_CAMPO1_NB"].ToString());//  { get; set; } //  NUMBER(20)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAMPO1_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAMPO2_NB = item["ORCA_CAMPO2_NB"].ToString();//  { get; set; } //  VARCHAR2(50)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAMPO2_NB = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_OPCIONCREA_V2 = item["ORCA_OPCIONCREA_V2"].ToString();//  { get; set; } //  VARCHAR2(10)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_OPCIONCREA_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_GRUPORUTA_NB = double.Parse(item["ORCA_GRUPORUTA_NB"].ToString());//  { get; set; } //  NUMBER(10)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_GRUPORUTA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CLIENTEREC_NB = int.Parse(item["ORCA_CLIENTEREC_NB"].ToString());// { get; set; } //  NUMBER(5)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CLIENTEREC_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAMPO3_NB = double.Parse(item["ORCA_CAMPO3_NB"].ToString());//  { get; set; } //  NUMBER(15)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAMPO3_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_CAMPO4_V2 = item["ORCA_CAMPO4_V2"].ToString();//  { get; set; } //  VARCHAR2(70)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_CAMPO4_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logOrdenes_Cargue.ORCA_IDMINISTERIO_V2 = item["ORCA_IDMINISTERIO_V2"].ToString();//  { get; set; } //  VARCHAR2(25)
            }
            catch (Exception ex)
            {
                logOrdenes_Cargue.ORCA_IDMINISTERIO_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                ListOrdenes_Cargue.Add(logOrdenes_Cargue);
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }

            #endregion fin del Bloque Informacion Orden de Cargue

            #region Definicion del Bloque informacion del reporte
            Rpt_Oficina = item["Oficina"].ToString();
            Rpt_Orden = double.Parse(item["Orden"].ToString());
            Rpt_FechaOrden = DateTime.Parse(item["FechaOrden"].ToString());
            Rpt_EstadoOrden = item["EstadoOrden"].ToString();

            #endregion fin de la Definicion del Bloque informacion del reporte

            getLogReporteMinisterioVarios(logOrdenes_Cargue.ORCA_OFICDESP_NB, logOrdenes_Cargue.ORCA_NUMERO_NB.ToString(), 3);
            ValidarPlanillas(logOrdenes_Cargue.ORCA_NUMERO_NB);
        }

        private void getLogReporteMinisterioVarios(int oficina, string llave, int transaccion)
        {
            cicloVida.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n");
            cicloVida.Append("Inicio Metodo => private void GetIdMinisterioOrdenCargue(int oficina,string llave)" + "\r\n");

            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[3] { ":oficina", ":llave", ":transaccion" };
            _vParametros = new object[3] { oficina, llave, transaccion };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "getLogReporteMinisterioVarios", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            switch (transaccion)
                            {
                                case 3:
                                    {

                                        Rpt_EstadoLogMinOrden = item["LRMI_ESTADO_V2"].ToString();
                                        Rpt_FecLogMinOrden = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
                                        /*try
                                        {
                                            getIdMinisterio(item, transaccion);
                                        }
                                        catch (Exception ex)
                                        {
                                            manejoErrores(ex);
                                        }*/

                                        Rpt_DescripcionLogMinOrden = item["LRMI_CAMPO2_V2"].ToString();
                                        try
                                        {
                                            Rpt_FecDetLogMinOrden = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_FecDetLogMinOrden = DateTime.Now;
                                        }
                                        try
                                        {
                                            Rpt_IdMinisterioOrden = double.Parse(item["LRMI_CAMPO2_V2"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_IdMinisterioOrden = 0;
                                            manejoErrores(ex);
                                        }

                                        break;
                                    }
                                case 4:
                                    {

                                        Rpt_EstadoLogMinPlanilla = item["LRMI_ESTADO_V2"].ToString();
                                        Rpt_FecLogMinPlanilla = DateTime.Parse(item["LRMI_FECREGISTRO_DT"].ToString());
                                        /*try
                                        {
                                            getIdMinisterio(item, transaccion);
                                        }
                                        catch (Exception ex)
                                        {
                                            manejoErrores(ex);
                                        }*/

                                        Rpt_DescripcionLogMinPlanilla = item["LRMI_CAMPO2_V2"].ToString();
                                        try
                                        {
                                            Rpt_FecDetLogMinPlanilla = DateTime.Parse(item["LRMI_CAMPO3_DT"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_FecDetLogMinPlanilla = DateTime.Now;
                                        }
                                        try
                                        {
                                            Rpt_IdMinisterioPlanilla = double.Parse(item["LRMI_CAMPO2_V2"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_IdMinisterioPlanilla = 0;
                                            manejoErrores(ex);
                                        }

                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Rpt_EstadoLogMinOrden = "Sin Registro";
                        Rpt_DescripcionLogMinOrden = "Sin Registro";
                        Rpt_FecLogMinOrden = DateTime.Now;
                        Rpt_IdMinisterioOrden = -987654321;
                        Rpt_FecDetLogMinOrden = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
        }
        private void getIdMinisterio(DataRow DrLogReporteMinisterio, int transaccion)
        {
            cicloVida.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n");
            cicloVida.Append("Inicio Metodo => private void GetIdMinisterioOrdenCargue(int oficina,string llave)" + "\r\n");
            double secuencia = double.Parse(DrLogReporteMinisterio["LRMI_SECUENCIA_NB"].ToString());
            int oficina = int.Parse(DrLogReporteMinisterio["LRMI_OFICINA_NB"].ToString());
            string llave = DrLogReporteMinisterio["LRMI_LLAVE_V2"].ToString();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[3] { ":logsecuencia", ":oficina", ":llave" };
            _vParametros = new object[3] { secuencia, oficina, llave };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "getIdMinisterio", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {

                            switch (transaccion)
                            {
                                case 3:
                                    {

                                        Rpt_DescripcionLogMinOrden = item["DELM_XMLRECIBIDO_XML"].ToString();
                                        Rpt_FecDetLogMinOrden = DateTime.Parse(item["DELM_FECENVIO_DT"].ToString());
                                        try
                                        {
                                            Rpt_IdMinisterioOrden = double.Parse(item["DELM_IDMINISTERIO_NB"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_IdMinisterioOrden = 0;
                                            manejoErrores(ex);
                                        }
                                        break;
                                    }
                                case 4:
                                    {

                                        Rpt_DescripcionLogMinPlanilla = item["DELM_XMLRECIBIDO_XML"].ToString();
                                        Rpt_FecDetLogMinPlanilla = DateTime.Parse(item["DELM_FECENVIO_DT"].ToString());
                                        try
                                        {
                                            Rpt_IdMinisterioPlanilla = double.Parse(item["DELM_IDMINISTERIO_NB"].ToString());
                                        }
                                        catch (Exception ex)
                                        {
                                            Rpt_IdMinisterioPlanilla = 0;
                                            manejoErrores(ex);
                                        }
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
        }

        private void manejoErrores(Exception ex)
        {
            cicloVida.Append(ex.Message);
        }

        private void ValidarPlanillas(double OrdenCargue)
        {
            cicloVida.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n");
            cicloVida.Append("Inicio Metodo => private bool ValidarPlanillas()" + "\r\n");

            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":VIAJ_ORDCARGUE" };
            _vParametros = new object[1] { OrdenCargue };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "getViajesxOrdenCargue", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            try
                            {
                                addViajes(item);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                            }
                        }
                    }
                    else
                    {
                        Rpt_EstadoLogMinPlanilla = "Sin Registro";
                        Rpt_DescripcionLogMinPlanilla = "Sin Registro";
                        Rpt_FecLogMinPlanilla = DateTime.Now;
                        Rpt_IdMinisterioPlanilla = -987654321;
                        Rpt_FecDetLogMinPlanilla = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
        }

        private void addViajes(DataRow item)
        {
            Viajes logViajes = new Viajes();
            try
            {
                logViajes.VIAJ_NOPLANILLA_V2 = item["VIAJ_NOPLANILLA_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_NOPLANILLA_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_NEGOCIO_NB = double.Parse(item["VIAJ_NEGOCIO_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_NEGOCIO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_ORDCARGUE_NB = double.Parse(item["VIAJ_ORDCARGUE_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_ORDCARGUE_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_FECVIAJE_DT = DateTime.Parse(item["VIAJ_FECVIAJE_DT"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_FECVIAJE_DT = DateTime.Now;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_PLACA_CH = item["VIAJ_PLACA_CH"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_PLACA_CH = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_OFDESPACHA_NB = int.Parse(item["VIAJ_OFDESPACHA_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_OFDESPACHA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CLASEVEHI_NB = int.Parse(item["VIAJ_CLASEVEHI_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CLASEVEHI_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_ESTADO_V2 = item["VIAJ_ESTADO_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_ESTADO_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_MONEDA_NB = int.Parse(item["VIAJ_MONEDA_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_MONEDA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_NODTAI_NB = item["VIAJ_NODTAI_NB"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_NODTAI_NB = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_MOTONAVE_NB = int.Parse(item["VIAJ_MOTONAVE_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_MOTONAVE_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CONDUCTOR_NB = double.Parse(item["VIAJ_CONDUCTOR_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CONDUCTOR_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_PROPIETARIO_NB = double.Parse(item["VIAJ_PROPIETARIO_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_PROPIETARIO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_POSEEDOR_NB = double.Parse(item["VIAJ_POSEEDOR_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_POSEEDOR_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_FECANULA_DT = DateTime.Parse(item["VIAJ_FECANULA_DT"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_FECANULA_DT = DateTime.Now;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_TIPO_V2 = item["VIAJ_TIPO_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_TIPO_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CANTVIAJES_NB = int.Parse(item["VIAJ_CANTVIAJES_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CANTVIAJES_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_VALORCARGA_NB = decimal.Parse(item["VIAJ_VALORCARGA_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_VALORCARGA_NB = -321.0M;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_OBSERVACIONES_V2 = item["VIAJ_OBSERVACIONES_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_OBSERVACIONES_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_TRAILER_CH = item["VIAJ_TRAILER_CH"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_TRAILER_CH = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CUMLIQ_V2 = item["VIAJ_CUMLIQ_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CUMLIQ_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_FACTURADA_V2 = item["VIAJ_FACTURADA_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_FACTURADA_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_SINIESTROS_V2 = item["VIAJ_SINIESTROS_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_SINIESTROS_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_DOCTRANSPORTE_V2 = item["VIAJ_DOCTRANSPORTE_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_DOCTRANSPORTE_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CEDRELEVO_NB = double.Parse(item["VIAJ_CEDRELEVO_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CEDRELEVO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_TIPOVIAJE_V2 = item["VIAJ_TIPOVIAJE_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_TIPOVIAJE_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_DOCEXTERNO_V2 = item["VIAJ_DOCEXTERNO_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_DOCEXTERNO_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_USUCREA_NB = double.Parse(item["VIAJ_USUCREA_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_USUCREA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_USUANULA_NB = double.Parse(item["VIAJ_USUANULA_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_USUANULA_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_PORDCTOCOMER_NB = decimal.Parse(item["VIAJ_PORDCTOCOMER_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_PORDCTOCOMER_NB = -321.0M;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_PORMARGENINT_NB = decimal.Parse(item["VIAJ_PORMARGENINT_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_PORMARGENINT_NB = -321.0M;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CELULAR_NB = double.Parse(item["VIAJ_CELULAR_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CELULAR_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_FIN_NB = double.Parse(item["VIAJ_FIN_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_FIN_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_USUFIN_NB = double.Parse(item["VIAJ_USUFIN_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_USUFIN_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CAUSANULA_NB = item["VIAJ_CAUSANULA_NB"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CAUSANULA_NB = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CAMPO1_NB = double.Parse(item["VIAJ_CAMPO1_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CAMPO1_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CAMPO2_NB = double.Parse(item["VIAJ_CAMPO2_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CAMPO2_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CAMPO3_V2 = item["VIAJ_CAMPO3_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CAMPO3_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CAMPO4_V2 = item["VIAJ_CAMPO4_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CAMPO4_V2 = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_TIPMANIFIESTO_NB = int.Parse(item["VIAJ_TIPMANIFIESTO_NB"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_TIPMANIFIESTO_NB = -321;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_FECENTREGA_DT = DateTime.Parse(item["VIAJ_FECENTREGA_DT"].ToString());

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_FECENTREGA_DT = DateTime.Now;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_CONSMANIFIESTO_NB = item["VIAJ_CONSMANIFIESTO_NB"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_CONSMANIFIESTO_NB = string.Empty;
                manejoErrores(ex);
            }
            try
            {
                logViajes.VIAJ_IDMINISTERIO_V2 = item["VIAJ_IDMINISTERIO_V2"].ToString();

            }
            catch (Exception ex)
            {
                logViajes.VIAJ_IDMINISTERIO_V2 = string.Empty;
                manejoErrores(ex);
            }

            try
            {
                ListViajes.Add(logViajes);
            }
            catch (Exception ex)
            {
                manejoErrores(ex);
            }

            Rpt_Planilla = item["Planilla"].ToString();
            Rpt_FecViaje = DateTime.Parse(item["FecViaje"].ToString());
            Rpt_EstadoPlanilla = item["EstadoPlanilla"].ToString();

            getLogReporteMinisterioVarios(logViajes.VIAJ_OFDESPACHA_NB, logViajes.VIAJ_NOPLANILLA_V2, 4);
        }
        private void inicializarVariablesConsulta()
        {
            Rpt_Oficina = string.Empty;
            Rpt_Orden = -1;
            Rpt_FechaOrden = DateTime.Now;
            Rpt_EstadoOrden = string.Empty;
            Rpt_EstadoLogMinOrden = string.Empty;
            Rpt_DescripcionLogMinOrden = string.Empty;
            Rpt_FecLogMinOrden = DateTime.Now;
            Rpt_IdMinisterioOrden = -1;
            Rpt_FecDetLogMinOrden = DateTime.Now;
            Rpt_Planilla = string.Empty;
            Rpt_FecViaje = DateTime.Now;
            Rpt_EstadoPlanilla = string.Empty;
            Rpt_EstadoLogMinPlanilla = string.Empty;
            Rpt_DescripcionLogMinPlanilla = string.Empty;
            Rpt_FecLogMinPlanilla = DateTime.Now;
            Rpt_IdMinisterioPlanilla = -1;
            Rpt_FecDetLogMinPlanilla = DateTime.Now;
            Rpt_FecAnulaOrden = DateTime.Now;
            Rpt_FecAnulaPlanilla = DateTime.Now;
            /*
            Rpt_Negocio = -1;
            Rpt_Placa = string.Empty;
            Rpt_Cedula = -1;
            Rpt_Nombre = string.Empty;
            Rpt_Apellido = string.Empty;
            Rpt_Ruta = -1;
            Rpt_CodigoOrigen = -1;
            Rpt_CodigoDestino = -1;
            Rpt_Origen = -1;
            Rpt_Destino = -1;
            Rpt_Oficina = -1;
            Rpt_Producto = -1;
            Rpt_PlantaOrigen = -1;
            Rpt_PlantaDestino = -1;
            Rpt_ClientePaga = -1;
            Rpt_ClienteRecibe = -1;
            */
        }
        private void ComprobarLog()
        {
            cicloVida.Append(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + "\r\n");
            cicloVida.Append("Inicio Metodo => private void ComprobarLog()" + "\r\n");
        }
        public DataTable InicioGetIdMinisterio(DateTime fecIni, DateTime fecFin)
        {
            int procesados = 0;
            DataTable dt = new DataTable();
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_OFICINA" };
            _vParametros = new object[1] { 11 };
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "setIdMinisterio", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        double LRMI_SECUENCIA_NB = -1;
                        int LRMI_OFICINA_NB = -1;
                        foreach (DataRow item in dt.Rows)
                        {
                            if (LRMI_SECUENCIA_NB == double.Parse(item["LRMI_SECUENCIA_NB"].ToString()))
                            {
                                if (LRMI_OFICINA_NB == int.Parse(item["LRMI_OFICINA_NB"].ToString()))
                                {
                                    Console.WriteLine(" ");
                                    procesados++;
                                    LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                                    LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                                    Console.WriteLine("Secuencia : " + LRMI_SECUENCIA_NB + " Oficina : " + LRMI_OFICINA_NB + " Total ==> : " + procesados);
                                    updateRegistroLogReporteMinisterio(item);
                                }
                                else
                                {
                                    try
                                    {
                                        procesados++;
                                        LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                                        LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                                        Console.WriteLine("Secuencia : " + LRMI_SECUENCIA_NB + " Oficina : " + LRMI_OFICINA_NB + " Total ==> : " + procesados);
                                        updateRegistroLogReporteMinisterio(item);
                                    }
                                    catch (Exception ex)
                                    {
                                        manejoErrores(ex);
                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    procesados++;
                                    LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
                                    LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
                                    Console.WriteLine("Secuencia : " + LRMI_SECUENCIA_NB + " Oficina : " + LRMI_OFICINA_NB + " Total ==> : " + procesados);
                                    updateRegistroLogReporteMinisterio(item);
                                }
                                catch (Exception ex)
                                {
                                    manejoErrores(ex);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
            Console.ReadLine();
            return dt;
        }

        private void updateRegistroLogReporteMinisterio(DataRow item)
        {
            string LRMI_ESTADO_V2 = item["LRMI_ESTADO_V2"].ToString();
            double LRMI_SECUENCIA_NB = double.Parse(item["LRMI_SECUENCIA_NB"].ToString());
            int LRMI_OFICINA_NB = int.Parse(item["LRMI_OFICINA_NB"].ToString());
            string DELM_IDMINISTERIO_NB = item["DELM_IDMINISTERIO_NB"].ToString();
            DateTime LRMI_CAMPO3_DT = DateTime.Parse(item["DELM_FECENVIO_DT"].ToString());
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[5] { ":LRMI_CAMPO2", ":LRMI_CAMPO3", ":LRMI_SECUENCIA", ":LRMI_OFICINA", ":LRMI_ESTADO" };
            _vParametros = new object[5] { DELM_IDMINISTERIO_NB, LRMI_CAMPO3_DT, LRMI_SECUENCIA_NB, LRMI_OFICINA_NB, LRMI_ESTADO_V2 };
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    Console.WriteLine("Secuencia : " + LRMI_SECUENCIA_NB);
                    Console.WriteLine("Oficina : " + LRMI_OFICINA_NB);
                    if (DELM_IDMINISTERIO_NB!="1")
                    {
                        data.executeCommand("Varios", "SetUpdateLogReporteMinisterio", _nParametros, _vParametros);
                    }
                    else
                    {
                        Console.WriteLine("Secuencia : " + LRMI_SECUENCIA_NB);
                        Console.WriteLine("Oficina   : " + LRMI_OFICINA_NB);
                        Console.WriteLine("ID        : " + DELM_IDMINISTERIO_NB);
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }
        }
    }
}