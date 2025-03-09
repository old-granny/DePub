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
            PanelLoadForm = new Panel();
            ScrollPub = new VScrollBar();
            SuspendLayout();
            // 
            // PanelLoadForm
            // 
            PanelLoadForm.Location = new Point(0, 0);
            PanelLoadForm.Margin = new Padding(3, 4, 3, 4);
            PanelLoadForm.Name = "PanelLoadForm";
            PanelLoadForm.Size = new Size(2010, 1061);
            PanelLoadForm.TabIndex = 0;
            // 
            // ScrollPub
            // 
            ScrollPub.Location = new Point(584, 0);
            ScrollPub.Name = "ScrollPub";
            ScrollPub.Size = new Size(17, 550);
            ScrollPub.TabIndex = 0;
            // 
            // Acceuil
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(PanelLoadForm);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Acceuil";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel PanelLoadForm;
        private VScrollBar ScrollPub;
    }
}
