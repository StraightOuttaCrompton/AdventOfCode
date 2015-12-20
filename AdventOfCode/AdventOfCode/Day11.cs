using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AdventOfCode
{
    class Day11
    {
        public void Run()
        {
            Dictionary <int, string> blah = new Dictionary<int, string>();

            var input = "hepxcrrq";

            Console.WriteLine("Hello");
            Console.WriteLine(Part1(input));
            Console.Read();
        }

        private string Part1(string input)
        {
            while (!IsOk(input))
            {
                input = NextString(input);
            }
            return input;
        }

        private bool IsOk(string input)
        {
            if (input.Contains('i') || input.Contains('o') || input.Contains('l'))
            {
                return false;
            }
            if (!ContainsSameConsecutiveLetters(input) || !ContainsConsecutiveLetters(input))
            {
                return false;
            }
            return true;
        }

        private bool ContainsSameConsecutiveLetters(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i]==input[i+1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainsConsecutiveLetters(string input)
        {
            for (int i = 0; i < input.Length-2; i++)
            {
                if (input[i+1]==NextChar(input[i]) && input[i+2]==NextChar(input[i+1]))
                {
                    return true;
                }
            }
            return false;
        }



        private string NextString(string input)
        {
            var output = "";
            var length = input.Length;
            var i = length-1;

            StringBuilder str = new StringBuilder(input);


            if (input[i] == 'z')
            {
                str = new StringBuilder(NextString(input.Remove(i,1))+'a');
            }
            else
            {
                str[i]=NextChar(input[i]);
            }
            return str.ToString();
        }

        private char NextChar(char chr)
        {
            var output = 'a';

            switch (chr)
            {
                case 'a':
                    output = 'b';
                    break;
                case 'b':
                    output = 'c';
                    break;
                case 'c':
                    output = 'd';
                    break;
                case 'd':
                    output = 'e';
                    break;
                case 'e':
                    output = 'f';
                    break;
                case 'f':
                    output = 'g';
                    break;
                case 'g':
                    output = 'h';
                    break;
                case 'h':
                    output = 'i';
                    break;
                case 'i':
                    output = 'j';
                    break;
                case 'j':
                    output = 'k';
                    break;
                case 'k':
                    output = 'l';
                    break;
                case 'l':
                    output = 'm';
                    break;
                case 'm':
                    output = 'n';
                    break;
                case 'n':
                    output = 'o';
                    break;
                case 'o':
                    output = 'p';
                    break;
                case 'p':
                    output = 'q';
                    break;
                case 'q':
                    output = 'r';
                    break;
                case 'r':
                    output = 's';
                    break;
                case 's':
                    output = 't';
                    break;
                case 't':
                    output = 'u';
                    break;
                case 'u':
                    output = 'v';
                    break;
                case 'v':
                    output = 'w';
                    break;
                case 'w':
                    output = 'x';
                    break;
                case 'x':
                    output = 'y';
                    break;
                case 'y':
                    output = 'z';
                    break;
                case 'z':
                    output = 'a';
                    break;
            }
            return output;
        }
    }
}
