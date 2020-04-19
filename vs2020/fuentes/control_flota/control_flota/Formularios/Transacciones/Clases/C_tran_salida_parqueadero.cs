using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_salida_parqueadero : Interfaces.I_tran_salida_parqueadero
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_salida_parqueadero(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();
        }

        public DataSet combobox_conductores()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTORES_PROPIOS");
            return _ds;
        }
        public DataSet combobox_vehiculos()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.VEHICULOS_INGRE_PARQUEADERO");
            return _ds;
        }
        public DataSet combobox_trailers()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.TRAILERS_INGRE_PARQUEADERO");
            return _ds;
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_INGRE_PARQUEADERO");
            return _ds;
        }
        public void registrar_transaccion(string conductor, string vehiculo, string trailers)
        {
            _datos.registro("PK_CONTROL_FLOTA.REGISTRO_SALIDA_PARQUEADERO", conductor, vehiculo, trailers);
        }
        public void registrar_transaccion(string conductor, string vehiculo, string trailers, string plogin)
        {
            _datos.registro("PK_CONTROL_FLOTA.REGISTRO_SALIDA_PARQUEADERO", conductor, vehiculo, trailers,plogin);
        }

    }
}
