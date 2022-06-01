using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            char player = 'X';
            char[,] board = new char[3, 3];
            int movesPlayed = 0;

            //The game plays until win, lose or draw
            while (true)
            {
                Console.WriteLine();
                Print(board);

                Console.WriteLine();
                Console.WriteLine("It is " + player + "'s turn.");

                Console.Write("Please enter row: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter column: ");
                int col = Convert.ToInt32(Console.ReadLine());

                while (row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine($"Coordinates {col},{row} are not on the board. Please enter new coordinates.");
                    Console.Write("Please enter row: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter column: ");
                    col = Convert.ToInt32(Console.ReadLine());
                }

                while (board[row, col] == 'X' || board[row, col] == 'O')
                {
                    Console.WriteLine("This space contains " + board[row, col] + ". Please select a new row.");
                    Console.Write("Please enter row: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter column: ");
                    col = Convert.ToInt32(Console.ReadLine());
                }

                board[row, col] = player;

                //Check for winner horizontal
                if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }
                if (player == board[1, 0] && player == board[1, 1] && player == board[1, 2])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }
                if (player == board[2, 0] && player == board[2, 1] && player == board[2, 2])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }

                //Check for winner vertical
                if (player == board[0, 0] && player == board[1, 0] && player == board[2, 0])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }
                if (player == board[0, 1] && player == board[1, 1] && player == board[2, 1])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }
                if (player == board[0, 2] && player == board[1, 2] && player == board[2, 2])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }

                //Check for winner Diagonal
                if (player == board[0, 0] && player == board[1, 1] && player == board[2, 2])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }
                if (player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
                {
                    Console.WriteLine(player + " has won!");
                    Print(board);
                    break;
                }

                movesPlayed = movesPlayed + 1;

                if (movesPlayed == 9)
                {
                    Console.WriteLine("Draw");
                    break;
                }

                player = ChangeTurn(player);
            }

            Console.ReadLine();
        }
        static char ChangeTurn(char currentPlayer)
        {
            if (currentPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }

        static void Print(char[,] board)
        {
            Console.WriteLine("  | 0 | 1 | 2 |");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " | ");

                for (int col = 0; col < 3; col++)
                {
                    char value = board[row, col];
                    if (value == '\0')
                    {
                        value = ' ';
                    }

                    Console.Write(value);
                    Console.Write(" | ");

                }
                Console.WriteLine();
            }
        }
    }
}
