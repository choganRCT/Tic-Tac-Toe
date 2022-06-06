using System;
using System.Collections.Generic;
using System.Text;
using Tic_Tac_Toe.Math;

namespace Tic_Tac_Toe.TicTacToe.PlayerControllers
{
    class ConsolePlayerController : IPlayerController
    {
        public Vec2 GetMove(Player player, Board board)
        {
            Console.WriteLine($"Enter move for {player.Name}");

            var location = GetLocation(); 

            while (!board.LocationIsOnBoard(location))
            {
                Console.WriteLine($"({location.X}, {location.Y}) is not on the board");
                location = GetLocation();
            }

            while (!board.SpaceIsEmpty(location))
            {
                Console.WriteLine($"A move has already been made to ({location.X}, {location.Y})");
                location = GetLocation();
            }

            return location;
        }

        private Vec2 GetLocation()
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
