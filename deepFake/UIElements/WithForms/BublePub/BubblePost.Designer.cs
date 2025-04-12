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
            retourBTN = new Button();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.AutoScroll = true;
            MainPanel.Controls.Add(retourBTN);
            MainPanel.Location = new Point(12, 12);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1880, 1017);
            MainPanel.TabIndex = 0;
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
            ClientSize = new Size(1904, 1041);
            Controls.Add(MainPanel);
            Name = "BubblePost";
            Text = "BubblePost";
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
        private Button retourBTN;
    }
}