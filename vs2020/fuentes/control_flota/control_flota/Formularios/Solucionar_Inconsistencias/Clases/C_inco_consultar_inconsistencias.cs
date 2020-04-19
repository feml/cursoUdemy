using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Solucionar_Inconsistencias.Clases
{
    class C_inco_consultar_inconsistencias : Interfaces.I_inco_consultar_inconsistencias
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_inco_consultar_inconsistencias(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();

        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_INCONSISTENCIA","T","REGISTROS MARCADOS CON INCONSISTENCIAS EN EL TALLER");
            return _ds;
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers)
        {
            //_datos.registro("PK_CONTROL_FLOTA.REGISTRO_INCONSISTENCIA", conductor, vehiculo, trailers);
        }

    }
}
