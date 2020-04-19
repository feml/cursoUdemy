using SendingEmail.Implementacion;
namespace SendingEmail.Interfaces
{
    public interface ICorreo
    {
        void CorreoBaseDatos(string asunto, string cuerpo);
        void CorreoDesarrollador(string asunto, string cuerpo);
        void CorreoDesarrollador(string asunto, string cuerpo, string correoCliente, params MailAttachment[] attachments);
    }
}
