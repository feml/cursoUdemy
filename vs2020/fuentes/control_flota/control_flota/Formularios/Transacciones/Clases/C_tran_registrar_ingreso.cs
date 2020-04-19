using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_registrar_ingreso : Interfaces.I_tran_registrar_ingreso
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_registrar_ingreso(string usuario, string password, string cadena)
        {
            _datos = new control_flota.Clases.C_Datos(usuario, password, cadena);
            _ds = new DataSet();

        }
        public DataSet combobox_conductores()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTOR_PROPIOS_SOLICITADOS");
            return _ds;
        }
        public DataSet combobox_vehiculos(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.VEHICULOS_PROPIOS_SOLICITADOS", conductor);
            return _ds;
        }
        public DataSet combobox_trailers(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.TRAILERS_PROPIOS_SOLICITADOS", conductor);
            return _ds;
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_INGRESADOS_TALLER");
            return _ds;
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers)
        {
            //_datos.registro("PK_CONTROL_FLOTA.REGISTRO_INGRESO_TALLER", conductor, vehiculo, trailers);
            //_datos.registroIngreso("PK_CONTROL_INGRESO.PDB_CONTROL_INGRESO", conductor, vehiculo, trailers);
            _datos.registroIngreso("PK_CONTROL_FLOTA.PDB_CONTROL_INGRESO", conductor, vehiculo, trailers);
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers, string plogin)
        {
            //_datos.registro("PK_CONTROL_FLOTA.REGISTRO_INGRESO_TALLER", conductor, vehiculo, trailers);
            //_datos.registroIngreso("PK_CONTROL_INGRESO.PDB_CONTROL_INGRESO", conductor, vehiculo, trailers);
            _datos.registroIngreso("PK_CONTROL_FLOTA.PDB_CONTROL_INGRESOMOD", conductor, vehiculo, trailers, plogin);
        }

    }
}
