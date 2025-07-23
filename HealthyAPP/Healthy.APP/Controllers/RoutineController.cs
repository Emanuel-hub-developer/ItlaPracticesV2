using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.Routine;
using HealthyAPP.ApplicationLayer.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.APP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RoutineController : Controller
    {
        private readonly IRoutineService _routineService;

        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpGet]
        [Route("getAllRoutines")]
        public async Task<IActionResult> GetAllRoutines()
        {
            var routines = await _routineService.GetAllRoutines();
            return Ok(new { success = true, data = routines });
        }

        [HttpGet]
        [Route("getRoutineById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var routine = await _routineService.GetRoutineById(id);
            return Ok(new { success = true, data = routine });
        }

        [HttpPost]
        [Route("createRoutine")]

        public async Task<IActionResult> CreateRoutine([FromBody] CreateRoutineDTO request)
        {
            var routine = await _routineService.CreateRoutine(request);
            return Ok(new { success = true, data = routine });

        }

        [HttpPut]
        [Route("updateRoutine/{id}")]

        public async Task<IActionResult> UpdateRoutine([FromBody] UpdateRoutineDTO request)
        {
            await _routineService.UpdateRoutine(request);

            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteRoutine/{id}")]

        public async Task<IActionResult> DeleteRoutine(int id)
        {
            await _routineService.DeleteRoutine(id);

            return NoContent();
        }
    }
}
