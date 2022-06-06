using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe
{
    class Piece
    {
        public PieceType Type { get; }
        public Player Owner { get; }
        public Vec2 Location { get; }

        public Piece(PieceType type, Player owner, Vec2 location)
        {
            Type = type;
            Owner = owner;
            Location = location;
        }
    }
}
