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
            PanelSigning = new Panel();
            PasswordTXB = new TextBox();
            UsernameTXB = new TextBox();
            LoginBTN = new Button();
            label1 = new Label();
            ResultLBL = new Label();
            label2 = new Label();
            PanelSigning.SuspendLayout();
            SuspendLayout();
            // 
            // PanelSigning
            // 
            PanelSigning.BorderStyle = BorderStyle.FixedSingle;
            PanelSigning.Controls.Add(label2);
            PanelSigning.Controls.Add(ResultLBL);
            PanelSigning.Controls.Add(label1);
            PanelSigning.Controls.Add(LoginBTN);
            PanelSigning.Controls.Add(UsernameTXB);
            PanelSigning.Controls.Add(PasswordTXB);
            PanelSigning.Location = new Point(12, 12);
            PanelSigning.Name = "PanelSigning";
            PanelSigning.Size = new Size(347, 444);
            PanelSigning.TabIndex = 4;
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
            // UsernameTXB
            // 
            UsernameTXB.Location = new Point(39, 250);
            UsernameTXB.Name = "UsernameTXB";
            UsernameTXB.Size = new Size(276, 23);
            UsernameTXB.TabIndex = 0;
            UsernameTXB.Text = "Username";
            UsernameTXB.Enter += UsernameTXB_Enter;
            // 
            // LoginBTN
            // 
            LoginBTN.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginBTN.Location = new Point(98, 329);
            LoginBTN.Name = "LoginBTN";
            LoginBTN.Size = new Size(139, 46);
            LoginBTN.TabIndex = 3;
            LoginBTN.Text = "Login";
            LoginBTN.UseVisualStyleBackColor = true;
            LoginBTN.Click += LoginBTN_Click;
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
            // ResultLBL
            // 
            ResultLBL.AutoSize = true;
            ResultLBL.Location = new Point(160, 329);
            ResultLBL.Name = "ResultLBL";
            ResultLBL.Size = new Size(0, 15);
            ResultLBL.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(138, 412);
            label2.Name = "label2";
            label2.Size = new Size(66, 21);
            label2.TabIndex = 5;
            label2.Text = "Go Back";
            label2.Click += label2_Click;
            // 
            // Signing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 476);
            Controls.Add(PanelSigning);
            Name = "Signing";
            Text = "Signing";
            PanelSigning.ResumeLayout(false);
            PanelSigning.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelSigning;
        private Label label2;
        private Label ResultLBL;
        private Label label1;
        private Button LoginBTN;
        private TextBox UsernameTXB;
        private TextBox PasswordTXB;
    }
}