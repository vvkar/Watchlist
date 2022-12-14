using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Core.Options;
using Watchlist.Domain.Interfaces.Services;

namespace Watchlist.Infrastructure.Business.Services
{
    public class SenderService : ISenderService
    {
        private readonly SmtpOptions _options;
        public SenderService(IOptionsSnapshot<SmtpOptions> options)
        {
            _options = options.Value;
        }

        public async Task SendEmailAsync(MailMessage message)
        {
            using var client = new SmtpClient(_options.Server, _options.Port)
            {
                Credentials = new NetworkCredential(_options.Login, _options.Password),
                EnableSsl = true,
            };

            await client.SendMailAsync(message);
        }
        //TODO: user email may be discovered from Auth service
        public MailMessage CreateFilmPromotionMessage(FilmEmailModel filmModel, string? userEmail = null)
        {
            var body = HtmlGenerator.GenerateFilmPromotionMessage(filmModel);
            var from = new MailAddress(_options.SenderEmail, _options.SenderName);

            var to = userEmail is null
                ? new MailAddress(_options.MockEmail)
                : new MailAddress(userEmail);

            var message = new MailMessage(from, to)
            {
                Subject = "Promotion",
                Body = body,
                IsBodyHtml = true
            };

            return message;
        }
    }
}
