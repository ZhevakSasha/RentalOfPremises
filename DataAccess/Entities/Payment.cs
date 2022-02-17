using DataAccess.Entities;
using System;

namespace DataAccess.Entityes
{
    public class Payment : BaseModel
    {
        public int RentId { get; set; }

        public DateTime Date { get; set; }

        public decimal Contribution { get; set; }

        public Rent Rent { get; set; }
    }
}
