using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_anular_registro : Interfaces.I_tran_anular_registro
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_anular_registro(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.F_GET_ANULAR_REGISTROS");
            return _ds;
        }
        public void anular_registro(int secuencia, string estado)
        {
            _datos.registro("PK_CONTROL_FLOTA.ANULAR_REGISTRO", secuencia, estado);
        }
        public void anular_registro(int secuencia, string estado, string plogin)
        {
            _datos.registro("PK_CONTROL_FLOTA.ANULAR_REGISTRO", secuencia, estado,plogin);
        }
    }
}
