using KamaFi.Retirement.Snapshot.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KamaFi.Retirement.Snapshot.Presentation.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id) => Ok(await _mediator.Send(new GetUserByIdQuery(id)));
    }
}