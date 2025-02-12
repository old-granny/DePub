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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelInsidePost = new Panel();
            boutonPagePost = new Button();
            PanelPulication = new Panel();
            ScrollPub = new VScrollBar();
            SuspendLayout();
            // 
            // panelInsidePost
            // 
            panelInsidePost.Location = new Point(42, 13);
            panelInsidePost.Name = "panelInsidePost";
            panelInsidePost.Size = new Size(10, 10);
            panelInsidePost.TabIndex = 0;
            // 
            // boutonPagePost
            // 
            boutonPagePost.Location = new Point(500, 600);
            boutonPagePost.Name = "boutonPagePost";
            boutonPagePost.Size = new Size(200, 30);
            boutonPagePost.TabIndex = 1;
            boutonPagePost.Text = "Nouvelle publication";
            boutonPagePost.UseVisualStyleBackColor = true;
            boutonPagePost.Click += boutonPagePost_Click;
            // 
            // PanelPulication
            // 
            PanelPulication.Location = new Point(277, 46);
            PanelPulication.Name = "PanelPulication";
            PanelPulication.Size = new Size(633, 550);
            PanelPulication.TabIndex = 2;
            // 
            // ScrollPub
            // 
            ScrollPub.Location = new Point(913, 46);
            ScrollPub.Name = "ScrollPub";
            ScrollPub.Size = new Size(19, 550);
            ScrollPub.TabIndex = 3;
            // 
            // Acceuil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(ScrollPub);
            Controls.Add(PanelPulication);
            Controls.Add(panelInsidePost);
            Controls.Add(boutonPagePost);
            Name = "Acceuil";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelInsidePost;
        private Button boutonPagePost;
        private Panel PanelPulication;
        private VScrollBar ScrollPub;
    }
}
