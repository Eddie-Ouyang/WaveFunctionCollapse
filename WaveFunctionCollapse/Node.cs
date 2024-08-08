using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{
    internal class Node
    {
        private HashSet<int>[] neighbors;

        public Node()
        {
            neighbors = new HashSet<int>[4];
            for(int i = 0; i < 4; i++) neighbors[i] = new HashSet<int>();
        }

        public void Add(int state, int direction)
        {
            neighbors[direction].Add(state);
        }

        public HashSet<int> GetNeighborInDirection(int direction)
        {
            return neighbors[direction];
        }

        public bool Contains(int state, int direction)
        {
            return neighbors[direction].Contains(state);
        }
        
    }
}
