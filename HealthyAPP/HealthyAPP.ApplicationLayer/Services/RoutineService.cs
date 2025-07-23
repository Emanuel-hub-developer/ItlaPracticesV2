using HealthyAPP.ApplicationLayer.Contract;
using HealthyAPP.ApplicationLayer.DTOs.Routine;
using HealthyAPP.ApplicationLayer.DTOs.User;
using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.ApplicationLayer.Services
{
    public class RoutineService : IRoutineService
    {

        private readonly IUnitOfWork _unitOfWork;
        public RoutineService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<RoutineDTO>> GetAllRoutines()
        {
            var routines = await _unitOfWork.Routines.GetAllAsync();

            var routinesResponse = routines.Select(routine => new RoutineDTO
            {
                Name = routine.Name,
                Description = routine.Description,
                Duration_Minutes = routine.Duration_Minutes,
                Type = routine.Type,
                Performed_Date = routine.Performed_Date,
                User_id = routine.User_id
            }).ToList();

            return routinesResponse;
        }


        public async Task<RoutineDTO> GetRoutineById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("The id need to have a value.");
            }
            var routine = await _unitOfWork.Routines.GetByIdAsync(id);

            var response = new RoutineDTO
            {
                Name = routine.Name,
                Description = routine.Description,
                Duration_Minutes = routine.Duration_Minutes,
                Type = routine.Type,
                Performed_Date = routine.Performed_Date,
                User_id = routine.User_id

            };

            return response;
        }


        public async Task<RoutineDTO> CreateRoutine(CreateRoutineDTO request)
        {
            if (request == null) { throw new ArgumentNullException("Routine cannot be null."); }

            var routine = new Routine
            {
                Name = request.Name,
                Description = request.Description,
                Duration_Minutes = request.Duration_Minutes,
                Type = request.Type,
                Performed_Date = request.Performed_Date

            };

            routine = await _unitOfWork.Routines.CreateAsync(routine);

            await _unitOfWork.CompleteAsync();

            return new RoutineDTO
            {
                Routine_id = request.Routine_id,
                Name = request.Name,
                Description = request.Description,
                Duration_Minutes = request.Duration_Minutes,
                Type = request.Type,
                Performed_Date = request.Performed_Date
            };

        }


        public async Task/*<RoutineDTO> */UpdateRoutine(UpdateRoutineDTO request)
        {
            if (request == null || request.Routine_id <= 0)
            {
                throw new ArgumentException("Invalid Routine data.");
            }

            var existingRoutine = await _unitOfWork.Routines.GetByIdAsync(request.Routine_id);

            if (existingRoutine == null)
            {
                throw new ArgumentException("Routine not found.");
            }

            existingRoutine.Name = request.Name;
            existingRoutine.Description = request.Description;
            existingRoutine.Duration_Minutes = request.Duration_Minutes;
            existingRoutine.Type = request.Type;
            existingRoutine.Performed_Date = request.Performed_Date;


            await _unitOfWork.Routines.UpdateAsync(existingRoutine);
            await _unitOfWork.CompleteAsync();


        }


        public async Task DeleteRoutine(int id)
        {
            var existingRoutine = await _unitOfWork.Routines.GetByIdAsync(id);

            if (existingRoutine == null)
            {
                throw new InvalidDataException("Routine not found.");
            }

            var result = await _unitOfWork.Routines.DeleteAsync(id);

            if (result == false)
            {
                throw new InvalidDataException("Failed to delete routine.");
            }

        }
    }
}
