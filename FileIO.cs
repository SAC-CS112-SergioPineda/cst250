using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class FileIO
    {
        Store store;

        public FileIO(Store store)
        { this.store = store; }

        public void SaveInventory()
        {
            string filename = "store.txt";

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Car car in store.CarList)
                {
                    writer.WriteLine($"{car.Make},{car.Model},{car.Year},{car.Price})");

                }
            }
        }

        public List<Car> LoadStore()
        {
            List<Car> cars = new List<Car>();
            string filename = "store.txt";
            using (StreamReader reader = new StreamReader(filename)) {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string make = parts[0];
                    string model = parts[1];
                    try
                    {
                        int year = int.Parse(parts[2]);
                        decimal price = decimal.Parse(parts[3]);
                        Car car = new Car(make, model, year, price);
                        cars.Add(car);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error parsing data for cars: " + line);
                    }

                }
            }
            return cars;
        }
    }
}
    
