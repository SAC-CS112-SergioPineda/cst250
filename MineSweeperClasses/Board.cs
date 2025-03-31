using System;

namespace MineSweeperClasses
{
    public class Board
    {
        public int Size { get; set; }
        public float Difficulty { get; set; }
        public Cell[,] Cells { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RewardsRemaining { get; set; } = 0;

        public enum GameStatus { InProgress, Won, Lost }
        public GameStatus State { get; set; }

        Random random = new Random();

        public Board(int size, float difficulty)
        {
            Size = size;
            Difficulty = difficulty;
            Cells = new Cell[size, size];
            InitializeBoard();
            PlaceRewards();
        }

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
            StartTime = DateTime.Now;
        }

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

        // Place rewards on random non-bomb cells
        public void PlaceRewards()
        {
            int totalRewards = Math.Max(1, Size / 5);
            int placedRewards = 0;

            while (placedRewards < totalRewards)
            {
                int x = random.Next(Size);
                int y = random.Next(Size);

                if (!Cells[x, y].IsBomb && !Cells[x, y].HasSpecialReward)
                {
                    Cells[x, y].HasSpecialReward = true;
                    placedRewards++;
                    RewardsRemaining++;
                }
            }
        }

        public void CalculateNumberOfBombNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Cells[i, j].IsBomb)
                    {
                        Cells[i, j].NumberOfBombNeighbors = 9;
                    }
                    else
                    {
                        Cells[i, j].NumberOfBombNeighbors = GetNumberOfBombNeighbors(i, j);
                    }
                }
            }
        }

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

        private bool IsCellOnBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }

        // Determine Game State
        public GameStatus DetermineGameState()
        {
            bool allNonBombCellsVisited = true;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Cells[i, j].IsBomb && Cells[i, j].IsVisited)
                    {
                        return GameStatus.Lost;
                    }
                    if (!Cells[i, j].IsBomb && !Cells[i, j].IsVisited)
                    {
                        allNonBombCellsVisited = false;
                    }
                }
            }

            return allNonBombCellsVisited ? GameStatus.Won : GameStatus.InProgress;
        }
    }
}