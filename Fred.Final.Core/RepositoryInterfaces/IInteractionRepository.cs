using Final.Core.Entities;
using Final.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.RepositoryInterfaces
{
    public  interface IInteractionRepository
    {
        //Task<bool> ExistIneraction(int InteractionId,int EmployeeId,DateTime IntDate);
        Task<IEnumerable<Interaction>> GetInteractionsByEmployeeId(int id);
        Task<IEnumerable<Interaction>> GetInteractionsByClientId(int id);
        
       

        
        
        Task<Interaction> GetByIdAsync(int Id); // return one record under certain class on corresponding Id



        //Creating
        Task<Interaction> AddAsync(Interaction entity);

        Task<Interaction> UpdateInteraction(int id, InteractionCreateRequestModel Interaction);

        //Delete
        Task DeleteAsync(Interaction entity);

        //show all
        Task<IEnumerable<Interaction>> ListAllAsync(); // return all records under certain class

    }
}
