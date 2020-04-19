using AccesoDatos.Credenciales.Implementacion;
using System;

namespace AccesoDatos.Credenciales
{
    public class Credentials: ICredentials, IDisposable
    {
        private bool disposed = false;
        public string usuarioBd { get; set; }
        public string passwordBd { get; set; }
        public string usuarioMail { get; set; }
        public string passwordMail { get; set; }
        public string escenario { get; set; }
        public string cadena { get; set; }
        //private Security _Security { get; set; }
        private ISecurity _Security { get; set; }
        public Credentials()
        {
            //_Security = new Security(usuarioBd, usuarioBd, escenario);
            //cadena = _Security.GetCadena();            
        }

        public string GetCadena()
        {
            _Security = new Security(usuarioBd, passwordBd, escenario);
            cadena = _Security.GetCadena();
            return  cadena;
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
