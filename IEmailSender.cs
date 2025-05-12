using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Log or do nothing for now.
        Console.WriteLine($"Sending Email To: {email}\nSubject: {subject}\nMessage: {htmlMessage}");
        return Task.CompletedTask;
    }
}
