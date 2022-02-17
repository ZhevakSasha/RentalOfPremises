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
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PaymentDto>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();

            if (payments == null)
            {
                return NotFound();
            }

            return Ok(payments);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PaymentDto>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
        {
            await _paymentService.AddPayment(paymentDto);

            return CreatedAtAction(nameof(GetPaymentById), new { Id = paymentDto.Id }, paymentDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto paymentDto)
        {
            try
            {
                await _paymentService.UpdatePayment(paymentDto);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }


            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var paymentDelete = await _paymentService.GetPaymentById(id);

            if (paymentDelete == null)
            {
                return NotFound();
            }

            await _paymentService.DeletePayment(id);

            return NoContent();
        }
    }
}
