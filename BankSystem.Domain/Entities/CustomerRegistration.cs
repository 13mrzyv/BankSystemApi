using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class CustomerRegistration
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string surName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string GmailAdress { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
    }
}
