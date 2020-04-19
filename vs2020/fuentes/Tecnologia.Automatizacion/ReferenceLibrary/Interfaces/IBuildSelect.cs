using System;
namespace ReferenceLibrary.Interfaces
{
    public interface IBuildSelect
    {
        string GetCommand(string library, string instruccion, string[] _nParametros, object[] _vParametros);

    }
}
