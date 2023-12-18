
namespace Service.Application.Services
{
    public class EmailService
    {
        public EmailService() { }

        public bool SendEmails(string email) {
            try
            {
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool SendAllEmails()
        {
            return true;
        }

    }
}
