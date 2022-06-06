using System.Linq;
using System.Threading;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe.PlayerControllers
{
    class AiPlayerController : IPlayerController
    {
        public Vec2 GetMove(Player player, Board board)
        {
            Thread.Sleep(500);

            Vec2 move;

            if (CanWin(player, board, out move))
            {
                return move;
            }

            if (OpponentCanWin(player, board, out move))
            {
                return move;
            }

            if (GetOffensiveMove(player, board, out move))
            {
                return move;
            }

            return RandomMove(board);
        }

        private bool CanWin(Player player, Board board, out Vec2 move)
        {
            move = null;

            var dimension = board
                .GetDimensions()
                .Where(dimension => dimension
                    .Pieces.Count(piece => piece.Type != PieceType.Empty && piece.Owner.Symbol == player.Symbol) == board.Size - 1)
                .FirstOrDefault();

            if (dimension != null)
            {
                var missingPiece = dimension
                    .Pieces
                    .Where(x => x.Type == PieceType.Empty)
                    .First();

                move = missingPiece.Location;
            }

            return dimension != null;
        }

        private bool OpponentCanWin(Player player, Board board, out Vec2 move)
        {
            move = null;

            var dimension = board
                .GetDimensions()
                .Where(dimension => dimension.Pieces
                    .Count(piece => piece.Type != PieceType.Empty) == board.Size - 1)
                .Where(dimension => dimension.Pieces
                    .Count(piece => piece.Type != PieceType.Empty && piece.Owner.Symbol == player.Symbol) == 0)
                .Where(dimension => dimension.Pieces
                    .Where(piece => piece.Type != PieceType.Empty)
                    .GroupBy(piece => piece.Owner.Symbol)
                    .Count() == 1)
                .FirstOrDefault();

            if (dimension != null)
            {
                var missingPiece = dimension
                    .Pieces
                    .Where(x => x.Type == PieceType.Empty)
                    .First();

                move = missingPiece.Location;
            }

            return dimension != null;
        }

        private bool GetOffensiveMove(Player player, Board board, out Vec2 move)
        {
            move = null;

            var dimension = board
                .GetDimensions()
                .Where(dimension => dimension.Pieces
                    .Any(piece => piece.Type == PieceType.Empty))
                .Where(dimension => dimension.Pieces
                    .Where(piece => piece.Type != PieceType.Empty)
                    .All(piece => piece.Owner.Symbol == player.Symbol))
                .OrderByDescending(dimension => dimension.Pieces
                    .Count(piece => piece.Type != PieceType.Empty))
                .FirstOrDefault();

            if (dimension != null)
            {
                var missingPiece = dimension
                    .Pieces
                    .Where(x => x.Type == PieceType.Empty)
                    .First();

                move = missingPiece.Location;
            }

            return dimension != null;
        }

        private Vec2 RandomMove(Board board)
        {
            var dimension = board
                .GetDimensions()
                .Where(dimension => dimension.Pieces
                    .Any(piece => piece.Type == PieceType.Empty))
                .FirstOrDefault();

            return dimension
                .Pieces
                .Where(x => x.Type == PieceType.Empty)
                .First()
                .Location;
        }
    }
}
