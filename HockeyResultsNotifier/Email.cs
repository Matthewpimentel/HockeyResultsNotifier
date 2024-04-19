using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Text;
using System.Threading.Tasks;

namespace HockeyResultsNotifier
{
    public class Email
    { 
        public void SendEmail(List<GameResult> results, string email)
        { 
            string emailContent = "";
            foreach (var result in results)
            {
                emailContent += result.ToString();
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Matthew Pimentel", "matthewpimentelgames@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Yesterday's Game Results";
            message.Body = new TextPart("plain")
            {
                Text = emailContent
            };

            string password = Environment.GetEnvironmentVariable("password");

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("matthewpimentelgames@gmail.com", password);
                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
