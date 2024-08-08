namespace WaveFunctionCollapse
{
    partial class CollapseMenu
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
            this.collapsePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // collapsePanel
            // 
            this.collapsePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.collapsePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsePanel.Location = new System.Drawing.Point(0, 0);
            this.collapsePanel.Name = "collapsePanel";
            this.collapsePanel.Size = new System.Drawing.Size(409, 734);
            this.collapsePanel.TabIndex = 0;
            this.collapsePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CollapsePanel_Paint);
            this.collapsePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.collapsePanel_MouseClick);
            // 
            // CollapseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 734);
            this.Controls.Add(this.collapsePanel);
            this.Name = "CollapseMenu";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel collapsePanel;
    }
}