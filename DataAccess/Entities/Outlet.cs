using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entityes
{
    public class Outlet
    {
        public int Id { get; set; }

        public int Floor { get; set; }

        public int Square { get; set; }

        public decimal RentalCostPerDay { get; set; }

        public bool IsOccupied { get; set; }

        public Rent Rent { get; set; }

    }
}
