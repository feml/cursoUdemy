using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranserComentarios.admin
{
    public partial class inicializar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] != null)
            {
                if (Session["Password_ID"] != null)
                {

                }
                else
                {
                    Response.Redirect("/TranserComentarios/admin/login.aspx");
                }
            }
            else
            {
                Response.Redirect("/TranserComentarios/admin/login.aspx");
            }

        }
    }
}