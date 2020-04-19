using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Selects.Implementacion
{
    public interface IBuildSelect
    {
        string Select(string bloque, string instruccion);
    }
}
