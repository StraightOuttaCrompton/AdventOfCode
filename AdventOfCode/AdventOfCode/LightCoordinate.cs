using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class LightCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsOn  { get; set; }

        public LightCoordinate(int x, int y, bool isOn)
        {
            X = x;
            Y = y;
            IsOn = isOn;
        } 
    }
}
