using BusinessLogic.DtoModels;
using BusinessLogic.Services;
using DataAccess.Entityes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalOfPremisesAPI.Controllers
{
    [Route("api/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        public RentService _rentService;
        public RentController(RentService rentService)
        {
            _rentService = rentService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<RentDto>>> GetAllRents()
        {
            var rents = await _rentService.GetAllRents();

            if (rents == null)
            {
                return NotFound();
            }

            return Ok(rents);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RentDto>> GetRentById(int id)
        {
            var rent = await _rentService.GetRentById(id);

            if (rent == null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRent([FromBody] RentDto rentDto)
        {
            await _rentService.AddRent(rentDto);

            return CreatedAtAction(nameof(GetRentById), new { Id = rentDto.Id }, rentDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRent([FromBody] RentDto rentDto)
        {
            try
            {
                await _rentService.UpdateRent(rentDto);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }


            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            var rentDelete = await _rentService.GetRentById(id);

            if (rentDelete == null)
            {
                return NotFound();
            }

            await _rentService.DeleteRent(id);

            return NoContent();
        }
    }
}
