using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshallsRevenue2
{
    class Program
    {
        const int INTERIOR_PRICE = 500;
        const int EXTERIOR_PRICE = 750;
        const int DISCOUNT_INTERIOR_PRICE = 450;
        const int DISCOUNT_EXTERIOR_PRICE = 699;
        const int MIN_MURALS = 0;
        const int MAX_MURALS = 30;
        public static string entryString;
        public static int month;
        public static int numOfMurals; 
        public static int revenueInterior;
        public static int revenueExterior;
        public static int total;
        public static bool isInteriorGreater;
        public static string[] interiorCustomers = new string[MAX_MURALS];
        public static string[] exteriorCustomers = new string[MAX_MURALS];
        public static char[] muralCodes = { 'L', 'S', 'A', 'C', 'O' };
        public static string[] muralCodesStrings = {"Landscape", "Seascape",
         "Abstract", "Children's", "Other"};
        public static char[] interiorCodes = new char[MAX_MURALS];
        public static char[] exteriorCodes = new char[MAX_MURALS];
        public static int x;
        public static bool isValid;
        public static bool found;
        public static int pos = 0;
        public static int[] interiorCounts = { 0, 0, 0, 0, 0 };
        public static int[] exteriorCounts = { 0, 0, 0, 0, 0 };
        public static char option;
        const char QUIT = 'Z';

        static void Main(string[] args)
        {

            
            promptMuralCodes(); 

        }

        public static int returnMonth()
        {
            Console.Write("Enter the month >> ");
            entryString = Console.ReadLine();
            month = Convert.ToInt32(entryString);
            while (month < 1 || month > 12)
            {
                Console.Write("Invalid month. Enter the month >> ");
                entryString = Console.ReadLine();
                month = Convert.ToInt32(entryString);

            }

            return month;

        }

        public static int promptMuralSchedule(String typeOfMural)
        {
            Console.Write("Enter number of " + typeOfMural + " murals scheduled >> ");
            entryString = Console.ReadLine();
            numOfMurals = Convert.ToInt32(entryString);
            while (numOfMurals < MIN_MURALS || numOfMurals > MAX_MURALS)
            {
                Console.WriteLine("Number must be between {0} and {1} inclusive", MIN_MURALS, MAX_MURALS);
                Console.Write("Enter number of interior murals scheduled >> ");
                entryString = Console.ReadLine();
                numOfMurals = Convert.ToInt32(entryString);
            }

            return numOfMurals; 
          



        }

        public static int returnTotalRevenue(int NumExterior, int NumInterior)
        {

            
            int month = returnMonth();

            //int numExterior = promptMuralSchedule("Exterior");
            //int numInterior = promptMuralSchedule("Interior"); 



            if (month == 12 || month == 1 || month == 2)
                NumExterior = 0;
            if (month == 4 || month == 5 || month == 9 || month == 1)
                revenueInterior = NumInterior * DISCOUNT_INTERIOR_PRICE;
            else
                revenueInterior = NumInterior * INTERIOR_PRICE;
            if (month == 7 || month == 8)
                revenueExterior = NumExterior * DISCOUNT_EXTERIOR_PRICE;
            else
                revenueExterior = NumExterior * EXTERIOR_PRICE;
            total = revenueInterior + revenueExterior;

            isInteriorGreater = NumInterior > NumExterior;

            Console.WriteLine("{0} interior murals are scheuled at {1} each for a total of {2}",
               NumInterior, INTERIOR_PRICE.ToString("C"), revenueInterior.ToString("C"));
            Console.ReadLine(); 
            Console.WriteLine("{0} exterior murals are scheuled at {1} each for a total of {2}",
               NumExterior, EXTERIOR_PRICE.ToString("C"), revenueExterior.ToString("C"));
            Console.ReadLine(); 
            Console.WriteLine("Total revenue expected is {0}", total.ToString("C"));
            Console.ReadLine(); 
            Console.WriteLine("It is {0} that there are more interior murals scheduled than exterior ones.", isInteriorGreater);
            Console.ReadLine(); 

           

            return total;
            

           
            
        }

        public static void fillArray(int numberOfMurals , String muralType , String[] muralArray , char[] charArray , int[] muralCount)
        {
            
            Console.WriteLine("Entering " + muralType + " jobs:");
            x = 0;
            while (x < numberOfMurals)
            {
                Console.Write("Enter customer name >> ");
                muralArray[x] = Console.ReadLine();
                Console.WriteLine("Mural options are:");
                for (int y = 0; y < muralCodes.Length; ++y)
                    Console.WriteLine("  {0}   {1}", muralCodes[y], muralCodesStrings[y]);
                Console.Write("       Enter mural style code >> ");
                charArray[x] = Convert.ToChar(Console.ReadLine());
                isValid = false;
                while (!isValid)
                {
                    for (int z = 0; z < muralCodes.Length; ++z)
                    {
                        if (charArray[x] == muralCodes[z])
                        {
                            isValid = true;
                            ++muralCount[z];
                        }
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("{0} is not a valid code", muralArray[x]);
                        Console.Write("       Enter mural style code >> ");
                        charArray[x] = Convert.ToChar(Console.ReadLine());
                    }
                }
                ++x;
            }

           

        }

        public static void promptMuralCodes()
        {
            int numExterior = promptMuralSchedule("Exterior");
            int numInterior = promptMuralSchedule("Interior");
            returnTotalRevenue(numExterior, numInterior);


            fillArray(numExterior, "Exterior", exteriorCustomers, exteriorCodes , exteriorCounts);
            fillArray(numInterior, "Interior", interiorCustomers, interiorCodes, interiorCounts); 

            Console.WriteLine("\nThe interior murals scheduled are:");
            for (x = 0; x < interiorCounts.Length; ++x)
            {
                 
                Console.WriteLine("{0, -20}  {1, 5}", muralCodesStrings[x], interiorCounts[x]);
            }
            Console.WriteLine("\nThe exterior murals scheduled are:");
            for (x = 0; x < exteriorCounts.Length; ++x)
            {
                Console.WriteLine("{0, -20}  {1, 5}", muralCodesStrings[x], exteriorCounts[x]);
            }
            Console.Write("\nEnter a mural type or {0} to quit >> ", QUIT);
            option = Convert.ToChar(Console.ReadLine());
            while (option != QUIT)
            {
                isValid = false;
                for (int z = 0; z < muralCodes.Length; ++z)
                {
                    if (option == muralCodes[z])
                    {
                        isValid = true;
                        pos = z;
                    }
                }
                if (!isValid)
                    Console.WriteLine("{0} is not a valid code", option);
                else
                {
                    Console.WriteLine("\nCustomers ordering {0} murals are:", muralCodesStrings[pos]);
                    found = false;
                    for (x = 0; x < numInterior; ++x)
                    {
                        if (interiorCodes[x] == option)
                        {
                            
                            Console.WriteLine("{0} Interior", interiorCustomers[x]);
                            found = true;
                        }
                    }
                    for (x = 0; x < numExterior; ++x)
                    {
                        if (exteriorCodes[x] == option)
                        {
                           
                            Console.WriteLine("{0} Exterior", exteriorCustomers[x]);
                            found = true;
                        }
                    }
                    if (!found)
                       Console.WriteLine("No customers ordered {0} murals", muralCodesStrings[pos]);
                }
                Console.Write("\nEnter a mural type or {0} to quit >> ", QUIT);

                option = Convert.ToChar(Console.ReadLine());
            }

        }


    }

    }





