using System;

namespace MineSweeperClasses
{
    // This is my main board class. It controls the game grid and handles bomb placement and neighbor calculations
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RewardsRemaining { get; set; } = 0;

        // I'm using an enum to store the game state
        public enum GameStatus { InProgress, Won, Lost }
        public GameStatus State { get; set; }

        Random random = new Random(); // Using this to generate random numbers for bombs

        // This constructor initializes the board based on the input size and difficulty
        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            InitializeBoard();
        }

        // I use this method to create each cell and initialize its properties
        private void InitializeBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[i, j] = new Cell
                    {
                        Row = i,
                        Column = j
                    };
                }
            }

            SetupBombs();
            CalculateNumberOfBombNeighbors();
            StartTime = DateTime.Now; // I set the game start time here
        }

        // This method randomly places bombs using the difficulty setting
        public void SetupBombs()
        {
            int totalBombs = (int)(Size * Size * Difficulty);
            int placedBombs = 0;

            while (placedBombs < totalBombs)
            {
                int x = random.Next(Size);
                int y = random.Next(Size);

                if (!Cells[x, y].IsBomb)
                {
                    Cells[x, y].IsBomb = true;
                    placedBombs++;
                }
            }
        }

        // This method calculates how many bombs are adjacent to each cell
        public void CalculateNumberOfBombNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Cells[i, j].IsBomb)
                    {
                        Cells[i, j].NumberOfBombNeighbors = 9; // I use 9 to indicate the cell is a bomb
                    }
                    else
                    {
                        Cells[i, j].NumberOfBombNeighbors = GetNumberOfBombNeighbors(i, j);
                    }
                }
            }
        }

        // I use this helper method to check adjacent cells and count how many are bombs
        private int GetNumberOfBombNeighbors(int row, int col)
        {
            int count = 0;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int newRow = row + dx;
                    int newCol = col + dy;

                    if (IsCellOnBoard(newRow, newCol) && Cells[newRow, newCol].IsBomb)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        // This method ensures I'm not checking out-of-bound cells
        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }
    }
}

