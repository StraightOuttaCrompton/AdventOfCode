using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day11
    {
        const int ColumnBase = 26;
        const int DigitMax = 7; // ceil(log26(Int32.Max))
        const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public void Run()
        {
            Dictionary <int, string> blah = new Dictionary<int, string>();

            var number = 66000195109;

            Console.WriteLine("Hello");
            Console.WriteLine(ToString(24*28*26));
            Console.Read();
        }





/*        private string NextString()
        {
            
        }*/


        public static string ToString(int index)
        {
            if (index <= 0)
                throw new IndexOutOfRangeException("index must be a positive number");

            if (index <= ColumnBase)
                return Digits[index - 1].ToString();

            var sb = new StringBuilder().Append(' ', DigitMax);
            var current = index;
            var offset = DigitMax;
            while (current > 0)
            {
                sb[--offset] = Digits[--current % ColumnBase];
                current /= ColumnBase;
            }
            return sb.ToString(offset, DigitMax - offset);
        }
    }
}
