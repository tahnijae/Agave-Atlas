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
using System.ComponentModel;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Capstone.Email_Stuff
{
    public class GmailClient
    {
        public static void TestMessage(string recepientName, string recepientEmail, string senderName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, "agaveatlas@hotmail.com"));
            message.To.Add(new MailboxAddress(recepientName, recepientEmail));
            message.Subject = "Testing Email";

            message.Body = new TextPart("plain")
            {
                Text = @"This message is a test!"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);

                client.Authenticate("agaveatlas@hotmail.com", "KaitlinLovesMargs23!");
                try
                {
                    client.Send(message);
                    client.Disconnect(true);
                    message.Dispose();
                }
                catch (SmtpException e)
                {
                    Console.WriteLine(e.StatusCode);
                    client.Disconnect(true);
                    message.Dispose();
                }
            }
        }
        public static void SendInvite(string recepientName, string recepientEmail, string senderName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(senderName, "agaveatlas@hotmail.com"));
            message.To.Add(new MailboxAddress(recepientName, recepientEmail));
            message.Subject = "Testing Email";

            message.Body = new TextPart("plain")
            {
                Text = @"This one was sent with recepient and sender params passed in from Postman"
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.office365.com", 587, false);

                client.Authenticate("agaveatlas@hotmail.com", "KaitlinLovesMargs23!");
                try
                {
                    client.Send(message);
                    client.Disconnect(true);
                    message.Dispose();
                }
                catch (SmtpException e)
                {
                    Console.WriteLine(e.StatusCode);
                    client.Disconnect(true);
                    message.Dispose();
                }
            }
        }
    }
}
