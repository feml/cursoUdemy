using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Ministerio
{
    public partial class LogicaNegocio : IDisposable
    {
        private readonly string usuario;
        private readonly string password;
        private readonly string usuEmail;
        private readonly string passEmail;
        private readonly string ambiente;
        public LogicaNegocio(string usuario, string password, string usuEmail, string passEmail, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.usuEmail = usuEmail;
            this.passEmail = passEmail;
            this.ambiente = ambiente;

        }

        public void prueba()
        {
            listarOficinas();
        }

        private bool disposed = false;
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
