using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace LMB.SOLID.SRP.Violation
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Ssn { get; set; }
        public DateTime InsertDate { get; set; }

        public string Add()
        {
            // Validate customer data
            if (!Email.Contains("@"))
                return "The customer email address is invalid!";

            if (Ssn.Length != 9)
                return "The customer Social Security Number is invalid!";

            // Add a new customer into database.
            using (var cn = new SqlConnection())
            {
                var cmd = new SqlCommand();

                cn.ConnectionString = "MyConnectionString";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CLIENTE (NAME, EMAIL, SSN, INSERTDATE) VALUES (@name, @email, @ssn, @insertdate))";

                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("email", Email);
                cmd.Parameters.AddWithValue("ssn", Ssn);
                cmd.Parameters.AddWithValue("insertdate", InsertDate);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            // Send a new email message
            var mail = new MailMessage("customer@domain.com", Email);
            var client = new SmtpClient
            {
                Port = 25,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Host = "smtp.google.com"
            };

            mail.Subject = "Bem Vindo.";
            mail.Body = "Congratulations! You are registered.";
            client.Send(mail);

            return "Customer successfully registered!";
        }
    }
}
