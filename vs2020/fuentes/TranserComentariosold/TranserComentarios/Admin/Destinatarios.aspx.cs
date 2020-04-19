/****************************** Encabezado del módulo ******************************\
* Nombre de la Clase:  plantilla.aspx.cs
* namespace:      comentariosTranser
* Fecha de Creacion: 14/07/2017
* Fecha de Modificacion: dd/mm/yyyy
* DESCRIPCION DE LA CLASE
* 
* Todos los dereches reservados.
* Copyright (c) Transportes y Servicios TRANSER S.A.
\*****************************************************************************/
#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
#endregion Using directives


namespace TranserComentarios.Admin
{
    public partial class Destinatarios : System.Web.UI.Page
    {
        private string cadena;
        private int codigo_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            cadena = @"Data Source=JSOPORTE\SQLEXPRESS;Initial Catalog=TranserComentarios;User ID=sa;Password=Satranser2015";
            // The Page is accessed for the first time.
            if (!IsPostBack)
            {
                // Enable the GridView paging option and 
                // specify the page size.
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
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                DataSet dsPerson = new DataSet();
                string strSelectCmd = @"SELECT DISTINCT Categorias.id CID,
                                            Categorias.descripcion CDescripcion, 
                                            Categoria_Correo.nombre CCoNombre,
                                            Categoria_Correo.email CCoCorreo,
                                            Categorias.Id_Padre CIdPadre,
                                            Categoria_Correo.id_Tipo_Funcionario CCoIdTipoFuncionario,
                                            Categoria_Correo.id CCID
                                            FROM Categorias, Categoria_Correo 
                                            where Categorias.id_Padre=3 
                                            and Categorias.id=id_Tipo_Funcionario";
                SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
                conn.Open();
                da.Fill(dsPerson, "Hibrido");
                DataView dvPerson = dsPerson.Tables["Hibrido"].DefaultView;
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
            //lbtnAdd.Visible = false;
        }

        // GridView.RowCancelingEdit Event
        protected void gvPerson_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Exit edit mode.
            gvPerson.EditIndex = -1;

            // Rebind the GridView control to show data in view mode.
            BindGridView();

            // Show the Add button.
            //lbtnAdd.Visible = true;
        }

        // GridView.RowUpdating Event
        protected void gvPerson_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //DataSet dsdvDestinatarios = new DataSet();
            //using (SqlConnection conn = new SqlConnection(cadena))
            //{
            //    string strSelectCmd = @"SELECT id ID, descripcion Descripcion FROM Categorias where id_Padre=3";
            //    SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
            //    conn.Open();
            //    da.Fill(dsdvDestinatarios, "Categorias");
            //}
            //DataTable dt = dsdvDestinatarios.Tables["Categorias"];
            //if (dt.Rows.Count > 0)
            //{
            //    //DropDownList loco = ((DropDownList)gvPerson.Rows[e.RowIndex].FindControl("ddl_Tipo_Funcionario"));
            //    //DropDownList DropDownList1 = ((DropDownList)gvPerson.Rows[e.RowIndex].FindControl("ddl_Tipo_Funcionario"));
            //    /*DropDownList1.DataSource = dt;
            //    DropDownList1.DataTextField = "Descripcion";
            //    DropDownList1.DataValueField = "ID";
            //    DropDownList1.DataBind();*/
            //}


