namespace deepFake
{
    partial class Signing
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
            panel1 = new Panel();
            label2 = new Label();
            PanelSigning = new Panel();
            ResultLBL = new Label();
            label1 = new Label();
            LoginBTN = new Button();
            UsernameTXB = new TextBox();
            PasswordTXB = new TextBox();
            panel1.SuspendLayout();
            PanelSigning.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(PanelSigning);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1282, 728);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(583, 662);
            label2.Name = "label2";
            label2.Size = new Size(83, 28);
            label2.TabIndex = 5;
            label2.Text = "Go Back";
            label2.Click += label2_Click;
            // 
            // PanelSigning
            // 
            PanelSigning.BorderStyle = BorderStyle.FixedSingle;
            PanelSigning.Controls.Add(ResultLBL);
            PanelSigning.Controls.Add(label1);
            PanelSigning.Controls.Add(LoginBTN);
            PanelSigning.Controls.Add(UsernameTXB);
            PanelSigning.Controls.Add(PasswordTXB);
            PanelSigning.Location = new Point(435, 41);
            PanelSigning.Margin = new Padding(3, 4, 3, 4);
            PanelSigning.Name = "PanelSigning";
            PanelSigning.Size = new Size(396, 591);
            PanelSigning.TabIndex = 4;
            // 
            // ResultLBL
            // 
            ResultLBL.AutoSize = true;
            ResultLBL.Location = new Point(183, 439);
            ResultLBL.Name = "ResultLBL";
            ResultLBL.Size = new Size(0, 20);
            ResultLBL.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(125, 89);
            label1.Name = "label1";
            label1.Size = new Size(146, 50);
            label1.TabIndex = 2;
            label1.Text = "Signing";
            // 
            // LoginBTN
            // 
            LoginBTN.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBTN.Location = new Point(125, 497);
            LoginBTN.Margin = new Padding(3, 4, 3, 4);
            LoginBTN.Name = "LoginBTN";
            LoginBTN.Size = new Size(159, 61);
            LoginBTN.TabIndex = 3;
            LoginBTN.Text = "Login";
            LoginBTN.UseVisualStyleBackColor = true;
            LoginBTN.Click += LoginBTN_Click;
            // 
            // UsernameTXB
            // 
            UsernameTXB.Location = new Point(45, 333);
            UsernameTXB.Margin = new Padding(3, 4, 3, 4);
            UsernameTXB.Name = "UsernameTXB";
            UsernameTXB.Size = new Size(315, 27);
            UsernameTXB.TabIndex = 0;
            UsernameTXB.Text = "Username";
            UsernameTXB.Enter += UsernameTXB_Enter;
            // 
            // PasswordTXB
            // 
            PasswordTXB.Location = new Point(45, 372);
            PasswordTXB.Margin = new Padding(3, 4, 3, 4);
            PasswordTXB.Name = "PasswordTXB";
            PasswordTXB.Size = new Size(315, 27);
            PasswordTXB.TabIndex = 1;
            PasswordTXB.Text = "Password";
            PasswordTXB.Enter += PasswordTXB_Enter;
            // 
            // Signing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1282, 728);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Signing";
            Text = "Signing";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            PanelSigning.ResumeLayout(false);
            PanelSigning.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private Panel panel1;
        private TextBox UsernameTXB;
        private Panel PanelSigning;
        private Label label1;
        private Button LoginBTN;
        private TextBox PasswordTXB;
        private Label label2;
        private Label ResultLBL;
    }
}