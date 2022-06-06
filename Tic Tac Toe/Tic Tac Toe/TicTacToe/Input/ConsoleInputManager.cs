using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe.Input
{
    class ConsoleInputManager : IInputManager
    {
        public Vec2 GetCoords()
        {
            return new Vec2(GetCoordinate("x coordinate"), GetCoordinate("y coordinate"));
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
    }
}
