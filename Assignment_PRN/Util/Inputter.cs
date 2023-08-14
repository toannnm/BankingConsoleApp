using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Assignment.Util
{
    class Inputter
    {
        public static int validateNumInt(string msg)
        {
            int inputted = -1;
            do
            {
                Write(msg);
                int.TryParse(ReadLine(), out inputted);
                if (inputted <= 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Invalid input!\nInput value must be a number greater than 0. Please try again!\n");
                    ResetColor();
                }
            } while (inputted <= 0);
            return inputted;
        }


        public static double validateNumDouble(string msg)
        {
            double inputted = -1;
            do
            {
                Write(msg);
                double.TryParse(ReadLine(), out inputted);
                if (inputted <= 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Invalid input!\nInput value must be a double greater than 0. Please try again!\n");
                    ResetColor();
                }
            } while (inputted <= 0);
            return inputted;
        }

        public static string validateString(string msg)
        {
            string inputted = "";
            do
            {
                Write(msg);
                inputted = ReadLine().Trim();
                if (inputted.Equals(""))
                {
                    WriteLine("Input value must be non-blank string. Please try again!\n");
                }
            } while (inputted.Equals(""));
            return inputted;
        }
        public static void redColor(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void greenColor(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        public static void yellowColor(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(msg);
            Console.ResetColor();
        }
        
    }
}
