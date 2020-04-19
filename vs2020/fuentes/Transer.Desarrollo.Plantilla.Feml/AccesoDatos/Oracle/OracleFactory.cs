using AccesoDatos.Credenciales;
using AccesoDatos.Monitoreo;
using AccesoDatos.Oracle.Implementacion;
using AccesoDatos.Selects;
using AccesoDatos.Selects.Implementacion;
using System;
using System.Data;

namespace AccesoDatos.Oracle
{
    public partial class OracleFactory : EstadoProceso, IFactory
    {
        private Credentials _credentials;
        public EstadoProceso _eP { get; set; }
        public string[] _nParametros { get; set; }
        public object[] _vParametros { get; set; }
        public DataTable _dataTable { get; set; }
        public IBuildSelect _select { get; set; }
        public OracleFactory(Credentials credentials)
        {
            _eP = new EstadoProceso();
            _dataTable = new DataTable();
            _select = new BuildSelect();
            _credentials = credentials;
        }
        public OracleFactory(string usuarioBd, string passwordBd, string escenario, string usuarioMail, string passwordMail)
        {
            _eP = new EstadoProceso();
            _dataTable = new DataTable();
            _select = new BuildSelect();

            _credentials = new Credentials();
            _credentials.usuarioBd = usuarioBd;
            _credentials.passwordBd = passwordBd;
            _credentials.escenario = escenario;
            _credentials.usuarioMail = usuarioMail;
            _credentials.passwordMail = passwordMail;
        }
        public OracleFactory()
        {
            _eP = new EstadoProceso();
            _dataTable = new DataTable();
            _select = new BuildSelect();

            _credentials = new Credentials();
            _credentials.usuarioBd = "Zm1vbnRveWE=";
            _credentials.passwordBd = "ZjkzNWNqbTkyNjI=";
            _credentials.escenario = "cHJvZHVjY2lvbg==";
            _credentials.usuarioMail = "cm9ib3Rjb3JyZW8=";
            _credentials.passwordMail = "VHlzODYwNTA0ODgy";
        }

        public bool ValidarConexion()
        {
            throw new NotImplementedException();
        }
        public DataTable GetDataTable(string bloque, string instruccion)
        {
            _nParametros = new string[0] { };
            _vParametros = new object[0] { };
            _dataTable = GetTable(_nParametros, _vParametros, bloque, instruccion);
            return _dataTable;
        }

        public DataTable GetDataTable(string[] nParametros, object[] vParametros, string bloque, string instruccion)
        {
            _nParametros = nParametros;
            _vParametros = vParametros;
            _dataTable = GetTable(_nParametros, _vParametros, bloque, instruccion);
            return _dataTable;
        }
    }
}
