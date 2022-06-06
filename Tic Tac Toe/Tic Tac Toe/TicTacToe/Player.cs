using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe
{
    class Player
    {
        public string Name { get; }
        public string Symbol { get; }

        private readonly IPlayerController controller;

        public Player(string name, string symbol, IPlayerController controller)
        {
            Name = name;
            Symbol = symbol;
            this.controller = controller;
        }

        public Vec2 GetMove(Board board)
        {
            return controller.GetMove(this, board);
        }
    }
}
