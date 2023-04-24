using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace POE_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class Ingredient
    {
        string name;
        double quantity;
        string unit;

        public Ingredient(string name, double quantity, string unit)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
        }

        public string display()
        {
            string result = this.quantity.ToString() + " " + this.unit + " " + this.name;
            return result;
        }
    }
}
