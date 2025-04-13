using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
   public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public Car(string make, string model, int year, decimal price = 0)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }
        public Car() {

            Make = "Nothing Yet";
            Model = "Nothign Yet";
            Year = 0;
            Price = 0;
        }

        public override string ToString()
        {
            return $"{Year} {Make} {Model} - ${Price}";
        }

    }
}
