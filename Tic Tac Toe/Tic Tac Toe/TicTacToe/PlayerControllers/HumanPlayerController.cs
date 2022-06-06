using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;
using Tic_Tac_Toe.TicTacToe.Input;
using Tic_Tac_Toe.TicTacToe.Rendering;

namespace Tic_Tac_Toe.TicTacToe.PlayerControllers
{
    class HumanPlayerController : IPlayerController
    {
        private readonly IInputManager inputManager;
        private readonly IRenderer renderer;

        public HumanPlayerController(IInputManager inputManager, IRenderer renderer)
        {
            this.inputManager = inputManager;
            this.renderer = renderer;
        }

        public Vec2 GetMove(Player player, Board board)
        {
            renderer.RenderText($"Enter move for {player.Name}");

            var location = inputManager.GetCoords();

            while (!board.LocationIsOnBoard(location))
            {
                renderer.RenderText($"({location.X}, {location.Y}) is not on the board");
                location = inputManager.GetCoords();
            }

            while (!board.SpaceIsEmpty(location))
            {
                renderer.RenderText($"A move has already been made to ({location.X}, {location.Y})");
                location = inputManager.GetCoords();
            }

            return location;
        }
    }
}
