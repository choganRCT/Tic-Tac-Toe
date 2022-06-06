using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe
{
    interface IPlayerController
    {
        Vec2 GetMove(Player player, Board board);
    }
}
