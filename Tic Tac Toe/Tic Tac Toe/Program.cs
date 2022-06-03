using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = "X";
            int choice = 0, winner = 0, turnCount = 0;
            bool correctInput = false, legalMove = true, gamePlay = true;


            //The game plays until win, lose or draw.
            while (gamePlay == true)
            {
                while (legalMove == true)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Board();

                    try
                    {
                        Console.WriteLine($"\nIt is player {player}'s turn.");
                        Console.Write("Pick a number from the board to place your mark: ");
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nYou did not pick a number on the board. Please pick again: ");
                        Console.ResetColor();
                        choice = Convert.ToInt32(Console.ReadLine());
                    }

                    while (correctInput == false)
                    {
                        if (choice > 0 && choice < 10)
                        {
                            correctInput = true;
                        }
                        else
                        {
                            correctInput = false;
                        }
                    }

                    if (space[choice] == "X" || space[choice] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{choice} is already taken.");
                        Console.ResetColor();
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        legalMove = false;
                    }
                    else
                    {
                        space[choice] = player;
                        legalMove = true;
                        turnCount++;
                        winner = CheckWin();
                        if (winner == 1)
                        {
                            gamePlay = false;
                            Console.Clear();
                            Console.WriteLine($"\nCongratulations!! {player} has Won!!!\n");
                            Board();
                            Console.WriteLine("\n Press Enter to start a new game.");
                            Console.ReadLine();

                            //reset board
                            for (int i = 0; i < 10; i++)
                            {
                                space[i] = i.ToString();
                            }

                        }
                        else
                        {
                            gamePlay = true;
                        }
                        player = ChangeTurn(player);
                    }

                    if (turnCount == 9)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nThe game ended in a draw.\n");
                        Console.ResetColor();
                        Board();
                        Console.WriteLine("\n Press Enter to start a new game.");
                        Console.ReadLine();

                        //reset board
                        for (int i = 0; i < 10; i++)
                        {
                            space[i] = i.ToString();
                        }
                    }
                }
            }
        }
        static int CheckWin()
        {
            //Check 3 horizontal rows, 3 vertical rows, 2 diagonals
            if (space[1] == space[2] && space[2] == space[3])
            {
                return 1;
            }
            else if (space[4] == space[5] && space[5] == space[6])
            {
                return 1;
            }
            else if (space[7] == space[8] && space[8] == space[9])
            {
                return 1;
            }
            else if (space[1] == space[4] && space[4] == space[7])
            {
                return 1;
            }
            else if (space[2] == space[5] && space[5] == space[8])
            {
                return 1;
            }
            else if (space[3] == space[6] && space[6] == space[9])
            {
                return 1;
            }
            else if (space[1] == space[5] && space[5] == space[9])
            {
                return 1;
            }
            else if (space[3] == space[5] && space[5] == space[7])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static string ChangeTurn(string Player)
        {
            if (Player == "X")
            {
                return "O";
            }
            else
            {
                return "X";
            }
        }
        static string[] space = new string[10] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        //space 0 isn't used
        static void Board()
        {
            Console.WriteLine("\t {0} | {1} | {2}", space[1], space[2], space[3]);
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t {0} | {1} | {2}", space[4], space[5], space[6]);
            Console.WriteLine("\t-----------");
            Console.WriteLine("\t {0} | {1} | {2}", space[7], space[8], space[9]);
        }
    }
}
