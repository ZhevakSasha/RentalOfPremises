using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Entityes
{
    public class Rent
    {
        public int Id { set; get; }

        public int OutletId { set; get; }

        public int ClientId { set; get; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }

        public Outlet Outlet { get; set; }

        public Client Client { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();
    }
}
