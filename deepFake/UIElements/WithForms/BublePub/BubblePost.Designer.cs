namespace deepFake.UIElements.WithForms.BublePub
{
    partial class BubblePost
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
            MainPanel = new Panel();
            panel2 = new Panel();
            ScrollablePanel = new Panel();
            retourBTN = new Button();
            MainPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Controls.Add(panel2);
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1920, 1080);
            MainPanel.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(ScrollablePanel);
            panel2.Location = new Point(100, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(1500, 800);
            panel2.TabIndex = 1;
            // 
            // ScrollablePanel
            // 
            ScrollablePanel.Location = new Point(30, 3);
            ScrollablePanel.Name = "ScrollablePanel";
            ScrollablePanel.Size = new Size(1000, 4000);
            ScrollablePanel.TabIndex = 0;
            ScrollablePanel.MouseWheel += ScrollablePanel_MouseWheel;
            // 
            // retourBTN
            // 
            retourBTN.Location = new Point(891, 984);
            retourBTN.Name = "retourBTN";
            retourBTN.Size = new Size(100, 30);
            retourBTN.TabIndex = 0;
            retourBTN.Text = "retour";
            retourBTN.UseVisualStyleBackColor = true;
            retourBTN.Click += retourBTN_Click;
            // 
            // BubblePost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 845);
            Controls.Add(MainPanel);
            Name = "BubblePost";
            Text = "BubblePost";
            MainPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Button retourBTN;
        private Panel panel2;
        private Panel ScrollablePanel;
    }
}