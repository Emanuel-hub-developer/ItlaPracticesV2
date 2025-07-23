using HealthyAPP.DomainLayer.Entities;
using HealthyAPP.InfrastructureLayer.Context;
using HealthyAPP.InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyAPP.InfrastructureLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthyAPPContext _context;

        public GenericRepository<User> Users { get; }
        public GenericRepository<MealPlan> MealPlans { get; }
        public GenericRepository<Routine> Routines { get; }
        public GenericRepository<HealthLog> HealthLogs { get; }


        public UnitOfWork(HealthyAPPContext context)
        {
            _context = context;

            // Inicializar los repositorios
            Users = new GenericRepository<User>(_context);
            MealPlans = new GenericRepository<MealPlan>(_context);
            Routines = new GenericRepository<Routine>(_context);
            HealthLogs = new GenericRepository<HealthLog>(_context);

        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task RollBackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
