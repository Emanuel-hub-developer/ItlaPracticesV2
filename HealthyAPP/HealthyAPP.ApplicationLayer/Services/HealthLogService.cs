using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.HealthLog;
using HealthyAPP.ApplicationLayer.DTOs.MealPlan;
using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.Services
{
    public class HealthLogService : IHealthLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HealthLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HealthLogDTO>> GetAllHealthLogs()
        {
            var healthLog = await _unitOfWork.HealthLogs.GetAllAsync();

            var healthLogResponse = healthLog.Select(health => new HealthLogDTO
            {
                LogDate = health.LogDate,
                Blood_Pressure = health.Blood_Pressure,
                Weight = health.Weight,
                Glucose = health.Glucose

            }).ToList();

            return healthLogResponse;
        }


        public async Task<HealthLogDTO> GetHealthLogById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The id need to have a value.");
            }
            var healthLog = await _unitOfWork.HealthLogs.GetByIdAsync(id);

            var response = new HealthLogDTO

            {
                LogDate = healthLog.LogDate,
                Blood_Pressure = healthLog.Blood_Pressure,
                Weight = healthLog.Weight,
                Glucose = healthLog.Glucose
            };

            return response;
        }


        public async Task<HealthLogDTO> CreateHealthLog(CreateHealthLogDTO request)
        {
            if (request == null) { throw new ArgumentNullException("Health Log cannot be null."); }

            var healthLog = new HealthLog
            {
                LogDate = request.LogDate,
                Blood_Pressure = request.Blood_Pressure,
                Weight = request.Weight,
                Glucose = request.Glucose
            };

            healthLog = await _unitOfWork.HealthLogs.CreateAsync(healthLog);

            await _unitOfWork.CompleteAsync();

            return new HealthLogDTO
            {
                HealthLog_Id = request.HealthLog_id,
                LogDate = healthLog.LogDate,
                Blood_Pressure = request?.Blood_Pressure,
                Weight = request?.Weight,
                Glucose = request?.Glucose
            };

        }


        public async Task/*<HealthLogDTO> */UpdateHealthLog(UpdateHealthLogDTO request)
        {
            if (request == null || request.HealthLog_id <= 0)
            {
                throw new ArgumentException("Invalid Health Log data.");
            }

            var existingHealthLog = await _unitOfWork.HealthLogs.GetByIdAsync(request.HealthLog_id);


            if (existingHealthLog == null)
            {
                throw new ArgumentException("Health Log not found.");
            }


            existingHealthLog.LogDate = request.LogDate;
            existingHealthLog.Blood_Pressure = request.Blood_Pressure;
            existingHealthLog.Weight = request.Weight;
            existingHealthLog.Glucose = request.Glucose;

            await _unitOfWork.HealthLogs.UpdateAsync(existingHealthLog);
            await _unitOfWork.CompleteAsync();


        }


        public async Task DeleteHealthLog(int id)
        {
            var existingHealthLog = await _unitOfWork.HealthLogs.GetByIdAsync(id);

            if (existingHealthLog == null)
            {
                throw new InvalidDataException("Health Log not found.");
            }

            var result = await _unitOfWork.HealthLogs.DeleteAsync(id);

            if (result == false)
            {
                throw new InvalidDataException("Failed to delete Health Log.");
            }

        }
    }
}
