using Final.Core.Entities;
using Final.Core.RepositoryInterfaces;
using Final.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Final.Core.Models.Request;
using System.Linq.Expressions;

namespace Final.Infrastructure.Repository
{
    public class ClientRepository :  IClientRepository
    {
        private readonly FinalDbContext _dbContext;
        public ClientRepository(FinalDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async  Task<Client> AddAsync(Client entity)
        {
            _dbContext.Set<Client>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //----------------------------------------------------------
        public async Task DeleteAsync(Client entity)
        {
            _dbContext.Set<Client>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Client>().FindAsync(id);
        }
        //------------------------------------------------
        public async Task<Client> GetClientByEmail(string email)
        {
            return await _dbContext.Clients.Include(c=>c.Interactions)
                .FirstOrDefaultAsync(m => m.Email ==email);
        }

        public  Client GetEntityById(int id)
        {
            return _dbContext.Set<Client>().Find(id);
        }

        public async Task<IEnumerable<Client>> ListAllAsync()
        {
            return await _dbContext.Set<Client>().ToListAsync();
        }

        public Task<IEnumerable<Client>> ListAsync(Expression<Func<Client, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Interaction>> ShowInteractions(int id)
        {
            var interactions = await _dbContext.Interactions.Where(i => i.ClientId==id).ToListAsync();
            return interactions;
        }

        public Task<Client> UpdateAsync(Client entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> UpdateClient(int id, ClientRegisterRequestModel client)
        {
            var local = _dbContext.Set<Client>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Client { Id = id, Name = client.Name, Email = client.Email, Phones = client.Phone, AddedOn = client.AddedOn, Address = client.Address,AddedBy =client.AddedBy  };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        //public class EFRepository<T> : IAsyncRepository<T> where T : class
        //{
        //protected readonly FinalDbContext _dbContext;
        //public EFRepository(FinalDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public virtual async Task<T> AddAsync(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public virtual async Task DeleteAsync(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);

        //    await _dbContext.SaveChangesAsync();
        //}


        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}


        //public virtual async Task<IEnumerable<T>> ListAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public virtual async Task<T> UpdateAsync(T entity)

        //{
        //    throw new NotImplementedException();
        //}

        //public virtual T GetEntityById(int id)
        //{
        //    return _dbContext.Set<T>().Find(id);
        //}

        //public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}
        // }
    }

}
