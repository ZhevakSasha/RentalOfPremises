using BusinessLogic.DtoModels;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalOfPremisesAPI.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<ClientDto>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ClientDto>> GetClientById(int id)
        {
            var client = await _clientService.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient([FromBody] ClientDto clientDto)
        {
            await _clientService.AddClient(clientDto);

            return CreatedAtAction(nameof(GetClientById), new { Id = clientDto.Id }, clientDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient([FromBody] ClientDto clientDto)
        {
            try
            {
                await _clientService.UpdateClient(clientDto);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var clientDelete = await _clientService.GetClientById(id);

            if (clientDelete == null)
            {
                return NotFound();
            }

            await _clientService.DeleteClient(id);

            return NoContent();
        }
    }
}
