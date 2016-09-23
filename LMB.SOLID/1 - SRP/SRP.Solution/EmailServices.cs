using System.Net.Mail;

namespace LMB.SOLID.SRP.Solution
{
    public static class EmailServices
    {
        public static bool IsValid(string email)
        {
            return email.Contains("@");
        }

        public static bool Send(string to, string subject, string message)
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