using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLogic
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] TheGrid { get; set; }

        public Board(int s)
        {
            Size = s;
            TheGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void ClearBoard()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j].IsLegalNextMove = false;
                    TheGrid[i, j].IsCurrentlyOccupied = "";

                }
            }
        }

        public void MarkNextLegalMoves(Cell targetCell, string chessPiece)
        {
            ClearBoard();

            switch (chessPiece)
            {
                case "Knight":
                    targetCell.IsCurrentlyOccupied = "N";
                    if (IsOnTheBoard(targetCell.Row + 2, targetCell.Column + 1))
                        TheGrid[targetCell.Row + 2, targetCell.Column + 1].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row + 2, targetCell.Column - 1))
                        TheGrid[targetCell.Row + 2, targetCell.Column - 1].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row - 2, targetCell.Column + 1))
                        TheGrid[targetCell.Row - 2, targetCell.Column + 1].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row - 2, targetCell.Column - 1))
                        TheGrid[targetCell.Row - 2, targetCell.Column - 1].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row + 1, targetCell.Column + 2))
                        TheGrid[targetCell.Row + 1, targetCell.Column + 2].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row + 1, targetCell.Column - 2))
                        TheGrid[targetCell.Row + 1, targetCell.Column - 2].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row - 1, targetCell.Column + 2))
                        TheGrid[targetCell.Row - 1, targetCell.Column + 2].IsLegalNextMove = true;
                    if (IsOnTheBoard(targetCell.Row - 1, targetCell.Column - 2))
                        TheGrid[targetCell.Row - 1, targetCell.Column - 2].IsLegalNextMove = true;
                    break;

                case "Rook":
                    targetCell.IsCurrentlyOccupied = "R";
                    for (int i = 1; i < Size; i++)
                    {
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column))
                            TheGrid[targetCell.Row + i, targetCell.Column].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column))
                            TheGrid[targetCell.Row - i, targetCell.Column].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row, targetCell.Column + i))
                            TheGrid[targetCell.Row, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row, targetCell.Column - i))
                            TheGrid[targetCell.Row, targetCell.Column - i].IsLegalNextMove = true;
                    }
                    break;

                case "Bishop":
                    targetCell.IsCurrentlyOccupied = "B";
                    for (int i = 1; i < Size; i++)
                    {
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column + i))
                            TheGrid[targetCell.Row + i, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column - i))
                            TheGrid[targetCell.Row + i, targetCell.Column - i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column + i))
                            TheGrid[targetCell.Row - i, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column - i))
                            TheGrid[targetCell.Row - i, targetCell.Column - i].IsLegalNextMove = true;
                    }
                    break;

                case "Queen":
                    targetCell.IsCurrentlyOccupied = "Q";
                    for (int i = 1; i < Size; i++)
                    {
                        // Rook-like moves
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column))
                            TheGrid[targetCell.Row + i, targetCell.Column].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column))
                            TheGrid[targetCell.Row - i, targetCell.Column].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row, targetCell.Column + i))
                            TheGrid[targetCell.Row, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row, targetCell.Column - i))
                            TheGrid[targetCell.Row, targetCell.Column - i].IsLegalNextMove = true;

                        // Bishop-like moves
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column + i))
                            TheGrid[targetCell.Row + i, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row + i, targetCell.Column - i))
                            TheGrid[targetCell.Row + i, targetCell.Column - i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column + i))
                            TheGrid[targetCell.Row - i, targetCell.Column + i].IsLegalNextMove = true;
                        if (IsOnTheBoard(targetCell.Row - i, targetCell.Column - i))
                            TheGrid[targetCell.Row - i, targetCell.Column - i].IsLegalNextMove = true;
                    }
                    break;

                case "King":
                    targetCell.IsCurrentlyOccupied = "K";
                    for (int r = -1; r <= 1; r++)
                    {
                        for (int c = -1; c <= 1; c++)
                        {
                            if (r != 0 || c != 0)
                            {
                                int newRow = targetCell.Row + r;
                                int newCol = targetCell.Column + c;
                                if (IsOnTheBoard(newRow, newCol))
                                    TheGrid[newRow, newCol].IsLegalNextMove = true;
                            }
                        }
                    }
                    break;

                case "Pawn":
                    targetCell.IsCurrentlyOccupied = "P";

                    /*  A pawn travels straight “north” on the screen.
                        On this board the vertical direction is the 𝙘𝙤𝙡𝙪𝙢𝙣 index,
                        so we change 𝘾𝙤𝙡𝙪𝙢𝙣 (not Row) to mark legal moves.          */

                    int oneUp = targetCell.Column - 1;        // one square north
                    if (IsOnTheBoard(targetCell.Row, oneUp))
                        TheGrid[targetCell.Row, oneUp].IsLegalNextMove = true;

                    // two squares north from the starting rank (Column == Size‑2, i.e. row 6 on an 8×8)
                    if (targetCell.Column == Size - 2)
                    {
                        int twoUp = targetCell.Column - 2;
                        if (IsOnTheBoard(targetCell.Row, twoUp))
                            TheGrid[targetCell.Row, twoUp].IsLegalNextMove = true;
                    }

                    break;
            }
        }




        public bool IsOnTheBoard(int row, int col)
        {
            return row >= 0 && row < Size && col >= 0 && col < Size;
        }
    }
}

