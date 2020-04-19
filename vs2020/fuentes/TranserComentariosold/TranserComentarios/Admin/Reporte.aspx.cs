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
    public partial class Reporte : System.Web.UI.Page
    {
        private string cadena;
        protected void Page_Load(object sender, EventArgs e)
        {
            cadena = @"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015";
            // The Page is accessed for the first time.
            if (!IsPostBack)
            {
                // Enable the GridView paging option and 
                // specify the page size.
                gdvMensajes.AllowPaging = true;
                gdvMensajes.PageSize = 15;

                // Enable the GridView sorting option.
                gdvMensajes.AllowSorting = true;

                // Initialize the sorting expression.
                ViewState["SortExpression"] = "TipoFuncionario ASC";

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
                string strSelectCmd = @"select DISTINCT tf.descripcion TipoFuncionario,
                                                tm.descripcion TipoMensaje,
                                                count(id_Mensaje) Total
                                        from categorias tf, categorias tm, destinatariosMensaje, Categoria_Correo
                                        where destinatariosMensaje.id_TipoFuncionario=Categoria_Correo.id_Tipo_Funcionario
                                        and destinatariosMensaje.id_TipoFuncionario=tf.id
                                        and tf.id_Padre=3
                                        and tm.id_Padre=2
                                        group by tf.descripcion, tm.descripcion;";

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