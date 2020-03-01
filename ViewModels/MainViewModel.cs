using Dice.Client.Web;
using ResearchBot.Helpers;
using ResearchBot.Models;
using ResearchBot.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.ViewModels
{
    public class MainViewModel : NotifyBase
    {
        private SingleBetCycle singleCycle;
        private MultiBetCycle multiBet;
        private SessionInfo session;
        private SingleBetData data;
        public int Count { get; set; }

        private MainWndModel viewObject;
        public MainWndModel ViewObject
        {
            get => viewObject;
            set
            {
                viewObject = value;
                OnPropertyChanged("ViewObject");
            }
        }        
        public MainViewModel() 
        {
            if (singleCycle == null)
            {
                singleCycle = new SingleBetCycle();
            }
            singleCycle.OnBetCompleted += SingleCycle_OnBetCompleted;
            ViewObject = new MainWndModel
            {
                
            };
        }

        public void Start()
        {
            Count = 30000;
            if (session == null)
            {
                var Login = new LoginService();
                Login.OnStartSession += Login_OnStartSession;
                //Login.LoginAsync("gerrr", "359x7Ke");
                Login.LoginAsync("sarrr21", "1K796ij");
            }
            else
            {
                Betting();
            }
        }

        private void Login_OnStartSession(SessionInfo session, string error = "")
        {
            if (session != null)
            {
                this.session = session;
                Preparebetting();
                Betting();
            }
        }

        private void Preparebetting()
        {
            ViewObject.BetCount = 0;
            ViewObject.NegativeBets = 0;
            ViewObject.Balance = session[Currencies.Doge].Balance;
            ViewObject.Currency = Currencies.Doge;
            
            data = new SingleBetData
            {
                Session = session,
                PayIn = -0.000000001m,
                Currency = Currencies.Doge,
                ClientSeed = new Random().Next(),
                //Repit = 1,
                //Drawdoun = 15,
                //GessLow = 0,
                //GessHigh = 490500,
                //PercentMax = 499500,
                //PercentMin = 490000
                Repit = 2,
                Drawdoun = 27,
                GessLow = 0,
                GessHigh = 249749,
                PercentMax = 249749,
                PercentMin = 240000
            };
        }

        private void Betting()
        {             
            data.PayIn = data.SetBaseBet();
            singleCycle.StartBet(data);
        }

        private void SingleCycle_OnBetCompleted(BetResult result)
        {
            ViewObject.Balance = session[Currencies.Doge].Balance;
            ViewObject.BetCount++;
            ViewObject.NegativeBets = result.BetCount;
            Count--;
            if (Count > 0)
            {                
                Betting();                
            }
            else
            {
                ViewObject.BetsOn = true;
            }
        }

        private RelayCommand startCommand;
        public RelayCommand StartCommand
        {
            get
            {
                return startCommand ??
                  (startCommand = new RelayCommand(obj =>
                  {
                      Start();
                      ViewObject.BetsOn = !ViewObject.BetsOn;
                  }));
            }
        }
    }
}
