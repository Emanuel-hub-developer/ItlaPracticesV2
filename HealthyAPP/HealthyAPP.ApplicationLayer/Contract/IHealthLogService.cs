using HealthyAPP.ApplicationLayer.DTOs.HealthLog;

namespace HealthyAPP.ApplicationLayer.Contract
{
    public interface IHealthLogService
    {
        Task<HealthLogDTO> CreateHealthLog(CreateHealthLogDTO request);
        Task DeleteHealthLog(int id);
        Task<List<HealthLogDTO>> GetAllHealthLogs();
        Task<HealthLogDTO> GetHealthLogById(int id);
        Task UpdateHealthLog(UpdateHealthLogDTO request);
    }
}