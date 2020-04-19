namespace SecurityScheme.Entities_Security
{
    public class SecurityMail
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        public SecurityMail(string Usuario, string Password)
        {
            this.Usuario = Usuario;
            this.Password = Password;
        }
    }
}
