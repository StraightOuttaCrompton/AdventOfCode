using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day6
    {
        public void Run()
        {
            
            var inputFile = System.IO.File.ReadAllLines(@"C:\Users\jcrompto\Documents\GitHubRepos\AdventOfCode\AdventOfCode\AdventOfCode\Day6Input.txt");
            var listOfInstructions = CalculateListofInstructions(inputFile);
            //Part1(listOfInstructions);

            var lightGrid = ConstructGrid(1000, 1000);

            lightGrid = TurnOn(lightGrid, new[] { 1, 1 }, new[] { 1, 2 });
            Console.WriteLine(lightGrid[0][0]);
            Console.WriteLine(lightGrid[0][1]);

            //Console.WriteLine(blah[1]);
            Console.Read();


        }

        private int Part1(List<string[]> inputList)
        {
            var lightGrid = ConstructGrid(1000, 1000);
            foreach (var input in inputList)
            {
                switch (input[0])
                {
                    case "toggle":
                        Console.WriteLine("togged");
                        Console.WriteLine(input[3]);
                        break;
                    case "turn-on":
                        lightGrid = TurnOn(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    case "turn-off":
                        lightGrid = TurnOn(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    default:
                        Console.WriteLine("Error, invalid input");
                        break;
                }
            }
            

            return 5;
        }

        private int[] ConvertToArray(string str)
        {
            int[] outputArray = new int[2];
            string[] args = str.Split(',');

            outputArray[0] = Int32.Parse(args[0]);
            outputArray[1] = Int32.Parse(args[1]);

            return outputArray;
        }

        private List<bool[]> Toggle(List<bool[]> lightGrid, int[] from, int[] to)
        {
            for (int x = from[0] - 1; x < to[0]; x++)
            {
                for (int y = from[1] - 1; y < to[1]; y++)
                {
                    if (lightGrid[x][y])
                    {
                        lightGrid[x][y] = false;
                    }
                    else if (!lightGrid[x][y])
                    {
                        lightGrid[x][y] = true;
                    }
                }
            }
            return lightGrid;
        }

        private List<bool[]> TurnOn(List<bool[]> lightGrid, int[] from, int[] to)
        {
            for (int x = from[0]-1; x < to[0]; x++)
            {
                for (int y = from[1]-1; y < to[1]; y++)
                {
                    lightGrid[x][y] = true;
                }
            }
            return lightGrid;
        }

        private List<bool[]> TurnOff(List<bool[]> lightGrid, int[] from, int[] to)
        {
            for (int x = from[0] - 1; x < to[0]; x++)
            {
                for (int y = from[1] - 1; y < to[1]; y++)
                {
                    lightGrid[x][y] = false;
                }
            }
            return lightGrid;
        }


        private List<bool[]> ConstructGrid(int x, int y)
        {
            var outputList = new List<bool[]>();
            for (int i = 0; i < x; i++)
            {
                bool[] temp = new bool[y];
                outputList.Add(temp);
            }
            return outputList;
        } 






        private List<string[]> CalculateListofInstructions(string[] inputFile)
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
