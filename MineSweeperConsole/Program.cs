using System;
using MineSweeperClasses;

namespace MineSweeperConsole
{ 

    internal class Program
    {
        // The main method runs my application
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");

            // I ask for the board size and difficulty
            Console.Write("Enter the board size (e.g., 10 for a 10x10 board): ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Enter the difficulty (0.1 for Easy, 0.15 for Medium, 0.2 for Hard): ");
            float difficulty = float.Parse(Console.ReadLine());

            // I create a new instance of the board
            Board board = new Board(size, difficulty);

            Console.WriteLine("\nThe bombs and numbers are ready. Here are the answers:");
            PrintAnswers(board);
        }

        // This method displays the entire board with bombs and neighbor counts
        static void PrintAnswers(Board board)
        {
            Console.Write("   ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write($" {i} ");
            }
            Console.WriteLine();

            for (int x = 0; x < board.Size; x++)
            {
                Console.Write($" {x} ");
                for (int y = 0; y < board.Size; y++)
                {
                    var cell = board.Cells[x, y];
                    if (cell.IsBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B "); // Bomb
                    }
                    else if (cell.NumberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {cell.NumberOfBombNeighbors} "); // Bomb Neighbor Count
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" . "); // No Bomb
                    }
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
