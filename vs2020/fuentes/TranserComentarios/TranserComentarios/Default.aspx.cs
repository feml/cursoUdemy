/****************************** Encabezado del módulo ******************************\
* Nombre de la Clase:  namespace TranserComentarios / public partial class Default : System.Web.UI.Page
* namespace:      TranserComentarios
* Fecha de Creacion: 14/08/2017
* Fecha de Modificacion: dd/mm/yyyy
* DESCRIPCION DE LA CLASE
* 
* Todos los dereches reservados.
* Copyright (c) Transportes y Servicios TRANSER S.A.
\*****************************************************************************/
#region Definicion de las librerias utilizadas en el desarrollo de la clase
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
#endregion fin de la Definicion de las librerias utilizadas en el desarrollo de la clase

namespace TranserComentarios
{
    /// <summary>
    /// public partial class Default : System.Web.UI.Page
    /// </summary>
    #region Definicion de la clase public partial class Default : System.Web.UI.Page
    public partial class Default : System.Web.UI.Page
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

        /// <summary>
        /// protected void Page_Load(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        #region Definicion del evento protected void Page_Load(object sender, EventArgs e)
        protected void Page_Load(object sender, EventArgs e)
        {
            cadena = WebConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            //lblCadena.Text = cadena;
            if (!IsPostBack)
            {
                cargarTipomensaje();
                cargarTipoPersona();
                cargarDestinatarios();
            }
        }

        #endregion fin de la Definicion del evento protected void Page_Load(object sender, EventArgs e)

        /// <summary>
        /// private void cargarTipomensaje()
        /// </summary>
        #region Definicion del metodo private void cargarTipomensaje()
        private void cargarTipomensaje()
        {
            StringBuilder sbselect = new StringBuilder();
            sbselect.Append("select id,descripcion,id_Padre");
            sbselect.Append(" from categorias ");
            sbselect.Append(" where id_Padre=2");
            string select = sbselect.ToString();
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(select, con);
            DataSet dataset = new DataSet("DatasetGenerico");
            DataTable dt = new DataTable("Categorias");
            using (con)
            {
                try
                {
                    SqlDataAdapter OraDataAdapter = new SqlDataAdapter(cmd);
                    OraDataAdapter.Fill(dt);
                    ddTipoMensaje.DataSource = dt;
                    ddTipoMensaje.DataBind();
                    ddTipoMensaje.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }
            if (dt.Rows.Count > 0)
            {
                ddTipoMensaje.DataTextField = "descripcion";
                ddTipoMensaje.DataValueField = "id";

                dataset.Tables.Add(dt);
            }
            else
            {
                lblMensaje.Text = @"Aun no hay despachos ...";
            }
        }
        #endregion fin de la Definicion del metodo private void cargarTipomensaje()

        /// <summary>
        /// private void cargarTipoPersona()
        /// </summary>
        /// 
        #region Definicion del metodo private void cargarTipoPersona()
        private void cargarTipoPersona()
        {
            StringBuilder sbselect = new StringBuilder();
            sbselect.Append("select id,descripcion,id_Padre");
            sbselect.Append(" from categorias ");
            sbselect.Append(" where id_Padre=1");
            string select = sbselect.ToString();
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(select, con);
            DataSet dataset = new DataSet("DatasetGenerico");
            DataTable dt = new DataTable("Categorias");
            using (con)
            {
                try
                {
                    SqlDataAdapter OraDataAdapter = new SqlDataAdapter(cmd);
                    OraDataAdapter.Fill(dt);
                    ddTipoPersona.DataSource = dt;
                    ddTipoPersona.DataBind();
                    ddTipoPersona.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }
            if (dt.Rows.Count > 0)
            {
                ddTipoPersona.DataTextField = "descripcion";
                ddTipoPersona.DataValueField = "id";
                dataset.Tables.Add(dt);
            }
        }
        #endregion fin de la Definicion del metodo private void cargarTipoPersona()

        /// <summary>
        /// private void cargarDestinatarios()
        /// </summary>
        #region Definicion del metodo private void cargarDestinatarios()
        private void cargarDestinatarios()
        {
            StringBuilder sbselect = new StringBuilder();
            sbselect.Append("select id,descripcion,id_Padre");
            sbselect.Append(" from categorias ");
            sbselect.Append(" where id_Padre=3");
            string select = sbselect.ToString();
            SqlConnection con = new SqlConnection(cadena);
            SqlCommand cmd = new SqlCommand(select, con);
            DataSet dataset = new DataSet("DatasetGenerico");
            DataTable dt = new DataTable("Categorias");
            using (con)
            {
                try
                {
                    SqlDataAdapter OraDataAdapter = new SqlDataAdapter(cmd);
                    OraDataAdapter.Fill(dt);
                    gvDestinatarios.DataSource = dt;
                    gvDestinatarios.DataBind();
                    gvDestinatarios.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = ex.Message;
                }
            }
        }
        #endregion fin de la Definicion del metodo private void cargarDestinatarios()

        /// <summary>
        /// protected void btnEnviar_Click(object sender, EventArgs e)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Definicion del metodo protected void btnEnviar_Click(object sender, EventArgs e)
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cbxValidar.Checked)
            {
                int _idMensaje = int.Parse(ddTipoMensaje.SelectedValue);
                asunto = "SISTEMA DE SUGERENCIAS - " + ddTipoMensaje.SelectedItem.Text;
                int _idTipoPersona = int.Parse(ddTipoPersona.SelectedValue);
                string restado = string.Empty;
                int max = 0;
                bool getmax = false;
                foreach (GridViewRow row in gvDestinatarios.Rows)
                {
                    CheckBox cb = row.FindControl("chkEnviar") as CheckBox;
                    if (cb != null && cb.Checked)
                    {
                        if (getmax)
                        {
                            string cod_correo = Convert.ToString(gvDestinatarios.DataKeys[row.RowIndex].Value); //string.Empty;
                            string correo = buscarCorreo(cod_correo);
                            insertarRegistroDestinatarioMensaje(max, int.Parse(cod_correo));
                            enviar_correo_soporte(asunto, txtMensaje.Text, 1, correo);
                        }
                        else
                        {
                            max = buscarMaxMensajes();
                            getmax = true;
                            string cod_correo = Convert.ToString(gvDestinatarios.DataKeys[row.RowIndex].Value); //string.Empty;
                            string correo = buscarCorreo(cod_correo);
                            insertarRegistroCategoria(_idMensaje, _idTipoPersona, txtNombre.Text, txtApellido.Text, int.Parse(txtCedula.Text), txtEmail.Text, txtCiudad.Text, txtMensaje.Text, "true");
                            insertarRegistroDestinatarioMensaje(max, int.Parse(cod_correo));
                            enviar_correo_soporte(asunto, txtMensaje.Text, 1, txtEmail.Text);
                            enviar_correo_soporte(asunto, txtMensaje.Text, 1, correo);
                        }
                    }
                }   
            }
            Response.Redirect("Default.aspx");
        }
        #endregion fin de la Definicion del metodo protected void btnEnviar_Click(object sender, EventArgs e)

