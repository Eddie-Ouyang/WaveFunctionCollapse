namespace WaveFunctionCollapse
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ColorPalette = new System.Windows.Forms.Panel();
            this.colorSelectD = new System.Windows.Forms.PictureBox();
            this.colorSelectB = new System.Windows.Forms.PictureBox();
            this.colorSelectG = new System.Windows.Forms.PictureBox();
            this.colorSelectY = new System.Windows.Forms.PictureBox();
            this.colorSelectR = new System.Windows.Forms.PictureBox();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.OutputPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Generate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectR)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColorPalette
            // 
            this.ColorPalette.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ColorPalette.Controls.Add(this.colorSelectD);
            this.ColorPalette.Controls.Add(this.colorSelectB);
            this.ColorPalette.Controls.Add(this.colorSelectG);
            this.ColorPalette.Controls.Add(this.colorSelectY);
            this.ColorPalette.Controls.Add(this.colorSelectR);
            this.ColorPalette.Location = new System.Drawing.Point(40, 51);
            this.ColorPalette.Name = "ColorPalette";
            this.ColorPalette.Size = new System.Drawing.Size(271, 54);
            this.ColorPalette.TabIndex = 0;
            // 
            // colorSelectD
            // 
            this.colorSelectD.AccessibleName = "4";
            this.colorSelectD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.colorSelectD.Location = new System.Drawing.Point(219, 3);
            this.colorSelectD.Name = "colorSelectD";
            this.colorSelectD.Size = new System.Drawing.Size(48, 48);
            this.colorSelectD.TabIndex = 4;
            this.colorSelectD.TabStop = false;
            this.colorSelectD.Click += new System.EventHandler(this.SelectColor);
            // 
            // colorSelectB
            // 
            this.colorSelectB.AccessibleName = "3";
            this.colorSelectB.BackColor = System.Drawing.Color.Red;
            this.colorSelectB.Location = new System.Drawing.Point(165, 3);
            this.colorSelectB.Name = "colorSelectB";
            this.colorSelectB.Size = new System.Drawing.Size(48, 48);
            this.colorSelectB.TabIndex = 3;
            this.colorSelectB.TabStop = false;
            this.colorSelectB.Click += new System.EventHandler(this.SelectColor);
            // 
            // colorSelectG
            // 
            this.colorSelectG.AccessibleName = "2";
            this.colorSelectG.BackColor = System.Drawing.Color.Lime;
            this.colorSelectG.Location = new System.Drawing.Point(111, 3);
            this.colorSelectG.Name = "colorSelectG";
            this.colorSelectG.Size = new System.Drawing.Size(48, 48);
            this.colorSelectG.TabIndex = 2;
            this.colorSelectG.TabStop = false;
            this.colorSelectG.Click += new System.EventHandler(this.SelectColor);
            // 
            // colorSelectY
            // 
            this.colorSelectY.AccessibleName = "1";
            this.colorSelectY.BackColor = System.Drawing.Color.Yellow;
            this.colorSelectY.Location = new System.Drawing.Point(57, 3);
            this.colorSelectY.Name = "colorSelectY";
            this.colorSelectY.Size = new System.Drawing.Size(48, 48);
            this.colorSelectY.TabIndex = 1;
            this.colorSelectY.TabStop = false;
            this.colorSelectY.Click += new System.EventHandler(this.SelectColor);
            // 
            // colorSelectR
            // 
            this.colorSelectR.AccessibleName = "0";
            this.colorSelectR.BackColor = System.Drawing.Color.Cyan;
            this.colorSelectR.Location = new System.Drawing.Point(3, 3);
            this.colorSelectR.Name = "colorSelectR";
            this.colorSelectR.Size = new System.Drawing.Size(48, 48);
            this.colorSelectR.TabIndex = 0;
            this.colorSelectR.TabStop = false;
            this.colorSelectR.Click += new System.EventHandler(this.SelectColor);
            // 
            // InputPanel
            // 
            this.InputPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.InputPanel.Location = new System.Drawing.Point(40, 189);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(503, 467);
            this.InputPanel.TabIndex = 1;
            this.InputPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.InputPanel_Paint);
            this.InputPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.InputPanel_MouseClick);
            // 
            // OutputPanel
            // 
            this.OutputPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.OutputPanel.Location = new System.Drawing.Point(577, 25);
            this.OutputPanel.Name = "OutputPanel";
            this.OutputPanel.Size = new System.Drawing.Size(872, 756);
            this.OutputPanel.TabIndex = 2;
            this.OutputPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputPanel_Paint);
            this.OutputPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OutputPanel_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Generate);
            this.panel1.Controls.Add(this.OutputPanel);
            this.panel1.Controls.Add(this.InputPanel);
            this.panel1.Controls.Add(this.ColorPalette);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1471, 812);
            this.panel1.TabIndex = 0;
            // 
            // Generate
            // 
            this.Generate.AutoSize = true;
            this.Generate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.Generate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Generate.Location = new System.Drawing.Point(348, 51);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(197, 29);
            this.Generate.TabIndex = 3;
            this.Generate.Text = "Generate Nodes";
            this.Generate.Click += new System.EventHandler(this.generateNodes);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(353, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Step";
            this.label1.Click += new System.EventHandler(this.Step_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 812);
            this.Controls.Add(this.panel1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ColorPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelectR)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ColorPalette;
        private System.Windows.Forms.PictureBox colorSelectD;
        private System.Windows.Forms.PictureBox colorSelectB;
        private System.Windows.Forms.PictureBox colorSelectG;
        private System.Windows.Forms.PictureBox colorSelectY;
        private System.Windows.Forms.PictureBox colorSelectR;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Panel OutputPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Generate;
        private System.Windows.Forms.Label label1;
    }
}

