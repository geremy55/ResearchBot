using Dice.Client.Web;
using ResearchBot.Models;
using ResearchBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Controlls
{
    public class ConsoleBetControll
    {
        private int Count = 1000;
        private SingleBetCycle singleCycle;
        private MultiBetCycle multiBet;
        private SessionInfo session;
        public ConsoleBetControll()
        {
            if (singleCycle == null)
            {
                singleCycle = new SingleBetCycle();
            }
            singleCycle.OnBetCompleted += SingleCycle_OnBetCompleted;

            multiBet = new MultiBetCycle();
            multiBet.OnBetCompleted += MultiBet_OnBetCompleted;
        }
              

        public void Start()
        {
          if(session==null)
            {
                var Login = new LoginService();
                Login.OnStartSession += Login_OnStartSession;
                Login.LoginAsync("sarrr21", "1K796ij");
            }
            else
            {
                MBetting();
            }
        }

        private void Login_OnStartSession(SessionInfo session, string error = "")
        {           
            if (session != null)
            {
                this.session = session;
                Betting();
            }
        }

        private void Betting()
        {            
            SingleBetData data = new SingleBetData
            {
                Session = session,
                PayIn = -0.000000001m,
                Currency = Currencies.Doge,
                ClientSeed = new Random().Next(),
                Repit = 2,
                Drawdoun = 33,
                GessLow = 0,
                GessHigh = 249749,
                PercentMax = 249749,
                PercentMin = 249000
                //Repit = 9,
                //Drawdoun = 150,
                //GessLow = 0,
                //GessHigh = 54900,
                //PercentMax = 54900,
                //PercentMin = 53900
            };
            data.PayIn = data.SetBaseBet();
            singleCycle.StartBet(data);
        }

        private void SingleCycle_OnBetCompleted(BetResult result)
        {
            if (Count > 0)
            {
                Betting();
                Count--;
            }           
        }

        private void MBetting()
        {
            MultiBetData data = new MultiBetData
            {
                Session = session,
                PayIn = -0.00000001m,
                Currency = Currencies.BTC,
                ClientSeed = new Random().Next(),
                Repit = 1,
                Drawdoun = 15,
                GessLow = 0,
                GessHigh = 499499,
                PercentMax = 499499,
                PercentMin = 499000
            };
            multiBet.StartBet(data);
        }

        private void MultiBet_OnBetCompleted(BetResult result)
        {
            if (Count > 0)
            {
                MBetting();
                Count--;
            }
        }
    }
}