        /// <summary>
        /// public void enviar_correo_soporte(string asunto, string cuerpo, int oficina, string correo)
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="cuerpo"></param>
        /// <param name="oficina"></param>
        /// <param name="correo"></param>
        #region Definicion del metodo public void enviar_correo_soporte(string asunto, string cuerpo, int oficina, string correo)
        public void enviar_correo_soporte(string asunto, string cuerpo, int oficina, string correo)
        {
            msg = new MailMessage();
            #region Bloque MailMessage
            msg.To.Add(correo);
            msg.Bcc.Add(@"francisco.montoya.l@gmail.com");
            msg.From = new MailAddress("robotcorreo@transer.com.co", "Robot Correo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = true;
            #endregion fin del Bloque MailMessage

            SmtpClient client = new SmtpClient();
            #region Definicion del bloque SmtpClient
            _user_correo = "robotcorreo";
            _password_correo = "Tys860504882";
            client.Credentials = new System.Net.NetworkCredential(_user_correo, _password_correo);
            client.Port = 25;
            client.Host = "192.168.30.8";
            client.EnableSsl = false;
            #endregion fin de la Definicion del bloque SmtpClient
            try
            {
                client.Send(msg);
            }
            catch (SmtpException smtp_exception)
            {
                lblMensaje.Text = mensaje(smtp_exception);
            }
            catch (Exception exception)
            {
                lblMensaje.Text = mensaje(exception);
            }
        }
        #endregion fin de la Definicion del metodo public void enviar_correo_soporte(string asunto, string cuerpo, int oficina, string correo)

        /// <summary>
        /// private string mensaje(SmtpException ex)
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        #region Definicion del metodo private string mensaje(SmtpException ex)
        private string mensaje(SmtpException ex)
        {
            string htmlString;
            htmlString = ex.Message + "<br />";
            htmlString += ex.Source + "<br />";
            return htmlString;
        }
        #endregion fin de la Definicion del metodo private string mensaje(SmtpException ex)

        /// <summary>
        /// private string mensaje(SqlException ex)
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        #region Definicion del metodo private string mensaje(SqlException ex)
        private string mensaje(SqlException ex)
        {
            string htmlString;
            htmlString = ex.Message + "<br />";
            htmlString += ex.Source + "<br />";
            return htmlString;
        }
        #endregion fin de la Definicion del metodo private string mensaje(SmtpException ex)

        /// <summary>
        /// private string mensaje(Exception ex)
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        #region Definicion del mentodo private string mensaje(Exception ex)
        private string mensaje(Exception ex)
        {
            string htmlString;
            htmlString = ex.Message + "<br />";
            htmlString += ex.Source + "<br />";
            return htmlString;
        }
        #endregion fin de la Definicion del mentodo private string mensaje(Exception ex)

        /// <summary>
        /// private int buscarMaxMensajes()
        /// </summary>
        /// <returns></returns>
        #region Definicion del metodo private int buscarMaxMensajes()
        private int buscarMaxMensajes()
        {
            int max = 0;
            max = capturarMaxMensajes();
            return max + 1;
        }
        #endregion fin de la Definicion del metodo private int buscarMaxMensajes()

        /// <summary>
        /// private string buscarCorreo(string cod_correo)
        /// </summary>
        /// <param name="cod_correo"></param>
        /// <returns></returns>
        #region Definicion del metodo private string buscarCorreo(string cod_correo)
        private string buscarCorreo(string cod_correo)
        {
            string correo = string.Empty;
            using (SqlConnection connection = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand("select email Correo from Categoria_Correo where id_Tipo_Funcionario=" + cod_correo, connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                correo = reader.GetString(reader.GetOrdinal("Correo"));
                            }
                        }
                    }
                }
                catch (SqlException sql_exception)
                {
                    lblMensaje.Text = mensaje(sql_exception);
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = mensaje(ex);
                }
            }
            return correo;
        }
        #endregion fin de la Definicion del metodo private string buscarCorreo(string cod_correo)

        /// <summary>
        /// private void insertarRegistroDestinatarioMensaje(int max, int _idTipoPersona)
        /// </summary>
        /// <param name="max"></param>
        /// <param name="_idTipoPersona"></param>
        #region Definicion del metodo private void insertarRegistroDestinatarioMensaje(int max, int _idTipoPersona)
        private void insertarRegistroDestinatarioMensaje(int max, int _idTipoPersona)
        {
            StringBuilder insert = new StringBuilder();
            insert.Append(@"insert into destinatariosMensaje ");
            insert.Append(@"(id_Mensaje,id_TipoFuncionario) ");
            insert.Append(@" values (@maxid, @idTipoFuncionario) ");
            insert.Append(@"");
            string select = insert.ToString();
            string[] _nombreParametros;
            object[] _valorParametros;
            _nombreParametros = new string[2] { "@maxid", "@idTipoFuncionario" };
            _valorParametros = new object[2] { max, _idTipoPersona };
            ejecutar(select, _nombreParametros, _valorParametros);
        }
        #endregion fin de la Definicion del metodo private void insertarRegistroDestinatarioMensaje(int max, int _idTipoPersona)

        /// <summary>
        /// private void insertarRegistroCategoria(int _idMensaje, int _idTipoPersona, string nombres, string apellidos, int cedula, string correo, string ciudad, string mensaje, string enviado)
        /// </summary>
        /// <param name="_idMensaje"></param>
        /// <param name="_idTipoPersona"></param>
        /// <param name="nombres"></param>
        /// <param name="apellidos"></param>
        /// <param name="cedula"></param>
        /// <param name="correo"></param>
        /// <param name="ciudad"></param>
        /// <param name="mensaje"></param>
        /// <param name="enviado"></param>
        #region Definicion del metodo private void insertarRegistroCategoria(int _idMensaje, int _idTipoPersona, string nombres, string apellidos, int cedula, string correo, string ciudad, string mensaje, string enviado)
        private void insertarRegistroCategoria(int _idMensaje, int _idTipoPersona, string nombres, string apellidos, int cedula, string correo, string ciudad, string mensaje, string enviado)
        {
            //d.insertarRegistro(_idMensaje, _idTipoPersona,nombres,apellidos,cedula,@"jvillamiza@transer.com.co",ciudad,mensaje,enviado);
            StringBuilder insert = new StringBuilder();
            insert.Append(@"insert into mensaje ");
            insert.Append(@"(id_TipoPersona,id_TipoInformacion,nombres,apellidos,cedula,email,ciudad,mensaje,fechaEnvio,enviado) ");
            insert.Append(@" values (@idTipoPersona, @idTipoInformacion, @nombres,@apellidos,@cedula,@email,@ciudad,@mensaje,getDate(),@enviado) ");
            insert.Append(@"");
            string select = insert.ToString();
            string[] _nombreParametros;
            object[] _valorParametros;
            _nombreParametros = new string[9] { "@idTipoPersona", "@idTipoInformacion", "@nombres", "@apellidos", "@cedula", "@email", "@ciudad", "@mensaje", "@enviado" };
            _valorParametros = new object[9] { _idMensaje, _idTipoPersona, nombres, apellidos, cedula, correo, ciudad, mensaje, enviado };
            ejecutar(select, _nombreParametros, _valorParametros);
            //enviar_correo_soporte(asunto, txtMensaje.Text, 1, correo);
        }
        #endregion fin de la Definicion del metodo private void insertarRegistroCategoria(int _idMensaje, int _idTipoPersona, string nombres, string apellidos, int cedula, string correo, string ciudad, string mensaje, string enviado)


        /// <summary>
        /// public int capturarMaxMensajes()
        /// </summary>
        /// <returns></returns>
        /// 
        #region Definicion del metodo public int capturarMaxMensajes()
        public int capturarMaxMensajes()
        {
            int max = 0;
            //string cadena = WebConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cadena))
            using (SqlCommand cmd = new SqlCommand(" select max(id) maxid from mensaje", connection))
            {
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check is the reader has any rows at all before starting to read.
                        if (reader.HasRows)
                        {
                            // Read advances to the next row.
                            while (reader.Read())
                            {
                                // To avoid unexpected bugs access columns by name.
                                //object smax = reader.GetString(reader.GetOrdinal("maxid"));
                                object smax = reader.GetInt32(reader.GetOrdinal("maxid"));
                                //max = reader.GetString(reader.GetInt32("maxid"));
                                max = int.Parse(smax.ToString());
                            }
                        }
                    }
                }
                catch (SqlException oraexc)
                {
                    lblMensaje.Text = mensaje(oraexc);
                }
                catch (Exception exc)
                {
                    lblMensaje.Text = mensaje(exc);
                }
            }
            return max;
        }
        #endregion fin de la Definicion del metodo public int capturarMaxMensajes()

        /// <summary>
        /// public int ejecutar(string select, string[] nombre_parametro, object[] valor_parametro)
        /// </summary>
        /// <param name="select"></param>
        /// <param name="nombre_parametro"></param>
        /// <param name="valor_parametro"></param>
        /// <returns></returns>
        #region Definicion del metodo public int ejecutar(string select, string[] nombre_parametro, object[] valor_parametro)
        public int ejecutar(string select, string[] nombre_parametro, object[] valor_parametro)
        {
            int salida = 0;
            SqlCommand cmd = comandoExecute(select, nombre_parametro, valor_parametro);
            try
            {
                _start_time = DateTime.Now;
                salida = (int)cmd.ExecuteNonQuery();
                _end_time = DateTime.Now;
                _ts = _end_time - _start_time;
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (SqlException oraexc)
            {
                lblMensaje.Text = mensaje(oraexc);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception exc)
            {
                lblMensaje.Text = mensaje(exc);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return salida;
        }
        #endregion fin de la Definicion del metodo public int ejecutar(string select, string[] nombre_parametro, object[] valor_parametro)

        /// <summary>
        /// private OracleConnection conexion()
        /// </summary>
        /// <returns></returns>
        #region Definicion del metodo private OracleConnection conexion()
        private SqlConnection conexion()
        {
            conexionOpen = false;
            _connection = new SqlConnection();
            try
            {
                _connection.ConnectionString = cadena;
                _connection.Open();
                conexionOpen = true;
            }
            catch (SqlException oraexc)
            {
                lblMensaje.Text = mensaje(oraexc);
                _oracleexception = oraexc;
                excepcionPersonalizada = "Error de Oracle. \r\t\nMensaje de Error : " + oraexc.Message.ToString() + "  \r\t\nNumero del Error : " + oraexc.Number.ToString() + " \r\t\nNombre del Procedimiento : " + oraexc.Procedure.ToString() + "\r\t\n fuente del Error : " + oraexc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception exc)
            {
                lblMensaje.Text = mensaje(exc);
                _exception = exc;
                excepcionPersonalizada = "Error de ejecucion. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return _connection;
        }
        #endregion fin de la Definicion del metodo private OracleConnection conexion()

        /// <summary>
        /// private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)
        /// </summary>
        /// <param name="select"></param>
        /// <param name="nombre_parametro"></param>
        /// <param name="valor_parametro"></param>
        /// <returns></returns>
        #region Definicion del metodo private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)
        private SqlCommand comandoExecute(string select, string[] nombre_parametro, object[] valor_parametro)
        {
            _command = new SqlCommand();
            try
            {
                _command.Connection = conexion();
                _command.CommandType = CommandType.Text;
                _command.CommandText = select;
                for (int i = 0; i < nombre_parametro.Length; i++)
                {
                    _command.Parameters.Add(parametroInt(nombre_parametro[i], valor_parametro[i]));
                }
            }
            catch (SqlException oraexc)
            {
                _oracleexception = oraexc;
                excepcionPersonalizada = "Error de Oracle. \r\t\nMensaje de Error : " + oraexc.Message.ToString() + "  \r\t\nNumero del Error : " + oraexc.Number.ToString() + " \r\t\nNombre del Procedimiento : " + oraexc.Procedure.ToString() + "\r\t\n fuente del Error : " + oraexc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                lblMensaje.Text = mensaje(oraexc);
            }
            catch (Exception exc)
            {
                _exception = exc;
                excepcionPersonalizada = "Error de ejecucion. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                escribirMensaje(excepcionPersonalizada);
                lblMensaje.Text = mensaje(exc);
            }
            return _command;
        }
        #endregion fin de la Definicion del metodo private OracleCommand comando(string select, string[] nombre_parametro, object[] valor_parametro)        /// <summary>

        /// <summary>
        /// private OracleParameter parametroInt(string pnombre, object valor)
        /// </summary>
        /// <param name="pnombre"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        #region Definicion del metodo private OracleParameter parametroInt(string pnombre, object valor)
        private SqlParameter parametroInt(string pnombre, object valor)
        {
            bool getype = false;
            SqlParameter op = new SqlParameter();

            op.ParameterName = pnombre;
            op.Direction = ParameterDirection.Input;

            while (true)
            {
                if (valor.GetType() == Type.GetType("System.Int32"))
                {
                    op.Value = (int)valor;
                    op.SqlDbType = SqlDbType.Int;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Double"))
                {
                    op.Value = (Double)valor;
                    op.SqlDbType = SqlDbType.Int;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Int64"))
                {
                    op.Value = (long)valor;
                    op.SqlDbType = SqlDbType.Int;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.String"))
                {
                    op.Value = (string)valor;
                    op.SqlDbType = SqlDbType.VarChar;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.DateTime"))
                {
                    DateTime fecha = (DateTime)valor;
                    //op.Value = fecha.ToShortDateString() + " " +fecha.ToShortTimeString();
                    op.Value = valor;
                    op.SqlDbType = SqlDbType.Date;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Object"))
                {
                    op.Value = (byte[])valor;
                    op.SqlDbType = SqlDbType.BigInt;
                    getype = true;
                    break;
                }
                if (valor.GetType() == Type.GetType("System.Byte[]"))
                {
                    op.Value = (byte[])valor;
                    op.SqlDbType = SqlDbType.BigInt;
                    getype = true;
                    break;
                }
                if (!getype)
                {
                    try
                    {
                        op.Value = (byte[])valor;
                        op.SqlDbType = SqlDbType.BigInt;
                        getype = true;
                        break;
                    }
                    catch (Exception exc)
                    {
                        _exception = exc;
                        excepcionPersonalizada = "Error de ejecucion al momento de cargar parametos. \r\t\nMensaje de Error : " + exc.Message.ToString() + " \r\t\n data del Error : " + exc.Data.ToString() + " \r\t\nfuente del Error : " + exc.Source.ToString();
                        escribirMensaje(excepcionPersonalizada);
                        if (_connection.State == ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                    }
                }
            }

            return op;
        }
        #endregion fin de la Definicion del metodo private OracleParameter parametroInt(string pnombre, object valor)

        /// <summary>
        /// private void escribirMensaje(string mensaje)
        /// </summary>
        /// <param name="mensaje"></param>
        /// 
        #region Definicion del metodo private void escribirMensaje(string mensaje)
        private void escribirMensaje(string mensaje)
        {
            //HttpResponse Response = new HttpResponse(Response(@""));
            //System.Web.UI.Page Respose=new System.Web.UI.Page();
            //Respose.r.Redirect("ErrorEjecucion.aspx");
        }
        #endregion fin de la Definicion del metodo private void escribirMensaje(string mensaje)

        protected void cbxValidar_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxValidar.Checked)
            {
                btnEnviar.Enabled = true;
            }
        }

    }
    #endregion fin de la Definicion de la clase public partial class Default : System.Web.UI.Page
}