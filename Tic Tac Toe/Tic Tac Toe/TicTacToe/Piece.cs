using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.TicTacToe
{
    class Piece
    {
        public PieceType Type { get; }
        public Player Owner { get; }

        public Piece(PieceType type, Player owner)
        {
            Type = type;
            Owner = owner;
        }
    }
}
