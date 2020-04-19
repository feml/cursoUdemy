using System;
namespace SecurityScheme.Entities_Security
{
    public class AccessInformationMail
    {
        public SecurityMail SecurityEMail { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public bool EnableSsl { get; set; }

        public AccessInformationMail()
        {
            SecurityEMail = new SecurityMail("robotcorreo", "Tys860504882");
            SecurityEMail.Usuario = "robotcorreo";
            SecurityEMail.Password = "Tys860504882";
            Port = 25;
            Host = "192.168.30.8";
            EnableSsl = false;
        }
        public AccessInformationMail(string host)
        {
            SecurityEMail = new SecurityMail("robotcorreo", "Tys860504882");
            SecurityEMail.Usuario = "robotcorreo";
            SecurityEMail.Password = "Tys860504882";
            Port = 25;
            Host = host;
            EnableSsl = false;
        }
        public AccessInformationMail(string usuario, string password)
        {
            SecurityEMail = new SecurityMail("robotcorreo", "Tys860504882");
            SecurityEMail.Usuario = usuario;
            SecurityEMail.Password = password;
            Port = 25;
            Host = "192.168.30.8";
            EnableSsl = false;
        }
        public AccessInformationMail(string usuario, string password, string host)
        {
            SecurityEMail = new SecurityMail("robotcorreo", "Tys860504882");
            SecurityEMail.Usuario = usuario;
            SecurityEMail.Password = password;
            Port = 25;
            Host = host;
            EnableSsl = false;
        }
    }
}
