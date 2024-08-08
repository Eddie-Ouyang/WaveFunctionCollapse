using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace WaveFunctionCollapse
{
    public partial class MainWindow : Form
    {
        public static readonly int COLOR_COUNT = 5;
        private readonly int INPUT_SIZE = 8;
        private readonly int OUTPUT_SIZE = 16;

        private Color[] colors;
        private int currentColor;

        private int[,] inputGrid;
        private PanelData inputData;
        private Graphics inputDrawer;

        private PanelData outputData;
        private Graphics outputDrawer;

        private WFCEngine wfcGenerator;

        private Pen pen;
        private SolidBrush brush;

        private CollapseMenu collapseMenu;

        private int[] selectedNode;


        public MainWindow()
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

            outputDrawer = OutputPanel.CreateGraphics();
            outputData = new PanelData(OutputPanel, OUTPUT_SIZE, OUTPUT_SIZE);

            wfcGenerator = new WFCEngine(OUTPUT_SIZE);

            collapseMenu = new CollapseMenu(colors, this);
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
            if (x < 0 || y < 0) return;
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
            OutputPanel.Refresh();
        }

        private void OutputPanel_Paint(object sender, PaintEventArgs e)
        {
            var size = outputData.gridSize;
            var shiftX = outputData.shiftX;
            var shiftY = outputData.shiftY;

            for (int x = 0; x < OUTPUT_SIZE; x++)
            {
                for (int y = 0; y < OUTPUT_SIZE; y++)
                {
                    outputDrawer.DrawRectangle(pen, new Rectangle(shiftX + x * size, shiftY + y * size, size, size));
                    brush.Color = Color.White;
                    outputDrawer.DrawString(""+wfcGenerator.GetStates(y, x).Count, DefaultFont, brush, shiftX + x * size + size/2, shiftY + y * size + size/2);
                    var color = wfcGenerator.GetState(y, x);
                    if(color != 0)
                    {
                        brush.Color = colors[(color / 10000) % 10];
                        outputDrawer.FillRectangle(brush, shiftX + x * size, shiftY + y * size, size, size);
                    }
                }
            }
        }

        private void OutputPanel_MouseClick(object sender, MouseEventArgs e)
        {
            var size = outputData.gridSize;
            
            var relative = OutputPanel.PointToClient(Cursor.Position);
            var x = outputData.LocationToGridX(relative.X);
            var y = outputData.LocationToGridY(relative.Y);

            if (x < 0 || y < 0) return;

            collapseMenu.ConfigureMenu(wfcGenerator.GetStates(y, x));
            selectedNode = new int[] { y, x };
            collapseMenu.Show();
        }

        public void Collapse(int state)
        {
            var size = outputData.gridSize;
            var shiftX = outputData.shiftX;
            var shiftY = outputData.shiftY;

            wfcGenerator.Collapse(selectedNode[0], selectedNode[1], state);
            OutputPanel.Refresh();
        }

        private void Step_Click(object sender, EventArgs e)
        {
            wfcGenerator.Step();
            OutputPanel.Refresh();
        }
    }
}
