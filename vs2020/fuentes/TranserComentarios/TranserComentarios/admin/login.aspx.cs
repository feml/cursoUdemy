using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranserComentarios.admin
{
    public partial class login : System.Web.UI.Page
    {

        private bool conexionOpen;
        public bool ConexionOpen
        {
            get { return conexionOpen; }
            set { conexionOpen = value; }
        }
        private string cadena;
        public string Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
        private SqlConnection _connection;
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        private SqlCommand _command;
        public SqlCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }
        private SqlDataAdapter _datadapter;
        public SqlDataAdapter Datadapter
        {
            get { return _datadapter; }
            set { _datadapter = value; }
        }

        private SqlDataReader _datareader;

        public SqlDataReader Datareader
        {
            get { return _datareader; }
            set { _datareader = value; }
        }

        private DataTable _datatable;
        public DataTable tabledata
        {
            get { return _datatable; }
            set { _datatable = value; }
        }
        private SqlException _oracleexception;
        public SqlException Oracleexception
        {
            get { return _oracleexception; }
            set { _oracleexception = value; }
        }

        private SqlDataReader _oracleDataReader;
        public SqlDataReader OracleDataReader
        {
            get { return _oracleDataReader; }
            set { _oracleDataReader = value; }
        }

        private Exception _exception;
        public Exception Exception
        {
            get { return _exception; }
            set { _exception = value; }
        }

        private string excepcionPersonalizada;
        public string ExcepcionPersonalizada
        {
            get { return excepcionPersonalizada; }
            set { excepcionPersonalizada = value; }
        }

        private string quienUsoDbFacOra;

        public string QuienUsoDbFacOra
        {
            get { return quienUsoDbFacOra; }
            set { quienUsoDbFacOra = value; }
        }

        private string version;

        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        private DateTime _start_time;

        public DateTime Start_time
        {
            get { return _start_time; }
            set { _start_time = value; }
        }

        private DateTime _end_time;

        public DateTime End_time
        {
            get { return _end_time; }
            set { _end_time = value; }
        }

        private TimeSpan _ts;

        public TimeSpan Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            cadena = WebConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            if (IsPostBack)
            {
                cargarDatagRidView();
            }            

        }

        private void cargarDatagRidView()
        {
            StringBuilder sbselect = new StringBuilder();
            sbselect.Append("select login login, password password");
            sbselect.Append(" from usuarios ");
            string select = sbselect.ToString();
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(select, con);
            DataSet dataset = new DataSet("DatasetGenerico");
            DataTable dt = new DataTable("Usuarios");
            using (con)
            {
                try
                {
                    SqlDataAdapter OraDataAdapter = new SqlDataAdapter(cmd);
                    OraDataAdapter.Fill(dt);
                    if (dt.Rows.Count>0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (validarUsuarios(dr))
                            {
                                Session["User_ID"] = txbUsuario.Text;
                                Session["Password_ID"] = txbPassword.Text;
                                Response.Redirect("/TranserComentarios/admin/default.aspx");
                            } 
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }

        }

        private bool validarUsuarios(DataRow dr)
        {
            string usuario = dr["login"].ToString();
            string password = dr["password"].ToString();
            if (usuario==txbUsuario.Text)
            {
                if (password==txbPassword.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected void btnIngreso_Click(object sender, EventArgs e)
        {

        }
    }
}