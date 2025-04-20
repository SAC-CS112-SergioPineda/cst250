using System;
using MineSweeperClasses;

namespace MineSweeperConsole

    {
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");

            int boardSize = 0;
            float gameDifficulty = 0;
            int rewardCounter = 1; // Player starts with 1 reward (peek)

            // Ask the player for board size with input validation
            while (true)
            {
                Console.Write("Enter the board size (e.g., 5 for a 5x5 board): ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "x") return; // Allow exit
                if (int.TryParse(input, out boardSize) && boardSize > 2) break;
                Console.WriteLine("Invalid input. Please enter a number greater than 2.");
            }

            // Ask for difficulty level and cap it to prevent overpopulation
            while (true)
            {
                Console.Write("Enter the difficulty (0.1 = Easy, 0.15 = Medium, 0.2 = Hard): ");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "x") return;
                if (float.TryParse(input, out gameDifficulty) && gameDifficulty > 0 && gameDifficulty < 1) break;
                Console.WriteLine("Invalid input. Enter a decimal like 0.1 or 0.2.");
            }

            float cappedDifficulty = Math.Min(gameDifficulty, 0.3f); // Limit bombs to 30% max
            Board gameBoard = new Board(boardSize, cappedDifficulty); // Create the game board

            AssignRewardCell(gameBoard); // Place one reward cell on the board

            bool isGameRunning = true;

            while (isGameRunning)
            {
                Console.Clear();
                PrintGameState(gameBoard); // Show current game state

                Console.WriteLine("Type 'x' to quit, 'qq' to reveal the board");
                Console.WriteLine($"Bombs Remaining: {CountRemainingBombs(gameBoard)}");
                Console.WriteLine($"Rewards (Peek Count): {rewardCounter}");

                // Get the row input
                Console.Write("Enter row: ");
                string rowInput = Console.ReadLine();
                if (rowInput.Trim().ToLower() == "x") break;
                if (rowInput.Trim().ToLower() == "qq") { PrintAnswers(gameBoard); Console.ReadKey(); continue; }
                if (!int.TryParse(rowInput, out int row)) { Console.WriteLine("Invalid row."); continue; }

                // Get the column input
                Console.Write("Enter column: ");
                string colInput = Console.ReadLine();
                if (colInput.Trim().ToLower() == "x") break;
                if (!int.TryParse(colInput, out int col)) { Console.WriteLine("Invalid column."); continue; }

                // Ask the player for the type of move
                Console.Write("Choose action (Flag / Visit / Peek): ");
                string action = Console.ReadLine().Trim().ToLower();
                if (action == "x") break;
                if (action != "flag" && action != "visit" && action != "peek")
                {
                    Console.WriteLine("Invalid action. Try: Flag, Visit, or Peek.");
                    continue;
                }

                if (!IsValidCell(row, col, boardSize))
                {
                    Console.WriteLine("That's not on the board.");
                    continue;
                }

                Cell selectedCell = gameBoard.gameCells[row, col];

                if (action == "flag")
                {
                    ifCanFlag(selectedCell); // Mark or unmark a flag
                }
                else if (action == "visit")
                {
                    if (!selectedCell.isVisited && !selectedCell.isBomb && selectedCell.numberOfBombNeighbors == 0)
                        FloodFill(gameBoard, row, col); // Reveal all surrounding blank cells
                    else
                        ifCanVisit(selectedCell, gameBoard); // Regular visit action

                    if (selectedCell.hasSpecialReward)
                    {
                        rewardCounter++; // Gain an extra peek
                        selectedCell.hasSpecialReward = false;
                        gameBoard.rewardsRemaining--;
                    }
                }
                else if (action == "peek")
                {
                    if (rewardCounter > 0)
                    {
                        PeekCell(gameBoard, row, col); // Temporarily view the cell
                        rewardCounter--; // Use up one peek
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("No rewards left.");
                        Console.ReadKey();
                    }
                }

                if (ifGameOver(gameBoard)) isGameRunning = false;

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        // Peek at a specific cell without consequences
        static void PeekCell(Board board, int row, int col)
        {
            var cell = board.gameCells[row, col];
            Console.WriteLine("You peeked at this cell:");
            Console.WriteLine($"Row {row}, Col {col} -> " +
                (cell.isBomb ? "Bomb" :
                cell.hasSpecialReward ? "Reward" :
                $"{cell.numberOfBombNeighbors} nearby bombs"));
        }

        // Count bombs that are not flagged yet
        static int CountRemainingBombs(Board board)
        {
            int count = 0;
            foreach (var cell in board.gameCells)
            {
                if (cell.isBomb && !cell.isFlagged)
                    count++;
            }
            return count;
        }

        // Reveal all adjacent empty cells using recursion
        static void FloodFill(Board board, int row, int col)
        {
            if (!IsValidCell(row, col, board.boardSize)) return;
            var cell = board.gameCells[row, col];

            if (cell.isVisited || cell.isFlagged || cell.isBomb) return;

            cell.isVisited = true; // Mark current cell as visited

            if (cell.hasSpecialReward)
            {
                cell.hasSpecialReward = false; // Collect reward automatically
                board.rewardsRemaining--;
            }

            if (cell.numberOfBombNeighbors > 0) return; // Stop if neighbors have bombs

            // Visit surrounding cells recursively
            FloodFill(board, row - 1, col);
            FloodFill(board, row + 1, col);
            FloodFill(board, row, col - 1);
            FloodFill(board, row, col + 1);
            FloodFill(board, row - 1, col - 1);
            FloodFill(board, row - 1, col + 1);
            FloodFill(board, row + 1, col - 1);
            FloodFill(board, row + 1, col + 1);
        }

        // Try to randomly place a single reward cell
        static void AssignRewardCell(Board board)
        {
            int chance = (int)(1 / board.gameDifficulty);
            Random rnd = new Random();
            bool rewardPlaced = false;
            int attempts = 0;
            int maxAttempts = board.boardSize * board.boardSize * 10;

            while (!rewardPlaced && attempts < maxAttempts)
            {
                int r = rnd.Next(board.boardSize);
                int c = rnd.Next(board.boardSize);
                attempts++;

                if (!board.gameCells[r, c].isBomb && rnd.Next(chance) == 0)
                {
                    board.gameCells[r, c].hasSpecialReward = true;
                    board.rewardsRemaining++;
                    rewardPlaced = true;
                }
            }
        }

        // Make sure the cell picked is within bounds
        static bool IsValidCell(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        // Add or remove a flag on the cell
        static void ifCanFlag(Cell cell)
        {
            if (!cell.isVisited)
                cell.isFlagged = !cell.isFlagged;
        }

        // Visit a single cell
        static void ifCanVisit(Cell cell, Board board)
        {
            if (!cell.isFlagged && !cell.isVisited)
            {
                cell.isVisited = true;
                if (cell.isBomb)
                {
                    board.gameState = Board.GameStatus.Lost;
                    Console.WriteLine("You hit a bomb. Game Over.");
                }
            }
        }

        // Check for win or loss state
        static bool ifGameOver(Board board)
        {
            if (board.gameState == Board.GameStatus.Lost)
            {
                Console.WriteLine("Game Over. You lost.");
                return true;
            }

            bool hasWon = true;
            foreach (var cell in board.gameCells)
            {
                if (!cell.isBomb && !cell.isVisited)
                {
                    hasWon = false;
                    break;
                }
            }

            if (hasWon)
            {
                board.gameState = Board.GameStatus.Won;
                Console.WriteLine("Victory. You cleared the board.");
                return true;
            }

            return false;
        }

        // Print the board to the console
        static void PrintGameState(Board board)
        {
            Console.Write("    ");
            for (int col = 0; col < board.boardSize; col++)
                Console.Write($" {col}  ");
            Console.WriteLine();

            Console.Write("   ");
            for (int i = 0; i < board.boardSize; i++) Console.Write("+---");
            Console.WriteLine("+");

            for (int row = 0; row < board.boardSize; row++)
            {
                Console.Write($" {row} ");
                for (int col = 0; col < board.boardSize; col++)
                {
                    var cell = board.gameCells[row, col];
                    Console.Write("|");

                    if (cell.isFlagged)
                        Console.Write(" F ");
                    else if (!cell.isVisited)
                        Console.Write("   ");
                    else if (cell.isBomb)
                        Console.Write(" B ");
                    else if (cell.hasSpecialReward)
                        Console.Write(" r ");
                    else
                    {
                        Console.ForegroundColor = cell.numberOfBombNeighbors switch
                        {
                            1 => ConsoleColor.Magenta,
                            2 => ConsoleColor.DarkMagenta,
                            3 => ConsoleColor.Red,
                            >= 4 => ConsoleColor.DarkRed,
                            _ => Console.ForegroundColor
                        };
                        Console.Write($" {cell.numberOfBombNeighbors} ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("|");
                Console.Write("   ");
                for (int i = 0; i < board.boardSize; i++) Console.Write("+---");
                Console.WriteLine("+");
            }
        }

        // Print the full solution board with bombs and rewards
        static void PrintAnswers(Board board)
        {
            Console.Write("    ");
            for (int col = 0; col < board.boardSize; col++)
                Console.Write($" {col}  ");
            Console.WriteLine();

            Console.Write("   ");
            for (int i = 0; i < board.boardSize; i++) Console.Write("+---");
            Console.WriteLine("+");

            for (int row = 0; row < board.boardSize; row++)
            {
                Console.Write($" {row} ");
                for (int col = 0; col < board.boardSize; col++)
                {
                    var cell = board.gameCells[row, col];
                    Console.Write("|");

                    if (cell.isBomb)
                        Console.Write(" B ");
                    else if (cell.hasSpecialReward)
                        Console.Write(" r ");
                    else if (cell.numberOfBombNeighbors > 0)
                        Console.Write($" {cell.numberOfBombNeighbors} ");
                    else
                        Console.Write(" . ");
                }
                Console.WriteLine("|");
                Console.Write("   ");
                for (int i = 0; i < board.boardSize; i++) Console.Write("+---");
                Console.WriteLine("+");
            }
        }
    }
}

