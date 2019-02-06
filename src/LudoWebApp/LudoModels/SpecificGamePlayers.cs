using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebApp.LudoModels
{
    public class SpecificGamePlayers
    {
        public int gameId { get; set; }
        public int dice { get; set; }
        public Player currentPlayer { get; set; }
    }

}
