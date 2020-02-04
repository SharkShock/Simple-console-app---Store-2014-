using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleAppStore
{


    public class Program
    {

        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 30);
            Console.BufferHeight = 500;
            Console.BufferWidth = 100;
            
            List<Product> allproducts = new List<Product>();
            allproducts.Add(new Product("og kush", 9.25m, 941));
            allproducts.Add(new Product("dream queen", 9.20m, 884));
            allproducts.Add(new Product("mr. nice", 8.00m, 10205));
            allproducts.Add(new Product("shark shock", 10.90m, 94));
            allproducts.Add(new Product("lemon haze", 12.50m, 1024));
            allproducts.Add(new Product("silver lemon haze", 12.55m, 101));
            allproducts.Add(new Product("purple alien", 12.55m, 192));
            allproducts.Add(new Product("grape", 12.85m, 210));
            allproducts.Add(new Product("Jack Herer", 13.05m, 210));
            allproducts.Add(new Product("Grandaddy Purple", 13.10m, 210));


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('_', 70));
            Console.ForegroundColor = ConsoleColor.Yellow;
            string s = "WeLcOme|YOLO NiGGa";
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('_', 70));
            Console.ResetColor();


            //_____________________________________________________________

            foreach (var Product in allproducts)
            {
                string c = Product.Name.ToUpper();
                Console.SetCursorPosition((Console.WindowWidth - c.Length) / 2, Console.CursorTop);
                Console.WriteLine(c);
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("     Type the product name from the list above to see more details");
            bool isOk = false;
            while (!isOk)
            {
                var input = Console.ReadLine().ToLower();
                //Ovde instanciras da promenljiva isOk bude sta vrati 
                isOk = CheckIfInputExist(allproducts, input);
                if (!isOk)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please try again");
                    Console.ResetColor();

                }
            }

            Thread.Sleep(700);
            Console.WriteLine("");
            Console.WriteLine("Would you like to make a purchase? ");

            bool YesOrNo = false;
            while (!YesOrNo)
            {
                var inputA = Console.ReadLine().ToLower();
                YesOrNo = YesOrElse(inputA);
                if (!YesOrNo)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please try again");
                    Console.WriteLine("[YES/NO]");
                    Thread.Sleep(300);
                    Console.ResetColor();
                }

            }

            Thread.Sleep(700);
            Console.WriteLine("Type amount of the product you'd like to purchase: ");

            bool Amont = false;
            bool NumB = false;
            string inputB = "";

            while ((!NumB) || (!Amont))
            {
                inputB = Console.ReadLine(); //izvuceno iz while(!amont) zato sto mi treba u racunu dole
                NumB = NumOrNot(inputB);
                if (!NumB)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR");
                    Console.WriteLine("Your input should be number!");
                    Console.ResetColor();

                }
                else
                {
                    if (!Amont)
                    {
                        Amont = AmontB(Convert.ToInt32(inputB), inputGlobal.InStock);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" The is no enough product in stock");
                        Console.WriteLine("Please try again");
                        Console.ResetColor();
                        Thread.Sleep(1300);
                    }
                }
            }

            Thread.Sleep(700);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Are you ready for your total?");

            bool total = false;
            while (!total)
            {
                var inputT = Console.ReadLine();
                total = TotalCost(inputT);
                if (!total)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please try again");
                    Console.WriteLine("[YES/NO]");
                    Thread.Sleep(300);
                    Console.ResetColor();
                }

            }


            //_____________________________________________________________ total/ receipt

            Console.WriteLine("");
            Thread.Sleep(300);
            Console.WriteLine("You ordered product: " + inputGlobal.Name.ToUpper());
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(300);
            Console.WriteLine("You ordered: " + inputB + " products");
            Console.WriteLine("You ordered: " + Convert.ToInt32(inputB) * 3 + " products packages");
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(300);
            Console.WriteLine("Price for each product is: " + inputGlobal.Price);
            Console.WriteLine("");
            Console.WriteLine("");
            Thread.Sleep(700);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Total price will be: " + Convert.ToInt32(inputB) * inputGlobal.Price);
            Console.ResetColor();

            //_____________________________________________________________ end after total


            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            string p = "Thanks for chosing our services, have a wonderful day!";
            Console.SetCursorPosition((Console.WindowWidth - p.Length) / 2, Console.CursorTop);
            Console.WriteLine(p);
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" Exiting....please wait...");
            SlowIt(200, "||||||||||||||||||||||||||||||||");

        }




        //_____________________________________________________________


        public static Product inputGlobal { get; set; }



        //_____________________________________________________________


        private static bool CheckIfInputExist(List<Product> allproducts, string input)
        {
            bool isOk = false;
            foreach (var Product in allproducts)
            {
                if (input == Product.Name)
                {
                    inputGlobal = new Product(Product.Name, Product.Price, Product.InStock);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("");
                    string z = ("Seleceted product details: ");
                    Console.SetCursorPosition((Console.WindowWidth - z.Length) / 2, Console.CursorTop);
                    Console.WriteLine(z);
                    Console.WriteLine("");
                    Console.WriteLine("Product name: " + Product.Name.ToUpper() + "   Product Price: " + Product.Price +
                                      "      In Stock: " + Product.InStock);
                    Console.ResetColor();
                    isOk = true;
                    break;
                }

                else //(input != Product.Name)
                {
                    isOk = false;
                }
            }

            //Ovo return je sta ce da ti vrati metoda
            return isOk;
        }

        private static bool YesOrElse(string inputA)
        {
            bool YesOrNo = false;
            if (inputA == "yes")
            {
                Console.WriteLine("");
                Console.WriteLine("Awesome!");

                YesOrNo = true;
            }

            else if (inputA == "no")
            {
                Console.WriteLine("");
                Console.WriteLine("All right. Maybe next time.");
                Console.WriteLine("bye, bye..");
                Thread.Sleep(3000);
                Environment.Exit(0);

                YesOrNo = true;
            }

            else
            {
                YesOrNo = false;
            }
            return YesOrNo;

        }

        private static bool NumOrNot(string inputB)
        {
            bool NumB = false;
            int num;
            if (int.TryParse(inputB, out num))
            {
                NumB = true;
            }
            else
            {
                NumB = false;
            }
            return NumB;
            //_____________________________________________________________
        }

        private static bool AmontB(int inputB, int InStock)
        {
            bool Amont = false;
            if (inputB <= InStock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(700);
                Console.WriteLine(" You selected " + inputB + " product of " + inputGlobal.Name.ToUpper());
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.WriteLine(" While 1 product contain 3 packages");
                Console.WriteLine("");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" You actually ordered " + 3 * inputB + " packages of product");
                Console.ResetColor();

                Amont = true;
            }
            else
            {
                Amont = false;
            }
            return Amont;
        }

        private static bool TotalCost(string inputT)
        {
            bool total = false;
            if (inputT == "yes")
            {

                Thread.Sleep(250);
                Console.WriteLine("");
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("");
                Thread.Sleep(250);
                Console.ForegroundColor = ConsoleColor.Green;
                string x = "Here is your receipt:";
                Console.SetCursorPosition((Console.WindowWidth - x.Length) / 2, Console.CursorTop);
                Console.WriteLine(x);
                Console.ResetColor();

                total = true;
            }

            else if (inputT == "no")
            {
                Console.WriteLine("");
                Thread.Sleep(500);
                Console.WriteLine(" Your order has been denied due the receipt cancellation");
                Thread.Sleep(300);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" System will automaticly shut down");
                Console.ResetColor();
                Console.WriteLine("");
                Thread.Sleep(300);
                Console.WriteLine(" Please wait");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                SlowIt(400, "|||||||");
                Environment.Exit(0);

                total = true;
            }

            else
            {
                total = false;
            }
            return total;
        }

        static void SlowIt(int milsec_delay, string str)
        {
            foreach (char q in str)
            {
                Console.Write(q);
                Thread.Sleep(milsec_delay);
            }

        }

    }
}

