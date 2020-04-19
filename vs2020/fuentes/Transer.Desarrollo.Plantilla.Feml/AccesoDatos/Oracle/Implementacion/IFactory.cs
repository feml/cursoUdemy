using System;
using System.Data;

namespace AccesoDatos.Oracle.Implementacion
{
    public interface IFactory
    {
        bool ValidarConexion();
        DataTable GetDataTable(string bloque, string instruccion);
        DataTable GetDataTable(string[] nParametros, object[] vParametros, string bloque, string instruccion);

    }
}
