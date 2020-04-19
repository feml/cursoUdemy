using System;

namespace infrastructure
{
    public partial class CorreoElectronico : IDisposable
    {
        private bool disposed = false;
        public string MensajeError { get; set; }
        //private string UsuEmail;
        //private string PassEmail;
        /*public CorreoElectronico(string usuEmail, string passEmail)
        {
            UsuEmail = usuEmail;
            PassEmail = passEmail;
        }*/
        public bool SendMail(ConfiguracionEmail cfEmail)
        {
            bool CorreoExitoso = false;
            EnviarCorreo(cfEmail);
            return CorreoExitoso;
        }
        public bool SendMail(ConfiguracionEmail cfEmail, params MailAttachment[] attachments)
        {
            bool CorreoExitoso = false;
            EnviarCorreo(cfEmail, attachments);
            return CorreoExitoso;
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
