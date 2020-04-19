//using AccesoDatos.Credenciales;
//using AccesoDatos.Credenciales.Implementacion;
//using AccesoDatos.Oracle;
//using AccesoDatos.Oracle.Implementacion;
using ConsultasBd.LogicaConsultaBd;
using System;

namespace ConsultasBd
{
    class Program
    {
        static void Main(string[] args)
        {
            LogicaNegocio lg = new LogicaNegocio();
            lg.Inicio();            
        }
    }
}
