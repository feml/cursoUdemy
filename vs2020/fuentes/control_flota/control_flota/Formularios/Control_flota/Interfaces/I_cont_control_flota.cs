using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace control_flota.Formularios.Control_flota.Interfaces
{
    interface I_cont_control_flota
    {
        DataSet consulta_vehiculos_atendidos_taller(DateTimePicker fecini, DateTimePicker fecfin);
        DataSet consulta_vehiculos_oficinas();
        DataSet consulta_vehiculos_enturnados_taller();
        DataSet consulta_vehiculos_solicitados_taller();
        DataSet consulta_vehiculos_taller();
        DataSet consulta_vehiculos_despachados();
        DataSet consulta_vehiculos_parqueadero();
        DataSet consulta_vehiculos_siniestrados();
        DataSet consulta_reparaciones_externas();
        int[] consulta_flota();
        void generarArchivoPlanoNew(string select, DateTimePicker fecini, DateTimePicker fecfin);
        void generarArchivoPlanoonemes(string select, DateTimePicker fecini, DateTimePicker fecfin);
        void generarArchivoPlano(string select, DateTimePicker fecini, DateTimePicker fecfin);
    }
}
