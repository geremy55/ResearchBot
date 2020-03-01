using Dice.Client.Web;
using ResearchBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Controlls
{
    public class BettingController
    {
        private SingleBetCycle singleCycle;
        public BettingController()
        {
            if (singleCycle == null)
            {
                singleCycle = new SingleBetCycle();
            }
            singleCycle.OnBetCompleted += SingleCycle_OnBetCompleted;
            
        }
       

        public void Login(string login, string password)
        {
            var Login = new LoginService();
            Login.OnStartSession += Login_OnStartSession;
            Login.LoginAsync("gerrr", "359x7Ke");
        }

        private void Login_OnStartSession(SessionInfo session, string error = "")
        {
            if (session != null)
            {
                //this.session = session;
                //Preparebetting();
                //Betting();
            }
        }

        private void Preparebetting()
        {
            //ViewObject.BetCount = 0;
            //ViewObject.NegativeBets = 0;
            //ViewObject.Balance = session[Currencies.Doge].Balance;
            //ViewObject.Currency = Currencies.Doge;

            //data = new SingleBetData
            //{
            //    Session = session,
            //    PayIn = -0.000000001m,
            //    Currency = Currencies.Doge,
            //    ClientSeed = new Random().Next(),
            //    Repit = 2,
            //    Drawdoun = 33,
            //    GessLow = 0,
            //    GessHigh = 249749,
            //    PercentMax = 249749,
            //    PercentMin = 249000
            //    //Repit = 9,
            //    //Drawdoun = 120,
            //    //GessLow = 0,
            //    //GessHigh = 54900,
            //    //PercentMax = 54900,
            //    //PercentMin = 54500
            //};
        }

        private void Betting()
        {
            //data.PayIn = data.SetBaseBet();
            //singleCycle.StartBet(data);
        }

        private void SingleCycle_OnBetCompleted(Models.BetResult result)
        {
            //ViewObject.Balance = session[Currencies.Doge].Balance;
            //ViewObject.BetCount++;
            //ViewObject.NegativeBets = result.BetCount;
            //Count--;
            //if (Count > 0)
            //{
            //    Betting();
            //}
            //else
            //{
            //    ViewObject.BetsOn = true;
            //}
        }
    }
}
