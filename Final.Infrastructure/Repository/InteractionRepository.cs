using Final.Core.Entities;
using Final.Core.RepositoryInterfaces;
using Final.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Final.Core.Models.Request;

namespace Final.Infrastructure.Repository
{
    public class InteractionRepository :  IInteractionRepository
    {
        private readonly FinalDbContext _dbContext;
        public InteractionRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Interaction> AddAsync(Interaction entity)
        {
            _dbContext.Set<Interaction>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Interaction entity)
        {
            _dbContext.Set<Interaction>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Interaction> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Interaction>().FindAsync(id);
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsByClientId(int id)
        {
            return await _dbContext.Set<Interaction>().Where(i => i.ClientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsByEmployeeId(int id)
        {
            return await _dbContext.Set<Interaction>().Where(i => i.EmployeeId == id).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> ListAllAsync()
        {
            return await _dbContext.Set<Interaction>().ToListAsync();
        }

        public async Task<Interaction> UpdateInteraction(int id, InteractionCreateRequestModel Interaction)
        {
            var local = _dbContext.Set<Interaction>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Interaction { Id = id, ClientId = Interaction.ClientId, EmployeeId = Interaction.EmployeeId, InType = Interaction.Intype,
                IntDate = Interaction.IntDate, Remarks = Interaction.Remarks };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
