using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.MealPlan;
using HealthyAPP.ApplicationLayer.DTOs.Routine;
using Microsoft.AspNetCore.Mvc;

namespace Healthy.APP.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MealPlanController : Controller
    {
        private readonly IMealPlanService _mealPlanService;

        public MealPlanController(IMealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [HttpGet]
        [Route("getAllMealPlans")]
        public async Task<IActionResult> GetAllMealPlans()
        {
            var mealPlans = await _mealPlanService.GetAllMealPlans();
            return Ok(new { success = true, data = mealPlans });
        }

        [HttpGet]
        [Route("getMealPlanById/{id}")]
        public async Task<IActionResult> GetMealPlanById(int id)
        {
            var mealPlan = await _mealPlanService.GetMealPlanById(id);
            return Ok(new { success = true, data = mealPlan });
        }

        [HttpPost]
        [Route("createMealPlan")]

        public async Task<IActionResult> CreateMealPlan([FromBody] CreateMealPlanDTO request)
        {
            var mealPlan = await _mealPlanService.CreateMealPlan(request);
            return Ok(new { success = true, data = mealPlan });

        }

        [HttpPut]
        [Route("updateMealPlan/{id}")]
        public async Task<IActionResult> UpdateMealPlan([FromBody] UpdateMealPlanDTO request)
        {
            await _mealPlanService.UpdateMealPlan(request);

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteMealPlan/{id}")]

        public async Task<IActionResult> DeleteMealPlan(int id)
        {
            await _mealPlanService.DeleteMealPlan(id);

            return NoContent();
        }
    }
}
