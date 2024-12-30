using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Dtos.UserRequests
{
    public class LoginRequestModel
    {
        public string GmailAdress { get; set; }
        public string Password { get; set; }
    }
}
