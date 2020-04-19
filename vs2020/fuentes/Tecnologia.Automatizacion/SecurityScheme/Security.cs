using SecurityScheme.Entities_Security;
using SecurityScheme.Interfaces;

namespace SecurityScheme
{
    public class Security:ISecurity
    {

        private AccessInformationDataBase AccessInformationDB;
        private AccessInformationMail AccessInformationEMail;
        public string Cadena { get; set; }
        public Security()
        {
            AccessInformationDB = new AccessInformationDataBase();
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail();
        }
        public Security(string ambiente)
        {
            AccessInformationDB = new AccessInformationDataBase(ambiente);
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail();
        }
        public Security(string ambiente,string usuario,string password)
        {
            AccessInformationDB = new AccessInformationDataBase(ambiente, usuario, password);
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail();
        }
        public Security(string ambiente, string usuarioBd, string passwordBd, string usuarioMail, string passwordMail)
        {
            AccessInformationDB = new AccessInformationDataBase(ambiente, usuarioBd, passwordBd);
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail(usuarioMail, passwordMail);
        }
        public Security(string ambiente, string usuarioBd, string passwordBd, string usuarioMail, string passwordMail, string host)
        {
            AccessInformationDB = new AccessInformationDataBase(ambiente, usuarioBd, passwordBd);
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail(usuarioMail, passwordMail, host);
        }
        public Security(string ambiente, string usuarioBd, string passwordBd,string host)
        {
            AccessInformationDB = new AccessInformationDataBase(ambiente, usuarioBd, passwordBd);
            Cadena = AccessInformationDB.Cadena;
            AccessInformationEMail = new AccessInformationMail(host);
        }

        public string GetCadena()
        {
            return Cadena;
        }
        public AccessInformationDataBase getAccessInformationDB()
        {
            return AccessInformationDB;
        }

        public AccessInformationMail getAccessInformationMail()
        {
            return AccessInformationEMail;
        }
    }
}
