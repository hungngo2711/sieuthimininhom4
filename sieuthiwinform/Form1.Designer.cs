namespace sieuthiwinform
{
    partial class Form1
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            usertb = new TextBox();
            passtb = new TextBox();
            loginbtn = new Guna.UI2.WinForms.Guna2Button();
            roleCb = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // guna2CircleButton1
            // 
            guna2CircleButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2CircleButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2CircleButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2CircleButton1.FillColor = SystemColors.ActiveCaptionText;
            guna2CircleButton1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            guna2CircleButton1.ForeColor = Color.White;
            guna2CircleButton1.Location = new Point(-124, -3);
            guna2CircleButton1.Name = "guna2CircleButton1";
            guna2CircleButton1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleButton1.Size = new Size(267, 342);
            guna2CircleButton1.TabIndex = 0;
            guna2CircleButton1.Click += guna2CircleButton1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(245, 34);
            label1.Name = "label1";
            label1.Size = new Size(143, 32);
            label1.TabIndex = 1;
            label1.Text = "Đăng Nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(187, 147);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Tài khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(187, 200);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu";
            // 
            // usertb
            // 
            usertb.Location = new Point(265, 144);
            usertb.Name = "usertb";
            usertb.Size = new Size(165, 23);
            usertb.TabIndex = 4;
            // 
            // passtb
            // 
            passtb.Location = new Point(265, 192);
            passtb.Name = "passtb";
            passtb.Size = new Size(165, 23);
            passtb.TabIndex = 5;
            // 
            // loginbtn
            // 
            loginbtn.BorderRadius = 15;
            loginbtn.CustomizableEdges = customizableEdges2;
            loginbtn.DisabledState.BorderColor = Color.DarkGray;
            loginbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            loginbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            loginbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            loginbtn.FillColor = Color.FromArgb(255, 192, 255);
            loginbtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            loginbtn.ForeColor = Color.White;
            loginbtn.Location = new Point(265, 245);
            loginbtn.Name = "loginbtn";
            loginbtn.ShadowDecoration.CustomizableEdges = customizableEdges3;
            loginbtn.Size = new Size(151, 48);
            loginbtn.TabIndex = 6;
            loginbtn.Text = "Đăng nhập";
            loginbtn.Click += loginbtn_Click;
            // 
            // roleCb
            // 
            roleCb.FormattingEnabled = true;
            roleCb.Items.AddRange(new object[] { "Nhân viên", "Admin" });
            roleCb.Location = new Point(265, 106);
            roleCb.Name = "roleCb";
            roleCb.Size = new Size(165, 23);
            roleCb.TabIndex = 7;
            roleCb.Text = "Chọn ";
            roleCb.SelectionChangeCommitted += roleCb_SelectionChangeCommitted;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(461, 9);
            label4.Name = "label4";
            label4.Size = new Size(14, 15);
            label4.TabIndex = 8;
            label4.Text = "X";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(505, 337);
            Controls.Add(label4);
            Controls.Add(roleCb);
            Controls.Add(loginbtn);
            Controls.Add(passtb);
            Controls.Add(usertb);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(guna2CircleButton1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox usertb;
        private TextBox passtb;
        private Guna.UI2.WinForms.Guna2Button loginbtn;
        private ComboBox roleCb;
        private Label label4;
    }
}