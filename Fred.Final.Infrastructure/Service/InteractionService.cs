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

namespace Final.Infrastructure.Service
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;
        public InteractionService(IInteractionRepository InteractionRepository)
        {
            _interactionRepository = InteractionRepository;
        }

        public async Task<bool> AddInteraction(InteractionCreateRequestModel interaction)
        {

            var i = new Interaction
            {
                ClientId=interaction.ClientId,
                EmployeeId = interaction.EmployeeId,
                InType = interaction.Intype,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks


            };
            var createdInteraction = _interactionRepository.AddAsync(i);

            if (createdInteraction != null && createdInteraction.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task DeleteInteractionById(int id)
        {
            var res = _interactionRepository.GetByIdAsync(id).Result;
            if (res == null)
            {
                Console.WriteLine("not found Interaction with Id:" + id);
            }
            else
            {
                await _interactionRepository.DeleteAsync(res);
            }
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByClientId(int id)
        {
            return await _interactionRepository.GetInteractionsByClientId(id);
        }

        public async Task<IEnumerable<Interaction>> GetInteractionByEmployeeId(int id)
        {
            return await _interactionRepository.GetInteractionsByEmployeeId(id);
        }
    

        public async Task<Interaction> GetInteractionById(int id)
        {
            return await _interactionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Interaction>> ListAll()
        {
            return await _interactionRepository.ListAllAsync();
        }

        public async Task UpdateInteraction(int id, InteractionCreateRequestModel interaction)
        {

            await _interactionRepository.UpdateInteraction(id, interaction);
        }
    }
}
