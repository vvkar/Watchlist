using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watchlist.API.Controllers.Base;
using Watchlist.API.Models.Pesponses;
using Watchlist.API.Models.Pesponses.Base;
using Watchlist.API.Models.Requests;
using Watchlist.Infrastructure.Business.Commands.Watchlist.AddToWatchlist;
using Watchlist.Infrastructure.Business.Commands.Watchlist.ChangeFilmStatus;
using Watchlist.Infrastructure.Business.Queries.Watchlist.GetWatchlist;

namespace Watchlist.API.Controllers
{
    [ApiController]
    public class WatchlistController : BaseController
    {
        public WatchlistController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator)
        {
        }

        /// <summary>
        /// Adding film to User's watchlist
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Film added successfully</response>
        /// <response code="400">Invalid request data</response>
        [HttpPost]
        [Route("film")]
        [ProducesResponseType(typeof(SuccessResponse<WatchlistItemResponse>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToWatchlist([FromBody] AddToWatchlistRequest request)
        {
            var command = new AddToWatchlistCommand(request.UserId, request.FilmId);

            var result = await _mediator.Send(command);

            var response = _mapper.Map<WatchlistItemResponse>(result);

            return Ok(response);
        }

        /// <summary>
        /// Returns User's watchlist
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Watchlist successfully found</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">User doesn't have a watchlist</response>
        [HttpGet]
        [Route("{UserId}")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<WatchlistItemResponse>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWatchlist([FromRoute] GetWatchlistRequest request)
        {
            var query = new GetWatchlistQuery(request.UserId);

            var result = await _mediator.Send(query);

            var response = _mapper.Map<IEnumerable<WatchlistItemResponse>>(result);

            return Ok(response);
        }

        /// <summary>
        /// Switches film status in User's watchlist
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Film status successfully changed</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">User doesn't have this film in a watchlist</response>
        [HttpPatch]
        [Route("film")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<WatchlistItemResponse>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeFilmStatus([FromBody] ChangeFilmStatusRequest request)
        {
            var command = new ChangeFilmStatusCommand(request.UserId, request.FilmId, request.IsWatched);

            var result = await _mediator.Send(command);

            var response = _mapper.Map<WatchlistItemResponse>(result);

            return Ok(response);
        }
    }
}
