using BusinessLogic.DtoModels;
using BusinessLogic.Services;
using DataAccess.Entityes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalOfPremisesAPI.Controllers
{
    [Route("api/outlet")]
    [ApiController]
    public class OutletController : ControllerBase
    {
        public OutletService _outletService;
        public OutletController(OutletService outletService)
        {
            _outletService = outletService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<OutletDto>>> GetAllOutlets()
        {
            var outlets = await _outletService.GetAllOutlets();

            if (outlets == null)
            {
                return NotFound();
            }

            return Ok(outlets);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OutletDto>> GetOutletById(int id)
        {
            var outlet = await _outletService.GetOutletById(id);

            if (outlet == null)
            {
                return NotFound();
            }

            return Ok(outlet);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOutlet([FromBody] OutletDto outletDto)
        {
            await _outletService.AddOutlet(outletDto);

            return CreatedAtAction(nameof(GetOutletById), new { Id = outletDto.Id }, outletDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOutlet([FromBody] OutletDto outletDto)
        {
            try
            {
                await _outletService.UpdateOutlet(outletDto);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOutlet(int id)
        {
            var outletDelete = await _outletService.GetOutletById(id);

            if (outletDelete == null)
            {
                return NotFound();
            }

            await _outletService.DeleteOutlet(id);

            return NoContent();
        }
    }
}
