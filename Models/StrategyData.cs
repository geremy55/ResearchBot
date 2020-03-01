using Dice.Client.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Models
{
    public class StrategyData
    {
        public int Drawdoun { get; set; } = 16;
        public int Repit { get; set; } = 1;
        public int Multiplier { get; set; } = 2;
        public decimal PercentMin { get; set; } = 499498;
        public decimal PercentMax { get; set; } = 499499;
        public int BetCount { get; set; } = 100;
        public string AccountToWithdraw { get; set; } = "210910661";
        public Currencies Currency { get; set; } = Currencies.Doge;
    }
}
