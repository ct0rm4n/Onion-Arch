using DTOs;

namespace Services
{
    public interface IEMailService
    {
        Task SendAsync(EMailDTO req);
    }
}
