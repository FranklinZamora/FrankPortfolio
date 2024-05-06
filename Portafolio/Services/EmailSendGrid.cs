using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailSendGrid
    {
        Task Enviar(ContactDTO contact);
    }
    public class EmailSendGrid : IEmailSendGrid
    {
        private readonly IConfiguration configuration;

        public EmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar(ContactDTO contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"The client {contact.Email} wants to contact you";
            var to = new EmailAddress(email, name);
            var messageTextPlane = contact.Message;
            var contenthtml =   $@"From: {contact.Name} -
                                Email: {contact.Email}
                                Message: {contact.Message}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, messageTextPlane, contenthtml);
            var answer = await client.SendEmailAsync(singleEmail); 
        }
    }
}
