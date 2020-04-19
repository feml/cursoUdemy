using AccesoDatos.Credenciales.Implementacion;
using AccesoDatos.Monitoreo;
using System;

namespace AccesoDatos.Credenciales
{
    public partial class Security: ISecurity, IDisposable
    {
        private bool disposed = false;
        public string _usuario { get; set; }
        public string _password { get; set; }
        public string _cadena { get; set; }
        public string _ip { get; set; }
        public string _sid { get; set; }
        public string _ambiente { get; set; }
        public EstadoProceso _eP { get; set; }
        public Security()
        {
            _eP = new EstadoProceso();
        }
        public Security(string usuario, string password, string ambiente)
        {
            _eP = new EstadoProceso();
            this._usuario = usuario;
            this._password = password;
            this._ambiente = ambiente;
            _cadena = inicialization();
        }

        public string GetCadena()
        {
            return _cadena;
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
