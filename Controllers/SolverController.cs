using HRAnalyticsPrescriptiveAPI.Entities;
using HRAnalyticsPrescriptiveAPI.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAnalyticsPrescriptiveAPI.Controllers
{
    [Route("api/[controller]")]
    public class SolverController : ControllerBase
    {
        IPrescriptiveSolver _prescriptiveSolver;
        private readonly TelemetryClient _telemetryClient;

        public SolverController(IPrescriptiveSolver prescriptiveSolver, TelemetryClient telemetryClient)
        {
            _prescriptiveSolver = prescriptiveSolver;
            _telemetryClient = telemetryClient;
        }

        [HttpPost]
        [Route("Solve")]
        public IActionResult Solve([FromBody] Input argInput)
        {
            
            SolverResult result = new();
            try
            {
                _telemetryClient.TrackTrace("Solve API call started...");

                result = _prescriptiveSolver.Solve(argInput);

                _telemetryClient.TrackTrace("Solve API call ended...");
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackTrace("Exception caught while solving model...");
                _telemetryClient.TrackException(ex);
            }

            return Ok(result);
        }
    }
}
