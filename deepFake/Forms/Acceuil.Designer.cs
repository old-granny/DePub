namespace deepFake
{
    partial class Acceuil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceuil));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ScrollPub = new VScrollBar();
            TaskBar = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            UnMax = new Panel();
            exitButton = new Panel();
            TaskBar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // ScrollPub
            // 
            ScrollPub.Location = new Point(584, 0);
            ScrollPub.Name = "ScrollPub";
            ScrollPub.Size = new Size(17, 550);
            ScrollPub.TabIndex = 0;
            // 
            // TaskBar
            // 
            TaskBar.Controls.Add(flowLayoutPanel1);
            TaskBar.Dock = DockStyle.Top;
            TaskBar.Location = new Point(0, 0);
            TaskBar.Name = "TaskBar";
            TaskBar.Size = new Size(1904, 47);
            TaskBar.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Controls.Add(UnMax);
            flowLayoutPanel1.Controls.Add(exitButton);
            flowLayoutPanel1.Dock = DockStyle.Right;
            flowLayoutPanel1.Location = new Point(1762, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(142, 47);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Zoom;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(40, 40);
            panel2.TabIndex = 3;
            // 
            // UnMax
            // 
            UnMax.BackColor = Color.Transparent;
            UnMax.BackgroundImage = (Image)resources.GetObject("UnMax.BackgroundImage");
            UnMax.BackgroundImageLayout = ImageLayout.Zoom;
            UnMax.Location = new Point(49, 3);
            UnMax.Name = "UnMax";
            UnMax.Size = new Size(40, 40);
            UnMax.TabIndex = 1;
            UnMax.Paint += UnMax_Paint;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Transparent;
            exitButton.BackgroundImage = Properties.Resources.Exit;
            exitButton.BackgroundImageLayout = ImageLayout.Zoom;
            exitButton.Location = new Point(95, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(40, 40);
            exitButton.TabIndex = 2;
            exitButton.Click += exitButton_Click;
            exitButton.MouseEnter += exitButton_MouseEnter;
            exitButton.MouseLeave += exitButton_MouseLeave;
            // 
            // Acceuil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            ControlBox = false;
            Controls.Add(TaskBar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Acceuil";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form1";
            Load += Acceuil_Load;
            TaskBar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private VScrollBar ScrollPub;
        private Panel TaskBar;
        private Panel UnMax;
        private Panel exitButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
    }
}
