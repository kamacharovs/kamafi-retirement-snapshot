using KamaFi.Retirement.Snapshot.Application.Commands;
using KamaFi.Retirement.Snapshot.Application.Queries;
using KamaFi.Retirement.Snapshot.Application.Requests.Asset;
using KamaFi.Retirement.Snapshot.Application.Requests.Liability;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KamaFi.Retirement.Snapshot.Presentation.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUserById")]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id) => Ok(await _mediator.Send(new GetUserByIdQuery(id)));

        [HttpPost(Name = "CreateAsset")]
        [Route("assets")]
        public async Task<IActionResult> CreateAssetAsync([FromBody, Required] CreateAssetRequest request) => Ok(await _mediator.Send(new CreateAssetCommand(request)));

        [HttpPost(Name = "CreateLiability")]
        [Route("liabilities")]
        public async Task<IActionResult> CreateLiabilityAsync([FromBody, Required] CreateLiabilityRequest request) => Ok(await _mediator.Send(new CreateLiabilityCommand(request)));
    }
}