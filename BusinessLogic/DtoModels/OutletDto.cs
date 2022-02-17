using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DtoModels
{
    public class OutletDto
    {
        public int Id { get; set; }
        public int Floor { get; set; }

        public int Square { get; set; }

        public decimal RentalCostPerDay { get; set; }

        public bool IsOccupied { get; set; }
    }
}
