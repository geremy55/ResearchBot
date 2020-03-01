using Dice.Client.Web;
using ResearchBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResearchBot.Services
{
    public class SingleBetCycle
    {
        public delegate void NoMoneyHandler(long userId, Currencies curr);
        public event NoMoneyHandler OnNoMoney;
        public delegate void BettingResult(BetResult result);
        public event BettingResult OnBetCompleted;
        
        public SingleBetCycle()
        {

        }      
        public async void StartBet(SingleBetData bet)
        {
            var betResult = new BetResult();
            while (true)
            {
                var result = await DiceWebAPI.PlaceBetAsync(bet.Session, bet.PayIn, bet.GessLow, bet.GessHigh, bet.ClientSeed, bet.Currency);

                if (result.Success)
                {
                    betResult.BetCount++;
                    if (result.PayOut > 0)
                    {
                        betResult.Profit += result.PayOut - bet.PayIn;
                        OnBetCompleted?.Invoke(betResult);
                        break;
                    }
                    else
                    {
                        betResult.Profit -= bet.PayIn;                       
                        if (betResult.BetCount % bet.Repit == 0 && betResult.BetCount != 0) bet.PayIn = bet.PayIn * 2;
                        CalcPercent(betResult.BetCount, bet);
                    }
                }
                else
                {
                    if (result.InsufficientFunds)
                    {
                        OnNoMoney?.Invoke(bet.Session.AccountId, bet.Currency);
                        Thread.Sleep(20000);
                    }
                }
            }            
        }


        private void CalcPercent(int betNr, SingleBetData bet)
        {
            int col = (bet.Drawdoun / 2) / 3;
            long percentPart = (bet.PercentMax - bet.PercentMin) / 3;

            if (betNr <= col)
            {
                bet.GessHigh = new Random().Next((int)bet.PercentMin, (int)(bet.PercentMin + percentPart));
            }
            else if (betNr > col && betNr <= 2 * col)
            {
                bet.GessHigh = betNr % 2 > 0 ? new Random().Next((int)bet.PercentMax - 100, (int)bet.PercentMax) :
                    new Random().Next((int)bet.PercentMin, (int)(bet.PercentMin + percentPart * 2));
            }
            else if (betNr > 2 * col)
            {
                bet.GessHigh = betNr % 2 > 0 ? new Random().Next((int)bet.PercentMax - 100, (int)bet.PercentMax) :
                    new Random().Next((int)(bet.PercentMin + percentPart * 2), (int)bet.PercentMax);
            }
            bet.ClientSeed = new Random().Next();
        }
    }
}
