namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class CredentialBd
    {
        public string _Cadena { get; set; }
        private string _User { get; set; }
        private string _Password { get; set; }
        public Security _Sgrd { get; set; }
        public CredentialBd()
        {
            inicialization();
            _Sgrd = new Security(_User, _Password);
            _Cadena = _Sgrd._Cadena;
        }
        private void inicialization()
        {
            //user = "SOPORTE";
            //password = "SOPORTE";
            _User = "TRANSER";
            _Password = "TRANSER1";
        }
    }
}