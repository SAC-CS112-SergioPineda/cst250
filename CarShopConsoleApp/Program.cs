using CarClassLibrary;
using System.Diagnostics;
using Windows.Storage;
using FileIO = CarClassLibrary.FileIO;


namespace CarShopConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();

            Console.WriteLine("Welcome to the car Shop! First you must create some cars and put" +
                " them into inventory. Then you may add cars to the cart." +
                " Finally, you may checkout, which will calculate your total" +
                " bill.");

            int action = ChooseAction();
            while (action != 0)
            {
                try
                {
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine("Enter the make of the car: ");
                            string make = Console.ReadLine();

                            Console.WriteLine("Enter the model of the car: ");
                            string model = Console.ReadLine();

                            Console.WriteLine("Enter the year of the car: ");
                            if (!int.TryParse(Console.ReadLine(), out int year))
                            {
                                Console.WriteLine("Invalid year. Please enter a number.");
                                break;
                            }

                            Console.WriteLine("Enter the price of the car: ");
                            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                            {
                                Console.WriteLine("Invalid price. Please enter a number.");
                                break;
                            }

                            Car car = new Car(make, model, year, price);
                            store.CarList.Add(car);
                            Console.WriteLine("Car added to inventory.");
                            break;

                        case 2:
                            PrintStoreInventory();
                            Console.WriteLine("Enter the index of the car to add to cart: ");
                            if (int.TryParse(Console.ReadLine(), out int index) &&
                                index >= 0 && index < store.CarList.Count)
                            {
                                store.ShoppingList.Add(store.CarList[index]);
                                Console.WriteLine("Car added to cart.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index.");
                            }
                            break;

                        case 3:
                            decimal total = store.Checkout();
                            PrintShoppingList();
                            Console.WriteLine("Your total is: $" + total);
                            break;

                        case 4:
                            FileIO fileIO = new FileIO(store);
                            fileIO.SaveInventory();
                            Console.WriteLine("Inventory saved.");
                            break;

                        case 5:
                            FileIO fileIO2 = new FileIO(store);
                            store.CarList = fileIO2.LoadStore();
                            Console.WriteLine("Inventory loaded.");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                action = ChooseAction();
            }

            // Local helper methods with access to store object
            int ChooseAction()
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("(0) Quit (1) Create Car (2) Add Car to Cart (3) Checkout (4) Save Inventory (5) Load Inventory");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Defaulting to 0.");
                    return 0;
                }
                return choice;
            }

            void PrintStoreInventory()
            {
                Console.WriteLine("Inventory:");
                for (int i = 0; i < store.CarList.Count; i++)
                {
                    Console.WriteLine(i + ": " + store.CarList[i]);
                }
            }

            void PrintShoppingList()
            {
                Console.WriteLine("Shopping List:");
                for (int i = 0; i < store.ShoppingList.Count; i++)
                {
                    Console.WriteLine(i + ": " + store.ShoppingList[i]);
                }
            }
        }
    }
}