using EntityMilenio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace fml.Varios
{
    public partial class LogicaCaVarios : IDisposable
    {
        private bool disposed = false;
        private readonly string usuario;
        private readonly string password;
        private readonly string usuEmail;
        private readonly string passEmail;
        private readonly string ambiente;
        public StringBuilder cicloVida { get; set; }
        public List<Ordenes_Cargue> ListOrdenes_Cargue { get; set; }
        public List<Viajes> ListViajes { get; set; }
        public List<Log_Reporte_Ministerio> ListLog_Reporte_Ministerio { get; set; }
        public List<Det_Log_Ministerio> ListDet_Log_Ministerio { get; set; }
        public List<Oficinas> ListOficinas { get; set; }
        public List<ReelacionViajesEntreFechas> ListReelacionViajesEntreFechas { get; set; }

        public string Rpt_Oficina { get; set; }//1
        public double Rpt_Orden { get; set; }//1
        public DateTime Rpt_FechaOrden { get; set; }
        public string Rpt_EstadoOrden { get; set; }
        public string Rpt_EstadoLogMinOrden { get; set; }
        public string Rpt_DescripcionLogMinOrden { get; set; }
        public DateTime Rpt_FecLogMinOrden { get; set; }
        public double Rpt_IdMinisterioOrden { get; set; }
        public DateTime Rpt_FecDetLogMinOrden { get; set; }
        public string Rpt_Planilla { get; set; }
        public DateTime Rpt_FecViaje { get; set; }
        public string Rpt_EstadoPlanilla { get; set; }
        public string Rpt_EstadoLogMinPlanilla { get; set; }
        public string Rpt_DescripcionLogMinPlanilla { get; set; }
        public DateTime Rpt_FecLogMinPlanilla { get; set; }
        public double Rpt_IdMinisterioPlanilla { get; set; }
        public DateTime Rpt_FecDetLogMinPlanilla { get; set; }
        public DateTime Rpt_FecAnulaOrden { get; set; }
        public DateTime Rpt_FecAnulaPlanilla { get; set; }

        /*
public double Rpt_Negocio { get; set; }//ORCA_NEGOCIO_NB
public string Rpt_Placa { get; set; }//ORCA_PLACA_CH
public double Rpt_Cedula { get; set; }//COND_CEDULA_NB
public string Rpt_Nombre { get; set; }//COND_NOMBRE_V2
public string Rpt_Apellido { get; set; }//COND_APELLIDO_V2
public double Rpt_Ruta { get; set; }//RUTA_CODIGO_NB
public double Rpt_CodigoOrigen { get; set; }//RUTA_ORIGEN_NB
public double Rpt_CodigoDestino { get; set; }//RUTA_DESTINO_NB
//public double o.CIUD_CODIGO_NB { get; set; }
public double Rpt_Origen { get; set; }//o.CIUD_DESCRIPCION_V2
//public double d.CIUD_CODIGO_NB { get; set; }//d.CIUD_CODIGO_NB
public double Rpt_Destino { get; set; }//d.CIUD_DESCRIPCION_V2
//public double OFIC_CODOFIC_NB { get; set; }//OFIC_CODOFIC_NB
public double Rpt_Oficina { get; set; }//OFIC_NOMBRE_V2
//public double PROD_CODIGO_NB { get; set; }
public double Rpt_Producto { get; set; }//PROD_NOMBRE_V2
//public double PROD_ABREVIATURA_V2 { get; set; }
//public double po.PLAN_CODIGO_NB { get; set; }
public double Rpt_PlantaOrigen { get; set; }//po.PLAN_NOMBRE_V2
//public double po.PLAN_CIUDAD_NB { get; set; }
//public double pd.PLAN_CODIGO_NB { get; set; }
public double Rpt_PlantaDestino { get; set; }//pd.PLAN_NOMBRE_V2
//public double pd.PLAN_CIUDAD_NB { get; set; }
//public double cpo.CIPA_CLIENTE_NB { get; set; }
//public double cpo.CIPA_PLANTA_NB { get; set; }
//public double cp.CLIE_CODIGO_NB { get; set; }
//public double cp.CLIE_NIT_NB { get; set; }
public double Rpt_ClientePaga { get; set; }//cp.CLIE_NOMBRE_V2
//public double cr.CLIE_CODIGO_NB { get; set; }
//public double cr.CLIE_NIT_NB { get; set; }
public double Rpt_ClienteRecibe { get; set; }//cr.CLIE_NOMBRE_V2
*/






        public LogicaCaVarios(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.usuEmail = usuEmail;
            this.passEmail = passEmail;
            this.ambiente = ambiente;
            ctorInicioNn();
            ctorInicioCambioEstado();
            ctorgetIdMinisterio();
        }

        private void ctorInicioCambioEstado()
        {
            
        }
        private void ctorgetIdMinisterio()
        {

        }

        private void ctorInicioNn()
        {
            cicloVida = new StringBuilder();
            ListOrdenes_Cargue = new List<Ordenes_Cargue>();
            ListViajes = new List<Viajes>();
            ListLog_Reporte_Ministerio = new List<Log_Reporte_Ministerio>();
            ListDet_Log_Ministerio = new List<Det_Log_Ministerio>();
            ListOficinas = new List<Oficinas>();
            ListReelacionViajesEntreFechas = new List<ReelacionViajesEntreFechas>();
            inicializarVariablesConsulta();
        }
        
        public DataTable InicioCambioEstado(DateTime fecIni, DateTime fecFin)
        {
            DataTable dt = new DataTable();
            return dt;

        }

        public DataTable InicioNn(DateTime fecIni, DateTime fecFin)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Oficina", typeof(string));
            dt.Columns.Add("Orden", typeof(double));
            dt.Columns.Add("FechaOrden", typeof(DateTime));
            dt.Columns.Add("EstadoOrden", typeof(string));
            dt.Columns.Add("EstadoLogMinOrden", typeof(string));
            dt.Columns.Add("DescripcionLogMinOrden", typeof(string));
            dt.Columns.Add("FecLogMinOrden", typeof(DateTime));
            dt.Columns.Add("IdMinisterioOrden", typeof(double));
            dt.Columns.Add("FecDetLogMinOrden", typeof(DateTime));
            dt.Columns.Add("Planilla", typeof(string));
            dt.Columns.Add("FecViaje", typeof(DateTime));
            dt.Columns.Add("EstadoPlanilla", typeof(string));
            dt.Columns.Add("EstadoLogMinPlanilla", typeof(string));
            dt.Columns.Add("DescripcionLogMinPlanilla", typeof(string));
            dt.Columns.Add("FecLogMinPlanilla", typeof(DateTime));
            dt.Columns.Add("IdMinisterioPlanilla", typeof(double));
            dt.Columns.Add("FecDetLogMinPlanilla", typeof(DateTime));
            //dt.Columns.Add("FecAnulaOrden", typeof(DateTime));
            //dt.Columns.Add("FecAnulaPlanilla", typeof(DateTime));

            try
            {
                ValidarOrdenesCargue(fecIni, fecFin);
            }
            catch (Exception ex)
            {
                cicloVida.Append(ex.Message);
            }

            if (ListReelacionViajesEntreFechas.Count>0)
            {
                foreach (ReelacionViajesEntreFechas item in ListReelacionViajesEntreFechas)
                {
                    dt.Rows.Add(item.Oficina, 
                        item.Orden,                         
                        item.FechaOrden,
                        item.EstadoOrden,
                        item.EstadoLogMinOrden,
                        item.DescripcionLogMinOrden,
                        item.FecLogMinOrden,
                        item.IdMinisterioOrden,
                        item.FecDetLogMinOrden,
                        item.Planilla,
                        item.FecViaje,
                        item.EstadoPlanilla,
                        item.EstadoLogMinPlanilla,
                        item.DescripcionLogMinPlanilla,
                        item.FecLogMinPlanilla,
                        item.IdMinisterioPlanilla,
                        item.FecDetLogMinPlanilla);
                    //,
                    //    item.FecAnulaOrden,
                    //    item.FecAnulaPlanilla);
                }
            }
            return dt;
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {

                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
