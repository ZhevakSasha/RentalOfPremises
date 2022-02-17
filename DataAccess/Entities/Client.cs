using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Entityes
{
    public class Client : BaseModel
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string ContactPerson { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
