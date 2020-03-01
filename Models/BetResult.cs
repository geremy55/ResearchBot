using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Models
{
    public class BetResult
    {
        public decimal Profit { get; set; }
        public int BetCount { get; set; }
        public void Reset()
        {
            Profit = 0;
            BetCount = 0;
        }

    }
}
