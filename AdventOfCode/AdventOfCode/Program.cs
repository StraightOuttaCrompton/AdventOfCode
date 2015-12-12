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
/*            while (true)
            {
                Console.Write("Enter day number:");
                var dayNumber = Console.ReadLine();
                Console.WriteLine("");
                RunDay(dayNumber);
                Console.WriteLine("");
            }*/


            RunDay("11");
            Console.Read();

        }

        public static void RunDay(string dayNumber)
        {
            switch (dayNumber)
            {
                case "1":
                    Day1 day1 = new Day1();
                    day1.Run();
                    break;

                case "2":
                    Day2 day2 = new Day2();
                    day2.Run();
                    break;

                case "3":
                    Day3 day3 = new Day3();
                    day3.Run();
                    break;

                case "4":
                    Day4 day4 = new Day4();
                    day4.Run();
                    break;

                case "5":
                    Day5 day5 = new Day5();
                    day5.Run();
                    break;

                case "6":
                    Day6 day6 = new Day6();
                    day6.Run();
                    break;

                case "7":
                    Day7 day7 = new Day7();
                    day7.Run();
                    break;

                case "8":
                    Day8 day8 = new Day8();
                    day8.Run();
                    break;

                case "9":
                    Day9 day9 = new Day9();
                    day9.Run();
                    break;

                case "10":
                    Day10 day10 = new Day10();
                    day10.Run();
                    break;

                case "11":
                    Day11 day11 = new Day11();
                    day11.Run();
                    break;

                case "12":
                    Day12 day12 = new Day12();
                    day12.Run();
                    break;

                default:
                    Console.WriteLine("Not a valid input");
                    break;
            }
        }

    }
}
