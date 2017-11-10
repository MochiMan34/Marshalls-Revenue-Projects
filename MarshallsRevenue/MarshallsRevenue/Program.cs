using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarshallsRevenue
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
        public static int numInterior;
        public static int numExterior;
        public static int revenueInterior;
        public static int revenueExterior;
        public static int total;
        public static bool isInteriorGreater;
        string[] interiorCustomers = new string[MAX_MURALS];
        string[] exteriorCustomers = new string[MAX_MURALS];
        char[] muralCodes = { 'L', 'S', 'A', 'C', 'O' };
        string[] muralCodesStrings = {"Landscape", "Seascape",
         "Abstract", "Children's", "Other"};
        char[] interiorCodes = new char[MAX_MURALS];
        char[] exteriorCodes = new char[MAX_MURALS];
        public static int x;
        public static bool isValid;
        public static bool found;
        public static int pos = 0;
        public static int[] interiorCounts = { 0, 0, 0, 0, 0 };
        public static int[] exteriorCounts = { 0, 0, 0, 0, 0 };
        public static char option;
        const char QUIT = 'Z';



        static void main()
        {
            returnMonth(); 
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


    }
}

