using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DtoModels
{
    public class RegisterDto
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }
    }
}
