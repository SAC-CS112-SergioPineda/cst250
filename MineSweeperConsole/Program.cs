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
            int boardSize = int.Parse(Console.ReadLine());

            Console.Write("Enter the difficulty (0.1 for Easy, 0.15 for Medium, 0.2 for Hard): ");
            float gameDifficulty = float.Parse(Console.ReadLine());

            Board gameBoard = new Board(boardSize, gameDifficulty);

            Console.WriteLine("\nThe bombs and numbers are ready. Here are the answers:");
            PrintAnswers(gameBoard);
        }

        static void PrintAnswers(Board gameBoard)
        {
            Console.Write("   ");
            for (int colIndex = 0; colIndex < gameBoard.boardSize; colIndex++)
            {
                Console.Write($" {colIndex} ");
            }
            Console.WriteLine();

            for (int rowIndex = 0; rowIndex < gameBoard.boardSize; rowIndex++)
            {
                Console.Write($" {rowIndex} ");
                for (int colIndex = 0; colIndex < gameBoard.boardSize; colIndex++)
                {
                    var currentCell = gameBoard.gameCells[rowIndex, colIndex];

                    if (currentCell.isBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B ");
                    }
                    else if (currentCell.numberOfBombNeighbors > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {currentCell.numberOfBombNeighbors} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" . ");
                    }
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
