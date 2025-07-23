using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.MealPlan;
using HealthyAPP.ApplicationLayer.DTOs.Routine;
using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MealPlanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MealPlanDTO>> GetAllMealPlans()
        {
            var mealPlans = await _unitOfWork.MealPlans.GetAllAsync();

            var mealPlansResponse = mealPlans.Select(mealPlan => new MealPlanDTO
            {
                Name = mealPlan.Name,
                MealType = mealPlan.MealType,
                Calories = mealPlan.Calories,
                MealDate = mealPlan.MealDate

            }).ToList();

            return mealPlansResponse;
        }


        public async Task<MealPlanDTO> GetMealPlanById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The id need to have a value.");
            }
            var mealPlan = await _unitOfWork.MealPlans.GetByIdAsync(id);

            var response = new MealPlanDTO

            {
                Name = mealPlan.Name,
                MealType = mealPlan.MealType,
                Calories = mealPlan.Calories,
                MealDate = mealPlan.MealDate
            };

            return response;
        }


        public async Task<MealPlanDTO> CreateMealPlan(CreateMealPlanDTO request)
        {
            if (request == null) { throw new ArgumentNullException("Meal Plan cannot be null."); }

            var mealPlan = new MealPlan
            {
                Name = request.Name,
                MealType = request.MealType,
                Calories = request.Calories,
                MealDate = request.MealDate

            };

            mealPlan = await _unitOfWork.MealPlans.CreateAsync(mealPlan);

            await _unitOfWork.CompleteAsync();

            return new MealPlanDTO
            {
                MealPlan_id = mealPlan.MealPlan_id,
                Name = request.Name,
                MealType = request.MealType,
                Calories = request.Calories,
                MealDate = request.MealDate
            };

        }


        public async Task/*<MealPlanDTO> */UpdateMealPlan(UpdateMealPlanDTO request)
        {
            if (request == null || request.MealPlan_id <= 0)
            {
                throw new ArgumentException("Invalid Meal Plan data.");
            }

            var existingMealPlan = await _unitOfWork.MealPlans.GetByIdAsync(request.MealPlan_id);

            if (existingMealPlan == null)
            {
                throw new ArgumentException("Meal Plan not found.");
            }


            existingMealPlan.Name = request.Name;
            existingMealPlan.MealType = request.MealType;
            existingMealPlan.Calories = request.Calories;
            existingMealPlan.MealDate = request.MealDate;

            await _unitOfWork.MealPlans.UpdateAsync(existingMealPlan);
            await _unitOfWork.CompleteAsync();


        }


        public async Task DeleteMealPlan(int id)
        {
            var existingMealPlan = await _unitOfWork.MealPlans.GetByIdAsync(id);

            if (existingMealPlan == null)
            {
                throw new InvalidDataException("Meal Plan not found.");
            }

            var result = await _unitOfWork.MealPlans.DeleteAsync(id);

            if (result == false)
            {
                throw new InvalidDataException("Failed to delete Meal Plan.");
            }

        }
    }
}
