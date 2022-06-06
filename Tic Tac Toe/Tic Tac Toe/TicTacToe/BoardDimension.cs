using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.TicTacToe
{
    class BoardDimension
    {
        public BoardDimensionType Type { get; }
        public int Index { get; }
        public IEnumerable<Piece> Pieces { get; }

        public BoardDimension(BoardDimensionType type, int index, IEnumerable<Piece> pieces)
        {
            Type = type;
            Index = index;
            Pieces = pieces;
        }
    }
}
