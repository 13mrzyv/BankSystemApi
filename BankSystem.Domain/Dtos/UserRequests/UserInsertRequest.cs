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
        public string PrizeBonus { get; set; }
    }
}
