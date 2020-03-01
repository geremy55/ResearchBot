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
    public class MultiBetCycle
    {
        private BetResult betResult = null;

        public delegate void NoMoneyHandler(long userId, Currencies curr);
        public event NoMoneyHandler OnNoMoney;
        public delegate void MBettingResult(BetResult result);
        public event MBettingResult OnBetCompleted;
       
        public MultiBetCycle()
        {
            betResult = new BetResult();
        }
        
        public async void StartBet(MultiBetData bet)
        {
            PlaceAutomatedBetsResponse result = await DiceWebAPI.PlaceAutomatedBetsAsync(bet.Session, bet.MultiBetSettings);
            if (result.Success)
            {
                betResult.BetCount++;
                if (result.TotalPayOut == 0)
                {
                    decimal baseBet;
                    if (result.BetCount > 1)
                    {
                        baseBet = result.PayIns[result.BetCount - 1] <= result.PayIns[result.BetCount - 2] ?
                                        2 * result.PayIns[result.BetCount - 1] : 2 * result.PayIns[result.BetCount - 2];
                    }
                    else
                    {
                        baseBet = 2 * result.PayIns[result.BetCount - 1];
                    }

                    SingleBetCycle singlBet = new SingleBetCycle();
                    SingleBetData sBet = bet.GetSingleData(baseBet);
                    singlBet.OnNoMoney += SinglBet_OnNoMoney;
                    BetResult singlResult = null;
                    singlBet.StartBet(sBet);
                    betResult.BetCount = result.BetCount + singlResult.BetCount;
                    betResult.Profit = result.TotalPayOut + result.TotalPayIn + singlResult.Profit;
                }
                else
                {
                    betResult.BetCount = result.BetCount;
                    betResult.Profit = result.TotalPayOut + result.TotalPayIn;
                    OnBetCompleted?.Invoke(betResult);
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

        private void SinglBet_OnNoMoney(long userId, Currencies curr)
        {
            OnNoMoney?.Invoke(userId, curr);
            Thread.Sleep(20000);
        }
    }
}
