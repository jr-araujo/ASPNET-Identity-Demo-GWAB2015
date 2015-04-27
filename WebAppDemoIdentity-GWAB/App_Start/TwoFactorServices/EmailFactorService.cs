using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace WebAppDemoIdentity_GWAB.App_Start.TwoFactorServices
{
    public class EmailFactorService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {

            NetworkCredential credentials = new NetworkCredential(ConfigurationManager.AppSettings["SendGridUserName"], ConfigurationManager.AppSettings["SendGridSenha"]);

            SendGridMessage myMessage = new SendGridMessage();
            myMessage.AddTo(message.Destination);
            myMessage.From = new MailAddress("noreply@webdemoidentity.com.br", "GWAB 2015");
            myMessage.Subject = message.Subject;
            myMessage.Text = message.Body;

            // Create an Web transport for sending email.
            Web transportWeb = new Web(credentials);

            // Send the email.
            transportWeb.Deliver(myMessage);

            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}