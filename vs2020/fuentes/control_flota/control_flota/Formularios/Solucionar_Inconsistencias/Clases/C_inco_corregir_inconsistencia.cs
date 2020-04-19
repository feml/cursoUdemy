using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace control_flota.Formularios.Solucionar_Inconsistencias.Clases
{
    class C_inco_corregir_inconsistencia : Interfaces.I_inco_corregir_inconsistencia
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_inco_corregir_inconsistencia(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();

        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_INCONSISTENCIA");
            return _ds;
        }
        public void actualizar_inconsistencia(int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida)
        {
            _datos.registro("PK_CONTROL_FLOTA.ATENDER_INCONSISTENCIA", secuencia, estado, fecenturne, fecsolicita, fecingresa, fecsalida);
           
        }
        public void actualizar_inconsistencia(int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida, string plogin)
        {
            _datos.registro("PK_CONTROL_FLOTA.ATENDER_INCONSISTENCIA", secuencia, estado, fecenturne, fecsolicita, fecingresa, fecsalida,plogin);

        }

    }
}
