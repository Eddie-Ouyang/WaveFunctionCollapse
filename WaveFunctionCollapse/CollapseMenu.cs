using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaveFunctionCollapse
{
    public partial class CollapseMenu : Form
    {
        private List<int> states;
        private readonly int MENU_SIZE = 5;
        private int stateIndex;

        private PanelData menuData;
        private Color[] colors;
        private SolidBrush brush;
        private Graphics graphics;

        private MainWindow main;
        public CollapseMenu(Color[] colors, MainWindow main)
        {
            InitializeComponent();

            menuData = new PanelData(collapsePanel, 3, MENU_SIZE * 4 - 1);
            this.colors = colors;
            brush = new SolidBrush(Color.Black);
            graphics = collapsePanel.CreateGraphics();
            this.main = main;
        }

        private void CollapsePanel_Paint(object sender, PaintEventArgs e)
        {
            if (states == null) return;

            var size = menuData.gridSize;
            var shiftX = menuData.shiftX;
            var shiftY = menuData.shiftY;

            for(int i = stateIndex, center = 1; !(center > 1 && i % states.Count == stateIndex) && center < MENU_SIZE * 4; i++, center += 4)
            {
                var state = states[i%states.Count];

                brush.Color = state%10 == 9 ? Color.White : colors[state % 10];
                graphics.FillRectangle(brush, shiftX, shiftY + size * center, size, size);
                state /= 10;

                brush.Color = state % 10 == 9 ? Color.White : colors[state % 10];
                graphics.FillRectangle(brush, shiftX + size * 2, shiftY + size * center, size, size);
                state /= 10;

                brush.Color = state % 10 == 9 ? Color.White : colors[state % 10];
                graphics.FillRectangle(brush, shiftX + size, shiftY + size * center + size, size, size);
                state /= 10;

                brush.Color = state % 10 == 9 ? Color.White : colors[state % 10];
                graphics.FillRectangle(brush, shiftX + size, shiftY + size * center - size, size, size);
                state /= 10;

                brush.Color = state % 10 == 9 ? Color.White : colors[state % 10];
                graphics.FillRectangle(brush, shiftX + size, shiftY + size * center, size, size);
            }
        }

        public void ConfigureMenu(List<int> n)
        {
            states = n;
            collapsePanel.Refresh();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            stateIndex = 0;
        }

        private void collapsePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var relative = collapsePanel.PointToClient(Cursor.Position);
                var shiftX = menuData.shiftX;
                var shiftY = menuData.shiftY;
                var size = menuData.gridSize;
                var x = menuData.LocationToGridX(relative.X);
                var y = menuData.LocationToGridY(relative.Y);

                if (x < 0 || y < 0 || y % 4 == 3) return;
                main.Collapse(states[(stateIndex + y / 4) % states.Count]);
                stateIndex = 0;
                this.Hide();
            } 
            else if (e.Button == MouseButtons.Right)
            {
                stateIndex++;
                if(stateIndex >= states.Count) stateIndex = 0;
                collapsePanel.Refresh();
            }
        }
    }
}
