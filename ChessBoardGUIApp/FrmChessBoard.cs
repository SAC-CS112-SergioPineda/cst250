using ChessGameLogic;
using System.Diagnostics.Eventing.Reader;

namespace ChessBoardGUIApp
{
    public partial class FrmChessBoard : Form
    {

        public Board myBoard = new Board(8);
        public Button[,] buttons = new Button[8, 8];

        //  colour sets
        private readonly Color[] ColorSetCool =
        {
            Color.FromArgb(240, 240, 250),   // light square
            Color.FromArgb(220, 220, 220),   // dark square
            Color.FromArgb(180, 233, 180),   // legal‑move highlight
            Color.LightBlue                  // occupied‑square highlight
        };

        private readonly Color[] ColorSetWarm =
        {
            Color.FromArgb(220, 200, 200),
            Color.FromArgb(180, 160, 160),
            Color.LightCoral,
            Color.MistyRose
        };

        private readonly Color[] ColorSetWild =
        {
            Color.FromArgb(180, 180, 180),
            Color.FromArgb(160, 160, 160),
            Color.Aqua,
            Color.MediumAquamarine
        };

        // Helper that returns whichever set matches the checked radio button
        private Color[] ActiveSet =>
            radioBtnWarm.Checked ? ColorSetWarm :
            radioBtnWild.Checked ? ColorSetWild : ColorSetCool; // default = cool

        // constructor 
        public FrmChessBoard()
        {
            InitializeComponent();
            SetupButtons();                 // create 8×8 grid

            // repaint the board whenever user changes the theme
            radioBtn.CheckedChanged += ThemeChanged;
            radioBtnWarm.CheckedChanged += ThemeChanged;
            radioBtnWild.CheckedChanged += ThemeChanged;

            // ensure one theme is selected at start‑up
            if (!radioBtn.Checked && !radioBtnWarm.Checked && !radioBtnWild.Checked)
                radioBtn.Checked = true;
        }

        private void ThemeChanged(object? sender, EventArgs e) => updateButtonFaces(myBoard);

        // create chessboard buttons 
        private void SetupButtons()
        {
            int buttonSize = panelChessBoard.Width / myBoard.Size;
            panelChessBoard.Height = panelChessBoard.Width;

            for (int row = 0; row < myBoard.Size; row++)
            {
                for (int col = 0; col < myBoard.Size; col++)
                {
                    Button btn = new Button
                    {
                        Width = buttonSize,
                        Height = buttonSize,
                        Left = row * buttonSize,   // x‑coordinate
                        Top = col * buttonSize,   // y‑coordinate
                        Tag = new Point(row, col)
                    };

                    btn.Click += GridButtons_Click;
                    panelChessBoard.Controls.Add(btn);
                    buttons[row, col] = btn;
                }
            }
        }

        // click handler
        private void GridButtons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Point p = (Point)b.Tag;
            int row = p.X;
            int col = p.Y;

            string piece = comboPieceNames.Text;
            if (string.IsNullOrWhiteSpace(piece)) return;   // nothing selected

            myBoard.MarkNextLegalMoves(myBoard.TheGrid[row, col], piece);
            updateButtonFaces(myBoard);
        }

        // redraw all button faces / colours
        private void updateButtonFaces(Board board)
        {
            Color[] set = ActiveSet;
            Color light = set[0];
            Color dark = set[1];
            Color legal = set[2];
            Color occupied = set[3];

            var pieceMap = new Dictionary<string, string>
            {
                {"N", "Knight"},
                {"K", "King"},
                {"Q", "Queen"},
                {"B", "Bishop"},
                {"R", "Rook"},
                {"P", "Pawn"}
            };

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // reset text
                    buttons[i, j].Text = " ";

                    // determine background base colour (checkerboard)
                    buttons[i, j].BackColor = ((i + j) % 2 == 0) ? light : dark;

                    // highlight legal moves
                    if (board.TheGrid[i, j].IsLegalNextMove)
                    {
                        buttons[i, j].Text = "Legal Move";
                        buttons[i, j].BackColor = legal;
                    }

                    // show occupied piece
                    if (!string.IsNullOrEmpty(board.TheGrid[i, j].IsCurrentlyOccupied))
                    {
                        string key = board.TheGrid[i, j].IsCurrentlyOccupied;
                        if (pieceMap.ContainsKey(key))
                            buttons[i, j].Text = pieceMap[key];
                        buttons[i, j].BackColor = occupied;
                    }
                }
            }
        }
    }
}

