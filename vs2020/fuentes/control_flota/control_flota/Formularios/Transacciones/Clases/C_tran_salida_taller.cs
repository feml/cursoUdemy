using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_salida_taller : Interfaces.I_tran_salida_taller
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_salida_taller(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();
        }

        public DataSet combobox_conductores()
        {
            //_ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTOR_PROPIOS_INGRESADO");
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTORES_PROPIOS");//05/02/2014 se modifiac para que cargue todos los conductores habilitados.
            return _ds;
        }
        public DataSet combobox_vehiculos(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.VEHICULOS_PROPIOS_INGRESADO", conductor);
            return _ds;
        }
        public DataSet combobox_trailers(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.TRAILERS_PROPIOS_INGRESADO", conductor);
            return _ds;
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_SALIDA_TALLER");
            return _ds;
        }
        public void registrar_transaccion(string conductor, string vehiculo, string trailers)
        {
            //_datos.registro("PK_CONTROL_FLOTA.REGISTRO_SALIDA_TALLER", conductor, vehiculo, trailers);
            //_datos.registroSalida("PK_CONTROL_INGRESO.PDB_CONTROL_SALIDA", conductor, vehiculo, trailers);
            _datos.registroSalida("PK_CONTROL_FLOTA.PDB_CONTROL_SALIDA", conductor, vehiculo, trailers);
            
        }
        public void registrar_transaccion(string conductor, string vehiculo, string trailers, string plogin)
        {
            //_datos.registro("PK_CONTROL_FLOTA.REGISTRO_SALIDA_TALLER", conductor, vehiculo, trailers);
            //_datos.registroSalida("PK_CONTROL_INGRESO.PDB_CONTROL_SALIDA", conductor, vehiculo, trailers);
            _datos.registroSalida("PK_CONTROL_FLOTA.PDB_CONTROL_SALIDA", conductor, vehiculo, trailers, plogin);

        }

    }
}
