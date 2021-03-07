using Final.Core.Entities;
using Final.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.ServiceInterfaces
{
    public interface IInteractionService
    {
        Task<Interaction> GetInteractionById(int id);
        Task UpdateInteraction(int id, InteractionCreateRequestModel Interaction);
        Task DeleteInteractionById(int id);
        Task<bool> AddInteraction(InteractionCreateRequestModel Interaction);
        Task<IEnumerable<Interaction>> ListAll();
       
        Task<IEnumerable<Interaction>> GetInteractionByClientId(int id);
        Task<IEnumerable<Interaction>> GetInteractionByEmployeeId(int id);
    }
}