            using (SqlConnection conn = new SqlConnection(cadena))
            {
                // Create a command object.
                SqlCommand cmd = new SqlCommand();

                // Assign the connection to the command.
                cmd.Connection = conn;

                // Set the command text
                // SQL statement or the name of the stored procedure 
                cmd.CommandText = "UPDATE Categoria_Correo SET nombre = @nombre, email = @email WHERE id = @id";

                // Set the command type
                // CommandType.Text for ordinary SQL statements; 
                // CommandType.StoredProcedure for stored procedures.
                cmd.CommandType = CommandType.Text;

                // Get the PersonID of the selected row.
                //string strPersonID = gvPerson.Rows[e.RowIndex].Cells[3].Text;
                string idCodigoCorreo = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("txtCodigoID")).Text;
                /*DropDownList loco = ((DropDownList)gvPerson.Rows[e.RowIndex].FindControl("ddl_Tipo_Funcionario"));
                strPersonID = loco.SelectedValue;*/
                string strNombre = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("txtNombre")).Text;
                string strEmail = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("txtEmail")).Text;
                //string strFirstName = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("TextBox2")).Text;

                // Append the parameters.
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = idCodigoCorreo;
                cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = strNombre;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = strEmail;
                //cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = strFirstName;

                // Open the connection.
                conn.Open();

                // Execute the command.
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            // Exit edit mode.
            gvPerson.EditIndex = -1;

            // Rebind the GridView control to show data after updating.
            BindGridView();

            // Show the Add button.
            //lbtnAdd.Visible = true;
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
                cmd.CommandText = "DELETE FROM Categoria_Correo WHERE id = @id";

                // Set the command type
                // CommandType.Text for ordinary SQL statements; 
                // CommandType.StoredProcedure for stored procedures.
                cmd.CommandType = CommandType.Text;

                // Get the PersonID of the selected row.
                string strPersonID = gvPerson.Rows[e.RowIndex].Cells[5].Text;
                string idCodigoCorreo = ((TextBox)gvPerson.Rows[e.RowIndex].FindControl("txtCodigoID")).Text;

                // Append the parameter.
                //cmd.Parameters.Add("@id", SqlDbType.Int).Value = strPersonID;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = idCodigoCorreo;

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


        //protected void lbtnSubmit_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection conn = new SqlConnection(cadena))
        //    {
        //        // Create a command object.
        //        SqlCommand cmd = new SqlCommand();

        //        // Assign the connection to the command.
        //        cmd.Connection = conn;

        //        // Set the command text
        //        // SQL statement or the name of the stored procedure 
        //        cmd.CommandText = "INSERT INTO Categoria_Correo ( id_Tipo_Funcionario, email, nombre ) VALUES ( @id_Tipo_Funcionario, @email, @nombre )";

        //        // Set the command type
        //        // CommandType.Text for ordinary SQL statements; 
        //        // CommandType.StoredProcedure for stored procedures.
        //        cmd.CommandType = CommandType.Text;
        //        Random r = new Random();
        //        // Append the parameters.
        //        //cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = r.Next(3, 99999999);
        //        cmd.Parameters.Add("@id_Tipo_Funcionario", SqlDbType.NVarChar, 50).Value = codigo_ID;
        //        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = tbCorreo.Text;
        //        cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = tbNombre.Text;

        //        // Open the connection.
        //        conn.Open();

        //        // Execute the command.
        //        cmd.ExecuteNonQuery();
        //    }

        //    // Rebind the GridView control to show inserted data.
        //    BindGridView();

        //    // Empty the TextBox controls.
        //    //tbLastName.Text = "";

        //    //tbFirstName.Text = "";

        //    // Show the Add button and hiding the Add panel.
        //    lbtnAdd.Visible = true;
        //    pnlAdd.Visible = false;
        //}

        //protected void lbtnCancel_Click(object sender, EventArgs e)
        //{
        //    // Empty the TextBox controls.
        //    //tbLastName.Text = "";

        //    //tbFirstName.Text = "";

        //    // Show the Add button and hiding the Add panel.
        //    lbtnAdd.Visible = true;
        //    pnlAdd.Visible = false;
        //}

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    codigo_ID = Convert.ToInt16(DropDownList1.SelectedValue);
        //}

        protected void gvPerson_DataBound(object sender, GridViewRowEventArgs e)
        {




            DataSet dsdvDestinatarios = new DataSet();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                using (SqlConnection conn = new SqlConnection(cadena))
                {
                    string strSelectCmd = @"SELECT id ID, descripcion Descripcion FROM Categorias where id_Padre=3";
                    SqlDataAdapter da = new SqlDataAdapter(strSelectCmd, conn);
                    conn.Open();
                    da.Fill(dsdvDestinatarios, "Categorias");
                }
                DataTable dt = dsdvDestinatarios.Tables["Categorias"];
                if (dt.Rows.Count > 0)
                {
                    DropDownList DropDownList1 = (DropDownList)e.Row.FindControl("ddl_Tipo_Funcionario");
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "Descripcion";
                    DropDownList1.DataValueField = "ID";
                    DropDownList1.DataBind();
                }
            }
        }

        protected void gvPerson_DataBound(object sender, EventArgs e)
        {
            //DropDownList drp = (DropDownList)sender;
            GridView dre = (GridView)sender;
            //GridViewRow gv = (GridViewRow)drp.NamingContainer;
            //GridViewRow gv = (GridViewRow)sender;
            //int index = gv.RowIndex;
            //DropDownList DropDownList1 = (DropDownList)gvPerson.Rows[index].FindControl("ddl_Tipo_Funcionario");
            //Label label1 = (Label)gvPerson.Rows[index].FindControl("lblTipoFuncionario");
            //label1.Text = DropDownList1.SelectedItem.Text;
        }

        protected void lnkAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
