using System;
using Tic_Tac_Toe.TicTacToe;
using Tic_Tac_Toe.TicTacToe.Input;
using Tic_Tac_Toe.TicTacToe.Rendering;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new ConsoleInputManager(), new ConsoleRenderer());
            game.Play();
        }
    }
}
