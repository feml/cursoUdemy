using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using Transer.Desarrollo.Facturacion.BuildCommand;
using Transer.Desarrollo.Facturacion.CallExec;
using Transer.Desarrollo.Facturacion.Correo;
using Transer.Desarrollo.Facturacion.OracleManagedData;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.ProcesarAnexos
{
    public class Anexos
    {
        public Vgp _vgp { get; set; }
        Registro.Registro _log { get; set; }
        Correo.Correo _correo { get; set; }
        public long sizeAnexo { get; set; }
        public Anexos(Vgp vgp)
        {
            _vgp = vgp;
            _log = new Registro.Registro();
            _correo = new Correo.Correo(vgp);
        }

        public bool getAnexos(string factura)
        {
            bool anexos = false;
            DataTable dtAnexos = new DataTable();
            OracleData _datos = new OracleData(_vgp);
            dtAnexos = _datos.getAnexos(_vgp);
            if (dtAnexos.Rows.Count > 0)
            {
                anexos = true;
                foreach (DataRow dr in dtAnexos.Rows)
                {
                    procesarAdjuntos(dr, factura);
                }
                comprimirAdjuntos(factura);
            }
            else
            {
                anexos = false;
            }
            return anexos;
        }
        private void procesarAdjuntos(DataRow dr, string factura)
        {
            try
            {
                string nombre = dr[0].ToString();
                string extension = dr[1].ToString();
                var mifile = dr[2];
                byte[] cadena_bytes = (byte[])mifile;
                Encoding.GetEncoding(1252).GetString(cadena_bytes);
                string x = Encoding.GetEncoding(1252).GetString(cadena_bytes);
                switch (extension)
                {
                    case "PDF":
                        {
                            try
                            {
                                string output = x.Substring(x.IndexOf("%PDF"));
                                int index = output.LastIndexOf("%%EOF");
                                if (index > 0)
                                    output = output.Substring(0, index + 5);
                                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                                System.IO.File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre, bytes);
                                sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre).Length;
                            }
                            catch (Exception ex)
                            {
                                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                            }
                            break;
                        }
                    default:
                        {
                            try
                            {
                                string output = x.Substring(x.IndexOf("%PDF"));
                                int index = output.LastIndexOf("%%EOF");
                                if (index > 0)
                                    output = output.Substring(0, index + 5);
                                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(output);
                                System.IO.File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre + ".pdf", bytes);
                                //sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre).Length;
                                sizeAnexo += new System.IO.FileInfo("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + nombre + ".pdf").Length;
                            }
                            catch (Exception ex)
                            {
                                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
        }
        public void comprimirFacturaAdjuntos(string factura, string xml)
        {
            try
            {
                string ex1 = "c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip";
                string ex2 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\*.*";
                /*using (StreamWriter writer = new StreamWriter("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\" + factura + ".xml"))
                {
                    writer.WriteLine(_vgp.informaciondian.INDI_XMLENV_CB);
                }*/
                _log.cfg(_vgp._Directorio + "\\" + _vgp._InformacionDian.INDI_NUMDOC_V2 + "\\anexos\\", _vgp._InformacionDian.INDI_NUMDOC_V2 + ".xml", _vgp._InformacionDian.INDI_XMLENV_CB);
                string ejecucion = string.Empty;
                CallExecute cmprmr = new CallExecute(_vgp);
                ejecucion = cmprmr.generarZIP(ex1, ex2);

            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());" + "\r\nTiempo de proceso : ";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
        }
        public string getdataXmlAnexos(string factura)
        {
            string myxml = string.Empty;//getmixmlf();
            byte[] byteText = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");
            myxml = System.Convert.ToBase64String(byteText);
            File.WriteAllText("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".enc", myxml);
            string Base64String = File.ReadAllText("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".enc");

            byte[] array = System.Convert.FromBase64String(myxml); //Encoding.ASCII.GetBytes(Base64String);
            try
            {
                File.WriteAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + "recuperado.zip", array);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            return myxml;
        }

        private void comprimirAdjuntos(string factura)
        {
            string ex1 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip";
            string ex2 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\*.*";
            string ejecucion = string.Empty;
            CallExecute cmprmr = new CallExecute(_vgp);
            ejecucion = cmprmr.generarZIP(ex1, ex2);

            try
            {
                sizeAnexo = new System.IO.FileInfo(ex1).Length;
            }
            catch (Win32Exception ex)
            {
                string _mensajeError = @"Win32Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Win32Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (IOException ex)
            {
                string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "IOException.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            if (sizeAnexo > 2300000)
            {
                try
                {
                    string[] filePaths = Directory.GetFiles("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\");
                    foreach (string filePath in filePaths)
                    {
                        if (filePath.Contains(".zip"))
                        {
                            File.Delete(filePath);
                        }
                        if (filePath.Contains(".ZIP"))
                        {
                            File.Delete(filePath);
                        }
                    }
                }
                catch (Win32Exception ex)
                {
                    string _mensajeError = @"Win32Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                          "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                    _log.wr(_vgp._Directorio, "Win32Exception.txt", _mensajeError);
                    _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                }
                catch (IOException ex)
                {
                    string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                          "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                    _log.wr(_vgp._Directorio, "IOException.txt", _mensajeError);
                    _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                }
                catch (Exception ex)
                {
                    string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                          "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                          "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                    _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                    _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\Capacidad.txt", true))
                {
                    writer.WriteLine(" La factura : " + factura + "    El tamaño del archivo sobrepasa la capacidad maxima permitida. Los anexos se enviaran al correo del cliente registro en nuestro sistema.");
                }
                using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\" + factura + ".txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine(" Señor(es),  ");
                    writer.WriteLine(" " + getCliente(factura));
                    writer.WriteLine("  ");
                    writer.WriteLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Número de documento: " + factura);
                    writer.WriteLine(" Tipo de documento: " + _vgp._IcpdbInfoDian.tipoDocumentoDescriptivo);
                    writer.WriteLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
                    writer.WriteLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviaremos vía correo electrónico con el Asunto Factura(número de la factura)-Anexos al mismo correo en que reciben la notificación de la factura electrónica. ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
                    writer.WriteLine("  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" Atentamente,  ");
                    writer.WriteLine("  ");
                    writer.WriteLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");
                }
                comprimirAdjuntosTxt(factura);
                enviocorreo(factura);
            }


            try
            {
                string[] filePaths = Directory.GetFiles("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\");
                foreach (string filePath in filePaths)
                {
                    if (filePath.Contains(".pdf"))
                    {
                        File.Delete(filePath);
                    }
                    if (filePath.Contains(".PDF"))
                    {
                        File.Delete(filePath);
                    }
                }

            }
            catch (Win32Exception ex)
            {
                string _mensajeError = @"Win32Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Win32Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (IOException ex)
            {
                string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "IOException.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
        }
        private string getCliente(string factura)
        {
            string cliente = string.Empty;
            DataTable dtConsulta = new DataTable();
            BuildCommands selects = new BuildCommands();
            OracleData _datos = new OracleData(_vgp);
            dtConsulta = _datos.daDataTable(selects.getCliente(_vgp._LogReporteDian.LODI_LLAVE_V2), _vgp);
            if (dtConsulta.Rows.Count > 0)
            {
                foreach (DataRow dr in dtConsulta.Rows)
                {
                    cliente = dr[0].ToString();
                }
            }
            return cliente;
        }



        private void comprimirAdjuntosTxt(string factura)
        {
            string ex1 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip";
            string ex2 = "c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\*.*";
            string ejecucion = string.Empty;
            CallExecute cmprmr = new CallExecute(_vgp);
            ejecucion = cmprmr.generarZIP(ex1, ex2);
            try
            {
                string[] filePaths = Directory.GetFiles("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\");
                foreach (string filePath in filePaths)
                {
                    if (filePath.Contains(".pdf"))
                    {
                        File.Delete(filePath);
                    }
                    if (filePath.Contains(".PDF"))
                    {
                        File.Delete(filePath);
                    }
                }

            }
            catch (Win32Exception ex)
            {
                string _mensajeError = @"Win32Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Win32Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (IOException ex)
            {
                string _mensajeError = @"IOException : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "IOException.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException +
                                      "Procedimiento : caFEtysVS02_logicaProceso_public async void inicio() " +
                                      "instruccion : _vgp.logreportedian.LODI_OFICINA_NB = int.Parse(drFacturas[1].ToString());";
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                _correo.envioCorreoDesarrollador(ex.Message, _mensajeError, _vgp);
            }
            sizeAnexo = new System.IO.FileInfo(ex1).Length;
            //if (sizeAnexo > 2000000)
            //{
            //    //enviocorreo(factura);
            //    using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\Capacidad.txt", true))
            //    {
            //        writer.WriteLine(" ");
            //        writer.WriteLine("El tamaño del archivo sobrepasa la capacidad maxima permitida. Los anexos se enviaran al correo del cliente registro en nuestro sistema.");
            //        writer.WriteLine("*");
            //        writer.WriteLine(" ");
            //    }
            //    using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\" + factura + ".txt", true))
            //    {
            //        writer.WriteLine(" ");
            //        writer.WriteLine(" Señor(es),  ");
            //        writer.WriteLine(" " + getCliente(factura));
            //        writer.WriteLine("  ");
            //        writer.WriteLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
            //        writer.WriteLine("  ");
            //        writer.WriteLine(" Número de documento: " + factura);
            //        writer.WriteLine(" Tipo de documento: " + _vgp.icpdbInfodian.tipoDocumentoDescriptivo);
            //        writer.WriteLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
            //        writer.WriteLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviaremos vía correo electrónico con el Asunto " + factura + "-Anexos al mismo correo en que reciben la notificación de la factura electrónica. ");
            //        writer.WriteLine("  ");
            //        writer.WriteLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
            //        writer.WriteLine("  ");
            //        writer.WriteLine("  ");
            //        writer.WriteLine(" Atentamente,  ");
            //        writer.WriteLine("  ");
            //        writer.WriteLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");
            //    }
            //}
            if (sizeAnexo > 5000000)
            {

                using (StreamWriter writer = new StreamWriter(@"C:\Transer\ws\facturacion\" + factura + @"\Capacidad.txt", true))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine("El tamaño del archivo sobrepasa la capacidad de correo maxima permitida. Los anexos no se pueden enviar por este medio.");
                    writer.WriteLine("*");
                    writer.WriteLine(" ");
                }
            }

        }
        private void enviocorreo(string factura)
        {
            Correo.Correo correo = new Correo.Correo(_vgp);
            //byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\" + factura + ".zip");
            byte[] byteTextAnexos = File.ReadAllBytes("c:\\transer\\ws\\facturacion\\" + factura + "\\anexos\\anexos.zip");
            MailAttachment attach = new MailAttachment(byteTextAnexos, "anexos_" + _vgp._LogReporteDian.LODI_LLAVE_V2 + ".zip");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(" Señor(es),  ");
            sb.AppendLine(getCliente(_vgp._LogReporteDian.LODI_LLAVE_V2));
            sb.AppendLine("  ");
            sb.AppendLine(" Les informamos que TRANSPORTES Y SERVICIOS TRANSER S.A les ha emitido el siguiente documento. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Número de documento: " + factura);
            sb.AppendLine(" Tipo de documento: FACTURA");
            sb.AppendLine(" Fecha de emisión: " + DateTime.Now.ToLongDateString());
            sb.AppendLine("  ");
            sb.AppendLine(" Los anexos que soportan el documento sobrepasan el tamaño máximo permitido por nuestro PST, por tal razón los enviamos anexos al presente mensaje. ");
            sb.AppendLine("  ");
            sb.AppendLine(" Si tiene alguna inquietud al respecto no dude en contactar a nuestros representantes comerciales. ");
            sb.AppendLine("  ");
            sb.AppendLine("  ");
            sb.AppendLine(" Atentamente,  ");
            sb.AppendLine("  ");
            sb.AppendLine(" TRANSPORTES Y SERVICIOS TRANSER S.A ");

            correo.envioCorreoDesarrolador(factura + "-Anexos ", sb.ToString(), _vgp._InformacionDian.INDI_EMAIL_V2, _vgp, attach);

        }
    }
}
