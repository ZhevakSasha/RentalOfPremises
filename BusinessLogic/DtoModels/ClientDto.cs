using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DtoModels
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string ContactPerson { get; set; }
    }
}
