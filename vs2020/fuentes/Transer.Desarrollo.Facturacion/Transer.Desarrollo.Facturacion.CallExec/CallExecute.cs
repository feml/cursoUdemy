using System;
using System.Diagnostics;
using Transer.Desarrollo.Facturacion.Registro;
using Transer.Desarrollo.Facturacion.VariablesGlobalesProyecto;

namespace Transer.Desarrollo.Facturacion.CallExec
{
    public class CallExecute
    {
        public Registro.Registro _log { get; set; }
        public Vgp _vgp { get; set; }

        public CallExecute(Vgp vgp)
        {
            _vgp = vgp;
            _log = new Registro.Registro();
        }

        public string generarZIP(string ex1, string ex2)
        {
            string ejecucion = "O.K";
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"c:\WinZip\WINZIP32.EXE ";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = "-min -a " + ex1 + " " + ex2;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
                _log.wr(_vgp._Directorio, "Win32Exception.txt", _mensajeError);
                ejecucion = ex.Message;
            }
            catch (Exception ex)
            {
                string _mensajeError = @"Exception : " + ex.Source + "\nData source: " + ex.Message + "\nInnerException: " + ex.InnerException;
                _log.wr(_vgp._Directorio, "Exception.txt", _mensajeError);
                ejecucion = ex.Message;
            }
            return ejecucion;
        }
    }
}
