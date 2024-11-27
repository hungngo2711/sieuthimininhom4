namespace sieuthiwinform
{
    partial class Splash
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            progessbarid = new Guna.UI2.WinForms.Guna2ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 128, 255);
            label1.Location = new Point(137, 38);
            label1.Name = "label1";
            label1.Size = new Size(163, 32);
            label1.TabIndex = 2;
            label1.Text = "Siêu Thị Mini";
            // 
            // progessbarid
            // 
            progessbarid.CustomizableEdges = customizableEdges1;
            progessbarid.ForeColor = SystemColors.ControlText;
            progessbarid.Location = new Point(0, 287);
            progessbarid.Name = "progessbarid";
            progessbarid.ProgressColor = Color.FromArgb(94, 148, 255);
            progessbarid.ShadowDecoration.CustomizableEdges = customizableEdges2;
            progessbarid.Size = new Size(485, 10);
            progessbarid.TabIndex = 3;
            progessbarid.Text = "guna2ProgressBar1";
            progessbarid.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            progessbarid.ValueChanged += guna2ProgressBar1_ValueChanged;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Splash
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 298);
            Controls.Add(progessbarid);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Splash";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2ProgressBar progessbarid;
        private System.Windows.Forms.Timer timer1;
    }
}