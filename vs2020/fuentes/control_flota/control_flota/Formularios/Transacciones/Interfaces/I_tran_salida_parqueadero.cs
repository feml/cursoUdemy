using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Interfaces
{
    interface I_tran_salida_parqueadero
    {
        DataSet combobox_conductores();
        DataSet combobox_vehiculos();
        DataSet combobox_trailers();
        DataSet generar_reporte();
        void registrar_transaccion(string conductor, string vehiculo, string trailers);
        void registrar_transaccion(string conductor, string vehiculo, string trailers, string plogin);
    }
}
