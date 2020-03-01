using Dice.Client.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Models
{
    public abstract class BaseData
    {
        public SessionInfo Session { get; set; }
        public decimal PayIn { get; set; } 
        public int ClientSeed { get; set; }
        public Currencies Currency { get; set; }
        public long GessLow { get; set; }
        public long GessHigh { get; set; }
        public int Drawdoun { get; set; }
        public long PercentMin { get; set; }
        public long PercentMax { get; set; }
        public int Repit { get; set; } = 2;
        public decimal StopLoss { get; set; } = 0;

        public decimal SetBaseBet()
        {
            int BetUps = 2;
            int full = Drawdoun / Repit;
            int left = Drawdoun % Repit;

            int bigSum = 0;

            for (int j = 0; j <= full; j++)
            {
                bigSum += (int)Math.Pow(BetUps, j);
            }
            bigSum *= Repit;

            if (left > 0)
            {
                bigSum += left * (int)Math.Pow(BetUps, ++full);
            }
            return Math.Round(Math.Max(Session[Currency].Balance / bigSum, 0.00000001m), 8);
        }
    }
}
