using deepFake.UIElements.Basic;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Acceuil));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ScrollPub = new VScrollBar();
            PanelLoadForm = new Panel();
            PanelPrincipale = new TransparentPanel();
            PanelPrincipale.SuspendLayout();
            SuspendLayout();
            // 
            // ScrollPub
            // 
            ScrollPub.Location = new Point(584, 0);
            ScrollPub.Name = "ScrollPub";
            ScrollPub.Size = new Size(17, 550);
            ScrollPub.TabIndex = 0;
            // 
            // PanelLoadForm
            // 
            PanelLoadForm.AutoSize = true;
            PanelLoadForm.Location = new Point(12, 8);
            PanelLoadForm.Name = "PanelLoadForm";
            PanelLoadForm.Size = new Size(200, 100);
            PanelLoadForm.TabIndex = 0;
            // 
            // PanelPrincipale
            // 
            PanelPrincipale.BackColor = Color.Transparent;
            PanelPrincipale.Controls.Add(PanelLoadForm);
            PanelPrincipale.Dock = DockStyle.Fill;
            PanelPrincipale.Location = new Point(0, 0);
            PanelPrincipale.Margin = new Padding(5);
            PanelPrincipale.Name = "PanelPrincipale";
            PanelPrincipale.Padding = new Padding(5);
            PanelPrincipale.Size = new Size(1904, 1041);
            PanelPrincipale.TabIndex = 1;
            // 
            // Acceuil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1904, 1041);
            ControlBox = false;
            Controls.Add(PanelPrincipale);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "Acceuil";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form1";
            PanelPrincipale.ResumeLayout(false);
            PanelPrincipale.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private VScrollBar ScrollPub;
        private Panel PanelLoadForm;
        private TransparentPanel PanelPrincipale;
    }
}
