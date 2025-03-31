using System;
using System.Collections.Generic;
using System.Linq;


namespace MineSweeperClasses
{
    public class Cell
    {
        public int Row { get; set; } = -1;
        public int Column { get; set; } = -1;

        public bool IsVisited { get; set; } = false;
        public bool IsBomb { get; set; } = false;
        public bool IsFlagged { get; set; } = false;
        public int NumberOfBombNeighbors { get; set; } = 0;
        public bool HasSpecialReward { get; set; } = false;
        public bool HasFreeze { get; set; } = false; // New Freeze Feature

        // Implement UseReward Method
        public void UseReward()
        {
            if (!HasSpecialReward)
            {
                Console.WriteLine("No reward available on this cell.");
                return;
            }

            Console.WriteLine($"Using reward on cell ({Row}, {Column})...");

            if (IsBomb)
            {
                Console.WriteLine("This cell contains a bomb! Be careful!");
            }
            else
            {
                Console.WriteLine($"This cell is safe and has {NumberOfBombNeighbors} neighboring bombs.");
            }

            HasSpecialReward = false; // Reward is consumed
        }

        // Implement Freeze Feature
        public void UseFreeze()
        {
            if (!HasFreeze)
            {
                Console.WriteLine("No freeze power-up available on this cell.");
                return;
            }

            if (IsBomb)
            {
                IsBomb = false; // Disable the bomb
                Console.WriteLine($"Freeze used! Bomb at ({Row}, {Column}) has been neutralized.");
            }
            else
            {
                Console.WriteLine("No bomb at this location. Freeze wasted.");
            }

            HasFreeze = false; // Freeze is consumed
        }
    }
}
