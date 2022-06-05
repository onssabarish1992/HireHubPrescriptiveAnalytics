using HRAnalyticsPrescriptiveAPI.Entities;
using HRAnalyticsPrescriptiveAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAnalyticsPrescriptiveAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class SolverController : ControllerBase
    {
        IPrescriptiveSolver _prescriptiveSolver;

        public SolverController(IPrescriptiveSolver prescriptiveSolver)
        {
            _prescriptiveSolver = prescriptiveSolver;
        }

        [HttpPost]
        [Route("Solve")]
        public IActionResult Solve([FromBody] Input argInput)
        {
            SolverResult result = new();
            try
            {
                result = _prescriptiveSolver.Solve(argInput);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(result);
        }
    }
}
