using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neobank.Test.API.Controllers.Base;
using Neobank.Test.API.Models.Pesponses;
using Neobank.Test.API.Models.Pesponses.Base;
using Neobank.Test.API.Models.Requests;
using Watchlist.Infrastructure.Business.CQRS.Commands;
using Watchlist.Infrastructure.Business.CQRS.Queries;

namespace Neobank.Test.API.Controllers
{
    [ApiController]
    public class FilmsController : BaseController
    {
        public FilmsController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator)
        {
        }

        /// <summary>
        /// Searches films by provided title
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Search completed successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">No data found</response>
        [HttpGet]
        [Route("{Title}")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<ShortFilmResponse>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilms([FromRoute]GetFilmsRequest request)
        {
            var query = new GetFilmQuery(request.Title);

            var result = await _mediator.Send(query);

            var response = _mapper.Map<IEnumerable<ShortFilmResponse>>(result);

            return Ok(response);
        }

        /// <summary>
        /// Adding film to User's watchlist
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Film added successfully</response>
        /// <response code="400">Invalid request data</response>
        [HttpPost]
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
        [Route("watchlist/{UserId}")]
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
        [HttpPost]
        [Route("change-status")]
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<WatchlistItemResponse>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeFilmStatus([FromBody] ChangeFilmStatusRequest request)
        {
            var command = new ChangeFilmStatusCommand(request.UserId, request.FilmId);

            var result = await _mediator.Send(command);

            var response = _mapper.Map<WatchlistItemResponse>(result);

            return Ok(response);
        }
    }
}
