using CarClassLibrary;



namespace carStoreGuiApp
{
    public partial class frmCarStore : Form
    {
        //  Create an instance of Store here
        Store Store = new Store();

        BindingSource bindingSourceInventory = new BindingSource();
        BindingSource bindingSourceShoppingList = new BindingSource();
        public frmCarStore()
        {
            InitializeComponent();
            bindingSourceInventory.DataSource = Store.CarList;
            bindingSourceShoppingList.DataSource = Store.ShoppingList;

            ListInventory.DataSource = bindingSourceInventory;
            listShoppingCart.DataSource = bindingSourceShoppingList;

        }

        private void label2_Click(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string Make = txtMake.Text;
            string Model = txtModel.Text;
            int Year = int.Parse(txtYear.Text);
            decimal Price = decimal.Parse(txtPrice.Text);

            //  Correct variable name (lowercase 'car')
            Car car = new Car(Make, Model, Year, Price);

            //  Use the instance (myStore) instead of Store
            Store.CarList.Add(car);

            //  Use the correct variable and instance for the message
            MessageBox.Show(car + " added to inventory, which now has " + Store.CarList.Count + " items.");

            // Clear form fields
            txtMake.Clear();
            txtModel.Clear();
            txtYear.Clear();
            txtPrice.Clear();

            bindingSourceInventory.ResetBindings(false);
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Store.ShoppingList.Add((Car)ListInventory.SelectedItem);
            bindingSourceShoppingList.ResetBindings(false);

        }
    }
}