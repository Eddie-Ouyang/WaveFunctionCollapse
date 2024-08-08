using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WaveFunctionCollapse
{
    internal class WFCEngine
    {
        private readonly int[][] direction = new int[][] {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, 1}, new int[]{0, -1}};
        private int outputSize;

        private List<int> nodes;
        private Dictionary<int, Node> nodeDictionary;

        private int[,] collapsed;
        private bool[,,] superposition;
        private List<int[]> updateNodes;
        private Stack<int[]> activeNodes;
        private Stack<int[]> propagateNodes;

        public WFCEngine(int size)
        {
            outputSize = size;
            nodes = new List<int>();
            updateNodes = new List<int[]>();
            nodeDictionary = new Dictionary<int, Node>();
        }

        public void GenerateNodes(int[,] input)
        {
            nodes.Clear();
            nodeDictionary = new Dictionary<int, Node>();
            int[,] values = new int[input.GetLength(0), input.GetLength(1)];

            for(int x = 0; x < input.GetLength(0); x++)
            {
                for(int y = 0; y < input.GetLength(1); y++)
                {
                    var value = 100000 + input[x,y] * 10000
                                + (y > 0 ? input[x,y-1] : input[x,input.GetLength(1) - 1])
                                + (y < input.GetLength(1) - 1 ? input[x, y + 1] : 0) * 10
                                + (x < input.GetLength(0) - 1 ? input[x + 1, y] : 0) * 100
                                + (x > 0 ? input[x - 1, y] : input[input.GetLength(0) - 1, y]) * 1000;

                    values[x,y] = value;
                    if (!nodes.Contains(value))
                    {
                        nodes.Add(value);
                        nodeDictionary.Add(value, new Node());
                    }
                }
            }

            for(int x = 0; x < input.GetLength(0); x++)
            {
                for(int y = 0; y < input.GetLength(1); y++)
                {
                    for(int i = 0; i < 4; i++)
                    {
                        var dx = x + direction[i][0];
                        var dy = y + direction[i][1];
                        var node = nodeDictionary[values[x,y]];

                        if (dx < 0 || dy < 0 || dx >= input.GetLength(0) || dy >= input.GetLength(1)) node.Add(-1, i);
                        else node.Add(values[dx,dy], i);
                    }
                }
            }

            ResetGrid();
        }

        public void ResetGrid()
        {
            collapsed = new int[outputSize, outputSize];
            superposition = new bool[outputSize, outputSize, nodes.Count];
            propagateNodes = new Stack<int[]>();
            activeNodes = new Stack<int[]>();
        }

        public List<int> GetStates(int x, int y)
        {
            var result = new List<int>();

            for(int i = 0; i < nodes.Count; i++)
            {
                if (!superposition[x,y,i]) result.Add(nodes[i]);
            }

            return result;
        }

        public int GetState(int x, int y)
        {
            return collapsed != null ? collapsed[x,y] : 0;
        }

        public void Collapse(int x, int y, int state)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i] != state) superposition[x, y, i] = true;
            }
            collapsed[x, y] = state;
            propagateNodes.Push(new int[] { x, y });
            //for (int i = 0; i < 4; i++)
            //{
            //    var dx = x + direction[i][0];
            //    var dy = y + direction[i][1];

            //    if (dx < 0) dx = outputSize - 1;
            //    if (dy < 0) dy = outputSize - 1;
            //    if (dx >= outputSize) dx = 0;
            //    if (dy >= outputSize) dy = 0;

            //    propagateNodes.Push(new int[] { dx, dy });
            //    activeNodes.Push(new int[] { dx, dy });
            //}

            while(propagateNodes.Count > 0)
            {
                Propagate(propagateNodes.Pop());
            }
        }

        public void Propagate(int[] node)
        {
            for (int i = 0; i < 4; i++)
            {
                var dx = node[0] + direction[i][0];
                var dy = node[1] + direction[i][1];

                if (dx < 0) dx = outputSize - 1;
                if (dy < 0) dy = outputSize - 1;
                if (dx >= outputSize) dx = 0;
                if (dy >= outputSize) dy = 0;

                if (collapsed[dx, dy] != 0) continue;

                var change = 0;
                for (int j = 0; j < nodes.Count; j++) change += superposition[dx, dy, j] ? 0 : 1;
                UpdateStates(dx, dy);
                for (int j = 0; j < nodes.Count; j++) change -= superposition[dx, dy, j] ? 0 : 1;

                activeNodes.Push(new int[] { dx, dy } );
                if (change != 0) propagateNodes.Push(new int[] { dx, dy } );
            }
        }

        // Needs update
        private void UpdateStates(int x, int y)
        {
            List<int>[] possibleNeighbors = new List<int>[4];
            List<int> possibleSelfColor = new List<int>();

            for(int i = 0; i < 4; i++)
            {
                var dx = x + direction[i][0];
                var dy = y + direction[i][1];

                possibleNeighbors[i] = new List<int>();

                if (dx < 0) dx = outputSize - 1;
                if (dy < 0) dy = outputSize - 1;
                if (dx >= outputSize) dx = 0;
                if (dy >= outputSize) dy = 0;
                

                if (collapsed[dx, dy] != 0)
                {
                    var color = collapsed[dx, dy];
                    for (int j = 0; j < (i + 2) % 4; j++)
                    {
                        color /= 10;
                    }

                    possibleSelfColor.Add(color % 10);
                }

                for (int j = 0; j < nodes.Count; j++)
                {
                    if (!superposition[dx, dy, j])
                    {
                        var color = (nodes[j] / 10000) % 10;
                        if (!possibleNeighbors[i].Contains(color)) possibleNeighbors[i].Add(color);
                    }
                }
                
            }

            for(int i = 0; i < nodes.Count; i++)
            {
                if (superposition[x, y, i]) continue;
                var num = nodes[i];

                for (int j = 3; j >= 0; j--)
                {
                    if (!possibleNeighbors[j].Contains(num % 10))
                    {
                        superposition[x, y, i] = true;
                        break;
                    }
                    num /= 10;
                }

                if (possibleSelfColor.Count > 0 && !possibleSelfColor.Contains(num % 10)) superposition[x, y, i] = true;
            }
        }

        private void UpdateStatesV2(int x, int y)
        {
            for(int i = 0; i < 4; i++)
            {
                var dx = x + direction[i][0];
                var dy = y + direction[i][1];

                var value = 0;
                if (dx < 0 || dy < 0 || dx > outputSize - 1 || dy > outputSize - 1) value = -1;
                else if (collapsed[dx,dy] != 0) value = collapsed[dx,dy];

                if(value == 0)
                {
                    //HashSet<int> possibleStates = new HashSet<int>();
                    //for(int j = 0; j < nodes.Count; j++)
                    //{
                    //    if (superposition[dx, dy, j]) continue;

                    //    possibleStates.UnionWith(nodeDictionary[nodes[j]].GetNeighborInDirection(i/2*2 + (i+1)%2));
                    //}

                    //for(int j = 0; j < nodes.Count; j++)
                    //{
                    //    if (superposition[x,y,j]) continue;

                    //    if (!possibleStates.Contains(nodes[j])) superposition[x, y, j] = true;
                    //}

                    HashSet<int> possibleColors = new HashSet<int>();
                    for(int j = 0; j < nodes.Count; j++)
                    {
                        if (superposition[dx, dy, j]) continue;

                        possibleColors.Add((nodes[j]/10000)%10);
                    }

                    var colorIndex = 1;
                    for (int j = 0; j < (i / 2 * 2) + (i + 1) % 4; j++)
                    {
                        colorIndex *= 10;
                    }

                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (superposition[x, y, j]) continue;

                        if (!possibleColors.Contains((nodes[j] / colorIndex) % 10)) superposition[x,y,j] = true;
                    }
                }
                else
                {
                    for(int j = 0; j < nodes.Count; j++)
                    {
                        if (superposition[x, y, j]) continue;

                        if (!nodeDictionary[nodes[j]].Contains(value, i)) superposition[x, y, j] = true;
                    }
                }
            }
        }
    }
}
