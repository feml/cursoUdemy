using System;

namespace infrastructure
{
    public partial class Security
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string cadena { get; set; }
        public string ip { get; set; }
        public string sid { get; set; }
        public string ambiente { get; set; }
        public Security()
        {

        }
        public Security(string usuario, string password, string ambiente)
        {
            this.usuario = usuario;
            this.password = password;
            this.ambiente = ambiente;
            inicialization();
        }
    }
}
