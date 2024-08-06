using System;
using System.Drawing;
using System.Windows.Forms;

namespace WaveFunctionCollapse
{
    public partial class Form1 : Form
    {
        public static readonly int COLOR_COUNT = 5;
        private readonly int INPUT_SIZE = 14;

        private Color[] colors;
        private int currentColor;

        private int[,] inputGrid;
        private PanelData inputData;
        private Graphics inputDrawer;

        private WFCEngine wfcGenerator;

        private Pen pen;
        private SolidBrush brush;


        public Form1()
        {
            InitializeComponent();
            colors = new Color[COLOR_COUNT];
            colors[0] = colorSelectR.BackColor;
            colors[1] = colorSelectY.BackColor;
            colors[2] = colorSelectG.BackColor;
            colors[3] = colorSelectB.BackColor;
            colors[4] = colorSelectD.BackColor;

            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Black);

            inputGrid = new int[INPUT_SIZE,INPUT_SIZE];
            inputDrawer = InputPanel.CreateGraphics();
            inputData = new PanelData(InputPanel, inputGrid.GetLength(0), inputGrid.GetLength(1));

            wfcGenerator = new WFCEngine();
        }

        private void SelectColor(object sender, EventArgs e)
        {
            currentColor = int.Parse(((PictureBox)sender).AccessibleName);
        }

        private void InputPanel_Paint(object sender, PaintEventArgs e)
        {
            var size = inputData.gridSize;
            var shiftX = inputData.shiftX;
            var shiftY = inputData.shiftY;

            
            for (int y = 0; y < INPUT_SIZE; y++)
            {
                for (int x = 0; x < INPUT_SIZE; x++)
                {
                    brush.Color = colors[inputGrid[x,y]];
                    var rect = new Rectangle(shiftX + x * size, shiftY + y * size, size, size);
                    inputDrawer.FillRectangle(brush, rect);
                    inputDrawer.DrawRectangle(pen, rect);
                    
                }
            }
        }

        private void InputPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var relative = InputPanel.PointToClient(Cursor.Position);
            var x = inputData.LocationToGridX(relative.X);
            var y = inputData.LocationToGridY(relative.Y);
            inputGrid[x,y] = currentColor;


            var size = inputData.gridSize;
            var shiftX = inputData.shiftX;
            var shiftY = inputData.shiftY;

            brush.Color = colors[inputGrid[x, y]];
            var rect = new Rectangle(shiftX + x * size, shiftY + y * size, size, size);
            inputDrawer.FillRectangle(brush, rect);
            inputDrawer.DrawRectangle(pen, rect);
        }

        private void generateNodes(object sender, EventArgs e)
        {
            var source = (Label)sender;
            wfcGenerator.GenerateNodes(inputGrid);
            source.Text = "Complete";
        }
    }
}
