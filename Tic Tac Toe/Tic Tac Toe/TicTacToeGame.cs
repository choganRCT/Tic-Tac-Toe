using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe
{
    class TicTacToeGame
    {
        private static readonly int BoardSize = 3;
        private static readonly char PlayerX = 'X';
        private static readonly char PlayerO = 'O';
        private static readonly char EmptySpace = '\0';

        public void Play()
        {
            var board = new char[BoardSize, BoardSize];
            var player = PlayerX;

            char winner = EmptySpace;
            bool isDraw = false;

            while (winner == EmptySpace && !isDraw)
            {
                PrintBoard(board);
                PlayNextMove(board, player);
                winner = DetermineWinner(board);
                isDraw = IsDraw(board);
                player = player == PlayerX ? PlayerO : PlayerX;
            }

            if (isDraw)
            {
                Console.Write("Draw");
            }
            else
            {
                Console.WriteLine($"{winner} has won the game");
            }
        }

        private void PlayNextMove(char[,] board, char player)
        {
            Console.WriteLine("It is " + player + "'s turn.");

            int x = GetCoordinate("x coordinate");
            int y = GetCoordinate("y coordinate");

            while (!LocationIsOnBoard(x, y, board))
            {
                Console.WriteLine($"({x}, {y}) is not on the board");
                x = GetCoordinate("x coordinate");
                y = GetCoordinate("y coordinate");
            }

            while (!SpaceIsEmpty(x, y, board))
            {
                Console.WriteLine($"A move has already been made to ({x}, {y})");
                x = GetCoordinate("x coordinate");
                y = GetCoordinate("y coordinate");
            }

            board[x, y] = player;
        }

        private bool LocationIsOnBoard(int x, int y, char[,] board)
        {
            return x >= 0 && x < BoardSize && y >= 0 && y < BoardSize;
        }

        private bool SpaceIsEmpty(int x, int y, char[,] board)
        {
            return board[x, y] == EmptySpace;
        }

        private int GetCoordinate(string description)
        {
            int value;

            Console.Write($"{description}: ");
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid value");
                Console.Write($"{description}: ");
            }

            return value;
        }

        private void PrintBoard(char[,] board)
        {
            Console.WriteLine();

            Console.WriteLine("  | 0 | 1 | 2 |");
            for (int y = 0; y < 3; y++)
            {
                Console.Write(y + " | ");

                for (int x = 0; x < 3; x++)
                {
                    Console.Write(board[x, y] == EmptySpace ? ' ' : board[x, y]);
                    Console.Write(" | ");

                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private char DetermineWinner(char[,] board)
        {
            var dimensions = GetBoardDimensions(board);

            return dimensions
                .Where(spaces => spaces.Distinct().Count() == 1)
                .Select(spaces => spaces[0])
                .FirstOrDefault();
        }

        private bool IsDraw(char[,] board)
        {
            var dimensions = GetBoardDimensions(board);

            return dimensions
                .All(spaces => spaces.Contains(PlayerX) && spaces.Contains(PlayerO));
        }

        private List<List<char>> GetBoardDimensions(char[,] board)
        {
            var dimensions = new List<List<char>>();

            for (int y = 0; y < BoardSize; y++)
            {
                var spaces = new List<char>();

                for (int x = 0; x < BoardSize; x++)
                {
                    spaces.Add(board[x, y]);
                }

                dimensions.Add(spaces);
            }

            for (int x = 0; x < BoardSize; x++)
            {
                var spaces = new List<char>();

                for (int y = 0; y < BoardSize; y++)
                {
                    spaces.Add(board[x, y]);
                }

                dimensions.Add(spaces);
            }

            {
                var spaces = new List<char>();

                for (int x = 0, y = 0; x < BoardSize && y < BoardSize; x++, y++)
                {
                    spaces.Add(board[x, y]);
                }

                dimensions.Add(spaces);
            }

            {
                var spaces = new List<char>();

                for (int x = BoardSize - 1, y = 0; x >= 0 && y < BoardSize; x--, y++)
                {
                    spaces.Add(board[x, y]);
                }

                dimensions.Add(spaces);
            }

            return dimensions;
        }
    }
}
