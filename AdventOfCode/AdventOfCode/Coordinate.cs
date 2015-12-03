using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Visits { get; set; }

        public Coordinate(int x, int y, int visits)
        {
            X = x;
            Y = y;
            Visits = visits;
        }
    }
}

