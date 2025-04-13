namespace carStoreGuiApp
{
    partial class frmCarStore
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            groupBox1 = new GroupBox();
            txtPrice = new TextBox();
            txtYear = new TextBox();
            txtModel = new TextBox();
            txtMake = new TextBox();
            btnCreate = new Button();
            groupBox2 = new GroupBox();
            btnSortValue = new Button();
            btnSortYear = new Button();
            btnSortAtoZ = new Button();
            label7 = new Label();
            btnSearch = new Button();
            ListInventory = new ListBox();
            btnAddToCart = new Button();
            groupBox3 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            btnCheckout = new Button();
            listShoppingCart = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 61);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 0;
            label1.Text = "Make";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 100);
            label2.Name = "label2";
            label2.Size = new Size(63, 25);
            label2.TabIndex = 1;
            label2.Text = "Model";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 144);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 2;
            label3.Text = "Year";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 183);
            label4.Name = "label4";
            label4.Size = new Size(49, 25);
            label4.TabIndex = 3;
            label4.Text = "Price";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(txtYear);
            groupBox1.Controls.Add(txtModel);
            groupBox1.Controls.Add(txtMake);
            groupBox1.Controls.Add(btnCreate);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Location = new Point(12, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(312, 273);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "create A Car";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(79, 181);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(191, 31);
            txtPrice.TabIndex = 8;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(79, 144);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(193, 31);
            txtYear.TabIndex = 7;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(81, 100);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(191, 31);
            txtModel.TabIndex = 6;
            // 
            // txtMake
            // 
            txtMake.Location = new Point(81, 63);
            txtMake.Name = "txtMake";
            txtMake.Size = new Size(191, 31);
            txtMake.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(79, 224);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(112, 34);
            btnCreate.TabIndex = 4;
            btnCreate.Text = "create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnSortValue);
            groupBox2.Controls.Add(btnSortYear);
            groupBox2.Controls.Add(btnSortAtoZ);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(ListInventory);
            groupBox2.Location = new Point(339, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(255, 412);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Store Inv";
            // 
            // btnSortValue
            // 
            btnSortValue.Location = new Point(170, 37);
            btnSortValue.Name = "btnSortValue";
            btnSortValue.Size = new Size(53, 34);
            btnSortValue.TabIndex = 10;
            btnSortValue.Text = "$";
            btnSortValue.UseVisualStyleBackColor = true;
            // 
            // btnSortYear
            // 
            btnSortYear.Location = new Point(111, 36);
            btnSortYear.Name = "btnSortYear";
            btnSortYear.Size = new Size(53, 34);
            btnSortYear.TabIndex = 9;
            btnSortYear.Text = "Year";
            btnSortYear.UseVisualStyleBackColor = true;
            // 
            // btnSortAtoZ
            // 
            btnSortAtoZ.Location = new Point(52, 37);
            btnSortAtoZ.Name = "btnSortAtoZ";
            btnSortAtoZ.Size = new Size(53, 34);
            btnSortAtoZ.TabIndex = 8;
            btnSortAtoZ.Text = "a-z";
            btnSortAtoZ.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 41);
            label7.Name = "label7";
            label7.Size = new Size(45, 25);
            label7.TabIndex = 7;
            label7.Text = "Sort";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(52, 362);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(159, 35);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // ListInventory
            // 
            ListInventory.FormattingEnabled = true;
            ListInventory.ItemHeight = 25;
            ListInventory.Location = new Point(3, 77);
            ListInventory.Name = "ListInventory";
            ListInventory.Size = new Size(240, 279);
            ListInventory.TabIndex = 5;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(600, 158);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(112, 52);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(btnCheckout);
            groupBox3.Controls.Add(listShoppingCart);
            groupBox3.Location = new Point(727, 47);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(373, 443);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Shopping Cart";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(98, 406);
            label6.Name = "label6";
            label6.Size = new Size(59, 25);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 406);
            label5.Name = "label5";
            label5.Size = new Size(59, 25);
            label5.TabIndex = 7;
            label5.Text = "label5";
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(120, 362);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(112, 41);
            btnCheckout.TabIndex = 6;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // listShoppingCart
            // 
            listShoppingCart.FormattingEnabled = true;
            listShoppingCart.ItemHeight = 25;
            listShoppingCart.Location = new Point(3, 27);
            listShoppingCart.Name = "listShoppingCart";
            listShoppingCart.Size = new Size(343, 329);
            listShoppingCart.TabIndex = 5;
            // 
            // frmCarStore
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 502);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(btnAddToCart);
            Controls.Add(groupBox1);
            Name = "frmCarStore";
            Text = "Car Store";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private Button btnCreate;
        private GroupBox groupBox2;
        private ListBox ListInventory;
        private Button btnAddToCart;
        private GroupBox groupBox3;
        private Label label6;
        private Label label5;
        private Button btnCheckout;
        private ListBox listShoppingCart;
        private TextBox txtPrice;
        private TextBox txtYear;
        private TextBox txtModel;
        private TextBox txtMake;
        private Button btnSortValue;
        private Button btnSortYear;
        private Button btnSortAtoZ;
        private Label label7;
        private Button btnSearch;
    }
}
