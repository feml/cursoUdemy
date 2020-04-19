using SecurityScheme;
using SecurityScheme.Entities_Security;
using SecurityScheme.Interfaces;
using SendingEmail.Interfaces;
using System;

namespace SendingEmail
{
    public partial class Correo : IDisposable,ICorreo
    {
        private bool disposed = false;
        private AccessInformationMail security { get; set; }

        public string _log { get; set; }
        public Correo()
        {
            ISecurity isecurity = new Security();
            security = new AccessInformationMail();
            security = isecurity.getAccessInformationMail();
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
