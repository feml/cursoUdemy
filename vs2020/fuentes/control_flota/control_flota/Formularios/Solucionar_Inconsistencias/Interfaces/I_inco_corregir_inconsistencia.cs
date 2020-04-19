using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace control_flota.Formularios.Solucionar_Inconsistencias.Interfaces
{
    interface I_inco_corregir_inconsistencia
    {
        //DataSet combobox_conductores();
        //DataSet combobox_vehiculos();
        //DataSet combobox_trailers();
        DataSet generar_reporte();
        void actualizar_inconsistencia(int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida);
        void actualizar_inconsistencia(int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida, string plogin);
    }
}
