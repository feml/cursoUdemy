using DataFactory.Interfaces;
using ReferenceLibrary;
using ReferenceLibrary.Interfaces;
using SecurityScheme;
using SecurityScheme.Interfaces;
using SendingEmail;
using SendingEmail.Interfaces;
using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace DataFactory
{
    public partial class Factory : IDisposable, IFactory
    {
        private bool disposed = false;
        private ISecurity security;// { get; set; }
        private IBuildSelect buildSelect;// { get; set; }
        private ICorreo correo;
        private string[] _nParametros;
        private object[] _vParametros;
        private DataTable DetalleExcepcionOracle;
        private DataTable DetalleExcepcion;
        private Stopwatch timeMeasure;
        private bool Successfulexecution;
        private string ComandoConsulta;
        public Factory()
        {
            security = new Security();
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }

        private void VariableInitialization()
        {
            DetalleExcepcionOracle = new DataTable();
            DetalleExcepcionOracle.Columns.Add("Number", typeof(int));
            DetalleExcepcionOracle.Columns.Add("Procedure", typeof(string));
            DetalleExcepcionOracle.Columns.Add("DataSource", typeof(string));
            DetalleExcepcionOracle.Columns.Add("Source", typeof(string));
            DetalleExcepcionOracle.Columns.Add("ErrorCode", typeof(int));
            DetalleExcepcionOracle.Columns.Add("Mensaje", typeof(string));
            DetalleExcepcionOracle.Columns.Add("select", typeof(string));

            DetalleExcepcion = new DataTable();
            DetalleExcepcion.Columns.Add("Message", typeof(string));
            DetalleExcepcion.Columns.Add("StackTrace", typeof(string));
            DetalleExcepcion.Columns.Add("Source", typeof(string));
            DetalleExcepcion.Columns.Add("select", typeof(string));

        }

        public Factory(string ambiente)
        {
            security = new Security(ambiente);
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }
        public Factory(string ambiente, string usuario, string password)
        {
            security = new Security(ambiente, usuario, password);
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }
        public Factory(string ambiente, string usuario, string password, string host)
        {
            security = new Security(ambiente, usuario, password, host);
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }
        public Factory(string ambiente, string usuarioBd, string passwordBd, string usuarioMail, string passwordMail)
        {
            security = new Security(ambiente, usuarioBd, passwordBd, usuarioMail, passwordMail);
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }
        public Factory(string ambiente, string usuarioBd, string passwordBd, string usuarioMail, string passwordMail, string host)
        {
            security = new Security(ambiente, usuarioBd, passwordBd, usuarioMail, passwordMail, host);
            buildSelect = new BuildSelect();
            correo = new Correo();
            timeMeasure = new Stopwatch();
            VariableInitialization();
        }

        public DataTable GetTableReader(string library, string select, string[] nParametros, object[] vParametros)
        {
            _nParametros = nParametros;
            _vParametros = vParametros;
            return getTable(library, select, _nParametros, _vParametros);
        }
        public DataTable GetTableReader(string library, string select)
        {
            //string[] _nParametros;
            //object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            return getTable(library, select, _nParametros, _vParametros);
        }
        public DataTable GetTable(string library, string select)
        {
            //string[] _nParametros;
            //object[] _vParametros;
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            return getTable(library, select, _nParametros, _vParametros);
        }
        public DataTable GetTable(string library, string select, string[] nParametros, object[] vParametros)
        {
            _nParametros = nParametros;
            _vParametros = vParametros;
            return getTable(library, select, _nParametros, _vParametros);
        }
        public int ExecuteCommand(string library, string select, string[] nParametros, object[] vParametros)
        {
            _nParametros = nParametros;
            _vParametros = vParametros;

            return executeCommand(library, select, _nParametros, _vParametros);
        }
        public DataTable GetException()
        {
            return DetalleExcepcion;
        }
        public DataTable GetExcepcionOracle()
        {
            return DetalleExcepcionOracle;
        }
        public bool GetSuccessfulexecution()
        {
            return Successfulexecution;
        }
        public string GetComandoConsulta()
        {
            return ComandoConsulta;
        }
        public Stopwatch GetTimeMeasure()
        {
            return timeMeasure;
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
