using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Final.Core.Models.Request;

namespace Final.Core.RepositoryInterfaces
{
    public interface IClientRepository
    {
        Task<Client> GetClientByEmail(string email);
        Task<Client> UpdateClient(int id, ClientRegisterRequestModel client);
        Task<IEnumerable<Interaction>> ShowInteractions(int id);
        Task<Client> GetByIdAsync(int Id); // return one record under certain class on corresponding Id



        //Creating
        Task<Client> AddAsync(Client entity);

        //Updating
        Task<Client> UpdateAsync(Client entity);

        //Delete
        Task DeleteAsync(Client entity);

        Client GetEntityById(int Id);
        //show all
        Task<IEnumerable<Client>> ListAllAsync(); // return all records under certain class
        Task<IEnumerable<Client>> ListAsync(Expression<Func<Client, bool>> filter);

        ////we need CRUD

        ////Reading
        //Task<T> GetByIdAsync(int Id); // return one record under certain class on corresponding Id



        ////Creating
        //Task<T> AddAsync(T entity);

        ////Updating
        //Task<T> UpdateAsync(T entity);

        ////Delete
        //Task DeleteAsync(T entity);

        //T GetEntityById(int Id);
        ////show all
        //Task<IEnumerable<T>> ListAllAsync(); // return all records under certain class
        //Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
    }


}
