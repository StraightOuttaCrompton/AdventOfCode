using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day9
    {
        static List<List<int>> comb;
        static bool[] used;

        public void Run()
        {
            var inputFile = System.IO.File.ReadAllLines(@"C:\Users\jcrompto\Documents\GitHubRepos\AdventOfCode\AdventOfCode\AdventOfCode\Day9Input.txt");
            var listOfDistances = CalculateListofDirections(inputFile);
            var distancesDictionary = ConvertToDictionary(listOfDistances);

            List<string> townList = new List<string>(){"Faerun","Norrath","Tristram","AlphaCentauri","Arbre","Snowdin","Tambi","Straylight"};
            var combinationList = GetAllCombinations(townList);
            
            var allRouteDistances = FindAllRouteDistances(combinationList, distancesDictionary);
            Console.WriteLine("Shortest Distance:" + allRouteDistances.Min());
            Console.WriteLine("Longest Distance:"+allRouteDistances.Max());
        }

        private List<int> FindAllRouteDistances(List<List<string>> combinationList, Dictionary<Tuple<string, string>, int> locationDistances)
        {
            List<int> output = new List<int>{};
            foreach (var route in combinationList)
            {
                var routeCount = 0;
                for (int i = 0; i < route.Count-1; i++)
                {
                    Tuple<string, string> tempTuple1 = new Tuple<string, string>(route[i], route[i+1]);
                    Tuple<string, string> tempTuple2 = new Tuple<string, string>(route[i+1], route[i]);

                    if (locationDistances.ContainsKey(tempTuple1))
                    {
                        routeCount = routeCount + locationDistances[tempTuple1];
                    }
                    else if (locationDistances.ContainsKey(tempTuple2))
                    {
                        routeCount = routeCount + locationDistances[tempTuple2];
                    }
                    else
                    {
                        Console.WriteLine("Error in shortest route");
                        Console.Read();
                    }
                }
                output.Add(routeCount);
            }

            return output; 
        }

        private Dictionary<Tuple<string, string>, int> ConvertToDictionary(List<string[]> inputFile)
        {
            Dictionary<Tuple<string, string>, int> output = new Dictionary<Tuple<string, string>, int>();
            foreach (var input in inputFile)
            {
                Tuple<string, string> tempTuple = new Tuple<string, string>(input[0],input[2]);
                output.Add(tempTuple,Int32.Parse(input[4]));
            }
            return output;
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

        private List<string[]> CalculateListofDirections(string[] inputFile)
        {
            List<string[]> outputList = new List<string[]>();

            foreach (string line in inputFile)
            {
                string[] args = line.Split(' ');
                outputList.Add(args);
            }
            return outputList;
        }

    }
}
