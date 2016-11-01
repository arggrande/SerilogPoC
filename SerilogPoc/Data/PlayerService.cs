using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using SerilogPoc.Models;


namespace SerilogPoc.Data
{
    public class PlayerService : IPlayerService
    {
        private List<Player> _defaultStore;

        public PlayerService()
        {
            _defaultStore = new List<Player>();
            LoadData();
        }
        public List<Player> GetPlayers()
        {
            return _defaultStore;
           
        }

        public Player GetPlayer(string alias)
        {
            return _defaultStore.FirstOrDefault(f => f.Alias == alias);
        }

        private void LoadData()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SerilogPoc.Data.players.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    _defaultStore = JsonConvert.DeserializeObject<List<Player>>(result);
                }
            }
        }
    }

    public interface IPlayerService
    {
        List<Player> GetPlayers();
        Player GetPlayer(string alias);
    }
}