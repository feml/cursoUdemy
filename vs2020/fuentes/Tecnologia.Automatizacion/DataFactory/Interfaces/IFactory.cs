using System.Data;
using System.Diagnostics;

namespace DataFactory.Interfaces
{
    public interface IFactory
    {
        DataTable GetTableReader(string library, string select);
        DataTable GetTableReader(string library, string select, string[] _nParametros, object[] _vParametros);
        DataTable GetTable(string library, string select);
        DataTable GetTable(string library, string select, string[] _nParametros, object[] _vParametros);
        int ExecuteCommand(string library, string select, string[] _nParametros, object[] _vParametros);
        DataTable GetException();
        DataTable GetExcepcionOracle();
        bool GetSuccessfulexecution();
        string GetComandoConsulta();
        Stopwatch GetTimeMeasure();
    }
}
