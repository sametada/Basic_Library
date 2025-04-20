using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebApplication_01.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Here you can implement your email sending logic using SMTP, SendGrid, etc.
            return Task.CompletedTask;
            // For example, you can use SmtpClient to send emails.
            // using (var client = new SmtpClient("smtp.example.com"))
            // {
            //     client.Credentials = new NetworkCredential("username", "password");
            //     client.EnableSsl = true;
           
        }
    }
}
