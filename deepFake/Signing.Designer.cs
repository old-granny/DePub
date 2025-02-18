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
            panel1.Location = new Point(68, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(1331, 775);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(638, 575);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
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
            PanelSigning.Location = new Point(495, 111);
            PanelSigning.Name = "PanelSigning";
            PanelSigning.Size = new Size(347, 461);
            PanelSigning.TabIndex = 4;
            // 
            // ResultLBL
            // 
            ResultLBL.AutoSize = true;
            ResultLBL.Location = new Point(160, 329);
            ResultLBL.Name = "ResultLBL";
            ResultLBL.Size = new Size(38, 15);
            ResultLBL.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(109, 67);
            label1.Name = "label1";
            label1.Size = new Size(112, 40);
            label1.TabIndex = 2;
            label1.Text = "Signing";
            // 
            // LoginBTN
            // 
            LoginBTN.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBTN.Location = new Point(109, 373);
            LoginBTN.Name = "LoginBTN";
            LoginBTN.Size = new Size(139, 46);
            LoginBTN.TabIndex = 3;
            LoginBTN.Text = "Login";
            LoginBTN.UseVisualStyleBackColor = true;
            LoginBTN.Click += LoginBTN_Click;
            // 
            // UsernameTXB
            // 
            UsernameTXB.Location = new Point(39, 250);
            UsernameTXB.Name = "UsernameTXB";
            UsernameTXB.Size = new Size(276, 23);
            UsernameTXB.TabIndex = 0;
            UsernameTXB.Text = "Username";
            UsernameTXB.Enter += UsernameTXB_Enter;
            // 
            // PasswordTXB
            // 
            PasswordTXB.Location = new Point(39, 279);
            PasswordTXB.Name = "PasswordTXB";
            PasswordTXB.Size = new Size(276, 23);
            PasswordTXB.TabIndex = 1;
            PasswordTXB.Text = "Password";
            PasswordTXB.Enter += PasswordTXB_Enter;
            // 
            // Signing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1430, 860);
            Controls.Add(panel1);
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