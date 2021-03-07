using Final.Core.Entities;
using Final.Core.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.ServiceInterfaces
{
    public interface IClientService
    {
        Task<Client> GetClientById(int id);
        Task<Client> UpdateClient(int id,ClientRegisterRequestModel client);
        Task  DeleteClientById(int id);
        Task<bool> AddClient(ClientRegisterRequestModel client);
        Task<IEnumerable<Client>> ListAll();
        Task<Client> GetClientByEmail(string email);
        Task<IEnumerable<Interaction>> ShowInteractions(int id);
    }
}
