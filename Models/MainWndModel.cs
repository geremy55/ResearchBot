using Dice.Client.Web;
using ResearchBot.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Models
{
    public class MainWndModel:NotifyBase
    {
        private bool betsOn = true;
        public bool BetsOn 
        {
            get => betsOn;
            set
            {
                betsOn = value;
                ButtonText = betsOn ? "Start" : "Busy";
            }
        } 

        private int betCount;
        public int BetCount
        {
            get => betCount;
            set
            {
                betCount = value;
                OnPropertyChanged("BetCount");
            }
        }

        private decimal balance;
        public decimal Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        private Currencies currency;
        public  Currencies Currency
        {
            get => currency;
            set
            {
                currency = value;
                OnPropertyChanged("Currencie");
            }
        }

        private int negativeBets;
        public int NegativeBets
        {
            get => negativeBets;
            set
            {
                negativeBets = Math.Max(value, negativeBets);
                OnPropertyChanged("Negativebets");
            }
        }

        private string buttonText = "Start";
        public string ButtonText
        {
            get => buttonText;
            set
            {
                buttonText = value;
                OnPropertyChanged("ButtonText");
            }
        }

    }
}
