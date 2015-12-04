using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day4
    {
        public void Run()
        {
            var day4Input = "ckczppom";
            
            Console.WriteLine("Part1");
            Console.WriteLine(Part1(day4Input));
            Console.WriteLine("Part2");
            Console.WriteLine(Part2(day4Input));

            Console.Read();
        }

        private string Part1(string input)
        {
            var numberString = "1";
            var blah = false;

            while (!blah)
            {
                var md5Hash = CreateMD5Hash(input + numberString);
                blah = DoesStringStartWithFiveZeros(md5Hash);
                numberString = NextNumber(numberString);
            }

            numberString = (Int32.Parse(numberString)-1).ToString();
            return numberString;
        }

        private string Part2(string input)
        {
            var numberString = "1";
            var blah = false;

            while (!blah)
            {
                var md5Hash = CreateMD5Hash(input + numberString);
                blah = DoesStringStartWithSixZeros(md5Hash);
                numberString = NextNumber(numberString);
            }

            numberString = (Int32.Parse(numberString) - 1).ToString();
            return numberString;
        }


        private string NextNumber(string strNumber)
        {
            var intNumber = Int32.Parse(strNumber);
            intNumber++;
            return intNumber.ToString();
        }

        private bool DoesStringStartWithFiveZeros(string input)
        {
            if (input.Substring(0,5)=="00000")
            {
                return true;
            }
            return false;
        }

        private bool DoesStringStartWithSixZeros(string input)
        {
            if (input.Substring(0, 6) == "000000")
            {
                return true;
            }
            return false;
        }


        private string CreateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
