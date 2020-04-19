using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Interfaces
{
    interface I_tran_registrar_ingreso
    {
        DataSet combobox_conductores();
        DataSet combobox_vehiculos(string conductor);
        DataSet combobox_trailers(string conductor);
        DataSet generar_reporte();
        void registrar_turno(string conductor, string vehiculo, string trailers);
        void registrar_turno(string conductor, string vehiculo, string trailers, string plogin);
    }
}
