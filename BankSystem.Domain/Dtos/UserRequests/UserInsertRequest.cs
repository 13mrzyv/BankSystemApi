using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Dtos.UserRequests
{
    public class UserInsertRequest
    {
        public int UsertId { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }
        public string GmailAdress { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
    }
}
