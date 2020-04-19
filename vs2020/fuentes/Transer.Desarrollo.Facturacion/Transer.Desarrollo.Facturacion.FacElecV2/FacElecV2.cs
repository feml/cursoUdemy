using System;
using Transer.Desarrollo.Facturacion.LogicaNegocio;

namespace Transer.Desarrollo.Facturacion.FacElecV2
{
    class FacElecV2
    {
        static void Main(string[] args)
        {
            string nfactura = string.Empty;
            LogicaProceso lp = new LogicaProceso(DateTime.Now);
            try
            {
                nfactura = args[0].ToString();
                lp.Inicio(nfactura);
            }
            catch (Exception ex)
            {
                lp.Inicio("SETT4");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Finalizacion del proceso");
            Console.ReadKey();
        }
    }
}
