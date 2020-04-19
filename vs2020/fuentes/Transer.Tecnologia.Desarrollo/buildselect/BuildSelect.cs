using System;
using System.Text;
namespace buildselect
{
    public class BuildSelect
    {
        public string GetCommand(string s, string[] _nParametros, object[] _vParametros)
        {
            string select = string.Empty;
            switch (s)
            {
                case "InformacionDian21":
                    {
                        select = InformacionDian21();
                        break;
                    }
                case "getLogReporteDian":
                    {
                        select = getLogReporteDian();
                        break;
                    }
                case "getInformacionDian":
                    {
                        select = getInformacionDian();
                        break;
                    }
                case "pdbInfoDianFactura":
                    {
                        select = pdbInfoDianFactura();
                        break;
                    }
                case "pdbInfoDianNota":
                    {
                        select = pdbInfoDianNota();
                        break;
                    }
                case "FDB_LEER_ANEXOS_DIAN":
                    {
                        select = FDB_LEER_ANEXOS_DIAN();
                        break;
                    }
                case "getCliente":
                    {
                        select = getCliente();
                        break;
                    }
                case "UploadRequestFE":
                    {
                        select = UploadRequestFE();
                        break;
                    }
                case "insertDetLogDian":
                    {
                        select = insertDetLogDian();
                        break;
                    }
                case "updateLogReporteDian":
                    {
                        select = updateLogReporteDian();
                        break;
                    }
                case "updateInformacionDian":
                    {
                        select = updateInformacionDian();
                        break;
                    }
                case "updateInfoDianCufe":
                    {
                        select = updateInfoDianCufe();
                        break;
                    }
                case "updateDetLogDianCufe":
                    {
                        select = updateDetLogDianCufe();
                        break;
                    }
                case "updateLogReporteDianCufe":
                    {
                        select = updateLogReporteDianCufe();
                        break;
                    }
                case "updateInfoDianFactura":
                    {
                        select = updateInfoDianFactura();
                        break;
                    }
                case "getInformacionDianEnProceso":
                    {
                        select = getInformacionDianEnProceso();
                        break;
                    }
                case "getLogReporteBavaria":
                    {
                        select = getLogReporteBavaria();
                        break;
                    }
                case "getInfoBavaria":
                    {
                        select = getInfoBavaria();
                        break;
                    }
                case "InsertDetLogBavaria":
                    {
                        select = InsertDetLogBavaria();
                        break;
                    }
                case "UpdateLogReporteBavaria":
                    {
                        select = UpdateLogReporteBavaria();
                        break;
                    }
                case "pdbInfoDianFacturaOperativo":
                    {
                        select = pdbInfoDianFacturaOperativo();
                        break;
                    }
                case "pdbInfoDianNotaOperativo":
                    {
                        select = pdbInfoDianNotaOperativo();
                        break;
                    }
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
                case "getInfoLogReporteBavaria":
                    {
                        select = getInfoLogReporteBavaria();
                        break;
                    }
                case "getDetalleDetLogBavaria":
                    {
                        select = getDetalleDetLogBavaria();
                        break;
                    }
                case "getOficinas":
                    {
                        select = getOficinas();
                        break;
                    }
                case "getEstadosRobots":
                    {
                        select = getEstadosRobots();
                        break;
                    }
                case "getExecuteQuery":
                    {
                        select = getExecuteQuery(_nParametros, _vParametros);
                        break;
                    }
                case "getViajesEntreFechas":
                    {
                        select = getViajesEntreFechas(_nParametros, _vParametros);
                        break;
                    }                    
                case "getInfoMilenio":
                    {
                        select = getInfoMilenio();
                        break;
                    }                
                case "getInfoDeseguro":
                    {
                        select = getInfoDeseguro();
                        break;
                    }                
                case "getInfoOsp":
                    {
                        select = getInfoOsp();
                        break;
                    }                    
                case "getInfoAutBavaria":
                    {
                        select = getInfoAutBavaria();
                        break;
                    }                
                case "getInfoFactura":
                    {
                        select = getInfoFactura();
                        break;
                    }                
                case "getSelectInfoDian":
                    {
                        select = getSelectInfoDian();
                        break;
                    }                    
                case "resumenMilenioTodas":
                    {
                        select = resumenMilenioTodas();
                        break;
                    }
                case "resumenMilenioOficina":
                    {
                        select = resumenMilenioOficina();
                        break;
                    }
                case "fletes":
                    {
                        select = fletes();
                        break;
                    }
                case "anticipos":
                    {
                        select = anticipos();
                        break;
                    }
                case "facturas":
                    {
                        select = facturas();
                        break;
                    }                
                case "oficinas":
                    {
                        select = oficinas();
                        break;
                    }
                    
                case "getOrdenesRechazadas":
                    {
                        select = getOrdenesRechazadas();
                        break;
                    }
                default:
                    break;
            }
            return select;
        }
        private string oficinas()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" Select OFIC_CODOFIC_NB OFIC_CODOFIC, ");
            select.Append(" OFIC_NOMBRE_V2 OFIC_NOMBRE ");
            select.Append(" from oficinas ");
            select.Append(" union ");
            select.Append(" select 0 OFIC_CODOFIC, ");
            select.Append(" 'Todas las Oficinas' OFIC_NOMBRE ");
            select.Append(" from dual ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string facturas()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DISTINCT FACT_NOFACTURA_NB FACT_NOFACTURA, ");
            select.Append(" to_char(FACT_FECFACT_DT, 'DD/MM/YYYY HH24:MI:SS') FACT_FECFACT, ");
            select.Append(" decode(FACT_ESTADO_V2, 'A', 'FACTURADA', FACT_ESTADO_V2) FACT_ESTADO, ");
            select.Append(" DEFA_PLANILLA_V2 DEFA_PLANILLA ");
            select.Append(" FROM FACTURAS, DET_FACTURAS ");
            select.Append(" WHERE FACT_NOFACTURA_NB = DEFA_FACTURA_NB ");
            select.Append(" AND FACT_ESTADO_V2 = 'A' ");
            select.Append(" AND DEFA_PLANILLA_V2 =:planilla; ");
            select.Append("end;");
            return select.ToString();
        }
        private string anticipos()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select VIAN_ESTADO_NB VIAN_ESTADO, ");
            select.Append(" VIAN_TIPOANTICIPO_V2 tipoAnticipo, ");
            select.Append(" VIAN_CHEQUENRO_NB chequenro, ");
            select.Append(" VIAN_COMPROBANTE_NB comprobante, ");
            select.Append(" VIAN_VALOR_NB valorCheque, ");
            select.Append(" VOLA_NOVOLANTE_NB VOLA_NOVOLANTE, ");
            select.Append(" VOLA_TIPOVOLANTE_V2, ");
            select.Append(" VOLA_VALOR_NB VOLA_VALOR, ");
            select.Append(" VOLA_NUMERO_NB ");
            select.Append(" from viajes_anticipos, volantes ");
            select.Append(" where VIAN_PLANILLA_V2 = VOLA_PLANILLA_V2(+) ");
            select.Append(" and VIAN_ESTADO_NB <> 'L' ");
            select.Append(" and VOLA_ESTADO_V2 <> 'L' ");
            select.Append(" and VIAN_SECUENCIA_NB = VOLA_SECANTICIPO_NB ");
            select.Append(" and VIAN_PLANILLA_V2 = :planilla; ");
            select.Append("end;");
            return select.ToString();
        }

        private string fletes()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select VIDE_VOLUMEN_V2 VIDE_VOLUMEN, ");
            select.Append(" VIDE_FLETEEMPR_NB VIDE_FLETEEMPR, ");
            select.Append(" VIDE_FLETECOND_NB VIDE_FLETECOND, ");
            select.Append(" VIDE_ESTADO_V2 VIDE_ESTADO, ");
            select.Append(" CUMP_KILOSDESPACHA_NB CUMP_KILOSDESPACHA, ");
            select.Append(" CUMP_KILOSRECIBE_NB CUMP_KILOSRECIBE, ");
            select.Append(" CUMP_ESTADO_V2 CUMP_ESTADO ");
            select.Append(" from viaje_destinos, cumplidos ");
            select.Append(" where VIDE_PLANILLA_V2 = CUMP_PLANILLA_V2 ");
            select.Append(" and VIDE_ESTADO_V2 <> 'L' ");
            select.Append(" and CUMP_ESTADO_V2 <> 'L' ");
            select.Append(" and CUMP_PLANILLA_V2 =:planilla; ");
            select.Append("end;");
            return select.ToString();
        }
        private string resumenMilenioOficina()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select OFIC_CODOFIC_NB idOficina, ");
            select.Append(" OFIC_NOMBRE_V2 oficina, ");
            select.Append(" ORCA_NUMERO_NB orden, ");
            select.Append(" to_char(ORCA_FECCREA_DT, 'DD/MM/YYYY HH24:MI:SS') fecOrden, ");
            select.Append(" decode(ORCA_ESTADO_V2, 'A', 'Anulado', 'N', 'TRANSITO', ORCA_ESTADO_V2) estOrden, ");
            select.Append(" VEHI_PLACA_CH vehiculo, ");
            select.Append(" TRAI_PLACA_CH trailer, ");
            select.Append(" VIAJ_NOPLANILLA_V2 planilla, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT, 'DD/MM/YYYY HH24:MI:SS') fecPlanilla, ");
            select.Append(" decode(VIAJ_ESTADO_V2, 'A', 'Anulado', 'D', 'Despachado Transito', 'N', 'TRANSITO', VIAJ_ESTADO_V2) estPlanilla, ");
            select.Append(" VIAJ_CELULAR_NB celular, ");
            select.Append(" EMPL_NOMBRE_V2 || ' ' || EMPL_APELLIDO_V2 funcionario, ");
            select.Append(" decode(VIAJ_CUMLIQ_V2,'C','Cumplida','N','Sin Cumplir',VIAJ_CUMLIQ_V2) cumliq, ");
            select.Append(" to_char(VIAJ_FECANULA_DT, 'DD/MM/YYYY HH24:MI:SS') fecAnula, ");
            select.Append(" COND_CEDULA_NB idConductor, ");
            select.Append(" COND_NOMBRE_V2 || ' ' || COND_APELLIDO_V2 conductor, ");
            select.Append(" pr.PROP_CEDULA_NB idPropietario, ");
            select.Append(" pr.PROP_NOMBRE_V2 || ' ' || pr.PROP_APELLIDO_V2 propietario, ");
            select.Append(" po.PROP_CEDULA_NB idPoseedor, ");
            select.Append(" po.PROP_NOMBRE_V2 || ' ' || po.PROP_APELLIDO_V2 poseedor, ");
            select.Append(" PROD_NOMBRE_V2 producto, ");
            select.Append(" NEGO_NRONEGOCIO_NB idNegocio, ");
            select.Append(" clineg.CLIE_CODIGO_NB codClienteNegocio, ");
            select.Append(" clineg.CLIE_NIT_NB idClienteNegocio, ");
            select.Append(" clineg.CLIE_NOMBRE_V2 clienteNegocio, ");
            select.Append(" clipaga.CLIE_CODIGO_NB codClientePaga, ");
            select.Append(" clipaga.CLIE_NIT_NB idClientePaga, ");
            select.Append(" clipaga.CLIE_NOMBRE_V2 clientePaga, ");
            select.Append(" pto.PLAN_CODIGO_NB idPlaOrigen, ");
            select.Append(" pto.PLAN_NOMBRE_V2 PlantaOrigen, ");
            select.Append(" cpo.CIUD_DESCRIPCION_V2 PLAN_ORIGEN, ");
            select.Append(" co.CIUD_DESCRIPCION_V2 Origen, ");
            select.Append(" ptd.PLAN_CODIGO_NB idPlaDestino, ");
            select.Append(" ptd.PLAN_NOMBRE_V2 PlantaDestino, ");
            select.Append(" cpd.CIUD_DESCRIPCION_V2 PLAN_DESTINO, ");
            select.Append(" cd.CIUD_DESCRIPCION_V2 destino ");
            select.Append(" from ordenes_cargue, oficinas, vehiculos, trailers, viajes, empleados, conductores, propietarios pr, propietarios po, ");
            select.Append(" rutas, ciudades co, ciudades cd, plantas pto, plantas ptd, ciudades cpo, ciudades cpd, negocios, clientes clineg, ");
            select.Append(" clientes clipaga, productos ");
            select.Append(" where ORCA_NUMERO_NB = VIAJ_ORDCARGUE_NB(+) ");
            select.Append(" and ORCA_OFICDESP_NB = OFIC_CODOFIC_NB ");
            select.Append(" and ORCA_PLACA_CH = VEHI_PLACA_CH ");
            select.Append(" and ORCA_TRAILER_CH = TRAI_PLACA_CH(+) ");
            select.Append(" and VIAJ_USUCREA_NB = EMPL_CEDULA_NB ");
            select.Append(" and ORCA_CONDUCTOR_NB = COND_CEDULA_NB ");
            select.Append(" and VIAJ_PROPIETARIO_NB = pr.PROP_CEDULA_NB ");
            select.Append(" and VIAJ_POSEEDOR_NB = po.PROP_CEDULA_NB ");
            select.Append(" and ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append(" and RUTA_ORIGEN_NB = co.CIUD_CODIGO_NB ");
            select.Append(" and RUTA_DESTINO_NB = cd.CIUD_CODIGO_NB ");
            select.Append(" and ORCA_NEGOCIO_NB = NEGO_NRONEGOCIO_NB ");
            select.Append(" and NEGO_CLIENTENEGO_NB = clineg.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_CLIENTEPAGA_NB = clipaga.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_PRODUCTO_NB = PROD_CODIGO_NB ");
            select.Append(" and ORCA_PLANTAREMITE_NB = pto.PLAN_CODIGO_NB ");
            select.Append(" and ORCA_PLANTARECIBE_NB = ptd.PLAN_CODIGO_NB ");
            select.Append(" and pto.PLAN_CIUDAD_NB = cpo.CIUD_CODIGO_NB ");
            select.Append(" and ptd.PLAN_CIUDAD_NB = cpd.CIUD_CODIGO_NB ");
            //sbSelect.Append(" and trunc(ORCA_FECCREA_DT) = trunc(sysdate) ");
            select.Append(" and trunc(ORCA_FECCREA_DT) between trunc(:fecini) and trunc(:fecfin) ");
            select.Append(" and ORCA_OFICDESP_NB = :oficina ");
            select.Append(" order by ORCA_FECCREA_DT; ");
            select.Append("end;");
            return select.ToString();
        }


        private string resumenMilenioTodas()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select OFIC_CODOFIC_NB idOficina, ");
            select.Append("  OFIC_NOMBRE_V2 oficina, ");
            select.Append("  ORCA_NUMERO_NB orden, ");
            select.Append("  to_char(ORCA_FECCREA_DT, 'DD/MM/YYYY HH24:MI:SS') fecOrden, ");
            select.Append("  decode(ORCA_ESTADO_V2, 'A', 'Anulado', 'N', 'TRANSITO', ORCA_ESTADO_V2) estOrden, ");
            select.Append("  VEHI_PLACA_CH vehiculo, ");
            select.Append("  TRAI_PLACA_CH trailer, ");
            select.Append("  VIAJ_NOPLANILLA_V2 planilla, ");
            select.Append("  to_char(VIAJ_FECVIAJE_DT, 'DD/MM/YYYY HH24:MI:SS') fecPlanilla, ");
            select.Append("  decode(VIAJ_ESTADO_V2, 'A', 'Anulado', 'D', 'Despachado Transito', 'N', 'TRANSITO', VIAJ_ESTADO_V2) estPlanilla, ");
            select.Append("  VIAJ_CELULAR_NB celular, ");
            select.Append("  EMPL_NOMBRE_V2 || ' ' || EMPL_APELLIDO_V2 funcionario, ");
            select.Append("  decode(VIAJ_CUMLIQ_V2,'C','Cumplida','N','Sin Cumplir',VIAJ_CUMLIQ_V2) cumliq, ");
            select.Append("  to_char(VIAJ_FECANULA_DT, 'DD/MM/YYYY HH24:MI:SS') fecAnula, ");
            select.Append("  COND_CEDULA_NB idConductor, ");
            select.Append("  COND_NOMBRE_V2 || ' ' || COND_APELLIDO_V2 conductor, ");
            select.Append("  pr.PROP_CEDULA_NB idPropietario, ");
            select.Append("  pr.PROP_NOMBRE_V2 || ' ' || pr.PROP_APELLIDO_V2 propietario, ");
            select.Append("  po.PROP_CEDULA_NB idPoseedor, ");
            select.Append("  po.PROP_NOMBRE_V2 || ' ' || po.PROP_APELLIDO_V2 poseedor, ");
            select.Append("  PROD_NOMBRE_V2 producto, ");
            select.Append("  NEGO_NRONEGOCIO_NB idNegocio, ");
            select.Append("  clineg.CLIE_CODIGO_NB codClienteNegocio, ");
            select.Append("  clineg.CLIE_NIT_NB idClienteNegocio, ");
            select.Append("  clineg.CLIE_NOMBRE_V2 clienteNegocio, ");
            select.Append("  clipaga.CLIE_CODIGO_NB codClientePaga, ");
            select.Append("  clipaga.CLIE_NIT_NB idClientePaga, ");
            select.Append("  clipaga.CLIE_NOMBRE_V2 clientePaga, ");
            select.Append("  pto.PLAN_CODIGO_NB idPlaOrigen, ");
            select.Append("  pto.PLAN_NOMBRE_V2 PlantaOrigen, ");
            select.Append(" cpo.CIUD_DESCRIPCION_V2 PLAN_ORIGEN, ");
            select.Append(" co.CIUD_DESCRIPCION_V2 Origen, ");
            select.Append(" ptd.PLAN_CODIGO_NB idPlaDestino, ");
            select.Append(" ptd.PLAN_NOMBRE_V2 PlantaDestino, ");
            select.Append(" cpd.CIUD_DESCRIPCION_V2 PLAN_DESTINO, ");
            select.Append(" cd.CIUD_DESCRIPCION_V2 destino ");
            select.Append(" from ordenes_cargue, oficinas, vehiculos, trailers, viajes, empleados, conductores, propietarios pr, propietarios po, ");
            select.Append(" rutas, ciudades co, ciudades cd, plantas pto, plantas ptd, ciudades cpo, ciudades cpd, negocios, clientes clineg, ");
            select.Append(" clientes clipaga, productos ");
            select.Append(" where ORCA_NUMERO_NB = VIAJ_ORDCARGUE_NB(+) ");
            select.Append(" and ORCA_OFICDESP_NB = OFIC_CODOFIC_NB ");
            select.Append(" and ORCA_PLACA_CH = VEHI_PLACA_CH ");
            select.Append(" and ORCA_TRAILER_CH = TRAI_PLACA_CH(+) ");
            select.Append(" and VIAJ_USUCREA_NB = EMPL_CEDULA_NB ");
            select.Append(" and ORCA_CONDUCTOR_NB = COND_CEDULA_NB ");
            select.Append(" and VIAJ_PROPIETARIO_NB = pr.PROP_CEDULA_NB ");
            select.Append(" and VIAJ_POSEEDOR_NB = po.PROP_CEDULA_NB ");
            select.Append(" and ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append(" and RUTA_ORIGEN_NB = co.CIUD_CODIGO_NB ");
            select.Append(" and RUTA_DESTINO_NB = cd.CIUD_CODIGO_NB ");
            select.Append(" and ORCA_NEGOCIO_NB = NEGO_NRONEGOCIO_NB ");
            select.Append(" and NEGO_CLIENTENEGO_NB = clineg.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_CLIENTEPAGA_NB = clipaga.CLIE_CODIGO_NB ");
            select.Append(" and ORCA_PRODUCTO_NB = PROD_CODIGO_NB ");
            select.Append(" and ORCA_PLANTAREMITE_NB = pto.PLAN_CODIGO_NB ");
            select.Append(" and ORCA_PLANTARECIBE_NB = ptd.PLAN_CODIGO_NB ");
            select.Append(" and pto.PLAN_CIUDAD_NB = cpo.CIUD_CODIGO_NB ");
            select.Append(" and ptd.PLAN_CIUDAD_NB = cpd.CIUD_CODIGO_NB ");
            //sbSelect.Append(" and trunc(ORCA_FECCREA_DT) = trunc(sysdate) ");
            select.Append(" and trunc(ORCA_FECCREA_DT) between trunc(:fecini) and trunc(:fecfin) ");
            //sbSelect.Append(" and ORCA_OFICDESP_NB = 36 ");
            select.Append(" order by ORCA_FECCREA_DT; ");
            select.Append("end;");
            return select.ToString();
        }

        private string InformacionDian21()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL ");
            select.Append(" from informacion_dian_21 ");
            select.Append(" where INDI_NUMDOC_V2 =:numdoc ");
            select.Append(" and INDI_TIPODOC_V2 =:tipodoc ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getLogReporteDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LODI_SECUENCIA_NB, ");
            select.Append(" LODI_OFICINA_NB, ");
            select.Append(" LODI_TRANSACCION_NB, ");
            select.Append(" LODI_LLAVE_V2, ");
            select.Append(" LODI_FECREGISTRO_DT, ");
            select.Append(" LODI_ESTADO_V2, ");
            select.Append(" LODI_CAMPO1_NB, ");
            select.Append(" LODI_CAMPO2_V2, ");
            select.Append(" LODI_CAMPO3_DT, ");
            select.Append(" LODI_ESTADODIAN_V2 ");
            select.Append(" from log_reporte_dian ");
            select.Append(" where LODI_ESTADO_V2 =:LODI_ESTADO ");
            //select.Append(" and LODI_LLAVE_V2 ='SETT199' ");
            select.Append(" order by LODI_FECREGISTRO_DT; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            //select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL ");
            select.Append(" from informacion_dian ");
            select.Append(" where INDI_NUMDOC_V2 =:INDI_NUMDOC ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInformacionDianEnProceso()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            //select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL ");
            select.Append(" from informacion_dian ");
            select.Append(" where INDI_CUFEDIAN_V2 ='EN PROCESO' ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string pdbInfoDianFactura()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_fc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_FC_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianNota()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_nc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_NC_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianFacturaOperativo()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_fc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_FM_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianNotaOperativo()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_nc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_NCT_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string FDB_LEER_ANEXOS_DIAN()
        {
            StringBuilder select = new StringBuilder();
            select.Append("FDB_LEER_ANEXOS_DIAN");
            /*select.Append(" declare ");
            select.Append(" refcur1 SYS_REFCURSOR;  ");
            select.Append(" begin ");
            select.Append(" refcur1:=FDB_LEER_ANEXOS_DIAN (p_numdoc_v,p_oficina_n,p_tipodoc_v); ");
            select.Append(" end; ");*/
            return select.ToString();
        }
        private string getCliente()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select CLIE_NOMBRE_V2 cliente ");
            select.Append(" from facturas,clientes ");
            select.Append(" where FACT_CLIEPAGA_NB=CLIE_CODIGO_NB ");
            select.Append(" and FACT_NOFACTURA_NB=:factura;");
            select.Append("end;");
            return select.ToString();
        }
        private string UploadRequestFE()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append("  begin ");
            select.Append("  declare ");
            select.Append(" begin ");
            select.Append(" insert into upload (uplo_secuencia_nb,uplo_fechaenvio_ts,uplo_filename_v2,uplo_filedata_bl,uplo_companyid_v2, uplo_accountid_v2, uplo_status_v2, uplo_transactionid_v2, uplo_xmlfactura_bl, uplo_soapenviado_bl, uplo_soaprespuesta_bl) ");
            select.Append(" values (upload_sequence.nextval,sysdate,:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta);end;");
            select.Append(" end;");
            return select.ToString();
        }
        private string insertDetLogDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append("  declare  ");
            select.Append("  begin  ");
            select.Append("  insert into det_log_dian (DELD_SECUENCIA_NB,  ");
            select.Append("  DELD_LOGSECUENCIA_NB,  ");
            select.Append("  DELD_OFICINA_NB,  ");
            select.Append("  DELD_TRANSACCION_NB,  ");
            select.Append("  DELD_LLAVE_V2,  ");
            select.Append("  DELD_ESTADO_V2,  ");
            select.Append("  DELD_IDDIAN_V2,  ");
            select.Append("  DELD_CUFEDIAN_V2,  ");
            select.Append("  DELD_SOAPENVIADO_BL,  ");
            select.Append("  DELD_FECHAENVIO_DT,  ");
            select.Append("  DELD_SOAPRECIBIDO_BL,  ");
            select.Append("  DELD_CAMPO1_NB,  ");
            select.Append("  DELD_CAMPO2_V2,  ");
            select.Append("  DELD_CAMPO3_DT)  ");
            select.Append("  values ((select count(deld_secuencia_nb)+1 from det_log_dian where DELD_LOGSECUENCIA_NB=:secuencia),:secuencia,:oficina,:transacion,:llave,:estado,:iddian,:cufe,:soapEnviado,sysdate,:soapRecibido,null,null,null);  ");
            select.Append("  end;  ");
            return select.ToString();
        }
        private string updateLogReporteDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_dian set ");
            select.Append(" lodi_estado_v2=:estado ");
            select.Append(" where lodi_llave_v2=:factura;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" INDI_IDCARVAJAL_V2=:INDI_IDCARVAJAL,");
            select.Append(" INDI_CUFEDIAN_V2=:INDI_CUFEDIAN");
            select.Append(" where INDI_NUMDOC_V2=:INDI_NUMDOC;");
            select.Append(" end; ");
            return select.ToString();
        }
        private string updateInfoDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" indi_cufedian_v2=:INDI_CUFEDIAN, ");
            //select.Append(" indi_xmllegal_cb=:indi_xmllegal ");
            select.Append(" indi_xmlrec_bl=:indi_xmlrec ");
            select.Append(" where indi_numdoc_v2=:INDI_NUMDOC;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateDetLogDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update det_log_dian set ");
            select.Append(" DELD_CUFEDIAN_V2=:DELD_CUFEDIAN, ");
            select.Append(" DELD_ESTADO_V2='E'");
            select.Append(" where DELD_LLAVE_V2=:DELD_LLAVE;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateLogReporteDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_dian set ");
            select.Append(" LODI_ESTADO_V2='E', ");
            select.Append(" LODI_ESTADODIAN_V2='E', ");
            select.Append(" LODI_CAMPO3_DT=sysdate ");
            select.Append(" where LODI_LLAVE_V2=:LODI_LLAVE;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateInfoDianFactura()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" indi_repgrafica_bl=:indi_repgrafica ");
            select.Append(" where indi_numdoc_v2=:INDI_NUMDOC;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2 ");
            select.Append(" from LOG_REPORTE_BAVARIA ");
            select.Append(" where REBA_SECUENCIA_NB > 67414 ");
            select.Append(" and REBA_ESTADO_V2='P' ");
            //select.Append(" and trunc(REBA_FECHA_DT) between trunc(sysdate-341) and trunc(sysdate-59) ");
            //select.Append(" and trunc(REBA_FECHA_DT) between trunc(sysdate-341) and trunc(sysdate-300) ");
            select.Append(" order by REBA_SECUENCIA_NB; ");
            //select.Append(" and REBA_ESTADO_V2 = :REBA_ESTADO; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getLogReporteBavariaTMP()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2 ");
            select.Append(" from LOG_REPORTE_BAVARIA ");
            select.Append(" where REBA_ESTADO_V2 = :REBA_ESTADO; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInfoBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" SELECT V.VIAJ_NOPLANILLA_V2, ");
            select.Append(" O.OFIC_NOMBRE_V2, ");
            select.Append(" V.VIAJ_PLACA_CH, ");
            select.Append(" CV.CLVE_DESCRIP_V2, ");
            select.Append(" V.VIAJ_TRAILER_CH, ");
            select.Append(" V.VIAJ_FECVIAJE_DT, ");
            select.Append(" CM.CAMI_KMSTOTAL_NB, ");
            select.Append(" C.COND_NOMBRE_V2 || ' ' || C.COND_APELLIDO_V2 CONDUCTOR, ");
            select.Append(" C.COND_CEDULA_NB, ");
            select.Append(" CO.CIUD_DESCRIPCION_V2 CIUD_ORIGEN, ");
            select.Append(" CO.CIUD_CODIGO_NB COD_ORIGEN, ");
            select.Append(" CD.CIUD_DESCRIPCION_V2 CIUD_DESTINO, ");
            select.Append(" CD.CIUD_CODIGO_NB COD_DESTINO, ");
            select.Append(" CO.CIUD_DESCRIPCION_V2 || '-' || CD.CIUD_DESCRIPCION_V2 ORIGEN_DESTINO, ");
            select.Append(" O.ORCA_RUTA_NB, ");
            select.Append(" P.PROD_NOMBRE_V2, ");
            select.Append(" EMPAQ.GENE_DESCRIPCION_V2 ");
            select.Append(" FROM VIAJES V, OFICINAS O, CONDUCTORES C, ORDENES_CARGUE O, RUTAS R, ");
            select.Append(" CIUDADES CO, CIUDADES CD, VIAJE_DESTINOS VD, CUMPLIDOS M, ");
            select.Append(" PRODUCTOS P, VEHICULOS H, CLASE_VEHICULO CV, CAMINOS CM, GENERICAS EMPAQ ");
            select.Append(" WHERE V.VIAJ_OFDESPACHA_NB = O.OFIC_CODOFIC_NB ");
            select.Append(" AND V.VIAJ_CONDUCTOR_NB = C.COND_CEDULA_NB ");
            select.Append(" AND V.VIAJ_ORDCARGUE_NB = O.ORCA_NUMERO_NB ");
            select.Append(" AND CO.CIUD_CODIGO_NB = R.RUTA_ORIGEN_NB ");
            select.Append(" AND CD.CIUD_CODIGO_NB = R.RUTA_DESTINO_NB ");
            select.Append(" AND V.VIAJ_NOPLANILLA_V2 = M.CUMP_PLANILLA_V2 ");
            select.Append(" AND M.CUMP_NEGOCIO_NB = VD.VIDE_NEGOCIO_NB ");
            select.Append(" AND M.CUMP_NEGRUTSEC_NB = VD.VIDE_NEGRUTSEC_NB ");
            select.Append(" AND M.CUMP_PLANILLA_V2 = VD.VIDE_PLANILLA_V2 ");
            select.Append(" AND M.CUMP_NERUCAMINO_NB = VD.VIDE_NERUCAMINO_NB ");
            select.Append(" AND M.CUMP_NERURUTA_NB = VD.VIDE_NERURUTA_NB ");
            select.Append(" AND M.CUMP_PRODUCTO_NB = P.PROD_CODIGO_NB ");
            select.Append(" AND V.VIAJ_PLACA_CH = H.VEHI_PLACA_CH ");
            select.Append(" AND H.VEHI_CLASE_NB = CV.CLVE_SECUENCIA_NB ");
            select.Append(" AND VD.VIDE_NERURUTA_NB = R.RUTA_CODIGO_NB ");
            select.Append(" AND VD.VIDE_NERURUTA_NB = CM.CAMI_RUTA_NB ");
            select.Append(" AND VD.VIDE_NERUCAMINO_NB = CM.CAMI_SECUENCIA_NB ");
            select.Append(" AND M.CUMP_TIPOEMPAQUE_NB = EMPAQ.GENE_CODIGO_NB ");
            select.Append(" AND EMPAQ.GENE_NOMBRE_V2 = 'TIPOEMPAQUE' ");
            select.Append(" AND VD.VIDE_ESTADO_V2 != 'L' ");
            select.Append(" AND M.CUMP_ESTADO_V2 != 'L' ");
            select.Append(" AND V.VIAJ_NOPLANILLA_V2 =:VIAJ_NOPLANILLA; ");
            select.Append("end;");
            return select.ToString();
        }
        private string InsertDetLogBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" insert into det_log_bavaria(DEBA_SECUENCIA_NB,DEBA_LOGBAVARIA_NB,DEBA_OFICINA_NB,DEBA_TRANSACCION_NB,DEBA_LLAVE_V2,DEBA_NUMACEPTA_NB,DEBA_ESTADO_V2,DEBA_SOAPENVIADO_V2,DEBA_SOAPRECIBIDO_V2,DEBA_FECPROCESA_DT,DEBA_CAMPO1_NB,DEBA_CAMPO2_DT,DEBA_CAMPO3_V2) ");
            select.Append(" values ((select count(DEBA_SECUENCIA_NB)+1 from det_log_bavaria where DEBA_LOGBAVARIA_NB=:logbavaria and DEBA_OFICINA_NB=:oficina),:logbavaria,:oficina,4,:llave,:numacepta,:estado,:Bavariasoapenviado,:Bavariasoaprecibido,sysdate,null,null,null); ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string UpdateLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_bavaria set ");
            select.Append(" REBA_ESTADO_V2=:REBA_ESTADO_V2 ");
            select.Append(" where REBA_SECUENCIA_NB=:REBA_SECUENCIA_NB ");
            select.Append(" and REBA_OFICINA_NB=:REBA_OFICINA_NB; ");
            select.Append(" end;  ");
            return select.ToString();
        }
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
            //select.Append(" and LRMI_SECUENCIA_NB<3062409  ");
            //select.Append(" and LRMI_SECUENCIA_NB<3062409  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }


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
        private string PK_MINISTERIO_XML_CUMPLIDO_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte, ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB consecutivoRemesa, ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga, ");
            select.Append(" 'C' tipoCumplidoRemesa, ");
            select.Append(" '' motivoSuspensionRemesa, ");
            select.Append(" /*NVL(SUM(CUMPLIDOS.CUMP_KILOSDESPACHA_NB),0)*/FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada, ");
            select.Append(" /*NVL(SUM(CUMPLIDOS.CUMP_KILOSRECIBE_NB),0)*/FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada, ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB,'K',1,'V',1,ORCA_VOLUMEN_NB) unidadMedidaCapacidad, ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB-0.18/24),'DD/MM/YYYY') fechaLlegadaCargue, ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB-0.18/24),'HH24:MI') horaLlegadaCargueRemesa, ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB,'DD/MM/YYYY') fechaEntradaCargue, ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB /*+ (0.18/24)*/,'HH24:MI') horaEntradaCargueRemesa, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB,'DD/MM/YYYY') fechaSalidaCargue, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB /*+ (0.18/24*/,'HH24:MI') horaSalidaCargueRemesa, ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB-0.18/24),'DD/MM/YYYY') fechaLlegadaDescargue, ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB-0.18/24),'HH24:MI') horaLlegadaDescargueCumplido, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB,'DD/MM/YYYY') fechaEntradaDescargue, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB /*+ (0.18/24)*/,'HH24:MI') horaEntradaDescargueCumplido, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB,'DD/MM/YYYY') fechaSalidaDescargue, ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB /*+ (0.60/24)*/,'HH24:MI') horaSalidaDescargueCumplido, ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2,1,200) observaciones ");
            //select.Append(" FROM TIEMPOS_QM@milebog1, TIEMPOS_QM@milebog1 TIEMPOS_QM_A1, ");
            select.Append(" FROM TIEMPOS_QM, TIEMPOS_QM TIEMPOS_QM_A1, ");
            //select.Append(" TIEMPOS_QM@milebog1 TIEMPOS_QM_A2, TIEMPOS_QM@milebog1 TIEMPOS_QM_A3,         ");
            select.Append(" TIEMPOS_QM TIEMPOS_QM_A2, TIEMPOS_QM TIEMPOS_QM_A3,         ");
            select.Append(" ORDENES_CARGUE, VIAJES, CUMPLIDOS ");
            select.Append(" WHERE TIEMPOS_QM.MESQ_ORDENCARGUE_NB=:llave ");
            select.Append(" AND TIEMPOS_QM.MESQ_NUMACRO_NB=2 ");
            select.Append(" AND TIEMPOS_QM_A1.MESQ_NUMACRO_NB=6 ");
            select.Append(" AND TIEMPOS_QM_A2.MESQ_NUMACRO_NB=15 ");
            select.Append(" AND TIEMPOS_QM_A3.MESQ_NUMACRO_NB=19 ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB=TIEMPOS_QM.MESQ_ORDENCARGUE_NB ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB=TIEMPOS_QM_A1.MESQ_ORDENCARGUE_NB ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB=TIEMPOS_QM_A3.MESQ_ORDENCARGUE_NB ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB=TIEMPOS_QM_A2.MESQ_ORDENCARGUE_NB ");
            select.Append(" AND VIAJES.VIAJ_ORDCARGUE_NB=ORDENES_CARGUE.ORCA_NUMERO_NB ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=CUMPLIDOS.CUMP_PLANILLA_V2 ");
            select.Append(" AND ROWNUM<2 ");
            select.Append(" group by ORCA_NUMERO_NB,VIAJ_NOPLANILLA_V2,ORCA_VOLUMEN_NB,TIEMPOS_QM.MESQ_POSTIME_NB, ");
            select.Append(" TIEMPOS_QM_A2.MESQ_NUMACRO_NB,TIEMPOS_QM_A1.MESQ_POSTIME_NB,CUMP_OBSERVACIONES_V2, ");
            select.Append(" TIEMPOS_QM_A3.MESQ_POSTIME_NB,TIEMPOS_QM_A2.MESQ_POSTIME_NB ");
            select.Append(" union ");
            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte, ");
            select.Append(" VIAJES.VIAJ_ORDCARGUE_NB consecutivoRemesa, ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga, ");
            select.Append(" 'C' tipoCumplidoRemesa, ");
            select.Append(" '' motivoSuspensionRemesa, ");
            select.Append(" /*NVL(SUM(CUMPLIDOS.CUMP_KILOSDESPACHA_NB),0)*/FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada, ");
            select.Append(" /*NVL(SUM(CUMPLIDOS.CUMP_KILOSRECIBE_NB),0)*/FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada, ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB,'K',1,'V',1,ORCA_VOLUMEN_NB) unidadMedidaCapacidad, ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT-0.18/24),'DD/MM/YYYY') fechaLlegadaCargue, ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT-0.18/24),'HH24:MI') horaLlegadaCargueRemesa, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT,'DD/MM/YYYY') fechaEntradaCargue, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT /*+ (0.18/24)*/,'HH24:MI') horaEntradaCargueRemesa, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT,'DD/MM/YYYY') fechaSalidaCargue, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT /*+ (0.18/24)*/,'HH24:MI') horaSalidaCargueRemesa, ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT-0.18/24),'DD/MM/YYYY') fechaLlegadaDescargue, ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT-0.18/24),'HH24:MI') horaLlegadaDescargueCumplido, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT,'DD/MM/YYYY') fechaEntradaDescargue, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT /*+ (0.18/24)*/,'HH24:MI') horaEntradaDescargueCumplido, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT,'DD/MM/YYYY') fechaSalidaDescargue, ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT /*+ (0.18/24)*/,'HH24:MI') horaSalidaDescargueCumplido, ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2,1,200) observaciones ");
            select.Append(" FROM CUMPLIDOS_TIEMPOS, CUMPLIDOS_TIEMPOS CUMPLIDOS_TIEMPOS_A1,VIAJES, CUMPLIDOS, ");
            select.Append(" ORDENES_CARGUE ");
            select.Append(" WHERE CUMPLIDOS_TIEMPOS.CUTI_TIPOCARDES_V2='C' ");
            select.Append(" AND CUMPLIDOS_TIEMPOS_A1.CUTI_TIPOCARDES_V2='D' ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_SECCUMP_NB=CUMPLIDOS_TIEMPOS_A1.CUTI_SECCUMP_NB ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGOCIO_NB=CUMPLIDOS_TIEMPOS_A1.CUTI_NEGOCIO_NB ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2=CUMPLIDOS_TIEMPOS_A1.CUTI_PLANILLA_V2 ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGRUTSEC_NB=CUMPLIDOS_TIEMPOS_A1.CUTI_NEGRUTSEC_NB ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERUCAMINO_NB=CUMPLIDOS_TIEMPOS_A1.CUTI_NERUCAMINO_NB ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERURUTA_NB=CUMPLIDOS_TIEMPOS_A1.CUTI_NERURUTA_NB ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2 ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=CUMPLIDOS.CUMP_PLANILLA_V2 ");
            select.Append(" AND VIAJ_ORDCARGUE_NB=ORCA_NUMERO_NB ");
            select.Append(" and ORCA_NUMERO_NB=:llave ");
            select.Append(" GROUP BY VIAJES.VIAJ_ORDCARGUE_NB, VIAJES.VIAJ_NOPLANILLA_V2,CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT, ");
            select.Append(" CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT,CUMPLIDOS.CUMP_MEDIDAFALTA_V2,ORCA_VOLUMEN_NB, ");
            select.Append(" CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT,CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT,CUMPLIDOS.CUMP_OBSERVACIONES_V2 ");
            select.Append(" /***************************************************************/ ");
            select.Append(" union ");
            select.Append(" select DISTINCT 8605048823 numNitEmpresaTransporte, ");
            select.Append(" R.VITI_ORDCARGUE_NB consecutivoRemesa, ");
            select.Append(" VIAJ_NOPLANILLA_V2 numManifiestoCarga, ");
            select.Append(" 'C' tipoCumplidoRemesa, ");
            select.Append(" '' motivoSuspensionRemesa, ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada, ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada, ");
            select.Append(" DECODE(R.ORCA_VOLUMEN_NB,'K',1,'V',1,R.ORCA_VOLUMEN_NB) unidadMedidaCapacidad, ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT-0.18/24),'DD/MM/YYYY') fechaLlegadaCargue, ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT-0.18/24),'HH24:MI') horaLlegadaCargueRemesa, ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT),'DD/MM/YYYY') fechaEntradaCargue, ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT),'HH24:MI') horaEntradaCargueRemesa, ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT),'DD/MM/YYYY') fechaSalidaCargue, ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT),'HH24:MI') horaSalidaCargueRemesa, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT-0.18/24),'DD/MM/YYYY') fechaLlegadaDescargue, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT-0.18/24),'HH24:MI') horaLlegadaDescargueCumplido, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT),'DD/MM/YYYY') fechaEntradaDescargue, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT),'HH24:MI') horaEntradaDescargueCumplido, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT),'DD/MM/YYYY') fechaSalidaDescargue, ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT),'HH24:MI') horaSalidaDescargueCumplido, ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2,1,200) observaciones ");
            select.Append(" FROM viajes_tiempos R,viajes_tiempos D,ORDENES_CARGUE R,ORDENES_CARGUE D,VIAJES, ");
            select.Append(" cumplidos ");
            select.Append(" WHERE R.VITI_ORDCARGUE_NB=R.ORCA_NUMERO_NB ");
            select.Append(" AND R.VITI_PLANTA_NB=R.ORCA_PLANTAREMITE_NB ");
            select.Append(" AND D.VITI_ORDCARGUE_NB=D.ORCA_NUMERO_NB ");
            select.Append(" AND D.VITI_PLANTA_NB=D.ORCA_PLANTARECIBE_NB ");
            select.Append(" AND R.VITI_ORDCARGUE_NB=D.VITI_ORDCARGUE_NB ");
            select.Append(" AND D.VITI_ORDCARGUE_NB=:llave ");
            select.Append(" AND D.VITI_ORDCARGUE_NB=VIAJ_ORDCARGUE_NB ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=CUMPLIDOS.CUMP_PLANILLA_V2; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_PROPIETARIOS_NIT()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT '8605048823' numNitEmpresaTransporte,PROP_TIPOIDEN_V2 codTipoIdTercero,PROP_CEDULA_NB||decode(length(PROP_CEDULA_NB),10,null,9,f_chequeonit(PROP_CEDULA_NB,1),null) numIdTercero, ");
            select.Append(" PROP_NOMBRE_V2 nomIdTercero,null primerApellidoIdTercero,null segundoApellidoIdTercero,PROP_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(PROP_DIRECCION_V2,1,60) nomenclaturaDireccion,substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc,'1' codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero ");
            select.Append(" from propietarios,ciudades ");
            select.Append(" where PROP_TIPOIDEN_V2='N' ");
            select.Append(" and PROP_CIUDRES_NB=CIUD_CODIGO_NB ");
            select.Append(" and PROP_CEDULA_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
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
            select.Append(" 8605048823 NUMNITEMPRESATRANSPORTE ");
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

            select.Append(" end; ");
            return select.ToString();
        }
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
        private string UpdateLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO ");
            //select.Append(" LRMI_CAMPO1_NB =:LRMI_CAMPO1 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string UpdateLogReporteMinisterioCampo1()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO, ");
            select.Append(" LRMI_CAMPO1_NB =:LRMI_CAMPO1 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getInfoLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2, ");
            select.Append(" REBA_CAMPO1_NB, ");
            select.Append(" REBA_CAMPO2_DT, ");
            select.Append(" REBA_CAMPO3_V2 ");
            select.Append(" from log_reporte_bavaria ");
            select.Append(" where trunc(REBA_FECHA_DT) between trunc(sysdate-400) and trunc(sysdate) ");
            select.Append(" order by REBA_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getDetalleDetLogBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DEBA_SECUENCIA_NB, ");
            select.Append(" DEBA_LOGBAVARIA_NB, ");
            select.Append(" DEBA_OFICINA_NB, ");
            select.Append(" DEBA_TRANSACCION_NB, ");
            select.Append(" DEBA_LLAVE_V2, ");
            select.Append(" DEBA_NUMACEPTA_NB, ");
            select.Append(" DEBA_ESTADO_V2, ");
            select.Append(" DEBA_SOAPENVIADO_V2, ");
            select.Append(" DEBA_SOAPRECIBIDO_V2, ");
            select.Append(" DEBA_FECPROCESA_DT, ");
            select.Append(" DEBA_CAMPO1_NB, ");
            select.Append(" DEBA_CAMPO2_DT, ");
            select.Append(" DEBA_CAMPO3_V2 ");
            select.Append(" from det_log_bavaria ");
            select.Append(" where DEBA_LOGBAVARIA_NB =:DEBA_LOGBAVARIA ");
            select.Append(" and DEBA_OFICINA_NB =:DEBA_OFICINA ");
            select.Append(" and DEBA_LLAVE_V2 =:DEBA_LLAVE ");
            select.Append(" order by DEBA_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getOficinas()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select OFIC_CODDPTO_NB,  ");
            select.Append(" OFIC_CODOFIC_NB, ");
            select.Append(" OFIC_NOMBRE_V2, ");
            select.Append(" OFIC_CIUDAD_NB, ");
            select.Append(" OFIC_DIRECCION_V2, ");
            select.Append(" OFIC_TELEFONO_1_NB, ");
            select.Append(" OFIC_TELEFONO_2_NB, ");
            select.Append(" OFIC_INDICATIVO_NB, ");
            select.Append(" OFIC_CENCOST_NB, ");
            select.Append(" OFIC_ADMIN_NB, ");
            select.Append(" OFIC_EMAIL_V2, ");
            select.Append(" OFIC_EMPRESA_NB, ");
            select.Append(" OFIC_GERENCIA_NB  ");
            select.Append(" from oficinas  ");
            select.Append(" union ");
            select.Append(" select 1 OFIC_CODDPTO_NB, ");
            select.Append(" 0 OFIC_CODOFIC_NB, ");
            select.Append(" 'TODAS LAS OFICINAS' OFIC_NOMBRE_V2, ");
            select.Append(" 0 OFIC_CIUDAD_NB, ");
            select.Append(" ' N/A ' OFIC_DIRECCION_V2, ");
            select.Append(" 0 OFIC_TELEFONO_1_NB, ");
            select.Append(" 0 OFIC_TELEFONO_2_NB, ");
            select.Append(" 0 OFIC_INDICATIVO_NB, ");
            select.Append(" 0 OFIC_CENCOST_NB, ");
            select.Append(" 75145705 OFIC_ADMIN_NB, ");
            select.Append(" ' ' OFIC_EMAIL_V2, ");
            select.Append(" 0 OFIC_EMPRESA_NB, ");
            select.Append(" 0 OFIC_GERENCIA_NB ");
            select.Append(" from dual ");
            select.Append(" order by 2; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getEstadosRobots()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DISTINCT decode(LRMI_ESTADO_V2,'P','PENDIENTE','E','ENVIADO','R','RECHAZADO','U','URBANO',LRMI_ESTADO_V2) ESTA_NOMBRE_V2, ");
            select.Append(" LRMI_ESTADO_V2 ESTA_VALOR_V2, ");
            select.Append(" decode(LRMI_ESTADO_V2, 'P', 1, 'E', 2, 'R', 3, 'U', 4, 5) ESTA_CODIGO_NB ");
            select.Append(" from log_reporte_ministerio ");
            select.Append(" where LRMI_ESTADO_V2 in ('P', 'E', 'R', 'U') ");
            select.Append(" union ");
            select.Append(" select 'TODOS LOS ESTADOS' ESTA_NOMBRE_V2, ");
            select.Append(" 'X' ESTA_VALOR_V2, ");
            select.Append(" 0 ESTA_CODIGO_NB ");
            select.Append(" from dual ");
            select.Append(" order by 3; ");
            select.Append("end;");
            return select.ToString();
        }

        private string getExecuteQuery(string[] _nParametros, object[] _vParametros)
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append("end;");
            return select.ToString();
        }
        private string getViajesEntreFechas(string[] _nParametros, object[] _vParametros)
        {
            int codOficina = int.Parse(_vParametros[2].ToString());
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select OFIC_NOMBRE_V2, ");
            select.Append(" VIAJ_NOPLANILLA_V2, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT, 'DD/MM/YYYY HH24:MI:SS') VIAJ_FECVIAJE_DT ");
            //select.Append(" LRMI_SECUENCIA_NB, ");
            //select.Append(" LRMI_OFICINA_NB, ");
            //select.Append(" to_char(LRMI_FECREGISTRO_DT, 'DD/MM/YYYY HH24:MI:SS') LRMI_FECREGISTRO_DT, ");
            //select.Append(" decode(LRMI_ESTADO_V2,'P','Pendiente','E','Enviado','R','Rechazado','U','Urbano',LRMI_ESTADO_V2) LRMI_ESTADO_V2, ");
            //select.Append(" DELM_SECUENCIA_NB, ");
            //select.Append(" decode(DELM_ESTADO_V2,'P','Pendiente','E','Enviado','R','Rechazado','U','Urbano',DELM_ESTADO_V2) DELM_ESTADO_V2, ");
            //select.Append(" DELM_IDMINISTERIO_NB, ");
            //select.Append(" to_char(DELM_FECENVIO_DT, 'DD/MM/YYYY HH24:MI:SS') DELM_FECENVIO_DT ");
            //select.Append(" from viajes,oficinas,log_reporte_ministerio, det_log_ministerio ");
            select.Append(" from viajes,oficinas ");
            select.Append(" where VIAJ_OFDESPACHA_NB = OFIC_CODOFIC_NB ");
            //select.Append(" and VIAJ_NOPLANILLA_V2 = LRMI_LLAVE_V2 ");
            select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(:fecIni) and trunc(:fecFin) ");
            //select.Append(" and DELM_LOGSECUENCIA_NB = LRMI_SECUENCIA_NB ");
            //select.Append(" and DELM_OFICINA_NB = LRMI_OFICINA_NB ");
            //select.Append(" and LRMI_TRANSACCION_NB = 4 ");
            switch (codOficina)
            {
                case 0:
                    {
                        select.Append(" and VIAJ_OFDESPACHA_NB>=:codOficina ");
                        break;
                    }
                default:
                    {
                        select.Append(" and VIAJ_OFDESPACHA_NB=:codOficina ");
                        break;
                    }
            }
            select.Append(" order by 3; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInfoMilenio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" to_char(LRMI_FECREGISTRO_DT, 'DD/MM/YYYY HH24:MI:SS') LRMI_FECREGISTRO_DT, ");
            select.Append(" decode(LRMI_ESTADO_V2,'P','PENDIENTE','E','ENVIADO','R','RECHAZADO','U','URBANO',LRMI_ESTADO_V2) LRMI_ESTADO_V2, ");
            select.Append(" DELM_SECUENCIA_NB, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" to_char(DELM_FECENVIO_DT, 'DD/MM/YYYY HH24:MI:SS') DELM_FECENVIO_DT ");
            select.Append(" from log_reporte_ministerio, det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB = LRMI_SECUENCIA_NB ");
            select.Append(" and DELM_OFICINA_NB = LRMI_OFICINA_NB ");
            select.Append(" and LRMI_LLAVE_V2 =:llave ");
            select.Append(" and LRMI_TRANSACCION_NB = 4 ");
            select.Append(" order by 1,2; ");
            select.Append(" end; ");
            return select.ToString();
        }        
        private string getInfoDeseguro()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DESE_SECUENCIA_NB, ");
            select.Append(" REDE_SECUENCIA_NB, ");
            select.Append(" REDE_OFICINA_NB, ");
            select.Append(" REDE_FECHA_DT REDE_FECHA_DT, ");
            select.Append(" decode(REDE_ESTADO_V2, 'P', 'PENDIENTE', 'E', 'ENVIADO', 'R', 'RECHAZADO', 'U', 'URBANO', REDE_ESTADO_V2) REDE_ESTADO_V2, ");
            select.Append(" decode(DESE_ESTADO_V2, 'P', 'PENDIENTE', 'E', 'ENVIADO', 'R', 'RECHAZADO', 'U', 'URBANO', DESE_ESTADO_V2) DESE_ESTADO_V2, ");
            select.Append(" DESE_NUMACEPTA_NB, ");
            select.Append(" to_char(DESE_FECPROCESA_DT, 'DD/MM/YYYY HH24:MI:SS') DESE_FECPROCESA_DT ");
            select.Append(" from log_reporte_deseguro, det_log_desseguro ");
            select.Append(" where DESE_DESEGURO_NB = REDE_SECUENCIA_NB ");
            select.Append(" and DESE_OFICINA_NB = REDE_OFICINA_NB ");
            select.Append(" and REDE_LLAVE_V2 = :llave ");
            select.Append(" order by 1,2; ");
            select.Append(" end; ");
            return select.ToString();
        }        
        private string getInfoOsp()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LPAD_SECUENCIA_NB, ");
            select.Append(" LPAD_OFICINA_NB, ");
            select.Append(" LPAD_TRANSACCION_NB, ");
            select.Append(" LPAD_LLAVE_V2, ");
            select.Append(" LPAD_FECHA_DT, ");
            select.Append(" decode(LPAD_ESTADO_V2,'P','PENDIENTE','E','ENVIADO','R','RECHAZADO','U','URBANO','T','TERCERO',LPAD_ESTADO_V2) LPAD_ESTADO_V2, ");
            select.Append(" LPAD_IDADMINSAT_V2, ");
            select.Append(" to_char(LPAD_FECENVIO_DT, 'DD/MM/YYYY HH24:MI:SS') LPAD_FECENVIO_DT ");
            select.Append(" from log_plan_adminsat ");
            select.Append(" where LPAD_LLAVE_V2 =:llave ");
            select.Append(" order by 1,2; ");
            select.Append(" end; ");
            return select.ToString();
        }        
        private string getInfoAutBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DEBA_SECUENCIA_NB, ");
            select.Append(" REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_ESTADO_V2, ");
            select.Append(" decode(DEBA_ESTADO_V2, 'P', 'PENDIENTE', 'E', 'ENVIADO', 'R', 'RECHAZADO', 'U', 'URBANO', 'T', 'TERCERO', DEBA_ESTADO_V2) DEBA_ESTADO_V2, ");
            select.Append(" to_char(DEBA_FECPROCESA_DT,'DD/MM/YYYY HH24:MI:SS') DEBA_FECPROCESA_DT, ");
            select.Append(" DEBA_NUMACEPTA_NB ");
            select.Append(" from log_reporte_bavaria, det_log_bavaria ");
            select.Append(" where DEBA_LOGBAVARIA_NB = REBA_SECUENCIA_NB ");
            select.Append(" and DEBA_OFICINA_NB = REBA_OFICINA_NB ");
            select.Append(" and REBA_LLAVE_V2 =:llave ");
            select.Append(" order by 1,2; ");
            select.Append(" end; ");
            return select.ToString();
        }        
        private string getInfoFactura()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select ofic_nombre_v2 oficina, ");
            select.Append(" clie_nombre_v2 cliente, ");
            select.Append(" clie_nit_nb nit, ");
            select.Append(" clie_direccion_v2 direccion, ");
            select.Append(" ofic_codofic_nb codofic, ");
            select.Append(" to_char(fact_fecfact_dt,'DD/MM/YYYY HH24:MI:SS') fecha, ");
            select.Append(" fact_total_nb total ");
            select.Append(" from facturas,clientes,oficinas ");
            select.Append(" where fact_cliepaga_nb=clie_codigo_nb ");
            select.Append(" and fact_oficina_nb=ofic_codofic_nb ");
            select.Append(" and fact_nofactura_nb=:factura; ");
            select.Append(" end; ");
            return select.ToString();
        }        
        private string getSelectInfoDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select indi_numdoc_v2 factura, ");
            select.Append(" indi_email_v2 mail, ");
            select.Append(" indi_cufedian_v2 cufe, ");
            select.Append(" indi_idcarvajal_v2 idcarvajal, ");
            select.Append(" indi_repgrafica_bl pdf ");
            select.Append(" from informacion_dian ");
            select.Append(" where indi_numdoc_v2=:factura; ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string getOrdenesRechazadas()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_OFICINA_NB CODOFI,  ");
            select.Append(" OFIC_NOMBRE_V2 OFICINA, ");
            select.Append(" CLIE_NOMBRE_V2 CLIENTE, ");
            select.Append(" LRMI_ESTADO_V2 ESTADO, ");
            select.Append(" DELM_SECUENCIA_NB SEC, ");
            select.Append(" DELM_LOGSECUENCIA_NB LOGSEC, ");
            select.Append(" DELM_LLAVE_V2 ORDEN, ");
            select.Append(" DELM_ESTADO_V2 DETESTADO, ");
            select.Append(" DELM_XMLENVIADO_XML ENVIADO, ");
            select.Append(" to_char(DELM_FECENVIO_DT,'DD/MM/YYYY HH24:MI:SS') FECHA, ");
            select.Append(" DELM_XMLRECIBIDO_XML RECIBIDO  ");
            select.Append(" from oficinas, log_reporte_ministerio, det_log_ministerio, ordenes_cargue, negocios, clientes  ");
            select.Append(" where LRMI_SECUENCIA_NB = DELM_LOGSECUENCIA_NB  ");
            select.Append(" and LRMI_OFICINA_NB = DELM_OFICINA_NB  ");
            select.Append(" and OFIC_CODOFIC_NB = LRMI_OFICINA_NB  ");
            select.Append(" and LRMI_TRANSACCION_NB = 3  ");
            select.Append(" and LRMI_ESTADO_V2 = 'R'  ");
            select.Append(" and LRMI_LLAVE_V2 = ORCA_NUMERO_NB  ");
            select.Append(" and ORCA_NEGOCIO_NB = NEGO_NRONEGOCIO_NB  ");
            select.Append(" and NEGO_CLIENTENEGO_NB = CLIE_CODIGO_NB  ");
            //select.Append(" and trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-10) and trunc(sysdate)  ");
            select.Append(" order by CODOFI, LOGSEC, SEC;  ");
            select.Append("end;");
            return select.ToString();
        }
    }
}
