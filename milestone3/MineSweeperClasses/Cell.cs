using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeperClasses
{
    // I'm creating a class to represent each cell on the board
    public class Cell
    {
        public int rowIndex { get; set; } = -1; // I set the initial row to -1 to indicate it's uninitialized
        public int columnIndex { get; set; } = -1; // Similarly, the column is set to -1

        public bool isVisited { get; set; } = false; // Tracks if the cell has been revealed
        public bool isBomb { get; set; } = false; // Flag to mark if a bomb is placed here
        public bool isFlagged { get; set; } = false; // Tracks if the player flagged this cell
        public int numberOfBombNeighbors { get; set; } = 0; // Bombs surrounding this cell
        public bool hasSpecialReward { get; set; } = false; // For future game mechanics
    }
}
