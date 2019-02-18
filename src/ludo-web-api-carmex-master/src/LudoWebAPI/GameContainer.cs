using LudoGameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebAPI
{
    public class GamesContainer : IGamesContainer
    {
        private Dictionary<int, LudoGame> ludoGames;

        public GamesContainer()
        {
            ludoGames = new Dictionary<int, LudoGame>();
        }

        public LudoGame GetOrCreateGame(int id)
        {
            if (!ludoGames.ContainsKey(id))
            {
                ludoGames.Add(id, new LudoGame(new Diece()));
            }

            return ludoGames[id];
        }

        public List<int> GetAllGames()
        {
            return ludoGames.Select(d => d.Key).ToList();
        }

        public void DeleteGame(int id)
        {
            ludoGames.Remove(id);
        }
    }
}
