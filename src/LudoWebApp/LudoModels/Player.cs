using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebApp.LudoModels
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string PlayerColor { get; set; }
        public Piece[] Pieces { get; set; }
        public int Offset { get; set; }
    }
}
