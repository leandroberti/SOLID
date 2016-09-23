using System.Net.Mail;
using LMB.SOLID.DIP.Solution.Contracts;

namespace LMB.SOLID.DIP.Solution
{
    public class EmailServices : IEmailServices
    {
        public bool IsValid(string email)
        {
            return email.Contains("@");
        }

        public bool Send(string to, string subject, string message)
        {
            try
            {
                var mail = new MailMessage();
                var client = new SmtpClient();

                mail.To.Add(new MailAddress(to));
                mail.Subject = subject;
                mail.Body = message;

                client.Send(mail);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}