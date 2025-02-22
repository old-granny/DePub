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
            panelContenuePost = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            CancelBTN = new Button();
            boutonPost = new Button();
            Titre = new TextBox();
            Contenue = new TextBox();
            AddImageLBL = new Label();
            panel1 = new Panel();
            panelContenuePost.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenuePost
            // 
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;
            panelContenuePost.Controls.Add(flowLayoutPanel1);
            panelContenuePost.Controls.Add(CancelBTN);
            panelContenuePost.Controls.Add(boutonPost);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Location = new Point(334, 65);
            panelContenuePost.Name = "panelContenuePost";
            panelContenuePost.Size = new Size(608, 505);
            panelContenuePost.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(296, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(307, 444);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // CancelBTN
            // 
            CancelBTN.Location = new Point(293, 479);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new Size(312, 23);
            CancelBTN.TabIndex = 3;
            CancelBTN.Text = "Cancel";
            CancelBTN.UseVisualStyleBackColor = true;
            CancelBTN.Click += CancelBTN_Click;
            // 
            // boutonPost
            // 
            boutonPost.Location = new Point(293, 453);
            boutonPost.Name = "boutonPost";
            boutonPost.Size = new Size(312, 23);
            boutonPost.TabIndex = 2;
            boutonPost.Text = "publier";
            boutonPost.UseVisualStyleBackColor = true;
            boutonPost.Click += boutonPost_Click;
            // 
            // Titre
            // 
            Titre.Location = new Point(3, 3);
            Titre.Name = "Titre";
            Titre.Size = new Size(287, 23);
            Titre.TabIndex = 1;
            Titre.Text = "Titre";
            // 
            // Contenue
            // 
            Contenue.Location = new Point(3, 32);
            Contenue.Multiline = true;
            Contenue.Name = "Contenue";
            Contenue.Size = new Size(287, 470);
            Contenue.TabIndex = 0;
            Contenue.Text = "Contenue";
            // 
            // AddImageLBL
            // 
            AddImageLBL.AutoSize = true;
            AddImageLBL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddImageLBL.Location = new Point(745, 475);
            AddImageLBL.Name = "AddImageLBL";
            AddImageLBL.Size = new Size(83, 20);
            AddImageLBL.TabIndex = 4;
            AddImageLBL.Text = "Add Image";
            AddImageLBL.Click += label1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(AddImageLBL);
            panel1.Controls.Add(panelContenuePost);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1176, 676);
            panel1.TabIndex = 5;
            // 
            // PublierPost
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panel1);
            Name = "PublierPost";
            Text = "PublierPost";
            panelContenuePost.ResumeLayout(false);
            panelContenuePost.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenuePost;
        private Button boutonPost;
        private TextBox Titre;
        private TextBox Contenue;
        private Panel panel1;
        private Button CancelBTN;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label AddImageLBL;
    }
}