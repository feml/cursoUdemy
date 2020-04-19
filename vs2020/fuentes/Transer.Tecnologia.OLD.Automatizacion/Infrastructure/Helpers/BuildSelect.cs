using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public partial class BuildSelect
    {
        /// <summary>
        /// public string GetCommand(string library,string instruccion, string[] _nParametros, object[] _vParametros)
        /// </summary>
        /// <param name="library"></param>
        /// <param name="instruccion"></param>
        /// <param name="_nParametros"></param>
        /// <param name="_vParametros"></param>
        /// <returns></returns>
        public string GetCommand(string library, string instruccion, string[] _nParametros, object[] _vParametros)
        {
            string select = string.Empty;
            switch (library)
            {
                case "Ministerio":
                    {
                        select = GetCommandMinisterio(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Deseguro":
                    {
                        select = GetCommandDeseguro(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Facturacion":
                    {
                        select = GetCommandFacturacion(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Bavaria":
                    {
                        select = GetCommandBavaria(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "Varios":
                    {
                        select = GetCommandVarios(instruccion, _nParametros, _vParametros);
                        break;
                    }
                case "wfEnvioUnitario":
                    {
                        select = GetwfEnvioUnitario(instruccion, _nParametros, _vParametros);
                        break;
                    }
                default:
                    break;
            }
            return select;
        }


        /// <summary>
        /// private string GetCommandBavaria(string instruccion,string[] nParametros, object[] vParametros)
        /// </summary>
        /// <param name="instruccion"></param>
        /// <param name="nParametros"></param>
        /// <param name="vParametros"></param>
        /// <returns></returns>
        private string GetCommandBavaria(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;
            return select;
        }
        /// <summary>
        /// private string GetCommandFacturacion(string instruccion, string[] nParametros, object[] vParametros)
        /// </summary>
        /// <param name="instruccion"></param>
        /// <param name="nParametros"></param>
        /// <param name="vParametros"></param>
        /// <returns></returns>
        private string GetCommandFacturacion(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;
            return select;
        }

        /// <summary>
        /// private string GetCommandDeseguro(string instruccion, string[] nParametros, object[] vParametros)
        /// </summary>
        /// <param name="instruccion"></param>
        /// <param name="nParametros"></param>
        /// <param name="vParametros"></param>
        /// <returns></returns>
        private string GetCommandDeseguro(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;

            return select;
        }
        private string GetwfEnvioUnitario(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;
            switch (instruccion)
            {
                case "getLogReporteMinisterioUnitario":
                    {
                        select = getLogReporteMinisterioUnitario();
                        break;
                    }
                default:
                    break;
            }
            return select;
        }
        private string getLogReporteMinisterioUnitario()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_LLAVE_V2 =:LRMI_LLAVE ");
            select.Append(" and LRMI_TRANSACCION_NB =:LRMI_TRANSACCION ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }

        #region Definicion del Bloque GetCommandMinisterio
        /// <summary>
        /// private string GetCommandMinisterio(string instruccion, string[] nParametros, object[] vParametros)
        /// </summary>
        /// <param name="instruccion"></param>
        /// <param name="nParametros"></param>
        /// <param name="vParametros"></param>
        /// <returns>string select</returns>
        private string GetCommandMinisterio(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;
            switch (instruccion)
            {
                case "getLogReporteMinisterio":
                    {
                        select = getLogReporteMinisterio();
                        break;
                    }
                case "getLogReporteMinisterioEnvioUnitario":
                    {
                        select = getLogReporteMinisterioEnvioUnitario();
                        break;
                    }
                case "getLogReporteMinisterioEstadoTransaccion":
                    {
                        select = getLogReporteMinisterioEstadoTransaccion();
                        break;
                    }
                case "InsertDetLogMinisterio":
                    {
                        select = InsertDetLogMinisterio();
                        break;
                    }
                case "getDetLogMinisterio":
                    {
                        select = getDetLogMinisterio();
                        break;
                    }
                case "PK_MINISTERIO_XML_REMESA":
                    {
                        select = PK_MINISTERIO_XML_REMESA();
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA":
                    {
                        select = PK_MINISTERIO_XML_MANIFIESTO_CARGA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA":
                    {
                        select = PK_MINISTERIO_XML_CUMPLIDO_REMESA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO":
                    {
                        select = PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO();
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT":
                    {
                        select = PK_MINISTERIO_XML_PROPIETARIOS_NIT();
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA":
                    {
                        select = PK_MINISTERIO_XML_PROPIETARIOS_CEDULA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES":
                    {
                        select = PK_MINISTERIO_XML_CONDUCTORES();
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT":
                    {
                        select = PK_MINISTERIO_XML_CLIENTES_NIT();
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA":
                    {
                        select = PK_MINISTERIO_XML_CLIENTES_CEDULA();
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS":
                    {
                        select = PK_MINISTERIO_XML_VEHICULOS();
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS":
                    {
                        select = PK_MINISTERIO_XML_TRAILERS();
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO":
                    {
                        select = PK_MINISTERIO_XML_ANULAR_MANIFIESTO();
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_REMESA":
                    {
                        select = PK_MINISTERIO_XML_ANULAR_REMESA();
                        break;
                    }
                case "UpdateLogReporteMinisterio":
                    {
                        select = UpdateLogReporteMinisterio();
                        break;
                    }
                case "UpdateLogReporteMinisterioCampo1":
                    {
                        select = UpdateLogReporteMinisterioCampo1();
                        break;
                    }
                default:
                    break;
            }
            return select;
        }
        /// <summary>
        /// private string getLogReporteMinisterio()
        /// </summary>
        /// <returns>string</returns>
        private string getLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_ESTADO_V2 =:LRMI_ESTADO  ");
            //select.Append(" and TRUNC(LRMI_FECREGISTRO_DT) between TRUNC(sysdate-20) and trunc(sysdate) ");
            //select.Append(" and LRMI_TRANSACCION_NB not in (5,6)  ");
            select.Append(" and LRMI_TRANSACCION_NB  in (5,6)  ");
            //select.Append(" and LRMI_OFICINA_NB = 16 ");
            //select.Append(" and LRMI_TRANSACCION_NB = 4  ");
            //select.Append(" and LRMI_TRANSACCION_NB in (3,4,5,6,9,32,31)  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }
        /// <summary>
        /// private string getLogReporteMinisterioEnvioUnitario()
        /// </summary>
        /// <returns>string</returns>
        private string getLogReporteMinisterioEnvioUnitario()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_LLAVE_V2 =:LRMI_LLAVE  ");
            select.Append(" AND LRMI_TRANSACCION_NB =:LRMI_TRANSACCION  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }
        /// <summary>
        /// private string getDetLogMinisterio()
        /// </summary>
        /// <returns></returns>
        private string getDetLogMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" DELM_LOGSECUENCIA_NB, ");
            select.Append(" DELM_OFICINA_NB, ");
            select.Append(" DELM_TRANSACCION_NB, ");
            select.Append(" DELM_LLAVE_V2, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_XMLENVIADO_XML, ");
            select.Append(" DELM_FECENVIO_DT, ");
            select.Append(" DELM_XMLRECIBIDO_XML, ");
            select.Append(" DELM_CAMPO1_NB, ");
            select.Append(" DELM_CAMPO2_V2, ");
            select.Append(" DELM_CAMPO3_DT ");
            select.Append(" from det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB =:LRMI_SECUENCIA_NB ");
            select.Append(" and DELM_OFICINA_NB =:LRMI_OFICINA_NB ");
            select.Append(" order by DELM_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        /// <summary>
        /// private string getLogReporteMinisterioEstadoTransaccion()
        /// </summary>
        /// <returns></returns>
        private string getLogReporteMinisterioEstadoTransaccion()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_ESTADO_V2 =:LRMI_ESTADO  ");
            select.Append(" and LRMI_TRANSACCION_NB =:LRMI_TRANSACCION  ");
            select.Append(" and trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-720) and trunc(sysdate)  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }
        /// <summary>
        /// private string InsertDetLogMinisterio()
        /// </summary>
        /// <returns></returns>
        private string InsertDetLogMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" insert into det_log_ministerio (DELM_SECUENCIA_NB, ");
            select.Append(" DELM_LOGSECUENCIA_NB, ");
            select.Append(" DELM_OFICINA_NB, ");
            select.Append(" DELM_TRANSACCION_NB, ");
            select.Append(" DELM_LLAVE_V2, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_XMLENVIADO_XML, ");
            select.Append(" DELM_FECENVIO_DT, ");
            select.Append(" DELM_XMLRECIBIDO_XML, ");
            select.Append(" DELM_CAMPO1_NB, ");
            select.Append(" DELM_CAMPO2_V2, ");
            select.Append(" DELM_CAMPO3_DT) ");
            select.Append(" values(:secuencia, ");
            select.Append(" :LRMI_SECUENCIA_NB, ");
            select.Append(" :LRMI_OFICINA_NB, ");
            select.Append(" :LRMI_TRANSACCION_NB, ");
            select.Append(" :LRMI_LLAVE_V2, ");
            select.Append(" :LRMI_ESTADO_V2, ");
            select.Append(" :DELM_IDMINISTERIO_NB, ");
            select.Append(" :DELM_XMLENVIADO_XML, ");
            select.Append(" sysdate, ");
            select.Append(" :DELM_XMLRECIBIDO_XML, ");
            select.Append(" null, ");
            select.Append(" null, ");
            select.Append(" null); ");
            select.Append(" end;  ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_REMESA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' numNitEmpresaTransporte,  ");
            select.Append(" ORCA_NUMERO_NB consecutivoRemesa,  ");
            select.Append(" '' consecutivoInformacionCarga,  ");
            select.Append(" 'G' codOperacionTransporte,  ");
            select.Append(" '1' codNaturalezaCarga,  ");
            select.Append(" ORCA_PESOKGS_NB cantidadCargada,  ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB,'K',1,'V',1,ORCA_VOLUMEN_NB) unidadMedidaCapacidad,  ");
            select.Append(" DECODE(ORCA_TIPOEMPAQUE_NB,3,6,2,4,11,12,14,15,12,17,10,19,1,19,0) codTipoEmpaque,  ");
            select.Append(" '' pesoContenedorVacio,  ");
            select.Append(" PROD_MIN_V2 mercanciaRemesa,  ");
            select.Append(" SUBSTR(PROD_NOMBRE_V2 ,1,60) descripcionCortaProducto,  ");
            select.Append(" decode(CLIENTES_A.CLIE_TIPOIDENT,null,'N',CLIENTES_A.CLIE_TIPOIDENT) codTipoIdRemitente,  ");
            select.Append(" CLIENTES_A.CLIE_NIT_NB||decode(length(CLIENTES_A.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_A.CLIE_NIT_NB,1),null) numIdRemitente,  ");
            select.Append(" PLANTAS.PLAN_CODIGO_NB codSedeRemitente,  ");
            select.Append(" decode(CLIENTES_B.CLIE_TIPOIDENT,null,'N',CLIENTES_B.CLIE_TIPOIDENT) codTipoIdDestinatario,  ");
            select.Append(" CLIENTES_B.CLIE_NIT_NB||decode(length(CLIENTES_B.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_B.CLIE_NIT_NB,1),null) numIdDestinatario,  ");
            select.Append(" PLANTAS_A1.PLAN_CODIGO_NB codSedeDestinatario,  ");
            select.Append(" 'E' duenoPoliza,  ");
            select.Append(" 1000007 numPolizaTransporte,  ");
            select.Append(" 8600024002 companiaSeguro,  ");
            select.Append(" '31/03/2014' fechaVencimientoPolizaCarga,  ");
            select.Append("  11 HORASPACTOCARGA,  ");
            select.Append("  59 MINUTOSPACTOCARGA,  ");
            select.Append("  11 horasPactoDescargue,  ");
            select.Append("  59 minutosPactoDescargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (1/24),'dd/mm/yyyy') fechaLlegadaCargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (1/24), 'HH24:MI') horaLlegadaCargueRemesa,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (2/24),'dd/mm/yyyy') fechaEntradaCargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (2/24), 'HH24:MI') horaEntradaCargueRemesa,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (4/24),'dd/mm/yyyy') fechaSalidaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (4/24), 'HH24:MI') horaSalidaCargueRemesa,  ");
            select.Append(" decode(clientes_a.CLIE_TIPOIDENT,null,'N',clientes_a.CLIE_TIPOIDENT) codTipoIdPropietario,  ");
            select.Append(" CLIENTES_A.CLIE_NIT_NB||decode(length(CLIENTES_A.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_A.CLIE_NIT_NB,1),null) numIdPropietario,  ");
            select.Append(" PLANTAS.PLAN_CODIGO_NB codSedePropietario,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (1/24),'dd/mm/yyyy') fechaCitaPactadaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (1/24), 'HH24:MI') horaCitaPactadaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT +1,'dd/mm/yyyy') fechaCitaPactadaDescargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (2/24), 'HH24:MI') horaCitaPactadaDescargueRemesa  ");
            select.Append(" FROM ORDENES_CARGUE,CLIENTES CLIENTES,NEGOCIOS_PRODUCTOS, PRODUCTOS,CLIENTES_PLANTAS,PLANTAS,  ");
            select.Append(" PLANTAS PLANTAS_A1, CLIENTES_PLANTAS CLIENTES_PLANTAS_A1,CLIENTES CLIENTES_A,  ");
            select.Append(" CLIENTES CLIENTES_B/*,CLIENTES CLIENTES_A1*/  ");
            select.Append(" WHERE ORCA_CLIENTEPAGA_NB=CLIENTES.CLIE_CODIGO_NB  ");
            select.Append(" AND ORCA_NITREM_NB=CLIENTES_A.CLIE_CODIGO_NB  ");
            select.Append(" AND ORCA_CLIENTEREC_NB=CLIENTES_B.CLIE_CODIGO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NEGOCIO_NB=NEGOCIOS_PRODUCTOS.NEPR_NRONEGOCIO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PRODUCTO_NB=NEGOCIOS_PRODUCTOS.NEPR_PRODUCTO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PRODUCTO_NB=PRODUCTOS.PROD_CODIGO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTAREMITE_NB=CLIENTES_PLANTAS.CIPA_PLANTA_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTAREMITE_NB=PLANTAS.PLAN_CODIGO_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTARECIBE_NB=CLIENTES_PLANTAS_A1.CIPA_PLANTA_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTARECIBE_NB=PLANTAS_A1.PLAN_CODIGO_NB(+)  ");
            select.Append(" and ORCA_NUMERO_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_MANIFIESTO_CARGA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_MANIFIESTO_CARGA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' numNitEmpresaTransporte, ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga, ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB consecutivoRemesa, ");
            select.Append(" 'G' codOperacionTransporte, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT,'dd/mm/yyyy') fechaExpedicionManifiesto, ");
            select.Append(" CIUDADES.CIUD_DIVIPOLA_CH codMunicipioOrigenManifiesto, ");
            select.Append(" CIUDADES_A1.CIUD_DIVIPOLA_CH codMunicipioDestinoManifiesto, ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codIdTitularManifiesto, ");
            select.Append(" PROPIETARIOS.PROP_CEDULA_NB||decode(length(PROP_CEDULA_NB),10,null,9,f_chequeonit(PROP_CEDULA_NB,1),null) numIdTitularManifiesto, ");
            select.Append(" VIAJ_PLACA_CH numPlaca, ");
            select.Append(" ORDENES_CARGUE.ORCA_TRAILER_CH numPlacaRemolque, ");
            select.Append(" CONDUCTORES.COND_TIPOIDEN_V2 codIdConductor, ");
            select.Append(" CONDUCTORES.COND_CEDULA_NB numIdconductor, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,fdb_flete_cond(viajes.viaj_noplanilla_v2)) valorFletePactadoViaje, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,1) retencionFuenteManifiesto, ");
            select.Append(" decode(fdb_flete_cond(viajes.viaj_noplanilla_v2),0,0,decode(Viaj_ClaseVehi_Nb,0,0,round(nvl(FDB_CALRTEICA(viaj_ofdespacha_nb,viaj_noplanilla_v2),0)*1000/fdb_flete_cond(viajes.viaj_noplanilla_v2),3))) retencionIcaManifiestoCarga, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,FDB_ANTICIPOS_VIAJE(VIAJ_NOPLANILLA_V2)) ValorAnticipoManifiesto, ");
            select.Append(" CIUDADES.CIUD_DIVIPOLA_CH codMunicipioPagoSaldo, ");
            select.Append(" 'R' codResponsablePagoCargue,'D' codResponsablePagoDescargue,substr(VIAJ_OBSERVACIONES_V2,1,200)  observaciones, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT+10,'dd/mm/yyyy')  fechaPagoSaldoManifiesto, ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB  consecutivoRemesa ");
            select.Append(" FROM ORDENES_CARGUE, VIAJES, CIUDADES, ");
            select.Append(" CIUDADES CIUDADES_A1, RUTAS, PROPIETARIOS, ");
            select.Append(" CONDUCTORES, VIAJES_ANTICIPOS ");
            select.Append(" where ((ORDENES_CARGUE.ORCA_NUMERO_NB=VIAJES.VIAJ_ORDCARGUE_NB) ");
            select.Append(" AND (ORDENES_CARGUE.ORCA_RUTA_NB=RUTAS.RUTA_CODIGO_NB) ");
            select.Append(" AND (RUTAS.RUTA_ORIGEN_NB=CIUDADES.CIUD_CODIGO_NB) ");
            select.Append(" AND (RUTAS.RUTA_DESTINO_NB=CIUDADES_A1.CIUD_CODIGO_NB) ");
            select.Append(" AND (VIAJES.VIAJ_POSEEDOR_NB=PROPIETARIOS.PROP_CEDULA_NB) ");
            select.Append(" AND (VIAJES.VIAJ_CONDUCTOR_NB=CONDUCTORES.COND_CEDULA_NB) ");
            select.Append(" AND (VIAJES.VIAJ_NOPLANILLA_V2=VIAJES_ANTICIPOS.VIAN_PLANILLA_V2(+))) ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" LIQU_PLANILLA_V2 numManifiestoCarga, ");
            select.Append(" 'C' tipoCumplidoManifiesto, ");
            select.Append(" '' motivoSuspensionManifiesto, ");
            select.Append(" to_char(LIQU_FECHA_DT,'DD/MM/YYYY') fechaEntregaDocumentos, ");
            select.Append(" '' consecuenciaSuspension, ");
            select.Append(" 0 valorAdicionalHorasCargue, ");
            select.Append(" 0 valorAdicionalHorasDescargue, ");
            select.Append(" 0 valorAdicionalFlete, ");
            select.Append(" '' motivoValorAdicional, ");
            select.Append(" 0 valorDescuentoFlete, ");
            select.Append(" 0 motivoValorDescuentoManifiesto, ");
            select.Append(" 0 valorSobreanticipo, ");
            select.Append(" substr(LIQU_OBSERVACIONES_V2,1,200) observaciones ");
            select.Append(" FROM liquidaciones ");
            select.Append(" where LIQU_PLANILLA_V2=:llave ");
            select.Append(" and LIQU_ESTADO_V2='A'; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_CUMPLIDO_REMESA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_CUMPLIDO_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");
            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB consecutivoRemesa,   ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB /*+ (0.18/24)*/, 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB /*+ (0.18/24*/, 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB /*+ (0.18/24)*/, 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB /*+ (0.60/24)*/, 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM TIEMPOS_QM, TIEMPOS_QM TIEMPOS_QM_A1,   ");
            select.Append(" TIEMPOS_QM TIEMPOS_QM_A2, TIEMPOS_QM TIEMPOS_QM_A3,   ");
            select.Append(" ORDENES_CARGUE, VIAJES, CUMPLIDOS   ");
            select.Append(" WHERE TIEMPOS_QM.MESQ_ORDENCARGUE_NB =:llave   ");
            select.Append(" AND TIEMPOS_QM.MESQ_NUMACRO_NB = 2   ");
            select.Append(" AND TIEMPOS_QM_A1.MESQ_NUMACRO_NB = 6   ");
            select.Append(" AND TIEMPOS_QM_A2.MESQ_NUMACRO_NB = 15   ");
            select.Append(" AND TIEMPOS_QM_A3.MESQ_NUMACRO_NB = 19   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A1.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A3.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A2.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND VIAJES.VIAJ_ORDCARGUE_NB = ORDENES_CARGUE.ORCA_NUMERO_NB   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");

            select.Append(" AND ROWNUM < 2   ");
            select.Append(" group by ORCA_NUMERO_NB, VIAJ_NOPLANILLA_V2, ORCA_VOLUMEN_NB, TIEMPOS_QM.MESQ_POSTIME_NB,   ");
            select.Append(" TIEMPOS_QM_A2.MESQ_NUMACRO_NB, TIEMPOS_QM_A1.MESQ_POSTIME_NB, CUMP_OBSERVACIONES_V2,   ");
            select.Append(" TIEMPOS_QM_A3.MESQ_POSTIME_NB, TIEMPOS_QM_A2.MESQ_POSTIME_NB   ");
            select.Append(" union   ");
            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" VIAJES.VIAJ_ORDCARGUE_NB consecutivoRemesa,   ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT, 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT , 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT, 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT , 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT, 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT , 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT, 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT , 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM CUMPLIDOS_TIEMPOS, CUMPLIDOS_TIEMPOS CUMPLIDOS_TIEMPOS_A1, VIAJES, CUMPLIDOS,   ");
            select.Append(" ORDENES_CARGUE   ");
            select.Append(" WHERE CUMPLIDOS_TIEMPOS.CUTI_TIPOCARDES_V2 = 'C'   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS_A1.CUTI_TIPOCARDES_V2 = 'D'   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_SECCUMP_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_SECCUMP_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGOCIO_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NEGOCIO_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2 = CUMPLIDOS_TIEMPOS_A1.CUTI_PLANILLA_V2   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGRUTSEC_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NEGRUTSEC_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERUCAMINO_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NERUCAMINO_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERURUTA_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NERURUTA_NB   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2   ");
            select.Append(" AND VIAJ_ORDCARGUE_NB = ORCA_NUMERO_NB   ");
            select.Append(" and ORCA_NUMERO_NB =:llave   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");


            select.Append(" GROUP BY VIAJES.VIAJ_ORDCARGUE_NB, VIAJES.VIAJ_NOPLANILLA_V2, CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT,   ");
            select.Append(" CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT, CUMPLIDOS.CUMP_MEDIDAFALTA_V2, ORCA_VOLUMEN_NB,   ");
            select.Append(" CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT, CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT, CUMPLIDOS.CUMP_OBSERVACIONES_V2   ");
            select.Append(" union   ");
            select.Append(" select DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" R.VITI_ORDCARGUE_NB consecutivoRemesa,   ");
            select.Append(" VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(R.ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, R.ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT), 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT), 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT), 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM viajes_tiempos R, viajes_tiempos D, ORDENES_CARGUE R, ORDENES_CARGUE D, VIAJES,   ");
            select.Append(" cumplidos   ");
            select.Append(" WHERE R.VITI_ORDCARGUE_NB = R.ORCA_NUMERO_NB   ");
            select.Append(" AND R.VITI_PLANTA_NB = R.ORCA_PLANTAREMITE_NB   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB = D.ORCA_NUMERO_NB   ");
            select.Append(" AND D.VITI_PLANTA_NB = D.ORCA_PLANTARECIBE_NB   ");
            select.Append(" AND R.VITI_ORDCARGUE_NB = D.VITI_ORDCARGUE_NB   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB =:llave   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB = VIAJ_ORDCARGUE_NB   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");

            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2; ");
            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_PROPIETARIOS_NIT()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_PROPIETARIOS_NIT()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT '8605048823' numNitEmpresaTransporte,PROP_TIPOIDEN_V2 codTipoIdTercero,PROP_CEDULA_NB||decode(length(PROP_CEDULA_NB),10,null,9,f_chequeonit(PROP_CEDULA_NB,1),null) numIdTercero, ");
            select.Append(" PROP_NOMBRE_V2 nomIdTercero,'.' primerApellidoIdTercero,',' segundoApellidoIdTercero,PROP_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(PROP_DIRECCION_V2,1,60) nomenclaturaDireccion,substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc,'1' codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero ");
            select.Append(" from propietarios,ciudades ");
            select.Append(" where PROP_TIPOIDEN_V2='N' ");
            select.Append(" and PROP_CIUDRES_NB=CIUD_CODIGO_NB ");
            select.Append(" and PROP_CEDULA_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_PROPIETARIOS_CEDULA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_PROPIETARIOS_CEDULA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT '8605048823' numNitEmpresaTransporte, ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdTercero, ");
            select.Append(" to_char(PROP_CEDULA_NB) numIdTercero, ");
            select.Append(" PROP_NOMBRE_V2 nomIdTercero, ");
            select.Append(" FDB_PRIMERAPELLIDOPRO(PROP_CEDULA_NB) primerApellidoIdTercero, ");
            select.Append(" FDB_SEGUNDOAPELLIDOPRO(PROP_CEDULA_NB) segundoApellidoIdTercero ");
            select.Append(" /*rpad(decode(substr(substr(PROP_APELLIDO_V2,1,instr(PROP_APELLIDO_V2,' ',1)),1,12), ");
            select.Append(" null,PROP_APELLIDO_V2,substr(substr(PROP_APELLIDO_V2,1,instr(PROP_APELLIDO_V2,' ',1)),1,12)),12) ");
            select.Append(" primerApellidoIdTercero, ");
            select.Append(" rpad(decode(instr(PROP_APELLIDO_V2,' ',1),0,rpad(chr(32),12),substr(PROP_APELLIDO_V2, ");
            select.Append(" instr(PROP_APELLIDO_V2,' ',1)+1,12)),12) segundoApellidoIdTercero*/, ");
            select.Append(" PROP_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(PROP_DIRECCION_V2,1,60) nomenclaturaDireccion,substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc, ");
            select.Append(" '1' codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero ");
            select.Append(" from propietarios,ciudades ");
            select.Append(" where PROP_TIPOIDEN_V2<>'N' ");
            select.Append(" and PROP_CIUDRES_NB=CIUD_CODIGO_NB ");
            select.Append(" and PROP_CEDULA_NB=:llave ");
            select.Append(" order by PROP_CEDULA_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_CONDUCTORES()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_CONDUCTORES()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' NUMNITEMPRESATRANSPORTE, ");
            select.Append(" COND_TIPOIDEN_V2 codTipoIdTercero, ");
            select.Append(" COND_CEDULA_NB numIdTercero, ");
            select.Append(" COND_NOMBRE_V2 nomIdTercero, ");
            //select.Append(" /*rpad(decode(substr(substr(COND_APELLIDO_V2,1,instr(COND_APELLIDO_V2,' ',1)),1,12), ");
            //select.Append(" null,COND_APELLIDO_V2,substr(substr(COND_APELLIDO_V2,1,instr(COND_APELLIDO_V2,' ',1)),1,12)),12)*/ ");
            select.Append(" FDB_PRIMERAPELLIDO(COND_CEDULA_NB) primerApellidoIdTercero, ");
            //select.Append(" /*rpad(decode(instr(COND_APELLIDO_V2,' ',1),0,rpad(chr(32),12),substr(COND_APELLIDO_V2,instr(COND_APELLIDO_V2,' ',1)+1,12)),12)*/ ");
            select.Append(" FDB_SEGUNDOAPELLIDO(COND_CEDULA_NB) segundoApellidoIdTercero, ");
            select.Append(" COND_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(COND_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc, ");
            select.Append(" 0 codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero, ");
            select.Append(" COND_NOLICEN_NB numLicenciaConduccion, ");
            select.Append(" COND_CATEGORIA_V2 codCategoriaLicenciaConduccion, ");
            //select.Append(" ---DECODE(COND_CATEG_,7,'C1',8,'C2',9,'C3',2,4,3,4,COND_CATEG_) codCategoriaLicenciaConduccion, ");
            select.Append(" to_char(COND_FECVENTO_DT,'DD/MM/YYYY') fechaVencimientoLicencia ");
            select.Append(" from conductores,ciudades ");
            select.Append(" where COND_CIUDAD_NB=CIUD_CODIGO_NB ");
            //select.Append(" --- and COND_ESTADO_V2='A' ");
            select.Append(" and COND_CEDULA_NB = :LLAVE ");
            select.Append(" order by COND_CEDULA_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_CLIENTES_NIT()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_CLIENTES_NIT()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" CLIE_TIPOIDENT codTipoIdTercero, ");
            select.Append(" CLIE_NIT_NB||decode(length(CLIE_NIT_NB),10,null,9,f_chequeonit(CLIE_NIT_NB,1),null) numIdTercero, ");
            select.Append(" CLIE_NOMBRE_V2 nomIdTercero, ");
            select.Append(" CLIE_TELEFONO_1_NB numTelefonoContacto, ");
            select.Append(" substr(CLIE_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" CIUD_DIVIPOLA_CH codMunicipioRndc, ");
            select.Append(" CIPA_PLANTA_NB codSedeTercero, ");
            select.Append(" PLAN_NOMBRE_V2 nomSedeTercero, ");
            select.Append(" substr(PLAN_CAMPO2_V2,1,instr(PLAN_CAMPO2_V2,':',1)-1) latitud, ");
            select.Append(" SUBSTR(PLAN_CAMPO2_V2,(INSTR(PLAN_CAMPO2_V2,':',1)+1),15) longitud ");
            select.Append(" FROM CLIENTES,PLANTAS,CIUDADES,CLIENTES_PLANTAS ");
            select.Append(" WHERE CIPA_CLIENTE_NB=CLIE_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=CIPA_PLANTA_NB ");
            select.Append(" AND PLAN_CIUDAD_NB=CIUD_CODIGO_NB ");
            select.Append(" and CLIE_TIPOIDENt='N' ");
            select.Append(" and CIPA_ESTADO_V2='A' ");
            select.Append(" AND PLAN_CAMPO2_V2 IS NOT NULL ");
            select.Append(" AND PLAN_CODIGO_NB=:llave ");
            select.Append(" order by CLIE_NIT_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_CLIENTES_CEDULA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_CLIENTES_CEDULA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" CLIE_TIPOIDENt codTipoIdTercero, ");
            select.Append(" CLIE_NIT_NB numIdTercero, ");
            select.Append(" CLIE_NOMBRE_V2 nomIdTercero, ");
            select.Append(" CLIE_APELLIDO1  primerApellidoIdTercero, ");
            select.Append(" CLIE_APELLIDO2 segundoApellidoIdTercero, ");
            select.Append(" CLIE_TELEFONO_1_NB numTelefonoContacto, ");
            //select.Append(" --PLAN_DIRECCION_V2 TERDIRECCION, ");
            select.Append(" substr(CLIE_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" CIUD_DIVIPOLA_CH codMunicipioRndc, ");
            select.Append(" CIPA_PLANTA_NB codSedeTercero, ");
            select.Append(" PLAN_NOMBRE_V2 nomSedeTercero, ");
            select.Append(" substr(PLAN_CAMPO2_V2,1,instr(PLAN_CAMPO2_V2,':',1)-1) latitud, ");
            select.Append(" SUBSTR(PLAN_CAMPO2_V2,(INSTR(PLAN_CAMPO2_V2,':',1)+1),15) longitud ");
            select.Append(" FROM CLIENTES,PLANTAS,CIUDADES,CLIENTES_PLANTAS ");
            select.Append(" WHERE CIPA_CLIENTE_NB=CLIE_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=CIPA_PLANTA_NB ");
            select.Append(" AND PLAN_CIUDAD_NB=CIUD_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=:llave ");
            select.Append(" and CLIE_TIPOIDENT<>'N' ");
            select.Append(" order by CLIE_NIT_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_VEHICULOS()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_VEHICULOS()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT distinct VEHICULOS.VEHI_PLACA_CH numPlaca, ");
            select.Append(" DECODE(VEHI_CONFIGURACION_V2,'1','50','2','50','3','51','4','52','5','56','2S','53','3S','54','4S','55',NULL) codConfiguracionUnidadCarga, ");
            select.Append(" MARC_MIN_V2 codMarcaVehiculoCarga, ");
            select.Append(" LIVE_LINMIN_V2 codLineaVehiculoCarga, ");
            select.Append(" VEHI_NOEJES_NB numEjes, ");
            select.Append(" VEHI_MODELO_V2 anoFabricacionVehiculoCarga, ");
            select.Append(" VEHICULOS.VEHI_MODELOREPO_NB anoRepotenciacion, ");
            select.Append(" COLO_MIN_V2 codColorVehiculoCarga, ");
            select.Append(" VEHICULOS.VEHI_PESOVACIO_NB pesoVehiculoVacio, ");
            select.Append(" VEHI_CAPACIDAD_NB capacidadUnidadCarga, ");
            select.Append(" 1 unidadMedidaCapacidad, ");
            select.Append(" DECODE(CLVE_TIPO_V2,'A','0','R',(DECODE(VEHI_CLASE_NB,3,1,2,2,51,2,10,1,54,3,0))) codTipoCarroceria, ");
            select.Append(" VEHI_NOSERIE_V2 numChasis, ");
            select.Append(" 1 codTipoCombustible, ");
            select.Append(" DOCUMENTOS_VEHICULO.DOVE_NODOCUMENTO_NB numSeguroSoat, ");
            select.Append(" to_char(DOCUMENTOS_VEHICULO.DOVE_FECVENCE_DT,'DD/MM/YYYY') fechaVencimientoSoat, ");
            select.Append(" EMPRESAS.EMPR_NIT_NB||f_chequeonit(EMPR_NIT_NB,1) numNitAseguradoraSoat, ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codTipoIdPropietario, ");
            select.Append(" decode(propietarios.PROP_TIPOIDEN_V2,'C',ENLA_PROPIETARIO_NB,'N',ENLA_PROPIETARIO_NB|| ");
            select.Append(" (decode(length(ENLA_PROPIETARIO_NB),10,null,9,f_chequeonit(ENLA_PROPIETARIO_NB,1),NULL))) numIdPropietario, ");
            //select.Append(" ----ENLACE.ENLA_PROPIETARIO_NB||decode(length(ENLA_PROPIETARIO_NB),10,null,9,f_chequeonit(ENLA_PROPIETARIO_NB,1),null) numIdPropietario, ");
            select.Append(" PROPIETARIOS_A1.PROP_TIPOIDEN_V2 codTipoIdTenedor, ");
            select.Append(" ENLACE.ENLA_POSEEDOR_NB||decode(length(ENLA_POSEEDOR_NB),10,null,9,f_chequeonit(ENLA_POSEEDOR_NB,1),null) numIdTenedor, ");
            select.Append(" 8605048823 NUMNITEMPRESATRANSPORTE, ");
            select.Append(" VEHI_CONFIGURACION_V2 ConfiguracionUC, ");
            select.Append(" VEHI_RIGIDOMIN_NB RIGIDOMIN  ");
            select.Append(" FROM VEHICULOS,PROPIETARIOS,ENLACE,PROPIETARIOS PROPIETARIOS_A1,DOCUMENTOS_VEHICULO, ");
            select.Append(" LICENCIAS_DOCUMENTOS,EMPRESAS,marcas,LINEAS_VEHICULO,COLORES,CLASE_VEHICULO ");
            select.Append(" WHERE VEHICULOS.VEHI_PLACA_CH=ENLACE.ENLA_PLACA_CH ");
            select.Append(" AND LICENCIAS_DOCUMENTOS.LIDO_DESCRIPCION_V2='SOAT' ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_PLACA_CH=VEHICULOS.VEHI_PLACA_CH ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_DOCLICEN_NB(+)=LICENCIAS_DOCUMENTOS.LIDO_CODIGO_NB ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_ENTEEXPIDE_NB=EMPRESAS.EMPR_CODIGO_NB ");
            select.Append(" AND ENLACE.ENLA_PROPIETARIO_NB=PROPIETARIOS.PROP_CEDULA_NB ");
            select.Append(" AND ENLACE.ENLA_POSEEDOR_NB=PROPIETARIOS_A1.PROP_CEDULA_NB ");
            select.Append(" AND VEHI_MARCA_V2=MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_LINEA_NB=LIVE_CODIGO_NB ");
            select.Append(" AND LIVE_MARCA_NB=MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_COLOR_V2=COLO_CODIGO_NB ");
            select.Append(" AND VEHI_CLASE_NB=CLVE_SECUENCIA_NB ");
            select.Append(" AND VEHICULOS.VEHI_PLACA_CH = :llave ");
            select.Append(" AND DOVE_ESTADO_V2='A' ");
            select.Append(" order by VEHICULOS.VEHI_PLACA_CH; ");

            /*select.Append(" SELECT distinct VEHICULOS.VEHI_PLACA_CH numPlaca, ");
            select.Append(" DECODE(VEHI_CONFIGURACION_V2, '1', '50', '2', '45', '3', '51', '4', '52', '5', '56', '2S', '53', '3S', '54', '4S', '55', NULL) codConfiguracionUnidadCarga,       ");
            select.Append(" MARC_MIN_V2 codMarcaVehiculoCarga, ");
            select.Append(" LIVE_LINMIN_V2 codLineaVehiculoCarga,       ");
            select.Append(" VEHI_NOEJES_NB numEjes, ");
            select.Append(" VEHI_MODELO_V2 anoFabricacionVehiculoCarga,       ");
            select.Append(" VEHICULOS.VEHI_MODELOREPO_NB anoRepotenciacion, ");
            select.Append(" COLO_MIN_V2 codColorVehiculoCarga,       ");
            select.Append(" VEHICULOS.VEHI_PESOVACIO_NB pesoVehiculoVacio, ");
            select.Append(" VEHI_CAPACIDAD_NB capacidadUnidadCarga,       ");
            select.Append(" 1 unidadMedidaCapacidad,       ");
            select.Append(" DECODE(CLVE_TIPO_V2, 'A', '0', 'R', (DECODE(VEHI_CLASE_NB, 3, 1, 2, 2, 51, 2, 10, 1, 54, 3, 0))) codTipoCarroceria,       ");
            select.Append(" VEHI_NOSERIE_V2 numChasis, ");
            select.Append(" 1 codTipoCombustible,       ");
            select.Append(" DOCUMENTOS_VEHICULO.DOVE_NODOCUMENTO_NB numSeguroSoat, ");
            select.Append(" to_char(DOCUMENTOS_VEHICULO.DOVE_FECVENCE_DT, 'DD/MM/YYYY') fechaVencimientoSoat,     ");
            select.Append(" EMPRESAS.EMPR_NIT_NB || f_chequeonit(EMPR_NIT_NB, 1) numNitAseguradoraSoat,       ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codTipoIdPropietario, ");
            select.Append(" decode(propietarios.PROP_TIPOIDEN_V2, 'C', ENLA_PROPIETARIO_NB, 'N', ENLA_PROPIETARIO_NB || ");
            select.Append(" (decode(length(ENLA_PROPIETARIO_NB), 10, null, 9, f_chequeonit(ENLA_PROPIETARIO_NB, 1), NULL))) numIdPropietario,       ");
            //select.Append(" ----ENLACE.ENLA_PROPIETARIO_NB || decode(length(ENLA_PROPIETARIO_NB), 10, null, 9, f_chequeonit(ENLA_PROPIETARIO_NB, 1), null) numIdPropietario,       ");
            select.Append(" PROPIETARIOS_A1.PROP_TIPOIDEN_V2 codTipoIdTenedor, ");
            select.Append(" ENLACE.ENLA_POSEEDOR_NB || decode(length(ENLA_POSEEDOR_NB), 10, null, 9, f_chequeonit(ENLA_POSEEDOR_NB, 1), null) numIdTenedor,       ");
            select.Append(" 8605048823 NUMNITEMPRESATRANSPORTE ");
            select.Append(" FROM VEHICULOS,PROPIETARIOS,ENLACE,PROPIETARIOS PROPIETARIOS_A1, DOCUMENTOS_VEHICULO, ");
            select.Append(" LICENCIAS_DOCUMENTOS, EMPRESAS, marcas, LINEAS_VEHICULO, COLORES, CLASE_VEHICULO ");
            select.Append(" WHERE VEHICULOS.VEHI_PLACA_CH = ENLACE.ENLA_PLACA_CH ");
            select.Append(" AND LICENCIAS_DOCUMENTOS.LIDO_DESCRIPCION_V2 = 'SOAT' ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_PLACA_CH = VEHICULOS.VEHI_PLACA_CH ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_DOCLICEN_NB(+) = LICENCIAS_DOCUMENTOS.LIDO_CODIGO_NB ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_ENTEEXPIDE_NB = EMPRESAS.EMPR_CODIGO_NB ");
            select.Append(" AND ENLACE.ENLA_PROPIETARIO_NB = PROPIETARIOS.PROP_CEDULA_NB ");
            select.Append(" AND ENLACE.ENLA_POSEEDOR_NB = PROPIETARIOS_A1.PROP_CEDULA_NB ");
            select.Append(" AND VEHI_MARCA_V2 = MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_LINEA_NB = LIVE_CODIGO_NB ");
            select.Append(" AND LIVE_MARCA_NB = MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_COLOR_V2 = COLO_CODIGO_NB ");
            select.Append(" AND VEHI_CLASE_NB = CLVE_SECUENCIA_NB ");
            select.Append(" AND VEHICULOS.VEHI_PLACA_CH = :llave ");
            select.Append(" AND DOVE_ESTADO_V2 = 'A' ");
            select.Append(" order by VEHICULOS.VEHI_PLACA_CH; ");*/



            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_TRAILERS()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_TRAILERS()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' NUMNITEMPRESATRANSPORTE,   ");
            select.Append(" TRAI_PLACA_CH numPlaca,   ");
            select.Append(" DECODE(TRAI_NOEJES_NB,2,62,3,63,TRAI_NOEJES_NB) codConfiguracionUnidadCarga,   ");
            select.Append(" MARC_CAMPO4_V2 codMarcaVehiculoCarga,   ");
            select.Append(" TRAI_MODELO_NB anoFabricacionVehiculoCarga,   ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codTipoIdPropietario,   ");
            select.Append(" PROPIETARIOS.PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdPropietario,   ");
            select.Append(" PROPIETARIOS_A1.PROP_TIPOIDEN_V2 codTipoIdTenedor,   ");
            select.Append(" PROPIETARIOS_A1.PROP_CEDULA_NB||decode(length(PROPIETARIOS_A1.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS_A1.PROP_CEDULA_NB,1),null) numIdTenedor,   ");
            select.Append(" TRAI_PESO_NB pesoVehiculoVacio,   ");
            select.Append(" GENE_DESCRIPCION2_V2 codTipoCarroceria   ");
            select.Append(" FROM TRAILERS, ENLACE,PROPIETARIOS, PROPIETARIOS PROPIETARIOS_A1,MARCAS,GENERICAS   ");
            select.Append(" WHERE TRAILERS.TRAI_PLACA_CH=ENLACE.ENLA_TRAILER_CH   ");
            select.Append(" AND TRAILERS.TRAI_PROPIET_NB=PROPIETARIOS.PROP_CEDULA_NB   ");
            select.Append(" AND PROPIETARIOS_A1.PROP_CEDULA_NB=ENLACE.ENLA_POSEEDOR_NB   ");
            select.Append(" AND TRAI_MARCA_V2=MARC_SECUENCIA_NB   ");
            select.Append(" AND TRAI_TIPO_NB=GENE_CODIGO_NB   ");
            select.Append(" AND GENE_NOMBRE_V2 ='TIPO CARROCERIA'   ");
            select.Append(" AND TRAILERS.TRAI_PLACA_CH = :llave   ");
            select.Append(" UNION   ");
            select.Append(" SELECT DISTINCT '8605048823' NUMNITEMPRESATRANSPORTE,   ");
            select.Append(" TRAILERS.TRAI_PLACA_CH numPlaca,   ");
            select.Append(" DECODE(TRAI_NOEJES_NB,2,62,3,63,TRAI_NOEJES_NB) codConfiguracionUnidadCarga,   ");
            select.Append(" MARC_CAMPO4_V2 codMarcaVehiculoCarga,   ");
            select.Append(" TRAI_MODELO_NB anoFabricacionVehiculoCarga,   ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdPropietario,   ");
            select.Append(" PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdPropietario,   ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdTenedor,   ");
            select.Append(" PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdTenedor,   ");
            select.Append(" TRAI_PESO_NB pesoVehiculoVacio,   ");
            select.Append(" GENE_DESCRIPCION2_V2 codTipoCarroceria   ");
            select.Append(" FROM TRAILERS,PROPIETARIOS,MARCAS,GENERICAS   ");
            select.Append(" WHERE TRAILERS.TRAI_PROPIET_NB=PROPIETARIOS.PROP_CEDULA_NB   ");
            select.Append(" AND TRAI_MARCA_V2=MARC_SECUENCIA_NB   ");
            select.Append(" AND TRAI_TIPO_NB=GENE_CODIGO_NB   ");
            select.Append(" AND GENE_NOMBRE_V2 ='TIPO CARROCERIA'   ");
            select.Append(" AND TRAILERS.TRAI_PLACA_CH = :llave;   ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_ANULAR_MANIFIESTO()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_ANULAR_MANIFIESTO()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" VIAJ_NOPLANILLA_V2 numManifiestoCarga,'S' motivoAnulacionManifiesto, ");
            select.Append(" GENE_DESCRIPCION_V2 OBSERVACIONES ");
            select.Append(" FROM VIAJES,genericas ");
            select.Append(" WHERE GENE_NOMBRE_V2='CAUSA ANULA PLANILLA' ");
            select.Append(" and VIAJ_CAUSANULA_NB=GENE_CODIGO_NB ");
            select.Append(" and VIAJ_NOPLANILLA_V2=:LLAVE; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string PK_MINISTERIO_XML_ANULAR_REMESA()
        /// </summary>
        /// <returns></returns>
        private string PK_MINISTERIO_XML_ANULAR_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte,'A' motivoReversaRemesa, ");
            select.Append(" 'S' motivoAnulacionRemesa,ORCA_NUMERO_NB consecutivoRemesa ");
            select.Append(" from ordenes_cargue ");
            select.Append(" where ORCA_NUMERO_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        /// <summary>
        /// private string UpdateLogReporteMinisterio()
        /// </summary>
        /// <returns></returns>
        private string UpdateLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO, ");
            select.Append(" LRMI_CAMPO2_v2 =:LRMI_CAMPO2, ");
            select.Append(" LRMI_CAMPO3_dt = sysdate ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        /// <summary>
        /// private string UpdateLogReporteMinisterioCampo1()
        /// </summary>
        /// <returns></returns>
        private string UpdateLogReporteMinisterioCampo1()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO, ");
            select.Append(" LRMI_CAMPO1_NB =:LRMI_CAMPO1, ");
            select.Append(" LRMI_CAMPO2_V2 =:LRMI_CAMPO2 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }

        #endregion Fin de la Definicion del Bloque GetCommandMinisterio

        #region Definicion del Bloque GetCommandVarios
        private string GetCommandVarios(string instruccion, string[] nParametros, object[] vParametros)
        {
            string select = string.Empty;
            switch (instruccion)
            {
                case "getOrdenesCarguexReporteVarios":
                    {
                        select = getOrdenesCarguexReporteVarios();
                        break;
                    }
                case "getOrdenesCargue":
                    {
                        select = getOrdenesCargue();
                        break;
                    }
                case "getViajesxOrdenCargue":
                    {
                        select = getViajesxOrdenCargue();
                        break;
                    }
                case "getLogReporteMinisterioVarios":
                    {
                        select = getLogReporteMinisterioVarios();
                        break;
                    }
                case "getIdMinisterio":
                    {
                        select = getIdMinisterio();
                        break;
                    }

                case "setIdMinisterio":
                    {
                        select = setIdMinisterio();
                        break;
                    }
                case "SetUpdateLogReporteMinisterio":
                    {
                        select = SetUpdateLogReporteMinisterio();
                        break;
                    }
                case "getOrdenesCarguexHistoryPlanilla":
                    {
                        select = getOrdenesCarguexHistoryPlanilla();
                        break;
                    }

                case "getOrdenesCarguexHistoryPlanillaxLogReporteMinisterio":
                    {
                        select = getOrdenesCarguexHistoryPlanillaxLogReporteMinisterio();
                        break;
                    }

                case "getOrdenesCarguexHistoryPlanillaxDetLogMinisterio":
                    {
                        select = getOrdenesCarguexHistoryPlanillaxDetLogMinisterio();
                        break;
                    }
                default:
                    break;
            }
            return select;
        }



        private string getOrdenesCarguexReporteVarios()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select ORCA_NUMERO_NB, ");
            select.Append(" ORCA_NEGOCIO_NB, ");
            select.Append(" ORCA_FECCREA_DT, ");
            select.Append(" ORCA_PLACA_CH, ");
            select.Append(" ORCA_CONDUCTOR_NB, ");
            select.Append(" ORCA_NITREM_NB, ");
            select.Append(" ORCA_RUTA_NB, ");
            select.Append(" ORCA_OFICDESP_NB, ");
            select.Append(" ORCA_PRODUCTO_NB, ");
            select.Append(" ORCA_OBSERVACIONES_V2, ");
            select.Append(" ORCA_TIPOEMPAQUE_NB, ");
            select.Append(" ORCA_CANTIDAD_NB, ");
            select.Append(" ORCA_VOLUMEN_NB, ");
            select.Append(" ORCA_PESOKGS_NB, ");
            select.Append(" ORCA_ESTADO_V2, ");
            select.Append(" ORCA_TRAILER_CH, ");
            select.Append(" ORCA_CAMINO_NB, ");
            select.Append(" ORCA_SECUENCIA_NB, ");
            select.Append(" ORCA_PLANTAREMITE_NB, ");
            select.Append(" ORCA_PLANTARECIBE_NB, ");
            select.Append(" ORCA_CEDRELEVO_NB, ");
            select.Append(" ORCA_TIPOVIAJE_V2, ");
            select.Append(" ORCA_USUCREA_NB, ");
            select.Append(" ORCA_FECANULA_DT, ");
            select.Append(" ORCA_USUANULA_NB, ");
            select.Append(" ORCA_CAUSANULA_NB, ");
            select.Append(" ORCA_CLIENTEPAGA_NB, ");
            select.Append(" ORCA_CELULAR_NB, ");
            select.Append(" ORCA_CAMPO1_NB, ");
            select.Append(" ORCA_CAMPO2_NB, ");
            select.Append(" ORCA_OPCIONCREA_V2, ");
            select.Append(" ORCA_GRUPORUTA_NB, ");
            select.Append(" ORCA_CLIENTEREC_NB, ");
            select.Append(" ORCA_CAMPO3_NB, ");
            select.Append(" ORCA_CAMPO4_V2, ");
            select.Append(" ORCA_IDMINISTERIO_V2, ");
            select.Append(" ORCA_NUMERO_NB Orden, ");
            select.Append(" ORCA_FECCREA_DT FechaOrden, ");
            select.Append(" decode(ORCA_ESTADO_V2,'A','Anulada','N','Activa','P','Anulada','T','Estado T', ORCA_ESTADO_V2) EstadoOrden, ");
            select.Append(" ORCA_FECANULA_DT FecAnulaOrden, ");
            select.Append(" NEGO_NRONEGOCIO_NB Negocio, ");
            select.Append(" ORCA_FECCREA_DT FechaOrden, ");
            select.Append(" ORCA_PLACA_CH Placa, ");
            select.Append(" NEGO_CLIENTENEGO_NB, ");
            select.Append(" cl.CLIE_CODIGO_NB, ");
            select.Append(" cl.CLIE_NIT_NB, ");
            select.Append(" cl.CLIE_NOMBRE_V2, ");
            select.Append(" COND_CEDULA_NB Cedula, ");
            select.Append(" COND_NOMBRE_V2 Nombre, ");
            select.Append(" COND_APELLIDO_V2 Apellido, ");
            select.Append(" RUTA_CODIGO_NB Ruta, ");
            select.Append(" RUTA_ORIGEN_NB CodigoOrigen, ");
            select.Append(" RUTA_DESTINO_NB CodigoDestino, ");
            select.Append(" o.CIUD_CODIGO_NB, ");
            select.Append(" o.CIUD_DESCRIPCION_V2 Origen, ");
            select.Append(" d.CIUD_CODIGO_NB, ");
            select.Append(" d.CIUD_DESCRIPCION_V2 Destino, ");
            select.Append(" OFIC_CODOFIC_NB, ");
            select.Append(" OFIC_NOMBRE_V2 Oficina, ");
            select.Append(" PROD_CODIGO_NB, ");
            select.Append(" PROD_NOMBRE_V2 Producto, ");
            select.Append(" PROD_ABREVIATURA_V2, ");
            select.Append(" po.PLAN_CODIGO_NB, ");
            select.Append(" po.PLAN_NOMBRE_V2 PlantaOrigen, ");
            select.Append(" po.PLAN_CIUDAD_NB, ");
            select.Append(" pd.PLAN_CODIGO_NB, ");
            select.Append(" pd.PLAN_NOMBRE_V2 PlantaDestino, ");
            select.Append(" pd.PLAN_CIUDAD_NB, ");
            select.Append(" cpo.CIPA_CLIENTE_NB, ");
            select.Append(" cpo.CIPA_PLANTA_NB, ");
            select.Append(" cp.CLIE_CODIGO_NB, ");
            select.Append(" cp.CLIE_NIT_NB, ");
            select.Append(" cp.CLIE_NOMBRE_V2 ClientePaga, ");
            select.Append(" cr.CLIE_CODIGO_NB, ");
            select.Append(" cr.CLIE_NIT_NB, ");
            select.Append(" cr.CLIE_NOMBRE_V2 ClienteRecibe");
            select.Append(" from ordenes_cargue,negocios,clientes cl, conductores, rutas, ciudades o,ciudades d, oficinas, productos, plantas po,plantas pd, clientes_plantas cpo,clientes_plantas cpd, clientes cp,clientes cr ");
            select.Append(" where ORCA_NEGOCIO_NB = NEGO_NRONEGOCIO_NB ");
            select.Append(" and NEGO_CLIENTENEGO_NB = cl.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_CONDUCTOR_NB = COND_CEDULA_NB ");
            select.Append(" and ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append(" and RUTA_ORIGEN_NB = o.CIUD_CODIGO_NB ");
            select.Append(" and RUTA_DESTINO_NB = d.CIUD_CODIGO_NB ");
            select.Append(" and ORCA_OFICDESP_NB = OFIC_CODOFIC_NB ");
            select.Append(" and ORCA_PRODUCTO_NB = PROD_CODIGO_NB ");
            select.Append(" and po.PLAN_CODIGO_NB=cpo.CIPA_PLANTA_NB ");
            select.Append(" and cpo.CIPA_CLIENTE_NB= cl.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_PLANTAREMITE_NB = po.PLAN_CODIGO_NB ");
            select.Append(" and pd.PLAN_CODIGO_NB= cpd.CIPA_PLANTA_NB ");
            select.Append(" and ORCA_PLANTARECIBE_NB = pd.PLAN_CODIGO_NB ");
            select.Append(" and cpd.CIPA_CLIENTE_NB= cl.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_CLIENTEPAGA_NB = cp.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_CLIENTEREC_NB = cr.CLIE_CODIGO_NB ");
            //select.Append(" and ORCA_OFICDESP_NB = 39 ");
            select.Append(" and trunc(ORCA_FECCREA_DT) between trunc(:fecini) and trunc(:fecfin) ");
            //select.Append(" and orca_numero_nb = 1851412 ");
            select.Append(" order by ORCA_OFICDESP_NB; ");
            select.Append("end;");
            return select.ToString();
        }


        private string getOrdenesCargue()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select ORCA_NUMERO_NB, ");
            select.Append(" ORCA_NEGOCIO_NB, ");
            select.Append(" ORCA_FECCREA_DT, ");
            select.Append(" ORCA_PLACA_CH, ");
            select.Append(" ORCA_CONDUCTOR_NB, ");
            select.Append(" ORCA_NITREM_NB, ");
            select.Append(" ORCA_RUTA_NB, ");
            select.Append(" ORCA_OFICDESP_NB, ");
            select.Append(" ORCA_PRODUCTO_NB, ");
            select.Append(" ORCA_OBSERVACIONES_V2, ");
            select.Append(" ORCA_TIPOEMPAQUE_NB, ");
            select.Append(" ORCA_CANTIDAD_NB, ");
            select.Append(" ORCA_VOLUMEN_NB, ");
            select.Append(" ORCA_PESOKGS_NB, ");
            select.Append(" ORCA_ESTADO_V2, ");
            select.Append(" ORCA_TRAILER_CH, ");
            select.Append(" ORCA_CAMINO_NB, ");
            select.Append(" ORCA_SECUENCIA_NB, ");
            select.Append(" ORCA_PLANTAREMITE_NB, ");
            select.Append(" ORCA_PLANTARECIBE_NB, ");
            select.Append(" ORCA_CEDRELEVO_NB, ");
            select.Append(" ORCA_TIPOVIAJE_V2, ");
            select.Append(" ORCA_USUCREA_NB, ");
            select.Append(" ORCA_FECANULA_DT, ");
            select.Append(" ORCA_USUANULA_NB, ");
            select.Append(" ORCA_CAUSANULA_NB, ");
            select.Append(" ORCA_CLIENTEPAGA_NB, ");
            select.Append(" ORCA_CELULAR_NB, ");
            select.Append(" ORCA_CAMPO1_NB, ");
            select.Append(" ORCA_CAMPO2_NB, ");
            select.Append(" ORCA_OPCIONCREA_V2, ");
            select.Append(" ORCA_GRUPORUTA_NB, ");
            select.Append(" ORCA_CLIENTEREC_NB, ");
            select.Append(" ORCA_CAMPO3_NB, ");
            select.Append(" ORCA_CAMPO4_V2, ");
            select.Append(" ORCA_IDMINISTERIO_V2 ");
            select.Append(" from ordenes_cargue ");
            select.Append(" where ORCA_OFICDESP_NB = :ORCA_OFICDESP ");
            select.Append(" order by ORCA_OFICDESP_NB; ");
            select.Append("end;");
            return select.ToString();
        }

        private string getViajesxOrdenCargue()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select VIAJ_NOPLANILLA_V2, ");
            select.Append(" VIAJ_NEGOCIO_NB, ");
            select.Append(" VIAJ_ORDCARGUE_NB, ");
            select.Append(" VIAJ_FECVIAJE_DT, ");
            select.Append(" VIAJ_PLACA_CH, ");
            select.Append(" VIAJ_OFDESPACHA_NB, ");
            select.Append(" VIAJ_CLASEVEHI_NB, ");
            select.Append(" VIAJ_ESTADO_V2, ");
            select.Append(" VIAJ_MONEDA_NB, ");
            select.Append(" VIAJ_NODTAI_NB, ");
            select.Append(" VIAJ_MOTONAVE_NB, ");
            select.Append(" VIAJ_CONDUCTOR_NB, ");
            select.Append(" VIAJ_PROPIETARIO_NB, ");
            select.Append(" VIAJ_POSEEDOR_NB, ");
            select.Append(" VIAJ_FECANULA_DT, ");
            select.Append(" VIAJ_TIPO_V2, ");
            select.Append(" VIAJ_CANTVIAJES_NB, ");
            select.Append(" VIAJ_VALORCARGA_NB, ");
            select.Append(" VIAJ_OBSERVACIONES_V2, ");
            select.Append(" VIAJ_TRAILER_CH, ");
            select.Append(" VIAJ_CUMLIQ_V2, ");
            select.Append(" VIAJ_FACTURADA_V2, ");
            select.Append(" VIAJ_SINIESTROS_V2, ");
            select.Append(" VIAJ_DOCTRANSPORTE_V2, ");
            select.Append(" VIAJ_CEDRELEVO_NB, ");
            select.Append(" VIAJ_TIPOVIAJE_V2, ");
            select.Append(" VIAJ_DOCEXTERNO_V2, ");
            select.Append(" VIAJ_USUCREA_NB, ");
            select.Append(" VIAJ_USUANULA_NB, ");
            select.Append(" VIAJ_PORDCTOCOMER_NB, ");
            select.Append(" VIAJ_PORMARGENINT_NB, ");
            select.Append(" VIAJ_CELULAR_NB, ");
            select.Append(" VIAJ_FIN_NB, ");
            select.Append(" VIAJ_USUFIN_NB, ");
            select.Append(" VIAJ_CAUSANULA_NB, ");
            select.Append(" VIAJ_CAMPO1_NB, ");
            select.Append(" VIAJ_CAMPO2_NB, ");
            select.Append(" VIAJ_CAMPO3_V2, ");
            select.Append(" VIAJ_CAMPO4_V2, ");
            select.Append(" VIAJ_TIPMANIFIESTO_NB, ");
            select.Append(" VIAJ_FECENTREGA_DT, ");
            select.Append(" VIAJ_CONSMANIFIESTO_NB, ");
            select.Append(" VIAJ_IDMINISTERIO_V2, ");
            select.Append(" VIAJ_NOPLANILLA_V2 Planilla, ");
            select.Append(" VIAJ_FECVIAJE_DT FecViaje, ");
            select.Append(" OFIC_NOMBRE_V2 OfiDespacha, ");
            select.Append(" decode(VIAJ_ESTADO_V2, 'D', 'Transito', 'P', 'Estado P', 'A', 'Estado A', 'E', 'Estado E', VIAJ_ESTADO_V2) EstadoPlanilla, ");
            select.Append(" VIAJ_FECANULA_DT FecAnulaPlanilla ");
            select.Append(" from viajes,oficinas ");
            select.Append(" where VIAJ_OFDESPACHA_NB = OFIC_CODOFIC_NB ");
            select.Append(" and VIAJ_ORDCARGUE_NB =:VIAJ_ORDCARGUE ");
            select.Append(" order by VIAJ_FECVIAJE_DT; ");
            select.Append("end;");
            return select.ToString();
        }

        private string getLogReporteMinisterioVarios()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" decode(LRMI_ESTADO_V2,'R','Rechazado','E','Enviado','P','Pendiente','U','Urbano',LRMI_ESTADO_V2) LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT ");
            select.Append(" from log_reporte_ministerio ");
            select.Append(" where LRMI_OFICINA_NB = :oficina ");
            select.Append(" and LRMI_LLAVE_V2 = :llave ");
            select.Append(" and LRMI_TRANSACCION_NB = :transaccion; ");
            select.Append("end;");
            return select.ToString();
        }


        private string getOrdenesCarguexHistoryPlanilla()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            /*select.Append(" select OFIC_CODOFIC_NB, ");
            select.Append(" OFIC_NOMBRE_V2, ");
            select.Append(" ORCA_NUMERO_NB, ");
            select.Append(" ORCA_FECCREA_DT, ");
            select.Append(" ORCA_ESTADO_V2 ");
            select.Append(" from ordenes_cargue, oficinas ");
            select.Append(" where ORCA_OFICDESP_NB = OFIC_CODOFIC_NB ");
            select.Append(" and trunc(ORCA_FECCREA_DT) between trunc(sysdate - 2600) and trunc(sysdate) ");
            //select.Append(" and trunc(ORCA_FECCREA_DT) = trunc(sysdate) ");
            select.Append(" order by ORCA_FECCREA_DT; ");*/
            select.Append(" select OFIC_CODOFIC_NB, ");
            select.Append(" OFIC_NOMBRE_V2, ");
            select.Append(" VIAJ_NOPLANILLA_V2, ");
            select.Append(" VIAJ_FECVIAJE_DT, ");
            select.Append(" VIAJ_ESTADO_V2 ");
            select.Append(" from viajes, oficinas ");
            select.Append(" where VIAJ_OFDESPACHA_NB = OFIC_CODOFIC_NB ");
            select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-2300) and trunc(sysdate) ");
            select.Append(" order by VIAJ_FECVIAJE_DT; ");
            select.Append("end;");
            return select.ToString();
        }

        private string getOrdenesCarguexHistoryPlanillaxLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2 ");
            select.Append(" from log_reporte_ministerio ");
            select.Append(" where LRMI_LLAVE_V2 =:LRMI_LLAVE ");
            select.Append(" and LRMI_TRANSACCION_NB =:LRMI_TRANSACCION ");
            select.Append(" order by LRMI_FECREGISTRO_DT; ");
            select.Append("end;");
            return select.ToString();
        }

        private string getOrdenesCarguexHistoryPlanillaxDetLogMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_FECENVIO_DT ");
            select.Append(" from det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB =:DELM_LOGSECUENCIA ");
            select.Append(" and DELM_OFICINA_NB =:DELM_OFICINA ");
            select.Append(" and DELM_LLAVE_V2 =:DELM_LLAVE ");
            select.Append(" order by DELM_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getIdMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" DELM_LOGSECUENCIA_NB, ");
            select.Append(" DELM_OFICINA_NB, ");
            select.Append(" DELM_TRANSACCION_NB, ");
            select.Append(" DELM_LLAVE_V2, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_XMLENVIADO_XML, ");
            select.Append(" DELM_FECENVIO_DT, ");
            select.Append(" DELM_XMLRECIBIDO_XML, ");
            select.Append(" DELM_CAMPO1_NB, ");
            select.Append(" DELM_CAMPO2_V2, ");
            select.Append(" DELM_CAMPO3_DT ");
            select.Append(" from det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB = :logsecuencia ");
            select.Append(" and DELM_OFICINA_NB = :oficina ");
            select.Append(" and DELM_LLAVE_V2 = :llave ");
            select.Append(" order by DELM_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string setIdMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_FECENVIO_DT ");
            select.Append(" from log_reporte_ministerio, det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB = LRMI_SECUENCIA_NB ");
            select.Append(" and DELM_OFICINA_NB = LRMI_OFICINA_NB ");
            select.Append(" and DELM_TRANSACCION_NB = LRMI_TRANSACCION_NB ");
            select.Append(" and DELM_ESTADO_V2 = 'E' ");
            select.Append(" and lrmi_estado_v2 = 'E' ");
            select.Append(" and LRMI_OFICINA_NB=:LRMI_OFICINA ");
            select.Append(" and lrmi_campo2_v2 is null ");
            select.Append(" order by lrmi_fecregistro_dt; ");
            select.Append("end;");
            return select.ToString();
        }
        private string SetUpdateLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_CAMPO2_V2 =:LRMI_CAMPO2, ");
            select.Append(" LRMI_CAMPO3_DT =:LRMI_CAMPO3 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA ");
            select.Append(" and LRMI_ESTADO_V2 =:LRMI_ESTADO; ");
            select.Append("end;");
            return select.ToString();
        }
        #endregion fin de la Definicion del Bloque GetCommandVarios






























































    }
}
