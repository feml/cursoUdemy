using SecurityScheme.Entities_Security;
namespace SecurityScheme.Interfaces
{
    public interface ISecurity
    {
        string GetCadena();
        AccessInformationDataBase getAccessInformationDB();
        AccessInformationMail getAccessInformationMail();
    }
}
