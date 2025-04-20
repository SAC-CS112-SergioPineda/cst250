namespace ChessBoardGUIApp
{
    partial class FrmChessBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblPieceName = new Label();
            comboPieceNames = new ComboBox();
            panelChessBoard = new Panel();
            radioBtn = new RadioButton();
            groupBox1 = new GroupBox();
            radioBtnWild = new RadioButton();
            radioBtnWarm = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblPieceName
            // 
            lblPieceName.AutoSize = true;
            lblPieceName.Location = new Point(523, 15);
            lblPieceName.Name = "lblPieceName";
            lblPieceName.Size = new Size(100, 25);
            lblPieceName.TabIndex = 0;
            lblPieceName.Text = "piece used:";
            // 
            // comboPieceNames
            // 
            comboPieceNames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPieceNames.FormattingEnabled = true;
            comboPieceNames.Items.AddRange(new object[] { "King ", "Queen", "Knight", "Rook", "Pawn", "Bishop" });
            comboPieceNames.Location = new Point(588, 12);
            comboPieceNames.Name = "comboPieceNames";
            comboPieceNames.Size = new Size(182, 33);
            comboPieceNames.TabIndex = 1;
            // 
            // panelChessBoard
            // 
            panelChessBoard.Location = new Point(12, 48);
            panelChessBoard.Name = "panelChessBoard";
            panelChessBoard.Size = new Size(500, 500);
            panelChessBoard.TabIndex = 2;
            // 
            // radioBtn
            // 
            radioBtn.AutoSize = true;
            radioBtn.Location = new Point(6, 30);
            radioBtn.Name = "radioBtn";
            radioBtn.Size = new Size(123, 29);
            radioBtn.TabIndex = 3;
            radioBtn.TabStop = true;
            radioBtn.Text = "cool mode";
            radioBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioBtnWild);
            groupBox1.Controls.Add(radioBtnWarm);
            groupBox1.Controls.Add(radioBtn);
            groupBox1.Location = new Point(523, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 150);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color Theme";
            // 
            // radioBtnWild
            // 
            radioBtnWild.AutoSize = true;
            radioBtnWild.Location = new Point(6, 100);
            radioBtnWild.Name = "radioBtnWild";
            radioBtnWild.Size = new Size(69, 29);
            radioBtnWild.TabIndex = 5;
            radioBtnWild.TabStop = true;
            radioBtnWild.Text = "wild";
            radioBtnWild.UseVisualStyleBackColor = true;
            // 
            // radioBtnWarm
            // 
            radioBtnWarm.AutoSize = true;
            radioBtnWarm.Location = new Point(6, 65);
            radioBtnWarm.Name = "radioBtnWarm";
            radioBtnWarm.Size = new Size(81, 29);
            radioBtnWarm.TabIndex = 4;
            radioBtnWarm.TabStop = true;
            radioBtnWarm.Text = "warm";
            radioBtnWarm.UseVisualStyleBackColor = true;
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 597);
            Controls.Add(groupBox1);
            Controls.Add(panelChessBoard);
            Controls.Add(comboPieceNames);
            Controls.Add(lblPieceName);
            Name = "FrmChessBoard";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPieceName;
        private ComboBox comboPieceNames;
        private Panel panelChessBoard;
        private RadioButton radioBtn;
        private GroupBox groupBox1;
        private RadioButton radioBtnWild;
        private RadioButton radioBtnWarm;
    }
}
