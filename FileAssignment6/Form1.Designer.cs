namespace FileAssignment6
{
    partial class FrmInventory
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
            txtName = new TextBox();
            txtValue = new TextBox();
            groupBox1 = new GroupBox();
            btnAdd = new Button();
            lblValue = new Label();
            lblName = new Label();
            gridInventory = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            rdoShowAll = new RadioButton();
            groupBox2 = new GroupBox();
            rdoShowMostValuable = new RadioButton();
            rdoShowLeastValuable = new RadioButton();
            rangeTrackBar1 = new RangeTrackBar();
            txtSearch = new TextBox();
            btnSearch = new Button();
            lblTotalItems = new Label();
            lblTotalValue = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridInventory).BeginInit();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(133, 32);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 31);
            txtName.TabIndex = 0;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(133, 69);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(150, 31);
            txtValue.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Controls.Add(lblValue);
            groupBox1.Controls.Add(lblName);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(txtValue);
            groupBox1.Location = new Point(12, 62);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 155);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupEntryForm";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(133, 115);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(15, 75);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(54, 25);
            lblValue.TabIndex = 3;
            lblValue.Text = "Value";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(15, 38);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Name";
            // 
            // gridInventory
            // 
            gridInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridInventory.Location = new Point(318, 42);
            gridInventory.Name = "gridInventory";
            gridInventory.RowHeadersWidth = 62;
            gridInventory.Size = new Size(601, 465);
            gridInventory.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1016, 33);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(149, 34);
            saveToolStripMenuItem.Text = "save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(149, 34);
            loadToolStripMenuItem.Text = "load";
            loadToolStripMenuItem.Click += MenuLoad_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(149, 34);
            exitToolStripMenuItem.Text = "exit";
            // 
            // rdoShowAll
            // 
            rdoShowAll.AutoSize = true;
            rdoShowAll.Location = new Point(15, 30);
            rdoShowAll.Name = "rdoShowAll";
            rdoShowAll.Size = new Size(106, 29);
            rdoShowAll.TabIndex = 5;
            rdoShowAll.TabStop = true;
            rdoShowAll.Text = "Show All";
            rdoShowAll.UseVisualStyleBackColor = true;
            rdoShowAll.CheckedChanged += RadioShowAll_CheckedChange;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rdoShowMostValuable);
            groupBox2.Controls.Add(rdoShowLeastValuable);
            groupBox2.Controls.Add(rdoShowAll);
            groupBox2.Location = new Point(12, 232);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(211, 150);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // rdoShowMostValuable
            // 
            rdoShowMostValuable.AutoSize = true;
            rdoShowMostValuable.Location = new Point(15, 100);
            rdoShowMostValuable.Name = "rdoShowMostValuable";
            rdoShowMostValuable.Size = new Size(164, 29);
            rdoShowMostValuable.TabIndex = 7;
            rdoShowMostValuable.TabStop = true;
            rdoShowMostValuable.Text = "3 Most Valuable";
            rdoShowMostValuable.UseVisualStyleBackColor = true;
            rdoShowMostValuable.CheckedChanged += RadioMostValuable_CheckedChanged;
            // 
            // rdoShowLeastValuable
            // 
            rdoShowLeastValuable.AutoSize = true;
            rdoShowLeastValuable.Location = new Point(15, 65);
            rdoShowLeastValuable.Name = "rdoShowLeastValuable";
            rdoShowLeastValuable.Size = new Size(163, 29);
            rdoShowLeastValuable.TabIndex = 6;
            rdoShowLeastValuable.TabStop = true;
            rdoShowLeastValuable.Text = "3 Least Valuable";
            rdoShowLeastValuable.UseVisualStyleBackColor = true;
            rdoShowLeastValuable.CheckedChanged += RaidoLeastValuable_CheckedChanged;
            // 
            // rangeTrackBar1
            // 
            rangeTrackBar1.LabelColor = Color.Gray;
            rangeTrackBar1.Location = new Point(12, 513);
            rangeTrackBar1.LowerColor = Color.DarkRed;
            rangeTrackBar1.LowerValue = 10;
            rangeTrackBar1.MaxValue = 100;
            rangeTrackBar1.MinimumSize = new Size(100, 50);
            rangeTrackBar1.MinValue = 0;
            rangeTrackBar1.Name = "rangeTrackBar1";
            rangeTrackBar1.Size = new Size(638, 75);
            rangeTrackBar1.TabIndex = 7;
            rangeTrackBar1.Text = "rangeMinMax";
            rangeTrackBar1.TickColor = Color.LightGray;
            rangeTrackBar1.TickFrequency = 10;
            rangeTrackBar1.TrackColor = Color.LightGray;
            rangeTrackBar1.UpperColor = Color.Teal;
            rangeTrackBar1.UpperValue = 90;
            rangeTrackBar1.Click += RangeMinMax_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(645, 513);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(193, 31);
            txtSearch.TabIndex = 8;
            txtSearch.Text = "search";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(645, 550);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 36);
            btnSearch.TabIndex = 9;
            btnSearch.Text = "search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // lblTotalItems
            // 
            lblTotalItems.AutoSize = true;
            lblTotalItems.Location = new Point(834, 519);
            lblTotalItems.Name = "lblTotalItems";
            lblTotalItems.Size = new Size(59, 25);
            lblTotalItems.TabIndex = 10;
            lblTotalItems.Text = "label1";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Location = new Point(834, 556);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(59, 25);
            lblTotalValue.TabIndex = 11;
            lblTotalValue.Text = "label2";
            // 
            // FrmInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 602);
            Controls.Add(lblTotalValue);
            Controls.Add(lblTotalItems);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(rangeTrackBar1);
            Controls.Add(groupBox2);
            Controls.Add(gridInventory);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmInventory";
            Text = "inv";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridInventory).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private TextBox txtValue;
        private GroupBox groupBox1;
        private Button btnAdd;
        private Label lblValue;
        private Label lblName;
        private DataGridView gridInventory;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private RadioButton rdoShowAll;
        private GroupBox groupBox2;
        private RadioButton rdoShowMostValuable;
        private RadioButton rdoShowLeastValuable;
        private ToolStripMenuItem exitToolStripMenuItem;
        private RangeTrackBar rangeTrackBar1;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblTotalItems;
        private Label lblTotalValue;
    }
}
