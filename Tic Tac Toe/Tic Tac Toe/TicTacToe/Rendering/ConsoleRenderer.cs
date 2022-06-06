using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tic_Tac_Toe.TicTacToe.Rendering
{
    class ConsoleRenderer : IRenderer
    {
        public void RenderBoard(Board board)
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

        public void RenderText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
