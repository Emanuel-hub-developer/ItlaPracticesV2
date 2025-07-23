using HealthyAPP.ApplicationLayer.DTOs.Routine;

namespace HealthyAPP.ApplicationLayer.Contract
{
    public interface IRoutineService
    {
        Task<RoutineDTO> CreateRoutine(CreateRoutineDTO request);
        Task DeleteRoutine(int id);
        Task<List<RoutineDTO>> GetAllRoutines();
        Task<RoutineDTO> GetRoutineById(int id);
        Task UpdateRoutine(UpdateRoutineDTO request);
    }
}