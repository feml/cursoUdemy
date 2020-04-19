using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Solucionar_Inconsistencias.Interfaces
{
    interface I_inco_consultar_inconsistencias
    {
        //DataSet combobox_conductores();
        //DataSet combobox_vehiculos();
        //DataSet combobox_trailers();
        DataSet generar_reporte();
        void registrar_turno(string conductor, string vehiculo, string trailers);
    }
}
