using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neobank.Test.API.Controllers.Base;
using Neobank.Test.API.Models.Pesponses;
using Neobank.Test.API.Models.Pesponses.Base;
using Neobank.Test.API.Models.Requests;
using Neobank.Test.Infrastructure.Business.CQRS.Commands;
using Neobank.Test.Infrastructure.Business.CQRS.Queries;

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
        [ProducesResponseType(typeof(SuccessResponse<IEnumerable<FilmResponse>>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(ErrorResponse<>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFilm([FromRoute]GetFilmsRequest request)
        {
            var query = new GetFilmQuery(request.Title);

            var result = await _mediator.Send(query);

            var response = _mapper.Map<IEnumerable<FilmResponse>>(result);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist([FromBody] AddToWatchlistRequest request)
        {
            var command = new AddToWatchlistCommand(request.UserId, request.FilmId);

            var result = await _mediator.Send(command);

            throw new NotImplementedException();
        }
    }
}
