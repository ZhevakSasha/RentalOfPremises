using DataAccess.Entities;

namespace DataAccess.Entityes
{
    public class Outlet : BaseModel
    {
        public int Floor { get; set; }

        public int Square { get; set; }

        public decimal RentalCostPerDay { get; set; }

        public bool IsOccupied { get; set; }

        public Rent Rent { get; set; }

    }
}
