using System;

namespace MineSweeperClasses
{
    public class Board
    {
        public int boardSize { get; set; }
        public float gameDifficulty { get; set; }
        public Cell[,] gameCells { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public int rewardsRemaining { get; set; } = 0;

        public enum GameStatus { InProgress, Won, Lost }
        public GameStatus gameState { get; set; }

        Random random = new Random();

        public Board(int boardSize, float gameDifficulty)
        {
            this.boardSize = boardSize;
            this.gameDifficulty = gameDifficulty;
            gameCells = new Cell[boardSize, boardSize];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    gameCells[rowIndex, columnIndex] = new Cell
                    {
                        rowIndex = rowIndex,
                        columnIndex = columnIndex
                    };
                }
            }

            SetupBombs();
            CalculateNumberOfBombNeighbors();
            startTime = DateTime.Now;
        }

        public void SetupBombs()
        {
            int totalBombs = (int)(boardSize * boardSize * gameDifficulty);
            int bombsPlaced = 0;

            while (bombsPlaced < totalBombs)
            {
                int randRow = random.Next(boardSize);
                int randCol = random.Next(boardSize);

                if (!gameCells[randRow, randCol].isBomb)
                {
                    gameCells[randRow, randCol].isBomb = true;
                    bombsPlaced++;
                }
            }
        }

        public void CalculateNumberOfBombNeighbors()
        {
            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    if (gameCells[rowIndex, columnIndex].isBomb)
                    {
                        gameCells[rowIndex, columnIndex].numberOfBombNeighbors = 9;
                    }
                    else
                    {
                        gameCells[rowIndex, columnIndex].numberOfBombNeighbors =
                            GetNumberOfBombNeighbors(rowIndex, columnIndex);
                    }
                }
            }
        }

        private int GetNumberOfBombNeighbors(int rowIndex, int columnIndex)
        {
            int bombCount = 0;

            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int adjRow = rowIndex + dx;
                    int adjCol = columnIndex + dy;

                    if (IsCellOnBoard(adjRow, adjCol) && gameCells[adjRow, adjCol].isBomb)
                    {
                        bombCount++;
                    }
                }
            }

            return bombCount;
        }

        private bool IsCellOnBoard(int rowIndex, int columnIndex)
        {
            return rowIndex >= 0 && rowIndex < boardSize && columnIndex >= 0 && columnIndex < boardSize;
        }
    }
}
