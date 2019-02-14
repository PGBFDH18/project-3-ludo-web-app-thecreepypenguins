using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LudoWebApp.LudoModels
{
    public class Player
    {
        [Range(1, 4)]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        [Range(1, 4)]
        public string PlayerColor { get; set; }
        public List<Piece> Pieces { get; set; }
        public int Offset { get; set; }
    }
}
