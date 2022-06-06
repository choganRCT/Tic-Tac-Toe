using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe
{
    class Board
    {
        public int Size { get; }

        private readonly Piece[,] pieces;

        public Board(int size)
        {
            Size = size;
            pieces = new Piece[size, size];
            ClearBoard();
        }

        public Piece this[int x, int y]
        {
            get => pieces[x, y];
        }

        public void ClearBoard()
        {
            for (int y = 0; y < Size; y++)
            {
                for (int x = 0; x < Size; x++)
                {
                    pieces[x, y] = new Piece(PieceType.Empty, null, new Vec2(x, y));
                }
            }
        }

        public void PlacePiece(int x, int y, Player owner)
        {
            pieces[x, y] = new Piece(PieceType.Standard, owner, new Vec2(x, y));
        }

        public bool LocationIsOnBoard(Vec2 location)
        {
            return location.X >= 0 && location.X < Size && location.Y >= 0 && location.Y < Size;
        }

        public bool SpaceIsEmpty(Vec2 location)
        {
            return pieces[location.X, location.Y].Type == PieceType.Empty;
        }

        public IEnumerable<BoardDimension> GetDimensions()
        {
            var dimensions = new List<BoardDimension>();

            for (int y = 0; y < Size; y++)
            {
                var spaces = new List<Piece>();

                for (int x = 0; x < Size; x++)
                {
                    spaces.Add(pieces[x, y]);
                }

                dimensions.Add(new BoardDimension(BoardDimensionType.Horizontal, y, spaces));
            }

            for (int x = 0; x < Size; x++)
            {
                var spaces = new List<Piece>();

                for (int y = 0; y < Size; y++)
                {
                    spaces.Add(pieces[x, y]);
                }

                dimensions.Add(new BoardDimension(BoardDimensionType.Vertical, x, spaces));
            }

            {
                var spaces = new List<Piece>();

                for (int x = 0, y = 0; x < Size && y < Size; x++, y++)
                {
                    spaces.Add(pieces[x, y]);
                }

                dimensions.Add(new BoardDimension(BoardDimensionType.DiagonalDown, 0, spaces));
            }

            {
                var spaces = new List<Piece>();

                for (int x = Size - 1, y = 0; x >= 0 && y < Size; x--, y++)
                {
                    spaces.Add(pieces[x, y]);
                }

                dimensions.Add(new BoardDimension(BoardDimensionType.DiagonalUp, 0, spaces));
            }

            return dimensions;
        }
    }
}
