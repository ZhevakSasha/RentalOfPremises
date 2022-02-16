using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entityes
{
    public class Payment
    {
        public int Id { get; set; }

        public int RentId { get; set; }

        public DateTime Date { get; set; }

        public decimal Contribution { get; set; }

        public Rent Rent { get; set; }
    }
}
