using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_ingreso_parqueadero : Interfaces.I_tran_ingreso_parqueadero
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_ingreso_parqueadero(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();

        }
        public DataSet combobox_conductores()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTORES_PROPIOS");
            return _ds;
        }
        public DataSet combobox_vehiculos(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.VEHICULOS_PROPIOS");
            return _ds;
        }
        public DataSet combobox_trailers(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.TRAILERS_PROPIOS");
            return _ds;
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_INGRE_PARQUEADERO");
            return _ds;
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers, string parqueadero)
        {
            _datos.registro_parqueadero("PK_CONTROL_FLOTA.REGISTRO_INGRE_PARQUEADERO", conductor, vehiculo, trailers, parqueadero);
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers, string parqueadero, string plogin)
        {
            _datos.registro_parqueadero("PK_CONTROL_FLOTA.REGISTRO_INGRE_PARQUEADERO", conductor, vehiculo, trailers, parqueadero,plogin);
        }

    }
}
