using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DtoModels
{
    public class LoginDetails
    {
        public LoginDetails(bool succeeded, string message, string token, DateTime expiration)
        {
            Succeeded = succeeded;
            Message = message;
            Token = token;
            Expiration = expiration;
        }
        public bool Succeeded { get; private set; }
        public string Message { get; private set; }
        public string Token { get; private set; }
        public DateTime Expiration { get; private set; }
    }
}
