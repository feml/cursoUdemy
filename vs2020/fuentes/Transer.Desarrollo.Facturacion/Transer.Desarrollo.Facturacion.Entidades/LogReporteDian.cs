using System;

namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class LogReporteDian
    {
        public long LODI_SECUENCIA_NB { get; set; }
        public int LODI_OFICINA_NB { get; set; }
        public int LODI_TRANSACCION_NB { get; set; }
        public string LODI_LLAVE_V2 { get; set; }
        public DateTime LODI_FECREGISTRO_DT { get; set; }
        public string LODI_ESTADO_V2 { get; set; }
        public long LODI_CAMPO1_NB { get; set; }
        public string LODI_CAMPO2_V2 { get; set; }
        public DateTime LODI_CAMPO3_DT { get; set; }
        public string LODI_ESTADODIAN_V2 { get; set; }
        public int totalFacturasPendientes { get; set; }
        public string MyProperty { get; set; }
    }
}
