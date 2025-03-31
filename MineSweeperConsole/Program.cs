using MineSweeperClasses;
using System;
using MineSweeperClasses;

namespace MineSweeperConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");

            Console.Write("Enter the board size (e.g., 10 for a 10x10 board): ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Enter the difficulty (0.1 for Easy, 0.15 for Medium, 0.2 for Hard): ");
            float difficulty = float.Parse(Console.ReadLine());

            // Prompt for background color selection
            Console.WriteLine("Choose your preferred console background color (e.g., Black, White, Cyan, Magenta, Yellow): ");
            string colorChoice = Console.ReadLine();

            if (Enum.TryParse(colorChoice, true, out ConsoleColor selectedColor))
            {
                Console.BackgroundColor = selectedColor;
                Console.Clear();
                Console.WriteLine($"Background color set to {selectedColor}.");
            }
            else
            {
                Console.WriteLine("Invalid color. Using default background color.");
            }

            // Adjust text color to ensure contrast with background
            Console.ForegroundColor = selectedColor == ConsoleColor.Black ? ConsoleColor.White : ConsoleColor.Black;

            // Create the game board
            Board board = new Board(size, difficulty);

            Console.WriteLine("\\nThe bombs and numbers are ready. You can secretly view answers by typing 'qq' during the game.");

            // Start the game loop
            PlayGame(board);
        }

        static void PrintAnswers(Board board)
        {
            Console.Write("    ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write($" {i,-2} "); // Align headers properly
            }
            Console.WriteLine();

            Console.WriteLine("   +" + new string('-', board.Size * 4) + "+");

            for (int x = 0; x < board.Size; x++)
            {
                Console.Write($" {x,-2}|");
                for (int y = 0; y < board.Size; y++)
                {
                    var cell = board.Cells[x, y];
                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B |");
                    }
                    else if (cell.HasSpecialReward)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" R |");
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {cell.NumberOfBombNeighbors} |");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" . |");
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("   +" + new string('-', board.Size * 4) + "+");
            }
        }

        static void PrintBoard(Board board)
        {
            Console.Write("    ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write($" {i,-2} ");
            }
            Console.WriteLine();

            Console.WriteLine("   +" + new string('-', board.Size * 4) + "+");

            for (int x = 0; x < board.Size; x++)
            {
                Console.Write($" {x,-2}|");
                for (int y = 0; y < board.Size; y++)
                {
                    var cell = board.Cells[x, y];

                    if (cell.IsFlagged)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" F |");
                    }
                    else if (!cell.IsVisited)
                    {
                        Console.Write(" ? |");
                    }
                    else if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B |");
                    }
                    else if (cell.HasSpecialReward && !cell.IsVisited)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" R |");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {cell.NumberOfBombNeighbors} |");
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("   +" + new string('-', board.Size * 4) + "+");
            }
        }

        static void PlayGame(Board board)
        {
            bool victory = false;
            bool death = false;

            while (!victory && !death)
            {
                PrintBoard(board);
                Console.Write("Enter row (or type 'qq' to reveal answers secretly): ");
                string rowInput = Console.ReadLine();

                // Secret answer reveal using 'qq'
                if (rowInput == "qq")
                {
                    Console.WriteLine("Revealing answers...");
                    PrintAnswers(board);
                    continue;
                }

                int row = int.Parse(rowInput);

                Console.Write("Enter column: ");
                int col = int.Parse(Console.ReadLine());

                Console.Write("Choose action (Flag, Visit, Use Reward, Peek): ");
                string action = Console.ReadLine().ToLower();

                var cell = board.Cells[row, col];

                if (action == "flag")
                {
                    cell.IsFlagged = !cell.IsFlagged;
                }
                else if (action == "visit")
                {
                    if (cell.IsBomb)
                    {
                        cell.IsVisited = true;
                        Console.WriteLine("You hit a bomb! Game Over.");
                        death = true;
                    }
                    else
                    {
                        cell.IsVisited = true;
                        if (cell.HasSpecialReward)
                        {
                            Console.WriteLine("You found a special reward! You can use it on your next move.");
                        }
                    }
                }
                else if (action == "use reward")
                {
                    if (cell.HasSpecialReward)
                    {
                        cell.UseReward();
                    }
                    else
                    {
                        Console.WriteLine("There is no reward at this location.");
                    }
                }
                else if (action == "peek")
                {
                    if (cell.IsBomb)
                    {
                        Console.WriteLine("Peek result: This cell contains a bomb. Be cautious!");
                    }
                    else
                    {
                        Console.WriteLine($"Peek result: This cell is safe with {cell.NumberOfBombNeighbors} neighboring bombs.");
                    }
                }

                var gameState = board.DetermineGameState();

                if (gameState == Board.GameStatus.Won)
                {
                    Console.WriteLine("Congratulations! You won!");
                    victory = true;
                }
                else if (gameState == Board.GameStatus.Lost)
                {
                    Console.WriteLine("You lost. Better luck next time.");
                    death = true;
                }
            }
        }
    }
}