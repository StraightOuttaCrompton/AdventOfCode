﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day2
    {
        public void Run()
        {
            string[] inputFile = System.IO.File.ReadAllLines(@"C:\Users\jcrompto\Documents\adventofcode\AdventOfCode\Day2Input.txt");
            var listOfPresentDimensions = ParseFile(inputFile);

            var wrappingPaperNeeded = CalculateTotalWrappingPaper(listOfPresentDimensions);
            var ribbonNeeded = CalculateTotalRibbon(listOfPresentDimensions);

            Console.WriteLine("Wrapping Paper Needed");
            Console.WriteLine(wrappingPaperNeeded);

            Console.WriteLine("Ribbon Needed");
            Console.WriteLine(ribbonNeeded);
            Console.ReadLine();
        }

        public List<int[]> ParseFile(string[] inputFile)
        {
            List<int[]> outputList = new List<int[]>();

            foreach (string line in inputFile)
            {
                string[] args = line.Split('x');
                outputList.Add(ConvertStringToInt(args));
            }

            return outputList;
        }

        public int[] ConvertStringToInt(string[] args)
        {
            var output = new int[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                output[i] = Int32.Parse(args[i]);
            }
            return output;
        }

        public int CalculateTotalWrappingPaper(List<int[]> listOfPresentDimensions)
        {
            var sumOfPaper = 0;
            foreach (var present in listOfPresentDimensions)
            {
                var paperForPresent = CalculatePaperForPresent(present);
                sumOfPaper = sumOfPaper + paperForPresent;
            }
            return sumOfPaper;
        }

        public int CalculatePaperForPresent(int[] present)
        {
            var side1 = present[0] * present[1];
            var side2 = present[1] * present[2];
            var side3 = present[0] * present[2];
            var slack = new[] { side1, side2, side3 }.Min();

            var totalPaper = slack + 2 * side1 + 2 * side2 + 2 * side3;

            return totalPaper;
        }

        public int CalculateTotalRibbon(List<int[]> listOfPresentDimensions)
        {
            var sumOfRibbon = 0;
            foreach (var present in listOfPresentDimensions)
            {
                var ribbonForPresent = CalculateRibbonForPresent(present);
                sumOfRibbon = sumOfRibbon + ribbonForPresent;
            }
            return sumOfRibbon;
        }

        public int CalculateRibbonForPresent(int[] present)
        {
            var dim1 = present[0];
            var dim2 = present[1];
            var dim3 = present[2];
            var maxDim = new[] { dim1, dim2, dim3 }.Max();

            var totalRibbonForPresent = 2 * (dim1 + dim2 + dim3 - maxDim) + dim1 * dim2 * dim3;
            return totalRibbonForPresent;
        }

    }
}
