using Watchlist.Domain.Core.Models;

namespace Watchlist.Infrastructure.Business.Services
{
    public static class HtmlGenerator
    {
        public static string GenerateFilmPromotionMessage(FilmEmailModel film)
        {
            var message = $@"
            <html>
            <head>
            </head>
            <body>
                <div class=""container"">
                    <div class=""content"">
                        <h1 class=""title"">{film?.Film?.Title}</h1>
                        <h2 class=""rating"">IMDB Rating: {film?.Film?.ImDbRating}</h2>
                        <img class=""poster"" src=""{film?.Poster?.Uri}"" alt=""Poster"" title=""Poster"" style=""display:block; max-width:600px""> 
                        <div class=""description"">{film?.Wiki?.HtmlDescription}</div>
                    </div>
                </div>
            </body>
            </html>";

            return message;
        }
    }
}