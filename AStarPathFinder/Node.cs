using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarPathFinder
{
    [DebuggerDisplay("{PathLength} - ({Point.X},{Point.Y})")]
    class Node
    {
        public double PathLength;
        public IntPoint2D Point;
        public override int GetHashCode()
        {
            return Point.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Node)
                return Point.Equals((obj as Node).Point);
            else return false;
        }
    }
}
