using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebApp.LudoModels
{
    public class PutGame
    {
        public int diece { get; set; }
        public Piece piece;
        public Player player;
    }
}
