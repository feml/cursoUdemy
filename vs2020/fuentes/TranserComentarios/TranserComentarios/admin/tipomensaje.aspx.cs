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
    public partial class tipomensaje : System.Web.UI.Page
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
                gvPerson.AllowPaging = true;
                gvPerson.PageSize = 15;

                // Enable the GridView sorting option.
                gvPerson.AllowSorting = true;

                // Initialize the sorting expression.
                ViewState["SortExpression"] = "descripcion ASC";

                // Populate the GridView.
                BindGridView();
            }
        }


        private void BindGridView()
        {
            // Get the connection string from Web.config. 
            // When we use Using statement, 
            // we don't need to explicitly dispose the object in the code, 
            // the using statement takes care of it.
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a DataSet object.
                DataSet dsPerson = new DataSet();

                // Create a SELECT query.
                string strSelectCmd = "SELECT id, descripcion, id_Padre FROM Categorias where id_Padre=2";

                // Create a SqlDataAdapter object
                // SqlDataAdapter represents a set of data commands and a 
                // database connection that are used to fill the DataSet and 
                // update a SQL Server database. 
                SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);

                // Open the connection
                conn.Open();

                // Fill the DataTable named "Person" in DataSet with the rows
                // returned by the query.new n
                da.Fill(dsPerson, "Categorias");

                // Get the DataView from Person DataTable.
                DataView dvPerson = dsPerson.Tables["Categorias"].DefaultView;

                // Set the sort column and sort order.
                dvPerson.Sort = ViewState["SortExpression"].ToString();

                // Bind the GridView control.
                gvPerson.DataSource = dvPerson;
                gvPerson.DataBind();
            }
        }

        // GridView.RowDataBound Event
        protected void gvPerson_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Make sure the current GridViewRow is a data row.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Make sure the current GridViewRow is either 
                // in the normal state or an alternate row.
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    // Add client-side confirmation when deleting.
                    ((LinkButton)e.Row.Cells[1].Controls[0]).Attributes["onclick"] = "if(!confirm('Esta seguro que desea eliminar este Tipo Persona ?')) return false;";
                }
            }
        }

        // GridView.PageIndexChanging Event
        protected void gvPerson_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the index of the new display page. 
            gvPerson.PageIndex = e.NewPageIndex;

            // Rebind the GridView control to 
            // show data in the new page.
            BindGridView();
        }

        // GridView.RowEditing Event
        protected void gvPerson_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Make the GridView control into edit mode 
            // for the selected row. 
            gvPerson.EditIndex = e.NewEditIndex;

            // Rebind the GridView control to show data in edit mode.
            BindGridView();

            // Hide the Add button.
            lbtnAdd.Visible = false;
        }

        // GridView.RowCancelingEdit Event
        protected void gvPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Exit edit mode.
            gvPerson.EditIndex = -1;

            // Rebind the GridView control to show data in view mode.
            BindGridView();

            // Show the Add button.
            lbtnAdd.Visible = true;
        }

        // GridView.RowUpdating Event
        protected void gvPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a command object.
                SqlCommand cmd = new SqlCommand();

                // Assign the connection to the command.
                cmd.Connection = conn;

                // Set the command text
                // SQL statement or the name of the stored procedure 
                cmd.CommandText = "UPDATE Categorias SET descripcion = @descripcion WHERE id = @id";

                // Set the command type
                // CommandType.Text for ordinary SQL statements; 
                // CommandType.StoredProcedure for stored procedures.
                cmd.CommandType = CommandType.Text;

                // Get the PersonID of the selected row.
                string strPersonID = gvPerson.Rows[e.RowIndex].Cells[2].Text;
                string strLastName = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("txbDescripcion")).Text;
                //string strFirstName = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("TextBox2")).Text;

                // Append the parameters.
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = strPersonID;
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50).Value = strLastName;
                //cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = strFirstName;

                // Open the connection.
                conn.Open();

                // Execute the command.
                cmd.ExecuteNonQuery();
            }

            // Exit edit mode.
            gvPerson.EditIndex = -1;

            // Rebind the GridView control to show data after updating.
            BindGridView();

            // Show the Add button.
            lbtnAdd.Visible = true;
        }

        // GridView.RowDeleting Event
        protected void gvPerson_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a command object.
                SqlCommand cmd = new SqlCommand();

                // Assign the connection to the command.
                cmd.Connection = conn;

                // Set the command text
                // SQL statement or the name of the stored procedure 
                cmd.CommandText = "DELETE FROM Categorias WHERE id = @id";

                // Set the command type
                // CommandType.Text for ordinary SQL statements; 
                // CommandType.StoredProcedure for stored procedures.
                cmd.CommandType = CommandType.Text;

                // Get the PersonID of the selected row.
                string strPersonID = gvPerson.Rows[e.RowIndex].Cells[2].Text;

                // Append the parameter.
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = strPersonID;

                // Open the connection.
                conn.Open();

                // Execute the command.
                cmd.ExecuteNonQuery();
            }

            // Rebind the GridView control to show data after deleting.
            BindGridView();
        }

        // GridView.Sorting Event
        protected void gvPerson_Sorting(object sender, GridViewSortEventArgs e)
        {
            string[] strSortExpression = ViewState["SortExpression"].ToString().Split(' ');

            // If the sorting column is the same as the previous one, 
            // then change the sort order.
            if (strSortExpression[0] == e.SortExpression)
            {
                if (strSortExpression[1] == "ASC")
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "DESC";
                }
                else
                {
                    ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
                }
            }
            // If sorting column is another column,  
            // then specify the sort order to "Ascending".
            else
            {
                ViewState["SortExpression"] = e.SortExpression + " " + "ASC";
            }

            // Rebind the GridView control to show sorted data.
            BindGridView();
        }

        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            // Hide the Add button and showing Add panel.
            lbtnAdd.Visible = false;
            pnlAdd.Visible = true;
        }

        protected void lbtnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a command object.
                SqlCommand cmd = new SqlCommand();

                // Assign the connection to the command.
                cmd.Connection = conn;

                // Set the command text
                // SQL statement or the name of the stored procedure 
                cmd.CommandText = "INSERT INTO Categorias ( descripcion, id_Padre ) VALUES ( @descripcion, @id_Padre )";

                // Set the command type
                // CommandType.Text for ordinary SQL statements; 
                // CommandType.StoredProcedure for stored procedures.
                cmd.CommandType = CommandType.Text;
                Random r = new Random();
                // Append the parameters.
                //cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = r.Next(3, 99999999);
                cmd.Parameters.Add("@descripcion", SqlDbType.NVarChar, 50).Value = tbLastName.Text;
                cmd.Parameters.Add("@id_Padre", SqlDbType.NVarChar, 50).Value = 1;

                // Open the connection.
                conn.Open();

                // Execute the command.
                cmd.ExecuteNonQuery();
            }

            // Rebind the GridView control to show inserted data.
            BindGridView();

            // Empty the TextBox controls.
            tbLastName.Text = "";

            //tbFirstName.Text = "";

            // Show the Add button and hiding the Add panel.
            lbtnAdd.Visible = true;
            pnlAdd.Visible = false;
        }

        protected void lbtnCancel_Click(object sender, EventArgs e)
        {
            // Empty the TextBox controls.
            tbLastName.Text = "";

            //tbFirstName.Text = "";

            // Show the Add button and hiding the Add panel.
            lbtnAdd.Visible = true;
            pnlAdd.Visible = false;
        }


    }
}