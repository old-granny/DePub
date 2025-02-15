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
            PanelPulication = new Panel();
            ScrollPub = new VScrollBar();
            boutonPagePost = new Button();
            SuspendLayout();
            // 
            // panelInsidePost
            // 
            panelInsidePost.Location = new Point(160, 24);
            panelInsidePost.Name = "panelInsidePost";
            panelInsidePost.Size = new Size(211, 541);
            panelInsidePost.TabIndex = 0;
            // 
            // PanelPulication
            // 
            PanelPulication.AutoScroll = true;
            PanelPulication.Location = new Point(377, 24);
            PanelPulication.Name = "PanelPulication";
            PanelPulication.Size = new Size(366, 550);
            PanelPulication.TabIndex = 2;
            PanelPulication.Scroll += PanelPulication_Scroll;
            // 
            // ScrollPub
            // 
            ScrollPub.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ScrollPub.Location = new Point(762, 24);
            ScrollPub.Name = "ScrollPub";
            ScrollPub.Size = new Size(19, 550);
            ScrollPub.TabIndex = 3;
            ScrollPub.Scroll += ScrollPub_Scroll;
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
