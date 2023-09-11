using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class Player
    {
        int record;
        public int Score { get; set; }
        public string Login { get; private set; }
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
        public string Password { get; set; }

        public Player()
        {
            Score = 0;
            Login = "anonim";
            Record = 0;
        }

        public Player(string login,string password)
        {
            Login = login;
            Password = password;
            Score = 0;
            Record = 0;
        }
    }
}
