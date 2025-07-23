using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Repositories;

namespace HealthyAPP.InfrastructureLayer.Interfaces
{
    public interface IUnitOfWork
    {
        GenericRepository<HealthLog> HealthLogs { get; }
        GenericRepository<MealPlan> MealPlans { get; }
        GenericRepository<Routine> Routines { get; }
        GenericRepository<User> Users { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task CompleteAsync();
        Task RollBackTransactionAsync();
    }
}