using System;
using System.IO;

namespace infrastructure
{
    public partial class LogAplication : IDisposable
    {
        public int posX { get; set; }
        public int posY { get; set; }

        private bool disposed = false;
        private string v;

        public string _ruta { get; set; }
        public string _archivo { get; set; }
        public string _mensaje { get; set; }
        public LogAplication(string ruta, string archivo)
        {
            _ruta = ruta;
            _archivo = archivo;
            posX = 0;//Fila maximo 80
            posY = 0;//Columnas maximo 24
        }

        public LogAplication(string v)
        {
            this.v = v;
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
