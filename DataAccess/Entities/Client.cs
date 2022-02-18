using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities
{
    public class Client : IdentityUser<int>, IBaseModel
    {
        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string ContactPerson { get; set; }

        public List<Rent> Rents { get; set; }
    }
}
