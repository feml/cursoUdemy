using System;
namespace fml.Ministerio
{
    public partial class GenerarXml : IDisposable
    {
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
