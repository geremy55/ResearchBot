using Dice.Client.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResearchBot.Services
{
    public class LoginService
    {
        public delegate void StartSession(SessionInfo session, string error = "");
        public event StartSession OnStartSession;

        private readonly string ApiKey = "b932ea4fa2e9407498169075b17d3d3a";
        public LoginService() { }

        public void LoginAsync(string login, string password, int code = 0)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) return;

            var responce = DiceWebAPI.BeginSession(ApiKey, login, password, code);

            if (responce.Success)
            {
                OnStartSession?.Invoke(responce.Session);
            }
            else
            {
                OnStartSession?.Invoke(null, DisplayError(responce));
            }
        }

        private string DisplayError(BeginSessionResponse response)
        {
            if (response.InvalidApiKey)
                return "The API key for this program is not valid";
            else if (response.LoginRequired)
                return "This account is protected by a username and password. Please login instead.";
            else if (response.RateLimited)
                return "Actions are being performed too quickly. Please slow down.";
            else if (response.WrongUsernameOrPassword)
                return "Wrong username or password";
            else if (response.ErrorMessage != null)
                return "Error: " + response.ErrorMessage;
            else
                return "An error occurred";
        }
    }
}
