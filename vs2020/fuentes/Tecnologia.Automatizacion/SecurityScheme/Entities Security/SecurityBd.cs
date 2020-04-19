namespace SecurityScheme.Entities_Security
{
    public class SecurityBd
    {
        public string Usuario { get; set; }
        public string Password { get; set; }

        public SecurityBd(string Usuario, string Password)
        {
            this.Usuario = Usuario;
            this.Password = Password;
        }
    }
}
