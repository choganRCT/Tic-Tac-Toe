using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tic_Tac_Toe.TicTacToe.Input;
using Tic_Tac_Toe.TicTacToe.PlayerControllers;
using Tic_Tac_Toe.TicTacToe.Rendering;

namespace Tic_Tac_Toe.TicTacToe
{
    class Game
    {
        private readonly IInputManager inputManager;
        private readonly IRenderer renderer;

        public Game(IInputManager inputManager, IRenderer renderer)
        {
            this.inputManager = inputManager;
            this.renderer = renderer;
        }

        public void Play()
        {
            var boardSize = GetBoardSize();
            var board = new Board(boardSize);

            var playerOne = new Player("Player 1", "X", new HumanPlayerController(inputManager, renderer));
            var playerTwo = new Player("Player 2", "O", new AiPlayerController());

            var players = new List<Player>() { playerOne, playerTwo };
            int currentPlayerIndex = 0;

            Player winner = null;
            bool isDraw = false;

            while (winner == null && !isDraw)
            {
                renderer.RenderBoard(board);
                var currentPlayer = players[currentPlayerIndex];
                renderer.RenderText($"{currentPlayer.Name}'s turn");
                var nextMove = currentPlayer.GetMove(board);
                board.PlacePiece(nextMove.X, nextMove.Y, currentPlayer);
                renderer.RenderText($"{currentPlayer.Name} has placed a piece at ({nextMove.X}, {nextMove.Y})");
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
                renderer.RenderBoard(board);
                Console.WriteLine("Draw");
            }
            else
            {
                renderer.RenderBoard(board);
                Console.WriteLine($"{winner.Name} has won the game");
            }
        }

        private Player DetermineWinner(Board board)
        {
            var dimensions = board.GetDimensions();

            return dimensions
                .Where(dimension => dimension.Pieces
                    .All(piece => piece.Type != PieceType.Empty))
                .Where(dimension => dimension.Pieces
                    .GroupBy(piece => piece.Owner.Symbol).Count() == 1)
                .Select(dimension => dimension.Pieces.First().Owner)
                .FirstOrDefault();
        }

        private bool IsDraw(Board board)
        {
            var dimensions = board.GetDimensions();

            return dimensions
                .All(dimension => dimension.Pieces
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
    }
}
