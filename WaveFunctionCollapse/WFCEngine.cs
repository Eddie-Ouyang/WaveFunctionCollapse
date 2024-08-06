using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{
    internal class WFCEngine
    {
        private readonly int OUTPUT_SIZE = 32;
        private List<int> nodes;
        private int[,] collapsed;
        private bool[,,] superposition;
        private List<int[]> updateNodes;

        public WFCEngine()
        {
            nodes = new List<int>();
            updateNodes = new List<int[]>();
        }

        public void GenerateNodes(int[,] input)
        {
            nodes.Clear();

            for(int x = 0; x < input.GetLength(0); x++)
            {
                for(int y = 0; y < input.GetLength(1); y++)
                {
                    var value = 100000 + input[x,y] * 10000
                                + (y > 0 ? input[x,y-1] : 9) * 1000
                                + (y < input.GetLength(1) - 1 ? input[x, y + 1] : 9) * 100
                                + (x < input.GetLength(0) - 1 ? input[x + 1, y] : 9) * 10
                                + (x > 0 ? input[x - 1, y] : 9);

                    if(!nodes.Contains(value)) nodes.Add(value);
                }
            }

            resetGrid();
        }

        public void resetGrid()
        {
            collapsed = new int[OUTPUT_SIZE, OUTPUT_SIZE];
            superposition = new bool[OUTPUT_SIZE, OUTPUT_SIZE, nodes.Count];
        }

        public void step()
        {

        }
    }
}
