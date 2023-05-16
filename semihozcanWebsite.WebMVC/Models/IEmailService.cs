namespace semihozcanWebsite.WebMVC.Models
{
    public interface IEmailService
    {
        void Send(EmailMessage message);
    }
}
