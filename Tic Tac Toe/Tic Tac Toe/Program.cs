﻿using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        // (2), (3)
        static readonly string[] space = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        static void Main()
        {
            string player = "X";
            // (1)
            int winner;
            int turnCount = 0;
            bool legalMove = true;
            bool gamePlay = true;
            //bool correctNumber = false;

            //The game plays until win, lose or draw.
            while (gamePlay == true)
            {
                while (legalMove == true)
                {
                    string choiceText;
                    bool validInput = false;

                    while (!validInput)
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Board();
                            Console.WriteLine($"\nIt is player {player}'s turn.");
                            Console.Write("Pick a number from the board to place your mark: ");
                            choiceText = Console.ReadLine();

                            bool isParsable = Int32.TryParse(choiceText, out int choice);
                            if (isParsable)
                            {
                                if (choice <= 0 || choice > 9)
                                {
                                    validInput = true;
                                }
                                else
                                {
                                    validInput = false;

                                    // (3)
                                    if (space[choice - 1] == "X" || space[choice - 1] == "O")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n{choice} is already taken.");
                                        Console.ResetColor();
                                        Console.Write("Press enter to continue.");
                                        Console.ReadLine();
                                        legalMove = true;
                                    }
                                    else
                                    {
                                        // (3)
                                        space[choice - 1] = player;

                                        legalMove = true;
                                        turnCount++;
                                        winner = CheckWin();

                                        if (winner == 1)
                                        {
                                            gamePlay = false;
                                            Console.Clear();
                                            Console.WriteLine($"\nCongratulations!! {player} has Won!!!\n");
                                            Board();
                                            Console.Write("\n Press Enter to start a new game.");
                                            Console.ReadLine();
                                            turnCount = 0;

                                            // (3)
                                            //reset board
                                            for (int i = 0; i < 9; i++)
                                            {
                                                space[i] = (i + 1).ToString();
                                            }

                                        }
                                        else
                                        {
                                            gamePlay = true;
                                        }
                                        player = ChangeTurn(player);

                                        if (turnCount == 9)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\nThe game ended in a draw.\n");
                                            Console.ResetColor();
                                            Board();
                                            Console.WriteLine("\n Press Enter to start a new game.");
                                            Console.ReadLine();
                                            turnCount = 0;

                                            // (3)
                                            //reset board
                                            for (int i = 0; i < 9; i++)
                                            {
                                                space[i] = (i + 1).ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            validInput = true;
                        }
                    }
                }
            }
        } // (4)

        static int CheckWin()
        {
            // (3)
            //Check 3 horizontal rows, 3 vertical rows, 2 diagonals
            if (space[0] == space[1] && space[1] == space[2])
            {
                return 1;
            }
            else if (space[3] == space[4] && space[4] == space[5])
            {
                return 1;
            }
            else if (space[6] == space[7] && space[7] == space[8])
            {
                return 1;
            }
            else if (space[0] == space[3] && space[3] == space[6])
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
            else if (space[0] == space[4] && space[4] == space[8])
            {
                return 1;
            }
            else if (space[2] == space[4] && space[4] == space[6])
            {
                return 1;
            }
            else
            {
                return 0;
            }
        } // (4)

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
        } // (4)

        static void Board()
        {
            // (5)
            Console.WriteLine($"\t {space[0]} | {space[1]} | {space[2]}");
            Console.WriteLine("\t-----------");
            Console.WriteLine($"\t {space[3]} | {space[4]} | {space[5]}");
            Console.WriteLine("\t-----------");
            Console.WriteLine($"\t {space[6]} | {space[7]} | {space[8]}");
        }
    }
}
