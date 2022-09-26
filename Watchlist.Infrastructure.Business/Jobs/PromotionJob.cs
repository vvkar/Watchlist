using Microsoft.Extensions.Options;
using Quartz;
using Watchlist.Domain.Core.Models;
using Watchlist.Domain.Core.Options;
using Watchlist.Domain.Interfaces.Repositories;
using Watchlist.Domain.Interfaces.Services;
using Watchlist.Infrastructure.Business.Services;

namespace Watchlist.Infrastructure.Business.Jobs
{
    public class PromotionJob : IJob
    {
        private readonly IWatchlistItemRepository _repo;
        private readonly IFilmSearchService _searchService;
        private readonly ISenderService _senderService;
        private readonly PromotionOptions _options;
        public PromotionJob(IWatchlistItemRepository repo,
                            IFilmSearchService searchService,
                            ISenderService senderService,
                            IOptions<PromotionOptions> options)
        {
            _repo = repo;
            _searchService = searchService;
            _senderService = senderService;
            _options = options.Value;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await CheckWatchlistAndPromote();
        }

        public async Task CheckWatchlistAndPromote()
        {
            var unwatchedList = await GetUnwatchedList();

            if (unwatchedList.Count() < _options.MinimumFilmsLimit)
                return;

            foreach(var film in unwatchedList)
            {
                if(CheckPromotionAbility(film))
                {
                    var promotionTask = PromoteFilm(film);
                    var updateTask = UpdateFilmPromotionDate(film);
                    await Task.WhenAll(promotionTask, updateTask);
                    break;
                }
            }
        }

        public async Task<IEnumerable<WatchlistItemModel>> GetUnwatchedList()
        {
            var userIdList = await _repo.GetUsersAsync();

            var usersWatchlist = await _repo.GetAllAsync();

            var unwatchedList = usersWatchlist.Where(x => x.IsWatched == false).OrderByDescending(x => x.ImDbRating).ToList();
            
            return unwatchedList;
        }

        private bool CheckPromotionAbility(WatchlistItemModel film)
        {
            return film.PromotionDate is null 
                || (DateTime.Now.Subtract((DateTime)film.PromotionDate).TotalDays) >= _options.MinimumDaysAfterPromotion;
        }

        private async Task PromoteFilm(WatchlistItemModel film, string? userEmail = null)
        {
            var emailModel = await _searchService.GetFilmEmailModelByIdAsync(film.Id);
            var message = _senderService.CreateFilmPromotionMessage(emailModel, userEmail);
            await _senderService.SendEmailAsync(message);
        }

        private async Task UpdateFilmPromotionDate(WatchlistItemModel film)
        {
            film.PromotionDate = DateTime.Now;
            await _repo.UpdateFullAsync(film);
        }
    }
}
