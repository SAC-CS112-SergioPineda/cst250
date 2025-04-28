using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAssignment6
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return "Id = " + Id + ", Name = " + Name + ", Value = " + Value;
        }
    }
}
