using System.Net.Mail;
using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Services
{
    public interface ISenderService
    {
        MailMessage CreateFilmPromotionMessage(FilmEmailModel filmModel, string? userEmail = null);
        Task SendEmailAsync(MailMessage message);
    }
}