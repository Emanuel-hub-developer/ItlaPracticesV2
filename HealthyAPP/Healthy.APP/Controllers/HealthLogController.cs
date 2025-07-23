using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.HealthLog;
using HealthyAPP.ApplicationLayer.DTOs.MealPlan;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.APP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HealthLogController : Controller
    {
        private readonly IHealthLogService _healthLogService;

        public HealthLogController(IHealthLogService healthLogService)
        {
            _healthLogService = healthLogService;
        }

        [HttpGet]
        [Route("getAllHealthLogs")]
        public async Task<IActionResult> GetAlllHealthLogs()
        {
            var healthLog = await _healthLogService.GetAllHealthLogs();
            return Ok(new { success = true, data = healthLog });
        }

        [HttpGet]
        [Route("getHealthLogById/{id}")]
        public async Task<IActionResult> GetlHealthLogById(int id)
        {
            var healthLog = await _healthLogService.GetHealthLogById(id);
            return Ok(new { success = true, data = healthLog });
        }

        [HttpPost]
        [Route("createHealthLog")]

        public async Task<IActionResult> CreateHealthLog([FromBody] CreateHealthLogDTO request)
        {
            var healthLog = await _healthLogService.CreateHealthLog(request);
            return Ok(new { success = true, data = healthLog });

        }

        [HttpPut]
        [Route("updateHealthLog/{id}")]
        public async Task<IActionResult> UpdateHealthLog([FromBody] UpdateHealthLogDTO request)
        {
            await _healthLogService.UpdateHealthLog(request);

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteHealthLog/{id}")]

        public async Task<IActionResult> DeleteHealthLog(int id)
        {
            await _healthLogService.DeleteHealthLog(id);

            return NoContent();
        }
    }
}
