using infrastructure;
using System;
using System.Data;
using System.IO;

namespace fml.Varios
{
    public partial class LogicaHistoryPlanilla
    {

        private void Inicio()
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dt = data.getTable("Varios", "getOrdenesCarguexHistoryPlanilla", _nParametros, _vParametros);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            try
                            {
                                addRow(item);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                            }
                        }

                        //procesarResultado();
                    }
                }
                catch (Exception ex)
                {
                    manejoErrores(ex);
                }
            }

        }

        private void procesarResultado()
        {
            foreach (DataRow drCon in _dtResultado.Rows)
            {
                using (StreamWriter writer = new StreamWriter(@"E:\err\manifiesto.txt", true))
                {
                    /*
                    _dtResultado.Columns.Add("Oficina", typeof(string));
                    _dtResultado.Columns.Add("Fecha", typeof(DateTime));
                    _dtResultado.Columns.Add("Llave", typeof(string));
                    _dtResultado.Columns.Add("Estado", typeof(string));
                    _dtResultado.Columns.Add("Ministerio", typeof(bool));
                    _dtResultado.Columns.Add("Id", typeof(string));
                    _dtResultado.Columns.Add("EstadoLogMin", typeof(string));
                    _dtResultado.Columns.Add("FecLogMin", typeof(DateTime));
                    _dtResultado.Columns.Add("Intentos", typeof(int));
                    _dtResultado.Columns.Add("EstadoDetLog", typeof(string));
                    _dtResultado.Columns.Add("FecDetLog", typeof(DateTime));
                    */
                    writer.WriteLine(drCon["Oficina"].ToString() + ";" + drCon["Fecha"].ToString() + ";" + drCon["Llave"].ToString() + ";" + drCon["Estado"].ToString() + ";" + drCon["Ministerio"].ToString() + ";" +
                        drCon["Id"].ToString() + ";" + drCon["EstadoLogMin"].ToString() + ";" + drCon["FecLogMin"].ToString() + ";" + drCon["Intentos"].ToString() + ";" + drCon["EstadoDetLog"].ToString() + ";" +
                        drCon["FecDetLog"].ToString());
                }
            }
        }

        private void addRow(DataRow reg)
        {
            Oficina = reg["OFIC_NOMBRE_V2"].ToString();
            /*
            Fecha = DateTime.Parse(reg["ORCA_FECCREA_DT"].ToString());
            Llave = reg["ORCA_NUMERO_NB"].ToString();
            Estado = reg["ORCA_ESTADO_V2"].ToString();
            */

            Fecha = DateTime.Parse(reg["VIAJ_FECVIAJE_DT"].ToString());
            Llave = reg["VIAJ_NOPLANILLA_V2"].ToString();
            Estado = reg["VIAJ_ESTADO_V2"].ToString();

            Ministerio = false;

            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[2] { ":LRMI_LLAVE", ":LRMI_TRANSACCION" };
            _vParametros = new object[2] { Llave, 4 };
            DataTable dtLogReporte = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dtLogReporte = data.getTable("Varios", "getOrdenesCarguexHistoryPlanillaxLogReporteMinisterio", _nParametros, _vParametros);
                    if (dtLogReporte.Rows.Count > 0)
                    {
                        Ministerio = true;
                        FecLogMin = DateTime.Now;
                        foreach (DataRow itemLogReporte in dtLogReporte.Rows)
                        {
                            EstadoLogMin = itemLogReporte["LRMI_ESTADO_V2"].ToString();
                            try
                            {
                                Id = addRowDetMin(itemLogReporte);
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                            }
                        }
                    }
                    else
                    {
                        EstadoLogMin = "No tiene registro en LOG_REPORTE_MINISTERIO";
                        Id = "No tiene registro";
                        FecLogMin = DateTime.Now;
                        Intentos = -1;
                        EstadoDetLog = "No tiene registro en DET_LOG_MINISTERIO";
                        FecDetLog = DateTime.Now;
                        try
                        {
                            _dtResultado.Rows.Add(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            procesarResultado(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            inicializarRow();
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

        private void procesarResultado(string oficina, DateTime fecha, string llave, string estado, bool ministerio, string id, string estadoLogMin, DateTime fecLogMin, int intentos, string estadoDetLog, DateTime fecDetLog)
        {
            using (StreamWriter writer = new StreamWriter(@"E:\err\manifiesto.txt", true))
            {
                writer.WriteLine(oficina + ";" + fecha + ";" + llave + ";" + estado + ";" + ministerio + ";" + id + ";" + estadoLogMin + ";" + fecLogMin + ";" + intentos + ";" + estadoDetLog + ";" + fecDetLog);
            }
            Console.WriteLine(oficina + ";" + fecha + ";" + llave + ";" + estado + ";" + ministerio + ";" + id + ";" + estadoLogMin + ";" + fecLogMin + ";" + intentos + ";" + estadoDetLog + ";" + fecDetLog);
        }

        private string addRowDetMin(DataRow itemLogReporte)
        {
            double DELM_LOGSECUENCIA = -1;
            try
            {
                DELM_LOGSECUENCIA = double.Parse(itemLogReporte["LRMI_SECUENCIA_NB"].ToString());
            }
            catch (Exception ex)
            {
                DELM_LOGSECUENCIA = -1;
                manejoErrores(ex);
            }
            int DELM_OFICINA = -1;
            try
            {
                DELM_OFICINA = int.Parse(itemLogReporte["LRMI_OFICINA_NB"].ToString());
            }
            catch (Exception ex)
            {
                DELM_OFICINA = -1;
                manejoErrores(ex);
            }
            string DELM_LLAVE = string.Empty;
            try
            {
                DELM_LLAVE = itemLogReporte["LRMI_LLAVE_V2"].ToString();
            }
            catch (Exception ex)
            {
                DELM_LLAVE = string.Empty;
                manejoErrores(ex);
            }
            string id = string.Empty;
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[3] { ":DELM_LOGSECUENCIA", ":DELM_OFICINA", ":DELM_LLAVE" };
            _vParametros = new object[3] { DELM_LOGSECUENCIA, DELM_OFICINA, DELM_LLAVE };
            DataTable dtLogReporte = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                try
                {
                    dtLogReporte = data.getTable("Varios", "getOrdenesCarguexHistoryPlanillaxDetLogMinisterio", _nParametros, _vParametros);
                    if (dtLogReporte.Rows.Count > 0)
                    {
                        Intentos = 0;
                        foreach (DataRow itemDetReporte in dtLogReporte.Rows)
                        {
                            Intentos++;
                            try
                            {
                                EstadoDetLog = itemDetReporte["DELM_ESTADO_V2"].ToString();
                                try
                                {
                                    FecDetLog = DateTime.Parse(itemDetReporte["DELM_FECENVIO_DT"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    FecDetLog = DateTime.Now;
                                    manejoErrores(ex);
                                }
                                Id = itemDetReporte["DELM_IDMINISTERIO_NB"].ToString();
                            }
                            catch (Exception ex)
                            {
                                manejoErrores(ex);
                            }
                        }
                        try
                        {
                            _dtResultado.Rows.Add(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            procesarResultado(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            inicializarRow();
                        }
                        catch (Exception ex)
                        {
                            manejoErrores(ex);
                        }

                    }
                    else
                    {
                        Intentos = -1;
                        EstadoDetLog = "No tiene registro en DET_LOG_MINISTERIO";
                        FecDetLog = DateTime.Now;
                        try
                        {
                            _dtResultado.Rows.Add(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            procesarResultado(Oficina, Fecha, Llave, Estado, Ministerio, Id, EstadoLogMin, FecLogMin, Intentos, EstadoDetLog, FecDetLog);
                            inicializarRow();
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
            return id;
        }

        private void inicializarRow()
        {
            Oficina = string.Empty;
            Fecha = DateTime.Now;
            Llave = string.Empty;
            Estado = string.Empty;
            Ministerio = false;
            Id = string.Empty;
            EstadoLogMin = string.Empty;
            FecLogMin = DateTime.Now;
            Intentos = -1;
            EstadoDetLog = string.Empty;
            FecDetLog = DateTime.Now;
        }

        private void manejoErrores(Exception ex)
        {
            cicloVida.Append(ex.Message);
        }


    }
}
