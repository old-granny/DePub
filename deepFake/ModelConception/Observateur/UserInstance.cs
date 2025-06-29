using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.ModelConception.Observateur
{
    public class UserInstance : ObserveurUser
    {
        private string Username;
        private int Id;
        private bool LoggedIn;

        public UserInstance()
        {
            Username = "anonymous";
            Id = -1;
            LoggedIn = false;
        }

        public void Login(string username, int id)
        {
            if(LoggedIn) return; // Ici on pourrait modifier a verifier
            if (Username != null && Id != null && id > 0 && Username.Length > 0)
            {
                Username = username;
                Id = id;
                LoggedIn = true;
                NotifierAbonne();
            }
            else { throw new Exception("Login imposible id ou username pas bon"); } 
           
        }
        public bool IsLogging()
        {
            return LoggedIn;
        }
        public void Logout()
        {
            Id = -1;
            Username = "anonymous";
            LoggedIn = false;
            NotifierAbonne();
        }


    }
}
