using KamaFi.Retirement.Snapshot.Services;
using Microsoft.AspNetCore.Mvc;

namespace KamaFi.Retirement.Snapshot.Core.Controllers
{
    [ApiController]
    [Route("v1/information")]
    public class InformationController : ControllerBase
    {
        private readonly IInformationRepository _repo;

        public InformationController(IInformationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("advantage/starting/early")]
        public IActionResult GetAdvantageOfStartingEarly()
        {
            return Ok(_repo.GetAdvantageOfStartingEarly());
        }
    }
}