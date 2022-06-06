using System;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe.TicTacToe.Rendering
{
    interface IRenderer
    {
        void RenderBoard(Board board);
        void RenderText(string text);
    }
}
