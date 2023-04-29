using KamaFi.Retirement.Snapshot.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KamaFi.Retirement.Snapshot.Presentation.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            return Ok(await _repo.GetAsync(id));
        }
    }
}