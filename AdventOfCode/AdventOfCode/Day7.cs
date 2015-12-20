using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day7
    {
        Dictionary<string, int> Wires = new Dictionary<string, int>();
        List<Gate> gates = new List<Gate>();

        public void Run()
        {
            var input = System.IO.File.ReadAllLines(@"C:\Users\HP\Documents\GitHub\AdventOfCode\AdventOfCode\AdventOfCode\Day7Input.txt");
            Parse(input,CalculateList(input));
            
            //Console.WriteLine(Part1());
            Console.WriteLine(Part2());
            Console.Read();
        }

        private int Part2()
        {
            Wires.Add("b", 16076);
            return Part1();
        }

        private int Part1()
        {
            var containsA = false;
            while (!containsA)
            {
                try
                {
                    var temp = Wires["a"];
                    containsA = true;
                }
                catch (Exception)
                {
                    Loop();
                    Console.WriteLine(Wires.Count);
                }
            }
            return Wires["a"];
        }

        private void Loop()
        {          
            List<Gate> tempList = new List<Gate>();
            foreach (var gate in gates)
            {
                try
                {
                    Calculate(gate);
                    tempList.Add(gate);
                }
                catch
                {
                   continue;
                }
            }

            foreach (var i in tempList)
            {
                gates.Remove(i);
            }
        }

        private void Calculate(Gate gate)
        {
            switch (gate.Type)
            {
                case "NOT":
                    Wires.Add(gate.Output, ~Wires[gate.Input[0]]);
                    break;

                case "AND":
                    try
                    {
                        Wires.Add(gate.Output, Wires[gate.Input[0]] & Wires[gate.Input[1]]);
                    }
                    catch 
                    {
                        Wires.Add(gate.Output, Int32.Parse(gate.Input[0]) & Wires[gate.Input[1]]);
                    }
                    break;

                case "OR":
                    Wires.Add(gate.Output, Wires[gate.Input[0]] ^ Wires[gate.Input[1]]);
                    break;

                case "RSHIFT":
                    Wires.Add(gate.Output, Wires[gate.Input[0]] >> Int16.Parse(gate.Input[1]));
                    break;

                case "LSHIFT":
                    Wires.Add(gate.Output, Wires[gate.Input[0]] << Int16.Parse(gate.Input[1]));
                    break;

                case "DIRECT":
                    try
                    {
                        Wires.Add(gate.Output, Int16.Parse(gate.Input[0]));
                    }
                    catch
                    {
                        Wires.Add(gate.Output, Wires[gate.Input[0]]);
                    }
                    break;
            }
        }

        private void Parse(string[] input,List<string[]> list)
        {
            var count = 0;
            foreach (var line in input)
            {
                if (line.Contains("NOT"))
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][1]);

                    Gate temp = new Gate(tempList, list[count][3], "NOT");
                    gates.Add(temp);
                }
                else if (line.Contains("AND"))
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][0]);
                    tempList.Add(list[count][2]);

                    Gate temp = new Gate(tempList, list[count][4], "AND");
                    gates.Add(temp);
                }
                else if (line.Contains("OR"))
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][0]);
                    tempList.Add(list[count][2]);

                    Gate temp = new Gate(tempList, list[count][4], "OR");
                    gates.Add(temp);
                }
                else if (line.Contains("RSHIFT"))
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][0]);
                    tempList.Add(list[count][2]);

                    Gate temp = new Gate(tempList, list[count][4], "RSHIFT");
                    gates.Add(temp);
                }
                else if (line.Contains("LSHIFT"))
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][0]);
                    tempList.Add(list[count][2]);

                    Gate temp = new Gate(tempList, list[count][4], "LSHIFT");
                    gates.Add(temp);
                }
                else
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(list[count][0]);

                    Gate temp = new Gate(tempList, list[count][2], "DIRECT");
                    gates.Add(temp);
                }
                count++;
            }
        }

        private List<string[]> CalculateList(string[] inputFile)
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

    class Gate
    {
        public List<string> Input { get; set; }
        public string Output { get; set; }
        public string Type { get; set; }

        public Gate(List<string> input , string output, string type )
        {
            Input = input;
            Output = output;
            Type = type;
        }
    }

}