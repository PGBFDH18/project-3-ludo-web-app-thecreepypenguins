using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LudoWebApp.LudoModels
{
    public class PutGame
    {
        [Range(0, 6)]
        public int diece { get; set; }
        public Piece piece;
        public Player player;
    }
}
