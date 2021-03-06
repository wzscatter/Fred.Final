using Final.Core.Entities;
using Final.Core.ServiceInterfaces;
using Final.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Final.Infrastructure.Repository;
using Final.Core.Models.Request;
using MovieShop.Core.Exceptions;
using System.Linq.Expressions;

namespace Final.Infrastructure.Service
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<bool> AddClient(ClientRegisterRequestModel client)                    
        {
            var dbClient = await _clientRepository.GetClientByEmail(client.Email);
            if(dbClient!=null)
            {
                throw new ConflictException("Email already exists");
            }

            var c= new Client { Name = client.Name, Email = client.Email, Phones = client.Phone,
                AddedOn = client.AddedOn, Address = client.Address };
            var createdClient = _clientRepository.AddAsync(c);

            if (createdClient != null && createdClient.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteClientById(int id)
        {
            var res =  _clientRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Client with Id:" + id);
            }
            else
            {
                await _clientRepository.DeleteAsync(res);
            }
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public Task<Client> GetClientByEmail(string email)
        {
            return _clientRepository.GetClientByEmail(email);
        }

        public Task<IEnumerable<Client>> ListAll()
        {
            return _clientRepository.ListAllAsync();
        }

        public async Task UpdateClient(int id,ClientRegisterRequestModel client)
        {
            await _clientRepository.UpdateClient(id,client);

        }

        public Task<IEnumerable<Interaction>> ShowInteractions(int id)
        {
            return _clientRepository.ShowInteractions(id);
        }
    }
}
