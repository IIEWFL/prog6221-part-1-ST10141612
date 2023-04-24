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
        public static List<double> originalQuantities = new List<double>();
       
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        double quantity;
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        string unit;
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

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

    public class Step
    {
        string description;
        public Step(string description)
        {
            this.description = description;
        }

        public string display()
        {
            return this.description;
        }

    }

}
