using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranserComentarios.admin
{
    public partial class reporte : System.Web.UI.Page
    {
        #region Definicion de la variables globales
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

        private string _password_correo;
        private string _user_correo;
        private string asunto;
        private MailMessage msg;

        #endregion fin de la Definicion de la variables globales

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] != null)
            {
                if (Session["Password_ID"] != null)
                {
                    inicio();
                }
                else
                {
                    Response.Redirect("/admin/login.aspx");
                }
            }
            else
            {
                Response.Redirect("/admin/login.aspx");
            }
        }

        private void inicio()
        {

            cadena = WebConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

            if (!IsPostBack)
            {
                gdvMensajes.AllowPaging = true;
                gdvMensajes.PageSize = 8;
                gdvMensajes.AllowSorting = true;
                ViewState["SortExpression"] = "TipoFuncionario ASC";
                BindGridView();
            }
        }

        private void BindGridView()
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a DataSet object.
                DataSet dsPerson = new DataSet();

                // Create a SELECT query.
                string strSelectCmd = @"SELECT tf.[descripcion] TipoFuncionario
                                  ,tm.[descripcion] TipoMensaje
	                              ,count(ms.[id]) cantidadMensaje
                              FROM [TranserComentarios].[dbo].[Categorias] tf, [TranserComentarios].[dbo].[Categorias] tm,[TranserComentarios].[dbo].[mensaje] ms,
                              [TranserComentarios].[dbo].[destinatariosMensaje] dm
                              where tf.id_Padre=3
                              and  ms.[id_TipoInformacion]=tm.[id]
                              and dm.id_Mensaje=ms.id
                              and dm.id_TipoFuncionario=tf.id
                              group by tf.[descripcion],tm.[descripcion]
                              order by 2;";
                SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
                conn.Open();
                da.Fill(dsPerson, "Categorias");
                DataView dvPerson = dsPerson.Tables["Categorias"].DefaultView;
                dvPerson.Sort = ViewState["SortExpression"].ToString();
                gdvMensajes.DataSource = dvPerson;
                gdvMensajes.DataBind();
            }
        }
        protected void gdvMensajes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gv = (GridView)sender;
            gdvMensajes.PageIndex = e.NewPageIndex;
            BindGridView();
        }

    }
}