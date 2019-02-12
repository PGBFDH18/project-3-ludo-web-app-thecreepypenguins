using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LudoWebApp.LudoModels
{
    public class Piece
    {
        public int PieceId { get; set; }
        public PieceGameStates State { get; set; }
        public int Position { get; set; }


    }
}
