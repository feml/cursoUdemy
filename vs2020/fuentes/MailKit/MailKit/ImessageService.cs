using System.Threading.Tasks;

namespace MailKit
{
    public interface ImessageService
    {
        /*Task SendEmailAsync(
            string fromDisplayName,
            string fromEmailAddress,
            string toName,
            string toEmailAddress,
            string subject,
            string menssage,
            params Attachment[] attachments);*/
        Task SendEmailAsync(string fromDisplayName,
    string fromEmailAddress,
    string toName,
    string toEmailAddress,
    string subject,
    string menssage);
    }
}
