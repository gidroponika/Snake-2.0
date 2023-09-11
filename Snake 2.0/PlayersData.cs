using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2._0
{
    internal class PlayersData
    {
        List<Player>players = new List<Player>();

        public PlayersData()
        {
            players.Add(new Player());
            players.Add(new Player("max","123456"));
            players.Add(new Player("QQQQ", "qwerty"));
            players.Add(new Player("AAAAA", "987654"));
        }

        public Player GetPlayer(string login,string password)
        {
            foreach(Player player in players)
            {
                if(player.Login.CompareTo(login)==0 &&
                    player.Password.CompareTo(password) == 0)
                {
                    return player;
                }
            }
            return new Player();
        }

        public void AddPlayer(string login,string password)
        {
            foreach (Player player in players)
            {
                if (player.Login.CompareTo(login) == 0 &&
                    player.Password.CompareTo(password) == 0)
                {
                    return;
                }
            }
            players.Add(new Player(login,password));
        }
    }
}
