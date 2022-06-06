using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tic_Tac_Toe.TicTacToe.PlayerControllers;

namespace Tic_Tac_Toe.TicTacToe
{
    class Game
    {
        public void Play()
        {
            var boardSize = GetBoardSize();
            var board = new Board(boardSize);

            var playerOne = new Player("Player 1", "X", new ConsolePlayerController());
            var playerTwo = new Player("Player 2", "O", new ConsolePlayerController());

            var players = new List<Player>() { playerOne, playerTwo };
            int currentPlayerIndex = 0;

            Player winner = null;
            bool isDraw = false;

            while (winner == null && !isDraw)
            {
                PrintBoard(board);
                var currentPlayer = players[currentPlayerIndex];
                var nextMove = currentPlayer.GetMove(board);
                board.PlacePiece(nextMove.X, nextMove.Y, currentPlayer);
                winner = DetermineWinner(board);
                isDraw = IsDraw(board);

                currentPlayerIndex++;
                if (currentPlayerIndex >= players.Count)
                {
                    currentPlayerIndex = 0;
                }
            }

            if (isDraw)
            {
                PrintBoard(board);
                Console.WriteLine("Draw");
            }
            else
            {
                PrintBoard(board);
                Console.WriteLine($"{winner.Name} has won the game");
            }
        }

        private Player DetermineWinner(Board board)
        {
            var dimensions = board.GetDimensions();

            return dimensions
                .Where(spaces => spaces.All(piece => piece.Type != PieceType.Empty))
                .Where(spaces => spaces.GroupBy(piece => piece.Owner.Symbol).Count() == 1)
                .Select(spaces => spaces.First().Owner)
                .FirstOrDefault();
        }

        private bool IsDraw(Board board)
        {
            var dimensions = board.GetDimensions();

            return dimensions
                .All(spaces => spaces
                    .Where(piece => piece.Type != PieceType.Empty)
                    .GroupBy(piece => piece.Owner.Symbol)
                    .Count() > 1);
        }

        private int GetBoardSize()
        {
            int value;

            Console.Write($"Enter board size (must be at least 3): ");
            while (!int.TryParse(Console.ReadLine(), out value) || value < 3)
            {
                Console.WriteLine("Invalid value");
                Console.Write($"Enter board size (must be at least 3): ");
            }

            return value;
        }

        private void PrintBoard(Board board)
        {
            Console.WriteLine();

            Console.WriteLine("  | " + string.Join(" | ", Enumerable.Range(0, board.Size)) + " |");

            for (int y = 0; y < board.Size; y++)
            {
                Console.Write(y + " | ");

                for (int x = 0; x < board.Size; x++)
                {
                    Console.Write(board[x, y].Type == PieceType.Empty ? " " : board[x, y].Owner.Symbol);
                    Console.Write(" | ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
