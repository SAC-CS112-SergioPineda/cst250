
namespace ChessBoardConsoleApp
{
    using System;
    using ChessBoardModel;
    using ChessGameLogic;

    class Program
    {
        static void Main(string[] args)
        {
            Board myboard = new Board(8);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Available pieces: Knight, Rook, Bishop, Queen, King, Pawn");

                // Validate piece input
                Console.Write("Enter a piece: ");
                string piece = Console.ReadLine();
                piece = char.ToUpper(piece[0]) + piece.Substring(1).ToLower();

                string[] validPieces = { "Knight", "Rook", "Bishop", "Queen", "King", "Pawn" };
                while (Array.IndexOf(validPieces, piece) == -1)
                {
                    Console.Write("Invalid piece. Please enter a valid piece: ");
                    piece = Console.ReadLine();
                    piece = char.ToUpper(piece[0]) + piece.Substring(1).ToLower();
                }

                int row = GetValidInput("Enter row (0-7): ");
                int col = GetValidInput("Enter column (0-7): ");

                myboard.MarkNextLegalMoves(myboard.TheGrid[row, col], piece);

                PrintBoard(myboard);

                Console.WriteLine("Press any key to place another piece...");
                Console.ReadKey();
            }
        }

        static int GetValidInput(string prompt)
        {
            int input;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out input) || input < 0 || input > 7)
            {
                Console.Write("Invalid input. " + prompt);
            }
            return input;
        }

        static void PrintBoard(Board board)
        {
            Console.WriteLine("   +---+---+---+---+---+---+---+---+");
            for (int row = 0; row < board.Size; row++)
            {
                Console.Write(" {0} |", row);
                for (int col = 0; col < board.Size; col++)
                {
                    Cell cell = board.TheGrid[row, col];
                    if (cell.IsCurrentlyOccupied != null && cell.IsCurrentlyOccupied != "")
                        Console.Write(" {0} |", cell.IsCurrentlyOccupied);
                    else if (cell.IsLegalNextMove)
                        Console.Write(" * |");
                    else
                        Console.Write("   |");
                }
                Console.WriteLine();
                Console.WriteLine("   +---+---+---+---+---+---+---+---+");
            }

            Console.Write("     ");
            for (int i = 0; i < board.Size; i++)
            {
                Console.Write(" {0}  ", i);
            }
            Console.WriteLine();
        }
    }
}