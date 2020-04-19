/**************************************************************************
@author  FMONTOYA
@version 1.0
Development Environment        :  MS Visual Studio .NET
Name of the File               :  I_tran_solicitar_turno.cs
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

namespace control_flota.Formularios.Transacciones.Interfaces
{
    interface I_tran_solicitar_turno
    {
        DataSet combobox_conductores();//Revisado 10/02/2014
        DataSet combobox_vehiculos();//Revisado 10/02/2014
        DataSet combobox_trailers();//Revisado 10/02/2014
        DataSet generar_reporte();//Revisado 10/02/2014
        void registrar_turno(string conductor, string vehiculo, string trailers, string plogin);//Revisado 10/02/2014
    }
}
