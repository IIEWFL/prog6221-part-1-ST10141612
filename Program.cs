using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
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
        public static double[] originalQuantities; // Array to hold the original quantities of the ingredients

        //Declarations of the fields of the ingredient class, as well as access modifier methods
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

        public Ingredient(string name, double quantity, string unit) //Ingredient object constructor
        {
            this.name = name;
            this.quantity = quantity;  
            this.unit = unit;
        }

        public string display() //Displays the details of the ingredient in string form
        {
            string result = this.quantity.ToString() + " " + this.unit + " " + this.name;
            return result;
        }
    }

    public class Step
    {
        //Declarations of the fields of the Step class, as well as access modifier methods
        string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Step(string description) //Step object constructor
        {
            this.description = description;
        }

        public string display() //Displays the details of the step object in string form
        {
            return this.description;
        }

    }

    public class Recipe
    {
        // A recipe contains an array of ingredients an array of steps
        public static Ingredient[] ingredients;
        public static Step[] steps;

        public static void createRecipe(int num_ing, int num_steps) // Method that creates a recipe object by first creating ingredient and step objects
        {
            ingredients = new Ingredient[num_ing];
            steps = new Step[num_steps];
            Ingredient.originalQuantities = new double[num_ing]; // Initializing Arrays after getting the number of ingredients and steps

            void addIngredients() // Creates an ingredient object and adds it to the list of ingredients
            {
                Console.WriteLine("--------------------------------------------");
                for (int i = 0; i < num_ing; i++)
                {
                    Console.WriteLine("Ingredient Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Quantity: ");
                    double quantity = Convert.ToDouble(Console.ReadLine());
                    Ingredient.originalQuantities[i] = quantity;
                    Console.WriteLine("Unit of Measure: ");
                    string unit = Console.ReadLine();
                    Console.WriteLine();
                    Ingredient ing = new Ingredient(name, quantity, unit);
                    ingredients[i] = ing;
                    

                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

            }

            void addSteps() // Creates a step object and adds it to the list of steps
            {
                Console.WriteLine("--------------------------------------------");
                for (int i = 0; i < num_steps; i++)
                {
                    Console.WriteLine("Enter step {0}/{1}", (i + 1), num_steps);
                    Step s = new Step(Console.ReadLine());
                    steps[i] = s;
                }
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Details Captured!");
                Console.ReadLine();
            }

            addIngredients();
            addSteps();
            Recipe R1 = new Recipe(ingredients, steps); // Creates a recipe using the information collected
            Controller.menu(); // Opens menu
        }

        public static void displayDetails() // Displays all the details of the recipe
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

        public Recipe(Ingredient[] ing, Step[] st) // Recipe object constructor
        {
            ingredients = ing;
            steps = st;
        }

        public static void changeScaleFactor() // Method scale the  recipe quantities by a factor
        {
            Console.WriteLine("Select the scale factor (x0.5,x2,x3...etc)");
            double factor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Converting string input to double
            foreach (Ingredient i in ingredients)
            {
                i.Quantity *=  factor; // Changing the quantity value by a factor
            }
            Console.WriteLine("Scale factor changed!");
            Console.ReadKey();
            Controller.menu();
        }

        public static void resetScaleFactor()
        {
            // This method sets the quantity values to the values stored in the "originalQuantities" array
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

