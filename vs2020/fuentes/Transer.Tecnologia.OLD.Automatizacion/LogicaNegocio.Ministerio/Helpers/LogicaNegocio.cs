using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Ministerio
{
    public partial class LogicaNegocio
    {
        private void listarOficinas()
        {
            string[] _nParametros;
            object[] _vParametros;
            _nParametros = new string[1] { ":LRMI_ESTADO" };
            _vParametros = new object[1] { "P" };
            DataTable dt = new DataTable();
            using (Factory data = new Factory(usuario, password, ambiente))
            {
                dt = data.getTable("Ministerio", "getOficinas", _nParametros, _vParametros);
            }
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["OFIC_CODIGO_NB"].ToString() + " " + dr["OFIC_NOMBRE_V2"].ToString());
            }
            Console.ReadKey();
        }
    }
}
