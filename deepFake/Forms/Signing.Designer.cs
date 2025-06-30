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
            FormPanel = new Panel();
            flowPanelForm = new FlowLayoutPanel();
            panel2 = new Panel();
            label3 = new Label();
            GrosLogo = new Panel();
            PhraseIntro = new Panel();
            LeftSidePanel = new Panel();
            RightSidePanel = new Panel();
            FormPanel.SuspendLayout();
            flowPanelForm.SuspendLayout();
            panel2.SuspendLayout();
            LeftSidePanel.SuspendLayout();
            RightSidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // FormPanel
            // 
            FormPanel.BackColor = Color.White;
            FormPanel.Controls.Add(flowPanelForm);
            FormPanel.Location = new Point(163, 136);
            FormPanel.Name = "FormPanel";
            FormPanel.Size = new Size(672, 609);
            FormPanel.TabIndex = 5;
            // 
            // flowPanelForm
            // 
            flowPanelForm.BackColor = Color.Transparent;
            flowPanelForm.Controls.Add(panel2);
            flowPanelForm.FlowDirection = FlowDirection.TopDown;
            flowPanelForm.Location = new Point(90, 50);
            flowPanelForm.Name = "flowPanelForm";
            flowPanelForm.Size = new Size(476, 492);
            flowPanelForm.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(473, 121);
            panel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Constantia", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(134, 15);
            label3.Name = "label3";
            label3.Size = new Size(193, 78);
            label3.TabIndex = 0;
            label3.Text = "Login";
            // 
            // GrosLogo
            // 
            GrosLogo.BackColor = Color.Transparent;
            GrosLogo.BackgroundImageLayout = ImageLayout.Zoom;
            GrosLogo.Location = new Point(3, 3);
            GrosLogo.Name = "GrosLogo";
            GrosLogo.Size = new Size(445, 181);
            GrosLogo.TabIndex = 6;
            // 
            // PhraseIntro
            // 
            PhraseIntro.BackColor = Color.Transparent;
            PhraseIntro.BackgroundImageLayout = ImageLayout.Zoom;
            PhraseIntro.Location = new Point(198, 255);
            PhraseIntro.Name = "PhraseIntro";
            PhraseIntro.Size = new Size(463, 141);
            PhraseIntro.TabIndex = 7;
            // 
            // LeftSidePanel
            // 
            LeftSidePanel.BackColor = Color.White;
            LeftSidePanel.Controls.Add(GrosLogo);
            LeftSidePanel.Controls.Add(PhraseIntro);
            LeftSidePanel.Location = new Point(3, 3);
            LeftSidePanel.Name = "LeftSidePanel";
            LeftSidePanel.Size = new Size(469, 867);
            LeftSidePanel.TabIndex = 8;
            // 
            // RightSidePanel
            // 
            RightSidePanel.Controls.Add(FormPanel);
            RightSidePanel.Location = new Point(478, 3);
            RightSidePanel.Name = "RightSidePanel";
            RightSidePanel.Size = new Size(957, 867);
            RightSidePanel.TabIndex = 9;
            // 
            // Signing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1432, 866);
            Controls.Add(RightSidePanel);
            Controls.Add(LeftSidePanel);
            Name = "Signing";
            Text = "Signing";
            FormPanel.ResumeLayout(false);
            flowPanelForm.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            LeftSidePanel.ResumeLayout(false);
            RightSidePanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel FormPanel;
        private FlowLayoutPanel flowPanelForm;
        private Panel panel2;
        private Label label3;
        private Panel GrosLogo;
        private Panel PhraseIntro;
        private Panel LeftSidePanel;
        private Panel RightSidePanel;
    }
}