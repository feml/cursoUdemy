using ReferenceLibrary.Interfaces;
using System;

namespace ReferenceLibrary
{
    public partial class BuildSelect : IDisposable, IBuildSelect
    {
        private bool disposed = false;


        public BuildSelect()
        {

        }

        /// <summary>
        /// public string GetCommand(string library,string instruccion, string[] _nParametros, object[] _vParametros)
        /// </summary>
        /// <param name="library"></param>
        /// <param name="instruccion"></param>
        /// <param name="_nParametros"></param>
        /// <param name="_vParametros"></param>
        /// <returns></returns>
        public string GetCommand(string library, string instruccion, string[] _nParametros, object[] _vParametros)
        {
            string select = string.Empty;
            switch (library)
            {
                case "Ministerio":
                    {
                        select = GetCommandMinisterio(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Deseguro":
                    {
                        select = GetCommandDeseguro(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Facturacion":
                    {
                        select = GetCommandFacturacion(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Bavaria":
                    {
                        select = GetCommandBavaria(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Varios":
                    {
                        select = GetCommandVarios(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "wfEnvioUnitario":
                    {
                        select = GetwfEnvioUnitario(instruccion, _nParametros, _vParametros);
                        break;
                    }
                default:
                    break;
            }
            return select;
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
