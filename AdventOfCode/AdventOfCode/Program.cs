using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            /*while (true)
            {
                Console.WriteLine("Enter day number");
                var dayNumber = Console.Read();
                RunDay(dayNumber);
                Console.Read();

            }*/
            RunDay('6');
            Console.Read();
            
        }

        public static void RunDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case '1':
                    Day1 day1 = new Day1();
                    day1.Run();
                    break;

                case '2':
                    Day2 day2 = new Day2();
                    day2.Run();
                    break;

                case '3':
                    Day3 day3 = new Day3();
                    day3.Run();
                    break;

                case '4':
                    Day4 day4 = new Day4();
                    day4.Run();
                    break;

                case '5':
                    Day5 day5 = new Day5();
                    day5.Run();
                    break;

                case '6':
                    Day6 day6 = new Day6();
                    day6.Run();
                    break;

                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }
        }

    }
}
