using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace control_flota.Interfaces
{
    interface I_Datos
    {
        DataSet generico(string select, DateTimePicker fecini, DateTimePicker fecfin);
        DataSet generico(string select);
        DataSet generico(string select, string valor, string tipo);
        DataSet generico(string select, string conductor);
        void registroIngreso(string select, string conductor, string vehiculo, string trailers);
        void registroSalida(string select, string conductor, string vehiculo, string trailers);
        void registro(string select, string conductor, string vehiculo, string trailers);
        void registro_parqueadero(string select, string conductor, string vehiculo, string trailers, string parqueadero);
        void registro(string select, int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida);
        int[] registro(string select);
        void registro(string select, int secuencia, string estado);
        bool validarUsuario(string Cadena);
        void registro(string select, string conductor, string vehiculo, string trailers, string plogin);
        void registroIngreso(string select, string conductor, string vehiculo, string trailers, string plogin);
        void registroSalida(string select, string conductor, string vehiculo, string trailers, string plogin);
        void registro(string select, int secuencia, string estado, string plogin);
        void registro_parqueadero(string select, string conductor, string vehiculo, string trailers, string parqueadero, string plogin);
        void registro(string select, int secuencia, string estado, DateTimePicker fecenturne, DateTimePicker fecsolicita, DateTimePicker fecingresa, DateTimePicker fecsalida, string plogin);
        DataSet generico(string select, DateTimePicker fecini, DateTimePicker fecfin, string estado);
        DataSet generico(string select, Int32 inta_conjunto, string nombreparametro);
    }
}
