using System;

namespace BusinessLogic.DtoModels
{
    public class PaymentDto
    {
        public int Id { get; set; }

        public int RentId { get; set; }

        public DateTime Date { get; set; }

        public decimal Contribution { get; set; }
    }
}
