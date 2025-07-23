using HealthyAPP.ApplicationLayer.DTOs.MealPlan;

namespace HealthyAPP.ApplicationLayer.Contract
{
    public interface IMealPlanService
    {
        Task<MealPlanDTO> CreateMealPlan(CreateMealPlanDTO request);
        Task DeleteMealPlan(int id);
        Task<List<MealPlanDTO>> GetAllMealPlans();
        Task<MealPlanDTO> GetMealPlanById(int id);
        Task UpdateMealPlan(UpdateMealPlanDTO request);
    }
}