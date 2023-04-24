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
            Controller.menu();
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
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Step(string description)
        {
            this.description = description;
        }

        public string display()
        {
            return this.description;
        }

    }

    public class Recipe
    {
        public static List<Ingredient> ingredients = new List<Ingredient>();
        public static List<Step> steps = new List<Step>();

        public static void createRecipe(int num_ing, int num_steps)
        {
            void addIngredients()
            {
                Console.WriteLine("--------------------------------------------");
                for (int i = 0; i < num_ing; i++)
                {
                    Console.WriteLine("Ingredient Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Ingredient.originalQuantities.Add(quantity);
                    Console.WriteLine("Unit of Measure: ");
                    string unit = Console.ReadLine();
                    Console.WriteLine();
                    Ingredient ing = new Ingredient(name, quantity, unit);
                    ingredients.Add(ing);

                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

            }

            void addSteps()
            {
                Console.WriteLine("--------------------------------------------");
                for (int i = 0; i < num_steps; i++)
                {
                    Console.WriteLine("Enter step {0}/{1}", (i + 1), num_steps);
                    Step s = new Step(Console.ReadLine());
                    steps.Add(s);
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Details Captured!");
                Console.ReadLine();
            }

            addIngredients();
            addSteps();
            Recipe R1 = new Recipe(ingredients, steps);
            Controller.menu();
        }

        public static void displayDetails()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Ingredients:");
            foreach (Ingredient i in Recipe.ingredients)
            {
                Console.WriteLine(i.display());
            }
            Console.WriteLine();

            Console.WriteLine("Steps:");
            foreach (Step s in Recipe.steps)
            {
                Console.WriteLine(s.display());
            }
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
            Controller.menu();

        }

        public Recipe(List<Ingredient> ing, List<Step> st)
        {
            ingredients = ing;
            steps = st;
        }

        public static void changeScaleFactor()
        {
            Console.WriteLine("Select the scale factor (x0.5,x2,x3...etc)");
            double scale = Convert.ToDouble(Console.ReadLine());
            foreach (Ingredient i in ingredients)
            {
                i.Quantity = i.Quantity * scale;
            }
            Console.WriteLine("Scale factor changed!");
            Console.ReadKey();
            Controller.menu();
        }

        public static void resetScaleFactor()
        {
            int index = 0;
            foreach (Ingredient i in ingredients)
            {
                i.Quantity = Ingredient.originalQuantities[index];
                index++;
            }
            Console.WriteLine("Scale Reset!");
            Console.ReadLine();
            Controller.menu();

        }

    }

    public class Controller
    {

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Recipe Wizard");
            Console.WriteLine();
            Console.WriteLine("1.Add a new recipe\n2.Display Recipe Details\n3.Change Scale Factor\n4.Reset Scale Factor\n5. Exit");
            Console.WriteLine();

            int prompt = Convert.ToInt32(Console.ReadLine());

            switch (prompt)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("How many ingredients in the recipe?");
                    int num_ing = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("How many steps in the recipe?");
                    int num_steps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Recipe.createRecipe(num_ing, num_steps);
                    break;

                case 2:
                    Recipe.displayDetails();
                    break;

                case 3:
                    Recipe.changeScaleFactor();
                    break;

                case 4:
                    Recipe.resetScaleFactor();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

            }

        }


    }


}

