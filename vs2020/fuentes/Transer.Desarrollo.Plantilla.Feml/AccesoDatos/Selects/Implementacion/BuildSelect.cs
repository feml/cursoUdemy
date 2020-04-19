using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Selects
{
    public partial class BuildSelect
    {
        #region Definicion del bloque varios

        private string VariosGetOficinas()
        {

            builder.Append(" declare ");
            builder.Append(" begin ");
            builder.Append(" open :refcur1 for ");

            builder.Append(" select OFIC_CODDPTO_NB, ");
            builder.Append(" OFIC_CODOFIC_NB, ");
            builder.Append(" OFIC_NOMBRE_V2, ");
            builder.Append(" OFIC_CIUDAD_NB, ");
            builder.Append(" OFIC_DIRECCION_V2, ");
            builder.Append(" OFIC_TELEFONO_1_NB, ");
            builder.Append(" OFIC_TELEFONO_2_NB, ");
            builder.Append(" OFIC_INDICATIVO_NB, ");
            builder.Append(" OFIC_CENCOST_NB, ");
            builder.Append(" OFIC_ADMIN_NB, ");
            builder.Append(" OFIC_EMAIL_V2, ");
            builder.Append(" OFIC_EMPRESA_NB, ");
            builder.Append(" OFIC_GERENCIA_NB ");
            builder.Append(" from oficinas ");
            builder.Append(" order by OFIC_CODOFIC_NB;  ");

            builder.Append("end;");
            return builder.ToString();
        }

        private string VariosGetOficina()
        {

            builder.Append(" declare ");
            builder.Append(" begin ");
            builder.Append(" open :refcur1 for ");

            builder.Append(" select OFIC_CODDPTO_NB, ");
            builder.Append(" OFIC_CODOFIC_NB, ");
            builder.Append(" OFIC_NOMBRE_V2, ");
            builder.Append(" OFIC_CIUDAD_NB, ");
            builder.Append(" OFIC_DIRECCION_V2, ");
            builder.Append(" OFIC_TELEFONO_1_NB, ");
            builder.Append(" OFIC_TELEFONO_2_NB, ");
            builder.Append(" OFIC_INDICATIVO_NB, ");
            builder.Append(" OFIC_CENCOST_NB, ");
            builder.Append(" OFIC_ADMIN_NB, ");
            builder.Append(" OFIC_EMAIL_V2, ");
            builder.Append(" OFIC_EMPRESA_NB, ");
            builder.Append(" OFIC_GERENCIA_NB ");
            builder.Append(" from oficinas ");
            builder.Append(" where OFIC_CODOFIC_NB=:OFIC_CODOFIC ");
            builder.Append(" order by OFIC_CODOFIC_NB;  ");

            builder.Append("end;");
            return builder.ToString();
        }

        #endregion fin de la Definicion del bloque varios

    }
}
