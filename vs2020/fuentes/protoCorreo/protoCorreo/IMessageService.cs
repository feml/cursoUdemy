using System.Threading.Tasks;

namespace protoCorreo
{
    public interface IMessageService
    {
        Task SendEmailAsync(
               string fromDisplayName,
               string fromEmailAddress,
               string toName,
               string toEmailAddress,
               string subject,
               string message,
               params Attachment[] attachments);

    }
}
