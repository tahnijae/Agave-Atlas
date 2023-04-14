using Capstone.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Capstone.Security;

namespace Capstone.Email_Stuff
{
    public class GmailClient
    {
        private readonly JwtGenerator jwt;

        SmtpClient client = new SmtpClient("smtp.gmail.com")
        {
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = true,
            Port = 587,
            Credentials = new NetworkCredential("agaveatlas@gmail.com", "KaitlinLovesMargs23!"),
            EnableSsl = true,
        };
        
        public GmailClient() { }

        public MailMessage createTestEmail(string senderName, string recepient)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("agaveatlas@gmail.com"),
                Subject = $"Join {senderName} on Agave Atlas!",
                Body = "This is a test!",
                IsBodyHtml = false,
                
            };
            mailMessage.To.Add(recepient);
            return mailMessage;
        }
        public void SendTest(MailMessage message)
        {
            
            try
            {
                
                this.client.Send(message);
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e);
            }
        }
        
    }
}
