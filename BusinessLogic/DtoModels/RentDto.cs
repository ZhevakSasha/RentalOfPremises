using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DtoModels
{
    public class RentDto
    {
        public int Id { get; set; }
        public int OutletId { set; get; }

        public int ClientId { set; get; }

        public DateTime DateOfStart { get; set; }

        public DateTime DateOfEnd { get; set; }
    }
}
