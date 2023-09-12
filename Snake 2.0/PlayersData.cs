using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Snake_2._0
{
    internal class PlayersData
    {
        const string PATH = "C:\\SaveSnake\\";
        const string SAVE = "save.json";
        List<Player>players = new List<Player>();

        public PlayersData()
        {
            players.Add(new Player());
            players.Add(new Player("max","123456"));
            players.Add(new Player("QQQQ", "qwerty"));
            players.Add(new Player("AAAAA", "987654"));
            InitializeData();

        }

        public Player GetPlayer(string login,string password)
        {
            foreach (Player player in players)
            {
                if (string.Compare(player.Login,login,false) == 0 &&
                    string.Compare(player.Password,password,false) == 0)
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

        void InitializeData()
        {
            if (File.Exists(PATH))
            {
                Stream stream = File.OpenRead(PATH);
                string data=File.ReadAllText(PATH+ SAVE);
                PlayersData pData = JsonConvert.DeserializeObject<PlayersData>(data);
                players = pData.players;
                stream.Close();
            }
            else
            {
                Directory.CreateDirectory(PATH);
                var file=File.Create(PATH+SAVE);
                players.Add(new Player());
                file.Close();
            }
        }

        public void SavePlayers()
        {
            //Stream file=File.OpenWrite(path+save);
            string saveString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(PATH + SAVE, saveString);
            //file.Close();
        }
    }
}
