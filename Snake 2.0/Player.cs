using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Player
    {
        public int Score { get; set; }

        public string Login
        {
            get
            {
                return login;
            }

            private set
            {
                string log = value.Trim();
                if (log.Length >= 3)
                {
                    login = log;
                }
                else
                {
                    login = string.Empty;
                }
            }
        }

        public string Password 
        {
            get 
            { 
                return password;
            }

            set 
            { 
                string pas=value.Trim();
                if (pas.Length >= 5)
                {
                    password = pas;
                }
                else
                {
                    password = string.Empty;
                }
            } 
        }

        public int Record
        {
            get { return record; }
            set
            {
                if (Score > record)
                {
                    record = value;
                }
            }
        }

        private int record;
        private string password;
        private string login;

        public Player()
        {
            Score = 0;
            Login = "anonim";
            Record = 0;
            password = string.Empty;
        }

        public Player(string login,string password)
        {
            Login = login;
            Password = password;
            Score = 0;
            Record = 0;
        }


        ///?
        /*public bool IsValid()
        {
            if((Login != "anonim" && string.IsNullOrEmpty(Password)) ||
                string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(Login))
            {
                return false;
            }
            return true;
        }*/
    }
}
