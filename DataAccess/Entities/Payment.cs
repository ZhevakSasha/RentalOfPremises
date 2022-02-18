using System;

namespace DataAccess.Entities
{
    public class Payment : IBaseModel
    {
        public int Id { get; set; }

        public int RentId { get; set; }

        public DateTime Date { get; set; }

        public decimal Contribution { get; set; }

        public Rent Rent { get; set; }
    }
}
