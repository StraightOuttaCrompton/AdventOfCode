using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day17
    {

        public void Run()
        {
            var inputFile = System.IO.File.ReadAllLines(@"C:\Users\jcrompto\Documents\GitHubRepos\AdventOfCode\AdventOfCode\AdventOfCode\Day17Input.txt");

            var list = inputFile.OrderBy(q => Convert.ToInt32(q)).ToList();
            Console.WriteLine(GetAllCombinations(list));
            Console.WriteLine("complete");
            //Console.WriteLine(Int32.Parse(list[0]) + Int32.Parse(list[1])+ Int32.Parse(list[2])+ Int32.Parse(list[3])+ Int32.Parse(list[4])+ Int32.Parse(list[5])+ Int32.Parse(list[6])+ Int32.Parse(list[7])+ Int32.Parse(list[8])+ Int32.Parse(list[9])+ Int32.Parse(list[10]));
            Console.Read();
        }

        public int MaxNumberOfContainers(List<string> input)
        {
            var count = 0;
            var i = 0;
            while (count<150)
            {
                count = count + Int32.Parse(input[i]);
                i++;
            }
            return i;
        }


        private static List<List<string>> GetAllCombinations(List<string> items)
        {
            if (items.Count > 1)
            {
                return items.SelectMany(item => GetAllCombinations(items.Where(i => !i.Equals(item)).ToList()),
                                       (item, permutation) => new[] { item }.Concat(permutation).ToList()).ToList();
            }
            return new List<List<string>> { items };
        }


    }
}

