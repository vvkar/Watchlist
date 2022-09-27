using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watchlist.API.Controllers.Base;
using Watchlist.API.Models.Pesponses;
using Watchlist.API.Models.Pesponses.Base;
using Watchlist.API.Models.Requests;
using Watchlist.Infrastructure.Business.Queries.Search.SearchFilms;

namespace Watchlist.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> SearchFilms([FromRoute] SearchFilmsRequest request)
        {
            var query = new SearchFilmsQuery(request.Title);

            var result = await _mediator.Send(query);

            var response = _mapper.Map<IEnumerable<ShortFilmResponse>>(result);

            return Ok(response);
        }
    }
}
