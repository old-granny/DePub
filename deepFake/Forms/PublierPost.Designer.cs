namespace deepFake
{
    partial class PublierPost
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
            PanelPrincipale = new Panel();
            PanelContenue = new Panel();
            PanelPost = new Panel();
            ScrollablePanel = new Panel();
            pictureBox1 = new PictureBox();
            TetePNL = new Panel();
            textBox1 = new TextBox();
            PanelPrincipale.SuspendLayout();
            PanelContenue.SuspendLayout();
            PanelPost.SuspendLayout();
            ScrollablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PanelPrincipale
            // 
            PanelPrincipale.BackColor = SystemColors.ButtonFace;
            PanelPrincipale.BorderStyle = BorderStyle.FixedSingle;
            PanelPrincipale.Controls.Add(PanelContenue);
            PanelPrincipale.Controls.Add(TetePNL);
            PanelPrincipale.Location = new Point(0, 0);
            PanelPrincipale.Margin = new Padding(3, 4, 3, 4);
            PanelPrincipale.Name = "PanelPrincipale";
            PanelPrincipale.Size = new Size(2194, 1393);
            PanelPrincipale.TabIndex = 5;
            // 
            // PanelContenue
            // 
            PanelContenue.Controls.Add(PanelPost);
            PanelContenue.Controls.Add(pictureBox1);
            PanelContenue.Location = new Point(0, 164);
            PanelContenue.Margin = new Padding(3, 4, 3, 4);
            PanelContenue.Name = "PanelContenue";
            PanelContenue.Size = new Size(2222, 1223);
            PanelContenue.TabIndex = 1;
            // 
            // PanelPost
            // 
            PanelPost.Controls.Add(ScrollablePanel);
            PanelPost.Location = new Point(385, 73);
            PanelPost.Margin = new Padding(3, 4, 3, 4);
            PanelPost.Name = "PanelPost";
            PanelPost.Size = new Size(1383, 1080);
            PanelPost.TabIndex = 7;
            // 
            // ScrollablePanel
            // 
            ScrollablePanel.Controls.Add(textBox1);
            ScrollablePanel.Location = new Point(3, 47);
            ScrollablePanel.Margin = new Padding(3, 4, 3, 4);
            ScrollablePanel.Name = "ScrollablePanel";
            ScrollablePanel.Size = new Size(1376, 2133);
            ScrollablePanel.TabIndex = 7;
            ScrollablePanel.MouseWheel += ScrollablePanel_MouseWheel;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.BigRectangle;
            pictureBox1.Location = new Point(183, 59);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1833, 1112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // TetePNL
            // 
            TetePNL.Location = new Point(0, 0);
            TetePNL.Margin = new Padding(3, 4, 3, 4);
            TetePNL.Name = "TetePNL";
            TetePNL.Size = new Size(2194, 156);
            TetePNL.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(983, 306);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(177, 99);
            textBox1.TabIndex = 0;
            // 
            // PublierPost
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1924, 1055);
            Controls.Add(PanelPrincipale);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PublierPost";
            Text = "PublierPost";
            PanelPrincipale.ResumeLayout(false);
            PanelContenue.ResumeLayout(false);
            PanelPost.ResumeLayout(false);
            ScrollablePanel.ResumeLayout(false);
            ScrollablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }



        #endregion
        private Panel PanelPrincipale;
        private Panel TetePNL;
        private Panel PanelContenue;
        private PictureBox pictureBox1;
        private Panel PanelPost;
        private Panel ScrollablePanel;
        private TextBox textBox1;
    }
}