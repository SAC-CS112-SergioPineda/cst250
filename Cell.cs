using System;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MineSweeperClasses
{
    // I'm creating a class to represent each cell on the board
    public class Cell
    {
        public int Row { get; set; } = -1; // I set the initial row to -1 to indicate it's uninitialized
        public int Column { get; set; } = -1; // Similarly, the column is set to -1

        public bool IsVisited { get; set; } = false; // This will help track if the cell has been revealed
        public bool IsBomb { get; set; } = false; // A flag to mark if a bomb is placed here
        public bool IsFlagged { get; set; } = false; // Tracks if the player flagged this cell as a bomb
        public int NumberOfBombNeighbors { get; set; } = 0; // Stores the number of bombs surrounding this cell
        public bool HasSpecialReward { get; set; } = false; // Special rewards may be added later
    }
}
