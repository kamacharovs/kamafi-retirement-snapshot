using KamaFi.Retirement.Snapshot.Data.Requests;
using KamaFi.Retirement.Snapshot.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KamaFi.Retirement.Snapshot.Core.Controllers
{
    [ApiController]
    [Route("v1/retirement")]
    public class RetirementController : ControllerBase
    {
        private readonly IRetirementRepository _repo;

        public RetirementController(IRetirementRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("calculator")]
        public IActionResult RetirementCalculator([FromBody, Required] RetirementCalculatorRequest request)
        {
            return Ok(_repo.RetirementCalculator(request));
        }
    }
}
