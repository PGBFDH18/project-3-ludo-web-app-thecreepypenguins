using LudoWebApp.LudoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LudoWebApp.Models
{
    public class LudoViewModel
    {
        public Game CurrentGame { get; set; }
        [Range (1,6)]
        public int Dice { get; set; }
        public List<Game> AllGames { get; set; }

        [Range(1, 4)]
        public int ColorPlayer1 { get; set; }
        [Range(1, 4)]
        public int ColorPlayer2 { get; set; }
        [Range(1, 4)]
        public int ColorPlayer3 { get; set; }
        [Range(1, 4)]
        public int ColorPlayer4 { get; set; }

        public Piece pices { get; set; }

    }
}
