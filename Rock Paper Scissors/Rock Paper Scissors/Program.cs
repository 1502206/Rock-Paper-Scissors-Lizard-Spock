using System;
using System.Diagnostics;

namespace Rock_Paper_Scissors
{
    public enum Item
    {
        Invalid, Rock, Paper, Scissors, Lizard, Spock, New
    }

    public class Rock_Paper_Scissors
    {

        private static ConsoleColor DefaultColor { get; set; } = ConsoleColor.Blue;
        public static ProcessStartInfo ExecutablePath { get; private set; }

        private static int playerScore = 0;
        private static Item playerItem = Item.Invalid;

        private static int computerScore = 0;
        private static Item computerItem = Item.Invalid;

        private static Random random = new Random();
        private static bool playerWon = false;

        public static void Main()
        {

            int countRock = 0;
            int countPaper = 0;
            int countScissors = 0;
            int countLizard = 0;
            int countSpock = 0;
            Console.WriteLine();

            while (true)
            {

                computerItem = (Item)random.Next(1, 6);

                Console.WriteLine($"Your Score: {playerScore} Computer score: {computerScore}");
                Console.WriteLine("(R)ock, (P)aper, (S)cissors, (L)izard, Sp(o)ck (N)ew Game");


                bool validChoice = false;
                while (!validChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Make your choice: ");
                    char playerItemInput = Console.ReadLine().ToLower()[0];

                    switch (playerItemInput)
                    {
                        case 'r':
                            {
                                playerItem = Item.Rock;
                                countRock += 1;
                                validChoice = true;
                                if (computerItem == Item.Scissors || computerItem == Item.Lizard)
                                {
                                    playerWon = true;
                                }
                                break;
                            }

                        case 'p':
                            {
                                playerItem = Item.Paper;
                                countPaper += 1;
                                validChoice = true;
                                if (computerItem == Item.Rock || computerItem == Item.Spock)
                                {
                                    playerWon = true;
                                }
                                break;
                            }

                        case 's':
                            {
                                playerItem = Item.Scissors;
                                countScissors += 1;
                                validChoice = true;
                                if (computerItem == Item.Paper || computerItem == Item.Lizard)
                                {
                                    playerWon = true;
                                }

                                break;
                            }

                        case 'l':
                            {
                                playerItem = Item.Lizard;
                                countLizard += 1;
                                validChoice = true;
                                if (computerItem == Item.Spock || computerItem == Item.Paper)
                                {
                                    playerWon = true;
                                }

                                break;
                            }

                        case 'o':
                            {
                                playerItem = Item.Spock;
                                countSpock += 1;
                                validChoice = true;
                                if (computerItem == Item.Scissors || computerItem == Item.Rock)
                                {
                                    playerWon = true;
                                }
                               
                                break;
                            }
                      
                        case 'n':
                            {
                                
                                Console.WriteLine($"\nFinal Score: Player: {playerScore} Computer {computerScore}");
                                
                                if (playerScore > computerScore)
                                {
                                    Console.WriteLine("Player Won");
                                }
                                if (playerScore < computerScore)
                                {
                                    Console.WriteLine("Computer Won");
                                }
                                if (playerScore == computerScore)
                                {
                                    Console.WriteLine("TIE");
                                }

                                int sum = countRock + countPaper + countScissors + countLizard + countSpock;
                                Console.WriteLine("Number of turns taken " + sum);

                                if (countRock > countPaper && countRock > countScissors && countRock > countLizard && countRock > countSpock)
                                {
                                    Console.WriteLine("Rock was the most used move ");
                                }
                                if (countPaper > countRock && countPaper > countScissors && countPaper > countLizard && countPaper > countSpock)
                                {
                                    Console.WriteLine("Paper was the most used move ");
                                }
                                if (countScissors > countPaper && countScissors > countRock && countScissors > countLizard && countScissors > countSpock)
                                {
                                    Console.WriteLine("Scissors was the most used move ");
                                }
                                if (countLizard > countPaper && countLizard > countRock && countLizard > countScissors && countLizard > countSpock)
                                {
                                    Console.WriteLine("Lizard was the most used move ");
                                }
                                if (countSpock > countPaper && countSpock > countRock && countSpock > countScissors && countSpock > countLizard)
                                {
                                    Console.WriteLine("Spock was the most used move ");
                                }
                                
                                countRock = 0;
                                countPaper = 0;
                                countScissors = 0;
                                countLizard = 0;
                                countSpock = 0;
                                computerScore = 0;
                                playerScore = 0;
                                
                                break;
                                
                            }
                    }
                }

                Console.WriteLine();
                Console.Write("You picked: ");
                ColorWriteLine($"{Enum.GetName(typeof(Item), playerItem)}");
                Console.Write($"Computer picked: ");
                ColorWriteLine($"{Enum.GetName(typeof(Item), computerItem)}");
                if (playerWon)
                {
                    ColorWriteLine(ConsoleColor.Green, "You won!");
                    playerScore++;
                }
                else if (playerItem != computerItem)
                {
                    ColorWriteLine(ConsoleColor.Red, "You lost!");
                    computerScore++;
                }
                else
                {
                    ColorWriteLine(ConsoleColor.Yellow, "Tie!");
                }

                playerWon = false;
                Console.WriteLine();
            }

        }

        private static void ColorWrite(ConsoleColor color, string message)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = old;
        }
        private static void ColorWrite(string message)
        {
            ColorWrite(DefaultColor, message);
        }

        private static void ColorWriteLine(ConsoleColor color, string message)
        {
            ColorWrite(color, message + '\n');
        }

        private static void ColorWriteLine(string message)
        {
            ColorWriteLine(DefaultColor, message);
        }
    }
}