using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
namespace control_flota.Formularios.Transacciones.Interfaces
{
    interface I_tran_anular_registro
    {
        DataSet generar_reporte();
        void anular_registro(int secuencia, string estado);
        void anular_registro(int secuencia, string estado, string plogin);
    }
}
