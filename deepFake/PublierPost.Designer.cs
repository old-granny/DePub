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
            AddImageLBL = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            CancelBTN = new Button();
            boutonPost = new Button();
            Titre = new TextBox();
            Contenue = new TextBox();
            panel1 = new Panel();
            panelContenuePost.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenuePost
            // 
            panelContenuePost.BackColor = SystemColors.ControlLight;
            panelContenuePost.BorderStyle = BorderStyle.FixedSingle;
            panelContenuePost.Controls.Add(AddImageLBL);
            panelContenuePost.Controls.Add(flowLayoutPanel1);
            panelContenuePost.Controls.Add(CancelBTN);
            panelContenuePost.Controls.Add(boutonPost);
            panelContenuePost.Controls.Add(Titre);
            panelContenuePost.Controls.Add(Contenue);
            panelContenuePost.Location = new Point(24, 23);
            panelContenuePost.Margin = new Padding(3, 4, 3, 4);
            panelContenuePost.Name = "panelContenuePost";
            panelContenuePost.Size = new Size(1245, 690);
            panelContenuePost.TabIndex = 4;
            // 
            // AddImageLBL
            // 
            AddImageLBL.AutoSize = true;
            AddImageLBL.BackColor = SystemColors.ButtonFace;
            AddImageLBL.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddImageLBL.Location = new Point(816, 579);
            AddImageLBL.Name = "AddImageLBL";
            AddImageLBL.Size = new Size(103, 25);
            AddImageLBL.TabIndex = 4;
            AddImageLBL.Text = "Add Image";
            AddImageLBL.Click += label1_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = SystemColors.ButtonFace;
            flowLayoutPanel1.Location = new Point(482, 4);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(758, 571);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // CancelBTN
            // 
            CancelBTN.Location = new Point(480, 646);
            CancelBTN.Margin = new Padding(3, 4, 3, 4);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new Size(762, 31);
            CancelBTN.TabIndex = 3;
            CancelBTN.Text = "Cancel";
            CancelBTN.UseVisualStyleBackColor = true;
            CancelBTN.Click += CancelBTN_Click;
            // 
            // boutonPost
            // 
            boutonPost.Location = new Point(478, 609);
            boutonPost.Margin = new Padding(3, 4, 3, 4);
            boutonPost.Name = "boutonPost";
            boutonPost.Size = new Size(762, 31);
            boutonPost.TabIndex = 2;
            boutonPost.Text = "publier";
            boutonPost.UseVisualStyleBackColor = true;
            boutonPost.Click += boutonPost_Click;
            // 
            // Titre
            // 
            Titre.Location = new Point(3, 4);
            Titre.Margin = new Padding(3, 4, 3, 4);
            Titre.Name = "Titre";
            Titre.Size = new Size(471, 27);
            Titre.TabIndex = 1;
            Titre.Text = "Titre";
            // 
            // Contenue
            // 
            Contenue.Location = new Point(3, 39);
            Contenue.Margin = new Padding(3, 4, 3, 4);
            Contenue.Multiline = true;
            Contenue.Name = "Contenue";
            Contenue.Size = new Size(471, 638);
            Contenue.TabIndex = 0;
            Contenue.Text = "Contenue";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panelContenuePost);
            panel1.Location = new Point(0, 1);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 728);
            panel1.TabIndex = 5;
            // 
            // PublierPost
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1282, 728);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PublierPost";
            Text = "PublierPost";
            panelContenuePost.ResumeLayout(false);
            panelContenuePost.PerformLayout();
            panel1.ResumeLayout(false);
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