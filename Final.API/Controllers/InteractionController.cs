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
    public class InteractionController : Controller
    {
        private readonly IInteractionService _InteractionService;
        public InteractionController(IInteractionService InteractionService)
        {
            _InteractionService = InteractionService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> ListAllInteractions()
        {
            var Interactions = await _InteractionService.ListAll();
            if (!Interactions.Any())
            {
                return NotFound("didnt find any Interaction, please add first");
            }
            return Ok(Interactions);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddInteraction(InteractionCreateRequestModel Interaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var CreateedInteraction = await _InteractionService.AddInteraction(Interaction);
            return Ok(CreateedInteraction);

        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> getInteractionbyid(int id)
        {
            var Interaction = await _InteractionService.GetInteractionById(id);
            if (Interaction == null)
            {
                return NotFound("not found target Interaction with id:" + id);
            }
            return Ok(Interaction);
        }



        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            var Interaction = await _InteractionService.GetInteractionById(id);
            await _InteractionService.DeleteInteractionById(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateInteraction(int id, InteractionCreateRequestModel Interaction)
        {
            await _InteractionService.UpdateInteraction(id, Interaction);
            return Ok();

        }

        [HttpGet]
        [Route("Employee/{id:int}")]
        public async Task<IActionResult> GetInterActionByEmployeeId(int id)
        {
            var interactions = await _InteractionService.GetInteractionByEmployeeId(id);

            return Ok(interactions);
        }

        [HttpGet]
        [Route("Client/{id:int}")]
        public async Task<IActionResult> ShowInteractions(int id)
        {
            var interactions = await _InteractionService.GetInteractionByClientId(id);

            return Ok(interactions);
        }

    }
}
