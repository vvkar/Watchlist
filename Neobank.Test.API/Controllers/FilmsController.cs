using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Neobank.Test.Infrastructure.Business.CQRS.Queries;
using Neobank.Test.API.Models.Requests;

namespace Neobank.Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FilmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{Title}")]
        public async Task<IActionResult> GetFilm([FromRoute]GetFilmsRequest request)
        {
            var query = new GetFilmQuery(request.Title);

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
