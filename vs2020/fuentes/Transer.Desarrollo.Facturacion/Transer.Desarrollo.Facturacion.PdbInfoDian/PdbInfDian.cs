using System;
using Transer.Desarrollo.Facturacion.BuildCommand;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.OracleManagedData;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.PdbInfoDian
{
    public class PdbInfDian
    {
        public Vgp _vgp { get; set; }
        public Registro.Registro _log { get; set; }
        public PdbInfDian(Vgp vgp)
        {
            _vgp = vgp;
        }
        public void generarInfoDian(string factura, int oficina, int transaccion)
        {
            BuildCommands select = new BuildCommands();
            _vgp._TargetFile._Archivo = "pdbinfodian.txt";
            _vgp._ClienteID = "pdbInfoDian";
            //string tipodoc = string.Empty;
            switch (transaccion)
            {
                case 1:
                    {
                        try
                        {
                            _vgp._IcpdbInfoDian.tipodocumento = "FC";
                            _vgp._IcpdbInfoDian.tipoDocumentoDescriptivo = "FACTURA";
                            OracleData _datos = new OracleData(_vgp);
                            _datos.execute((select.procedimientoInfoDianFactura(factura, oficina, _vgp._IcpdbInfoDian.tipodocumento, "I")), _vgp);
                        }
                        catch (Exception ex)
                        {
                            string lo = ex.Message;
                        }
                        break;
                    }
                case 2:
                    {
                        _vgp._IcpdbInfoDian.tipodocumento = "NC";
                        _vgp._IcpdbInfoDian.tipoDocumentoDescriptivo = "NOTA CREDITO";
                        OracleData _datos = new OracleData(_vgp);
                        _datos.execute((select.procedimientoInfoDianNota(factura, oficina, _vgp._IcpdbInfoDian.tipodocumento, "I")), _vgp);
                        break;
                    }
                case 3:
                    {
                        _vgp._IcpdbInfoDian.tipodocumento = "ND";
                        _vgp._IcpdbInfoDian.tipoDocumentoDescriptivo = "NOTA DEBITO";
                        OracleData _datos = new OracleData(_vgp);
                        _datos.execute((select.procedimientoInfoDianNota(factura, oficina, _vgp._IcpdbInfoDian.tipodocumento, "I")), _vgp);
                        break;
                    }
                default:
                    {
                        string _default = "El metodo caFEtysVS02_pdbInfoDian_generarInfoDian contiene un caso sin catalogar \r\n Informacion de parametro Nombre : transaccion Valor : " + transaccion;
                        _log = new Registro.Registro();
                        _log.wr(_vgp._Directorio, "Default.txt", _default);
                        Correo.Correo _correo = new Correo.Correo(_vgp);
                        _correo.envioCorreoDesarrollador("El metodo caFEtysVS02_pdbInfoDian_generarInfoDian contiene un caso sin catalogar", "El metodo caFEtysVS02_pdbInfoDian_generarInfoDian contiene un caso sin catalogar \r\n Parametros  factura : " + factura + "\r\n oficina : " + oficina + "\r\n transaccion: " + transaccion, _vgp);
                        break;
                    }
            }
        }
    }
}
