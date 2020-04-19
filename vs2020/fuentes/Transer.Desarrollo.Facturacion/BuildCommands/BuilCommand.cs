using System.Text;

namespace BuildCommands
{
    public class BuilCommand
    {
        public BuilCommand()
        {

        }

        public string logReporteDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for select LODI_SECUENCIA_NB LODI_SECUENCIA,");
            select.Append(" LODI_OFICINA_NB, ");
            select.Append(" LODI_TRANSACCION_NB LODI_OFICINA, ");
            select.Append(" LODI_LLAVE_V2 LODI_LLAVE, ");
            select.Append(" LODI_FECREGISTRO_DT LODI_FECREGISTRO, ");
            select.Append(" LODI_ESTADO_V2 LODI_ESTADO,");
            select.Append(" LODI_CAMPO1_NB,");
            select.Append(" LODI_CAMPO2_V2,");
            select.Append(" LODI_CAMPO3_DT,");
            select.Append(" LODI_ESTADODIAN_V2");
            select.Append(" from LOG_REPORTE_DIAN ");
            select.Append(" where LODI_ESTADO_V2=:LODI_ESTADO;");
            select.Append("end;");
            return select.ToString();
        }

        public string procedimientoInfoDianFactura(string factura, int oficina, string tipodoc, string tipotransaccion)
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_fc_dian('" + factura + "'," + oficina + ",'" + tipodoc + "','" + tipotransaccion + "',var); ");
            select.Append(" PDB_INFO_FC_DIAN_21 ('" + factura + "'," + oficina + ",'" + tipodoc + "','" + tipotransaccion + "',var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        public string procedimientoInfoDianNota(string factura, int oficina, string tipodoc, string tipotransaccion)
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            select.Append(" pdb_info_nc_dian('" + factura + "'," + oficina + ",'" + tipodoc + "','" + tipotransaccion + "',var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        public string getInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for select INDI_NUMDOC_V2 INDI_NUMDOC, ");
            select.Append(" INDI_OFICDOC_NB INDI_OFICDOC, ");
            select.Append(" INDI_TIPODOC_V2 INDI_TIPODOC, ");
            select.Append(" INDI_EMAIL_V2 INDI_EMAIL, ");
            select.Append(" INDI_XMLENV_CB INDI_XMLENV, ");
            select.Append(" INDI_CUFEDIAN_V2 INDI_CUFEDIAN, ");
            select.Append(" INDI_IDCARVAJAL_V2 INDI_IDCARVAJAL, ");
            select.Append(" INDI_XMLREC_BL INDI_XMLREC, ");
            select.Append(" INDI_REPGRAFICA_BL INDI_REPGRAFICA, ");
            select.Append(" INDI_XMLLEGAL_CB INDI_XMLLEGAL, ");
            select.Append(" INDI_IDCUFE_V2 INDI_IDCUFE ");
            select.Append(" from informacion_dian  ");
            select.Append(" where INDI_NUMDOC_V2=:INDI_NUMDOC;");
            select.Append("end;");
            return select.ToString();
        }

        public string getInformacionDian(vgp vgl)
        {
            StringBuilder select = new StringBuilder();
            select.Append("<soapenv:Envelope\r\n");
            select.Append("xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\"\r\n");
            select.Append("xmlns:inv=\"http://invoice.carvajal.com/invoiceService/\"\r\n");
            select.Append("xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("secext-1.0.xsd\"\r\n");
            select.Append("xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-");
            select.Append("utility-1.0.xsd\">\r\n");
            select.Append("   <soapenv:Header>\r\n");
            select.Append("   <wsse:Security>\r\n");
            select.Append("   <wsse:UsernameToken wsu:Id=\"" + vgl.httpwebrequestFunction._userId + "\">\r\n"); // vgs.upload._userId
            select.Append("   	<wsse:Username>" + vgl.httpwebrequestFunction._Username + "</wsse:Username>\r\n");
            select.Append("<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-");
            select.Append("wss-username-token-profile-");
            select.Append("1.0#PasswordText\">" + vgl.httpwebrequestFunction._Password + "</w");
            select.Append("sse:Password>\r\n");
            select.Append("	<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-");
            select.Append("200401-wss-soap-message-security-");
            select.Append("1.0#Base64Binary\">" + vgl.httpwebrequestFunction._nonce + "</wsse:Nonce>\r\n");
            select.Append("		<wsu:Created>" + vgl.httpwebrequestFunction._create + "</wsu:Created>\r\n");
            select.Append("		</wsse:UsernameToken>\r\n");
            select.Append("		</wsse:Security>\r\n");
            select.Append("   </soapenv:Header>\r\n");
            select.Append("   <soapenv:Body>\r\n");
            select.Append("      <inv:" + vgl.httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");//sb.Append("      <inv:UploadRequest>\r\n");
            select.Append("         <fileName>" + vgl.httpwebrequestFunction._FileName + "</fileName>\r\n");
            select.Append("         <fileData>" + vgl.httpwebrequestFunction._FileData + "</fileData>\r\n");
            select.Append("         <companyId>" + vgl.httpwebrequestFunction._companyId + "</companyId>\r\n");
            select.Append("         <accountId>" + vgl.httpwebrequestFunction._accountid + "</accountId>\r\n");
            select.Append("      </inv:" + vgl.httpwebrequestFunction._HttpWebRequestFunction + ">\r\n");//sb.Append("      </inv:UploadRequest>\r\n");
            select.Append("   </soapenv:Body>\r\n");
            select.Append("</soapenv:Envelope>");
            return select.ToString();
        }
        public string UploadRequestFE()
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
        public string updateLogReporteDian(string estado, string factura)
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_dian set ");
            select.Append(" lodi_estado_v2='" + estado + "'");
            select.Append(" where lodi_llave_v2='" + factura + "';");
            select.Append(" end;  ");

            return select.ToString();
        }
        public string insertDetLogDian()
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
        public string updateInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" INDI_IDCARVAJAL_V2=:INDI_IDCARVAJAL");
            select.Append(" where INDI_NUMDOC_V2=:INDI_NUMDOC;");
            select.Append(" end; ");

            return select.ToString();
        }


        public string getCliente(string factura)
        {
            StringBuilder select = new StringBuilder();
            select.Append(" select CLIE_NOMBRE_V2 cliente ");
            select.Append(" from facturas,clientes ");
            select.Append(" where FACT_CLIEPAGA_NB=CLIE_CODIGO_NB ");
            select.Append(" and FACT_NOFACTURA_NB='" + factura + "'");

            return select.ToString();
        }
    }
}
