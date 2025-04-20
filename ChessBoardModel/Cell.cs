using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
     public class Cell
    {

        public int Row { get; set; }
        public int Column { get; set; }

        public String IsCurrentlyOccupied { get; set; } = "";

        public bool IsLegalNextMove { get; set; }

        public Cell(int r, int c)
        {
            //ea cell has a row and column
            Row = r;
            Column = c;

            //by default the cell is not occupied by apiece nor is it a legal next move 

            IsCurrentlyOccupied = "";
            IsLegalNextMove = false;
        }
    }
}
