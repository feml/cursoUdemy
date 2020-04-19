using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranserComentarios.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        private int intentos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                intentos += 1;
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool Autenticado = false;
            Autenticado = LoginCorrecto(Login1.UserName, Login1.Password);
            e.Authenticated = Autenticado;
            if (Autenticado)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (intentos > 0)
                {
                    Response.Redirect("ErrorLogin.aspx");
                }
            }
        }

        private bool LoginCorrecto(string Usuario, string Contrasena)
        {
            bool loginok = false;
            DataTable dtUsuarios = new DataTable();
            string cadena = @"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015";
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                DataSet dsPerson = new DataSet("Usuarios");
                string strSelectCmd = @"select login, password
                                        from Usuarios;";
                SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
                conn.Open();
                da.Fill(dtUsuarios);
            }
            string usutmp = string.Empty;
            string passtmp = string.Empty;
            foreach (DataRow dr in dtUsuarios.Rows)
            {
                usutmp = dr[0].ToString();
                passtmp = dr[1].ToString();
                if (Usuario.Equals(usutmp))
                {
                    if (Contrasena.Equals(passtmp))
                    {
                        loginok = true;
                        break;
                    }
                    else
                    {
                        loginok = false;
                    }
                }
                else
                {
                    loginok = false;
                }
            }
            return loginok;
        }
    }
}