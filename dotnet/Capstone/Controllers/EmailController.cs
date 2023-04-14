using Capstone.Email_Stuff;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using System.Net.Mail;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class EmailController : ControllerBase
    {
        private readonly GmailClient gmailClient;

        public EmailController(GmailClient gmailClient)
        {
            this.gmailClient = gmailClient;
        }

        [HttpGet]
        public ActionResult TestEndpoint()
        {
            return Ok();
        }

        [HttpPost("testEmail")]
        public ActionResult<MailMessage> SendTestEmail(Email email)
        {
            MailMessage message = gmailClient.createTestEmail(email.senderName, email.recepient);

            gmailClient.SendTest(message);
            return message;
        }
    }
}
