using KamaFi.Retirement.Snapshot.Services;
using Microsoft.AspNetCore.Mvc;

namespace KamaFi.Retirement.Snapshot.Core.Controllers
{
    [ApiController]
    [Route("v1/retirement")]
    public class RetirementFactController : ControllerBase
    {
        private readonly IRetirementFactRepository _repo;

        public RetirementFactController(IRetirementFactRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("facts")]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _repo.GetAsync());
        }
    }
}