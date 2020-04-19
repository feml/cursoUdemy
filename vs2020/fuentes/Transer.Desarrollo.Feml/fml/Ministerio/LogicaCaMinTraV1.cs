using EntityMinisterio;
using infrastructure;
using System;
using System.Collections.Generic;

namespace fml
{
    public partial class LogicaCaMinTraV1 : IDisposable
    {
        public List<LogReporteMinisterio> lLogReporteMinisterio { get; set; }
        public LogAplication log { get; set; }
        public int regPendientes { get; set; }
        public int regEnviados { get; set; }
        public int regExitosos { get; set; }
        public int regRechazados { get; set; }
        public int regDuplicados { get; set; }
        public int regTotal { get; set; }
        public string tituloAplicacion { get; set; }
        public string MensajeCicloVidapCabecera { get; set; }
        public string MensajeLineaColor { get; set; }
        public string MensajeCicloVidaCuerpo { get; set; }
        public string MensajeCicloVidaResumen { get; set; }
        public string ColorMensajeCicloVida { get; set; }
        private bool disposed = false;
        private readonly string usuario;
        private readonly string password;
        private readonly string usuEmail;
        private readonly string passEmail;
        private readonly string ambiente;
        public string LogAplication { get; set; }
        public LogicaCaMinTraV1(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.usuEmail = usuEmail;
            this.passEmail = passEmail;
            this.ambiente = ambiente;
            regDuplicados = regExitosos = regRechazados = regEnviados = regPendientes = regTotal = 0;
            //tituloAplicacion = "                                 MINISTERIO DE TRANSPORTE                   ";
            LogAplication = string.Empty;
            log = new LogAplication(@"C:\Transer\ws\logs\", "logMinTransporte.txt");
            log.consoleTitle("MINISTERIO");
            lLogReporteMinisterio = new List<LogReporteMinisterio>();
        }

        public void Dispose()
        {
            Dispose(true);
            // Suppress finalization.
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
