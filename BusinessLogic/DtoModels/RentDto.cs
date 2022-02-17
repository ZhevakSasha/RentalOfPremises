using System;

namespace BusinessLogic.DtoModels
{
    public class RentDto
    {
        public int Id { get; set; }
        public int OutletId { set; get; }

        public int ClientId { set; get; }

        public DateTime DateOfStart { get; set; }

        public Decimal DownPayment { get; set; }
    }
}
