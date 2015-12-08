using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day5
    {
        public void Run()
        {
            string[] inputFile = System.IO.File.ReadAllLines(@"C:\Users\jcrompto\Documents\GitHubRepos\AdventOfCode\AdventOfCode\AdventOfCode\Day5Input.txt");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write(NumberOfNiceStringsPart2(inputFile));
            Console.Read();
            
        }

        //Part 1

        private int NumberOfNiceStringsPart1(string[] inputStringArray)
        {
            var count = 0;
            foreach (var str in inputStringArray)
            {
                if (IsStringNicePart1(str))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsStringNicePart1(string str)
        {
            if (ContainsDisallowedSubstring(str))
            {
                return false;
            }
            if (NumberOfVowels(str) > 2 && ContainsConsecutiveLetters(str))
            {
                return true;
            }
            return false;
        }

        private bool ContainsDisallowedSubstring(string str)
        {
            if (str.Contains("ab"))
            {
                return true;
            }
            if (str.Contains("cd"))
            {
                return true;
            }
            if (str.Contains("pq"))
            {
                return true;
            }
            if (str.Contains("xy"))
            {
                return true;
            }

            return false;
        }

        private bool ContainsConsecutiveLetters(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private int NumberOfVowels(string str)
        {
            var vowelCount = 0;
            foreach (var letter in str.ToLower())
            {
                switch (letter)
                {
                    case 'a':
                        vowelCount++;
                        break;
                    case 'e':
                        vowelCount++;
                        break;
                    case 'i':
                        vowelCount++;
                        break;
                    case 'o':
                        vowelCount++;
                        break;
                    case 'u':
                        vowelCount++;
                        break;
                }
            }
            return vowelCount;
        }



        //Part 2

        private int NumberOfNiceStringsPart2(string[] inputStringArray)
        {
            var count = 0;
            foreach (var str in inputStringArray)
            {
                if (IsStringNicePart2(str))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsStringNicePart2(string str)
        {
            if (ContainsPairOfTwoLetters(str) && ContainsRepeatingLetterWithOneLetterBetween(str))
            {
                return true;
            }
            return false;
        }

        private bool ContainsPairOfTwoLetters(string str)
        {
            for (var i = 0; i < str.Length - 1; i++)
            {
                var tempPair = string.Format("{0}{1}", str[i], str[i + 1]);

                var tempString = str.Remove(i, 2);
                tempString=tempString.Insert(i, "-");

                if (tempString.Contains(tempPair))
                {
                    return true;
                }

            }
            return false;
        }

        private bool ContainsRepeatingLetterWithOneLetterBetween(string str)
        {
            for (var i = 0; i < str.Length - 2; i++)
            {
                if (str[i] == str[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

    }
}
