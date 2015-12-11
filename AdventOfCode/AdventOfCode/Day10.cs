using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day10
    {
        public void Run()
        {
            var input = "3113322113";
            Console.WriteLine("Length of result after 40 iterations:" + Parse(input, 40).Length);
            Console.WriteLine("Length of result after 50 iterations:" + Parse(input, 50).Length);
        }

        private string Parse(string str, int iterations)
        {
            for (int i = 0; i < iterations; i++)
            {
                str = FindLookAndSay(str);
            }
            return str;
        }

        private string FindLookAndSay(string inputString)
        {
            var outputString = "";
            var split = SplitStringBetweenDifferentNumbers(inputString);
            foreach (var str in split)
            {
                var temp = LookAndSay(str);
                outputString += temp;
            }
            return outputString;
        }

        private string LookAndSay(string inputString)
        {
            var length = inputString.Length.ToString();
            var number = inputString[0].ToString();

            var output = String.Format("{0}{1}",length, number);
            return output;
        }



        private string[] SplitStringBetweenDifferentNumbers(string inputString)
        {
            for (int i = 0; i < inputString.Length-1; i++)
            {
                if (inputString[i]!= inputString[i+1])
                {
                    inputString=inputString.Insert(i+1, " ");
                    i++;

                }
            }
            return inputString.Split(' ');
        }
    }
}
