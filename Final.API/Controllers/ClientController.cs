using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using System.Threading.Tasks;
using Final.Core.ServiceInterfaces;
using Final.Core.Entities;
using Final.Core.Models.Request;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> ListAllClients()
        {
            var clients = await _clientService.ListAll();
            if (!clients.Any())
            {
                return NotFound("didnt find any client, please add first");
            }
            return Ok(clients);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClient(ClientRegisterRequestModel client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var registeredClient = await _clientService.AddClient(client);
            return Ok(registeredClient);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getclientbyid(int id)
        {
            var client = await _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound("not found target client with id:" + id);
            }
            return Ok(client);
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _clientService.GetClientById(id);
            await _clientService.DeleteClientById(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClient( int id,ClientRegisterRequestModel client)
        {   
            await _clientService.UpdateClient(id,client);
            return Ok();

        }

        [HttpGet]
        [Route("interactions")]
        //[Route("interactions/{id:int}")]
        public async Task<IActionResult> ShowInteractions(int id)
        {
            var interactions = await _clientService.ShowInteractions(id);
            
            return Ok(interactions);
        }

    }
}

