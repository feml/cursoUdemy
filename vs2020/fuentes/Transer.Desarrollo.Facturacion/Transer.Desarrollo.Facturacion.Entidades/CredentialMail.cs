namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class CredentialMail
    {
        public string _User { get; set; }
        public string _Password { get; set; }
        public CredentialMail()
        {
            inicialization();
        }
        private void inicialization()
        {
            _User = "FMONTOYA";
            _Password = "@Jsd2@xr1";
        }
    }
}