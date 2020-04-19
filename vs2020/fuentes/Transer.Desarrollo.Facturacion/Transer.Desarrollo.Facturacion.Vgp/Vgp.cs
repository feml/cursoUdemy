using System;
using Transer.Desarrollo.Facturacion.Entidades;

namespace Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto
{
    #region Definicion de la class vgp
    public class Vgp
    {
        public TargetFile _TargetFile { get; set; }
        public AuthorizationKey _AuthorizationKey { get; set; }
        public LogReporteDian _LogReporteDian { get; set; }
        public IcpdbInfoDian _IcpdbInfoDian { get; set; }
        public InformacionDian _InformacionDian { get; set; }
        public Upload _Upload { get; set; }
        public HttpWebRequestFunction _HttpWebRequestFunction { get; set; }
        public int _FacturasProcesadas { get; set; }
        public string _Cadena { get; set; }
        public string _Ip { get; set; }
        public string _Sid { get; set; }
        public string _ClienteID { get; set; }
        public string _Directorio { get; set; }
        public string _Archivo { get; set; }
        public string _StatusFactura { get; set; }
        public bool _PdbInfoDian { get; set; }

        public Vgp()
        {
            _TargetFile = new TargetFile();
            _Directorio = _TargetFile._Directorio;
            _Archivo = _TargetFile._Archivo;
            _AuthorizationKey = new AuthorizationKey();
            _Cadena = _AuthorizationKey._Credentialbd._Sgrd._Cadena;
            _Ip = _AuthorizationKey._Credentialbd._Sgrd._Ip;
            _Sid = _AuthorizationKey._Credentialbd._Sgrd._Sid;
            _LogReporteDian = new LogReporteDian();
            _IcpdbInfoDian = new IcpdbInfoDian();
            _InformacionDian = new InformacionDian();
            _Upload = new Upload();
            _HttpWebRequestFunction = new HttpWebRequestFunction();
        }
    }
#endregion fin de la Definicion de la class vgp
}
