using System;
namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class Upload
    {
        public long intUPLO_SECUENCIA_NB { get; set; }
        public DateTime UPLO_FECHAENVIO_TS { get; set; }
        public string UPLO_FILENAME_V2 { get; set; }
        public byte[] MyProperty { get; set; }
        public byte[] UPLO_FILEDATA_BL { get; set; }
        public string UPLO_COMPANYID_V2 { get; set; }
        public string UPLO_ACCOUNTID_V2 { get; set; }
        public string UPLO_STATUS_V2 { get; set; }
        public string UPLO_TRANSACTIONID_V2 { get; set; }
        public byte[] UPLO_XMLFACTURA_BL { get; set; }
        public byte[] UPLO_SOAPENVIADO_BL { get; set; }
        public byte[] UPLO_SOAPRESPUESTA_BL { get; set; }

    }
}
