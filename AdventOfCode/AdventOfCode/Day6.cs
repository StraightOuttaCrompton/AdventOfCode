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
            
            var inputFile = System.IO.File.ReadAllLines(@"C:\Users\HP\Documents\GitHub\AdventOfCode\AdventOfCode\AdventOfCode\Day6Input.txt");
            var listOfInstructions = CalculateListofInstructions(inputFile);

            Console.WriteLine("Number of lights on");
            Console.WriteLine(Part1(listOfInstructions));

            Console.WriteLine(Part2(listOfInstructions));

            Console.Read();
        }

        //Part 1

        private int Part1(List<string[]> inputList)
        {
            var lightGrid = ConstructGrid(1000, 1000);
            foreach (var input in inputList)
            {
                switch (input[0])
                {
                    case "toggle":
                        lightGrid = Toggle(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    case "turn-on":
                        lightGrid = TurnOn(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    case "turn-off":
                        lightGrid = TurnOff(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    default:
                        Console.WriteLine("Error, invalid input");
                        break;
                }
            }
            return CountTrues(lightGrid);
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
            for (int x = from[0] - 1; x < to[0]; x++)
            {
                for (int y = from[1] - 1; y < to[1]; y++)
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

        private int CountTrues(List<bool[]> lightGrid)
        {
            var count = 0;
            for (int x = 0; x < lightGrid.Count; x++)
            {
                for (int y = 0; y < lightGrid[0].Length; y++)
                {
                    if (lightGrid[x][y])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        //Part2

        private int Part2(List<string[]> inputList)
        {
            var lightGrid = ConstructGridPart2(1000, 1000);
            foreach (var input in inputList)
            {
                switch (input[0])
                {
                    case "toggle":
                        lightGrid = TogglePart2(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    case "turn-on":
                        lightGrid = TurnOnPart2(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    case "turn-off":
                        lightGrid = TurnOffPart2(lightGrid, ConvertToArray(input[1]), ConvertToArray(input[3]));
                        break;
                    default:
                        Console.WriteLine("Error, invalid input");
                        break;
                }
            }
            return TotalBrightness(lightGrid);
        }

        private List<int[]> TogglePart2(List<int[]> lightGrid, int[] from, int[] to)
                {
                    for (int x = from[0] - 1; x < to[0]; x++)
                    {
                        for (int y = from[1] - 1; y < to[1]; y++)
                        {
                            lightGrid[x][y]= lightGrid[x][y]+2;
                        }
                    }
                    return lightGrid;
                }

        private List<int[]> TurnOnPart2(List<int[]> lightGrid, int[] from, int[] to)
        {
            for (int x = from[0] - 1; x < to[0]; x++)
            {
                for (int y = from[1] - 1; y < to[1]; y++)
                {
                    lightGrid[x][y]++;
                }
            }
            return lightGrid;
        }

        private List<int[]> TurnOffPart2(List<int[]> lightGrid, int[] from, int[] to)
        {
            for (int x = from[0] - 1; x < to[0]; x++)
            {
                for (int y = from[1] - 1; y < to[1]; y++)
                {
                    if (lightGrid[x][y] > 0)
                    {
                        lightGrid[x][y]--;
                    }
                }
            }
            return lightGrid;
        }


        private List<int[]> ConstructGridPart2(int x, int y)
        {
            var outputList = new List<int[]>();
            for (int i = 0; i < x; i++)
            {
                int[] temp = new int[y];
                outputList.Add(temp);
            }
            return outputList;
        }

        private int TotalBrightness(List<int[]> lightGrid)
        {
            var count = 0;
            for (int x = 0; x < lightGrid.Count; x++)
            {
                for (int y = 0; y < lightGrid[0].Length; y++)
                {
                    count = count + lightGrid[x][y];
                }
            }
            return count;
        }

        //Both

        private int[] ConvertToArray(string str)
        {
            int[] outputArray = new int[2];
            string[] args = str.Split(',');

            outputArray[0] = Int32.Parse(args[0]);
            outputArray[1] = Int32.Parse(args[1]);

            return outputArray;
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
