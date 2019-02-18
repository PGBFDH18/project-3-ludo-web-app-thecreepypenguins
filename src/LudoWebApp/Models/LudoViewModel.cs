using LudoWebApp.LudoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebApp.Models
{
    public class LudoViewModel
    {
        public Game CurrentGame { get; set; }
        public int Dice { get; set; }
        public List<Game> AllGames { get; set; }


        public int ColorPlayer1 { get; set; }
        public int ColorPlayer2 { get; set; }
        public int ColorPlayer3 { get; set; }
        public int ColorPlayer4 { get; set; }

        public Piece pices { get; set; }

    }
}
