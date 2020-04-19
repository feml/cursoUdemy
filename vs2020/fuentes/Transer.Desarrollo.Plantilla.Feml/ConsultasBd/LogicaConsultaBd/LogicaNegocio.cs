using AccesoDatos.Oracle;
using AccesoDatos.Credenciales;
using AccesoDatos.Oracle.Implementacion;
using System;
using System.Data;

namespace ConsultasBd.LogicaConsultaBd
{
    public partial class LogicaNegocio
    {
        internal void Inicio()
        {
            Credentials credentials = new Credentials();
            credentials.usuarioBd = "Zm1vbnRveWE=";
            credentials.passwordBd = "ZjkzNWNqbTkyNjI=";
            credentials.escenario = "cHJvZHVjY2lvbg==";
            credentials.usuarioMail = "cm9ib3Rjb3JyZW8=";
            credentials.passwordMail = "VHlzODYwNTA0ODgy";
            credentials.GetCadena();
            IFactory factory = new OracleFactory(credentials);
            var consulta = factory.GetDataTable("Varios", "GetOficinas");
            string tmp = string.Empty;
            foreach (DataRow dr in consulta.Rows)
            {
                tmp += dr["ofic_nombre_v2"].ToString();
            }
            IFactory fac = new OracleFactory(credentials);
            string[] nParametros;
            object[] vParametros;
            nParametros = new string[1] { ":OFIC_CODOFIC" };
            vParametros = new object[1] { 16 };

            var misc = fac.GetDataTable(nParametros, vParametros, "Varios", "GetOficina");

            string uff = string.Empty;
            foreach (DataRow dr in misc.Rows)
            {
                uff = dr["ofic_nombre_v2"].ToString();
            }
        }
    }
}
