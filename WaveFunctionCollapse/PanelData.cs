using System;
using System.Windows.Forms;

namespace WaveFunctionCollapse
{
    internal class PanelData
    {
        //    public int relativeX {get; set;}
        //    public int relativeY {get; set;}
        public int gridSize {get; set;}
        public int shiftX {get; set;}
        public int shiftY {get; set;}
        public int gridX {get; set;}
        public int gridY {get; set;}

        public PanelData(Panel p, int width, int height)
        {
            gridSize = Math.Min(p.Width/width, p.Height/height);
            var topLeft = p.PointToScreen(new System.Drawing.Point(0, 0));
            //relativeX = topLeft.X;
            //relativeY = topLeft.Y;

            shiftX = (p.Width - gridSize * width) / 2;
            shiftY = (p.Height - gridSize * height) / 2;

            gridX = width;
            gridY = height;
        }

        public int LocationToGridX(int cursorX)
        {
            var x = (cursorX - shiftX) / gridSize;

            return x >= gridX ? -1 : x;
        }

        public int LocationToGridY(int cursorY)
        {
            var y = (cursorY - shiftY) / gridSize;

            return y >= gridY ? -1 : y;
        }
    }
}
