using Dice.Client.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Models
{
    public class MultiBetData : BaseData
    {
        public AutomatedBetsSettings MultiBetSettings
        {
            get { return AutoBetSetings(); }
        }

        public AutomatedBetsSettings AutoBetSetings()
        {
            return new AutomatedBetsSettings
            {
                BasePayIn = SetBaseBet(),
                ClientSeed = new Random().Next(),
                Currency = Currency,
                GuessHigh = GessHigh,
                GuessLow = GessLow,
                StartingPayIn = PayIn,
                IncreaseOnLosePercent = CalcIncreacePercent(),
                IncreaseOnWinPercent = 0,
                MaxAllowedPayIn = 0,
                MaxBets = Drawdoun*2/3,
                ResetOnLose = false,
                ResetOnLoseMaxBet = false,
                ResetOnWin = true,
                StopMaxBalance = Session[Currency].Balance + 0.00000001m,
                StopMinBalance = StopLoss,
                StopOnLoseMaxBet = false
            };
        }

        public SingleBetData GetSingleData(decimal baseBet)
        {
            return new SingleBetData
            {
                Session = Session,
                PayIn = baseBet,
                Currency = Currency,
                ClientSeed = new Random().Next(),
                GessLow = GessLow,
                GessHigh = GessHigh,
                PercentMax = PercentMax,
                PercentMin = PercentMin,
                Drawdoun = Drawdoun,
                Repit = Repit
            };
        }

        private decimal CalcIncreacePercent()
        {
            decimal magic = 499499;
            decimal percent = GessHigh / magic;
            return Math.Round(percent, 2);
        }

    }
}
