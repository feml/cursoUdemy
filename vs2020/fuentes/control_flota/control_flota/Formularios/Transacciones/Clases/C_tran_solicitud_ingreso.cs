/**************************************************************************
@author  FMONTOYA
@version 1.0
Development Environment        :  MS Visual Studio .NET
Name of the File               :  C_tran_solicitud_ingreso.cs
Creation/Modification History  :  23-Enero-2014     Created
                               :  23-Enero-2014     Modificado 
                               :  10-02-14     Modificado 
                               :  00-00-00     Modificado 
Overview:
 * 
 * 
 * 
**************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace control_flota.Formularios.Transacciones.Clases
{
    class C_tran_solicitud_ingreso : Formularios.Transacciones.Interfaces.I_tran_solicitud_ingreso
    {
        private control_flota.Interfaces.I_Datos _datos;
        private DataSet _ds;

        public C_tran_solicitud_ingreso(string usuario, string password, string cadena)
        { 
            _datos = new control_flota.Clases.C_Datos(usuario,password,cadena);
            _ds = new DataSet();
        }

        public DataSet combobox_conductores()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONDUCTORES_PROPIOS_ENTURNADOS");//Revisado 10/02/2014
            return _ds;
        }
        public DataSet combobox_vehiculos(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.VEHICULOS_PROPIOS_ENTURNADOS", conductor);//Revisado 10/02/2014
            return _ds;
        }
        public DataSet combobox_trailers(string conductor)
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.TRAILERS_PROPIOS_ENTURNADOS", conductor);//Revisado 10/02/2014
            return _ds;
        }
        public DataSet generar_reporte()
        {
            _ds = _datos.generico("PK_CONTROL_FLOTA.CONSULTA_SOLICITADOS_TALLER");//Revisado 10/02/2014
            return _ds;
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers)
        {
            _datos.registro("PK_CONTROL_FLOTA.SOLICITUD_INGRESO_TALLER", conductor, vehiculo, trailers);//Revisado 10/02/2014
        }
        public void registrar_turno(string conductor, string vehiculo, string trailers, string plogin)
        {
            _datos.registro("PK_CONTROL_FLOTA.SOLICITUD_INGRESO_TALLER", conductor, vehiculo, trailers, plogin);//Revisado 10/02/2014
        }

    }
}
