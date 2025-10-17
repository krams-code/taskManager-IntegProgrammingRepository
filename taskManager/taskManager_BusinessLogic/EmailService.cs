using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MimeKit;

namespace taskManager_BusinessLogic;

public class EmailService
{
    public static void SendEmail(string recipientEmail, string User, string task)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Task System", "test@example.com"));
        message.To.Add(new MailboxAddress("User", recipientEmail));
        message.Subject = "Task Confirmation";

        message.Body = new TextPart("plain")
        {
            Text = $"Hello {User},\n\n" +
                   $"Your task {task} was completed Successfully.\n\n" +
                   "Thank you for using TaskManager!"
        };
        using (var client = new MailKit.Net.Smtp.SmtpClient())
        {
            var smtpHost = "sandbox.smtp.mailtrap.io";
            var smtpPort = 2525;
            var userName = "9d7309d5e95cb7";
            var password = "96bf9b69c2739d";

            client.Connect(smtpHost, smtpPort, SecureSocketOptions.StartTls);
            client.Authenticate(userName, password);

            client.Send(message);
            client.Disconnect(true);
        }
    }
}

