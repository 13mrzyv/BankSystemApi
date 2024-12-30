using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Dtos
{
    public class LoginResponseModel
    {
        public string token { get; set; }
        public bool sucsess { get; set; }
        public string message { get; set; }
    }
}
