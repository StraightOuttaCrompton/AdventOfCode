using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day12
    {
        public void Run()
        {
            var inputFile = System.IO.File.ReadAllLines(@"C:\Users\HP\Documents\GitHub\AdventOfCode\AdventOfCode\AdventOfCode\Day12Input.txt");

            Console.WriteLine(SearchAndCountInts(inputFile));
            Console.Read();

        }

        private int SearchAndCountInts(string[] input)
        {
            var count = 0;
            for (int i = 0; i < input[0].Length; i++)
            {
                //account for negatives
                if (Char.IsNumber(input[0][i]))
                {
                    var j = 0;
                    while (Char.IsNumber(input[0][i + j]))
                    {
                        
                        j++;

                    }
                    var b = input[0].Substring(i,j);


                    count = count + Int32.Parse(b);
                }
            }
            return count;
        }
    }
}
