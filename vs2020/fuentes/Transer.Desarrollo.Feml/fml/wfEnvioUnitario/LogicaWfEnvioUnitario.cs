using EntityMinisterio;
using System;

namespace fml.wfEnvioUnitario
{
    public partial class LogicaWfEnvioUnitario : IDisposable
    {
        private bool disposed = false;
        private readonly string usuario;
        private readonly string password;
        private readonly string usuEmail;
        private readonly string passEmail;
        private readonly string ambiente;
        public string _xml_envio { get; set; }
        public string _funtion { get; set; }
        public string LogAplication { get; set; }

        public LogReporteMinisterio pLogReporteMinisterio { get; set; }
        public LogicaWfEnvioUnitario(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.usuEmail = usuEmail;
            this.passEmail = passEmail;
            this.ambiente = ambiente;



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
