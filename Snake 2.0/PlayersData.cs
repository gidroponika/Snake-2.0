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
        public List<Player> Players { get; private set; }
        private const string path = "C:\\SnakeSave\\";
        private const string file = "save.json";

        public PlayersData()
        {
            Initialize();
        }

        public Player GetDefaultPlayer()
        {
            /**foreach (var player in Players)
            {
                if(string.Compare(player.Login,"anonim",false) == 0)
                {
                    return player;
                }
            }
            Player p = new Player();
            Players.Add(p);

            return p;*/
            return new Player();
        }

        public void CreateNewPlayer(string login,string password)
        {
            var player = new Player(login,password);
            Players.Add(player);
        }

        public void SaveData()
        {
            //DeleteInvalidPlayer();

            string save = JsonConvert.SerializeObject(Players, Formatting.Indented);
            File.WriteAllText(path + file, save);
        }

        private void Initialize()
        {
            if (!File.Exists(path + file))
            {
                Directory.CreateDirectory(path);
                FileStream st=File.Create(path + file);
                st.Close();
                Players = new List<Player>(); 
                /*{
                    new Player()
                };*/
            }
            else
            {
                string save=File.ReadAllText(path + file);
                List<Player> pd = JsonConvert.DeserializeObject<List<Player>>(save);
                Players= pd;
            }
        }

        public Player GetPlayer(string login, string password)
        {
            foreach(Player player in Players)
            {
                if(player.Login == login && player.Password == password)
                {
                    return player;
                }
            }
            Console.WriteLine("Користувача не знайдено");
            return null;
        }

        private void DeleteInvalidPlayer()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i].IsValid())
                {
                    Players.RemoveAt(i);
                }
            }
        }
    }
}
