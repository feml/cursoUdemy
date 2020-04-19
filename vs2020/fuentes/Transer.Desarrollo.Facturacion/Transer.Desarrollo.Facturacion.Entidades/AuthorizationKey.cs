namespace Transer.Desarrollo.Facturacion.Entidades
{
    public class AuthorizationKey
    {
        public string _Host { get; set; }
        public int _Port { get; set; }
        public bool _EnableSsl { get; set; }
        public CredentialBd _Credentialbd { get; set; }
        public CredentialMail _Credentialmail { get; set; }
        public AuthorizationKey()
        {
            _Credentialbd = new CredentialBd();
            _Credentialmail = new CredentialMail();
            _Host = "192.168.30.8";
            _EnableSsl = false;
            _Port = 25;
        }
    }
}
