using System;
using System.Collections.Generic;
//using System.Data.Linq;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TranserComentarios
{
    public partial class Default : System.Web.UI.Page
    {
        private string _password_correo;
        private string _user_correo;
        private string asunto;
        protected void Page_Load(object sender, EventArgs e)
        {
            _password_correo = "transer";
            _user_correo = "TraColMin01";
            inicializar();
        }

        private void inicializar()
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string seleccionado = (string)DataBinder.Eval(e.Row.DataItem, "descripcion");
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = e;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int _idMensaje = int.Parse(ddTipoMensaje.SelectedValue);
            asunto = ddTipoMensaje.SelectedItem.Text;
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
                        //insertarRegistroCategoria(_idMensaje, _idTipoPersona, txtNombre.Text, txtApellido.Text, int.Parse(txtCedula.Text), correo, txtCiudad.Text, txtMensaje.Text, "true");
                        insertarRegistroCategoria(_idMensaje, _idTipoPersona, txtNombre.Text, txtApellido.Text, int.Parse(txtCedula.Text), txtEmail.Text, txtCiudad.Text, txtMensaje.Text, "true");
                        insertarRegistroDestinatarioMensaje(max, int.Parse(cod_correo));
                        enviar_correo_soporte(asunto, txtMensaje.Text, 1, txtEmail.Text);
                        enviar_correo_soporte(asunto, txtMensaje.Text, 1, correo);
                    }
                }
            }
            Response.Redirect("Default.aspx");
        }

        private string buscarCorreo(string cod_correo)
        {
            datos d = new datos();
            string correo = string.Empty;
            correo = d.capturarCorreo(cod_correo);
            return correo;
        }

        private int buscarMaxMensajes()
        {
            datos d = new datos();
            int max = 0;
            max = d.capturarMaxMensajes();
            return max + 1;
        }

        private void insertarRegistroCategoria(int _idMensaje, int _idTipoPersona, string nombres, string apellidos, int cedula, string correo, string ciudad, string mensaje, string enviado)
        {
            datos Categoria = new datos();
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
            Categoria.ejecutar(select, _nombreParametros, _valorParametros);
            //enviar_correo_soporte(asunto, txtMensaje.Text, 1, correo);
        }

        private void insertarRegistroDestinatarioMensaje(int max, int _idTipoPersona)
        {
            datos DestinatarioMensaje = new datos();
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
            DestinatarioMensaje.ejecutar(select, _nombreParametros, _valorParametros);
        }
        /// <summary>
        /// Definicion del metodo public void enviar_correo_soporte(string asunto, string cuerpo, int oficina)
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="cuerpo"></param>
        /// <param name="oficina"></param>
        /// 
        #region Definicion del metodo public void enviar_correo_soporte(string asunto, string cuerpo, int oficina)

        public void enviar_correo_soporte(string asunto, string cuerpo, int oficina, string correo)
        {
            #region Envio de correo
            MailMessage msg = new MailMessage();
            //msg.To.Add(correo);
            msg.To.Add(@"fmontoya@transer.com.co");
            //msg.Bcc.Add(correo);
            msg.Bcc.Add(@"francisco.montoya.l@gmail.com");
            msg.From = new MailAddress("robotcorreo@transer.com.co", "Robot Correo", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.Unicode;
            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_user_correo, _password_correo);
            client.Port = 25;
            client.Host = "192.168.30.8";
            client.EnableSsl = false;
            try
            {
                client.Send(msg);
            }
            catch (SmtpException smtp_exception)
            {
                string merror = smtp_exception.Message;
                //MessageBox.Show(smtp_exception.Message);
                //excepciones.smtpExcepcion(oficina, @"class ccorreo:transer.cclases.ccorreo", @"public void enviar_correo_soporte(string asunto, string cuerpo, int oficina)", @"c:\Transer\ws\web_ministerio\error_enviocorreo.txt", @"client.Send(msg);", smtp_exception);
            }

            #endregion // fin del Envio de correo

        }
        #endregion fin de la Definicion del metodo public void enviar_correo_soporte(string asunto, string cuerpo, int oficina)

    }
}