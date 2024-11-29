using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Domain.Entities
{
    public class Prize
    {
        public int PrizeId { get; set; }
        public string PrizeName { get; set; }
        public string RequiredBonus { get; set; }
    }
}
