namespace deepFake
{
    partial class FrontPage
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
            PanelContenuePublication = new Panel();
            SuspendLayout();
            // 
            // PanelContenuePublication
            // 
            PanelContenuePublication.AutoScroll = true;
            PanelContenuePublication.AutoSize = true;
            PanelContenuePublication.BackColor = Color.Transparent;
            PanelContenuePublication.Location = new Point(0, 0);
            PanelContenuePublication.Name = "PanelContenuePublication";
            PanelContenuePublication.Size = new Size(1121, 644);
            PanelContenuePublication.TabIndex = 3;
            // 
            // FrontPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1169, 689);
            Controls.Add(PanelContenuePublication);
            Name = "FrontPage";
            Text = "FrontPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel PanelContenuePublication;
    }
}