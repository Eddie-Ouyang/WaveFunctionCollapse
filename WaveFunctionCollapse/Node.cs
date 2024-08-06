using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{
    internal class Node
    {
        private int color;
        private int north;
        private int south;
        private int west;
        private int east;

        public Node(int color, int north, int south, int west, int east)
        {
            this.color = color;
            this.north = north;
            this.south = south;
            this.west = west;
            this.east = east;
        }

        public override int GetHashCode()
        {
            return color * 1000 + north * 1000 + south + 100 + west * 10 + east;
        }


    }
}
