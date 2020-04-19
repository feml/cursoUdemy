namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class TargetFile
    {
        public string _Directorio { get; set; }
        public string _Archivo { get; set; }

        public TargetFile()
        {
            inicialization();
        }
        private void inicialization()
        {
            _Directorio = @"c:\transer\ws\facturacion\";
            _Archivo = "caFEtys01.txt";
        }
    }
}
