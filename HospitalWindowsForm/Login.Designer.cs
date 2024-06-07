namespace HospitalWindowsForm
{
    partial class Login
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
            this.btn_simpanLogin = new System.Windows.Forms.Button();
            this.cB_Role = new System.Windows.Forms.ComboBox();
            this.tB_Password = new System.Windows.Forms.TextBox();
            this.tB_Email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cB_password = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_simpanLogin
            // 
            this.btn_simpanLogin.Location = new System.Drawing.Point(437, 442);
            this.btn_simpanLogin.Name = "btn_simpanLogin";
            this.btn_simpanLogin.Size = new System.Drawing.Size(138, 40);
            this.btn_simpanLogin.TabIndex = 17;
            this.btn_simpanLogin.Text = "Login";
            this.btn_simpanLogin.UseVisualStyleBackColor = true;
            this.btn_simpanLogin.Click += new System.EventHandler(this.btn_simpanLogin_Click);
            // 
            // cB_Role
            // 
            this.cB_Role.FormattingEnabled = true;
            this.cB_Role.Items.AddRange(new object[] {
            "Admin",
            "Doctor",
            "Patient"});
            this.cB_Role.Location = new System.Drawing.Point(343, 360);
            this.cB_Role.Name = "cB_Role";
            this.cB_Role.Size = new System.Drawing.Size(150, 28);
            this.cB_Role.TabIndex = 16;
            this.cB_Role.SelectedIndexChanged += new System.EventHandler(this.cB_Role_SelectedIndexChanged);
            // 
            // tB_Password
            // 
            this.tB_Password.Location = new System.Drawing.Point(343, 238);
            this.tB_Password.Name = "tB_Password";
            this.tB_Password.PasswordChar = '*';
            this.tB_Password.Size = new System.Drawing.Size(276, 26);
            this.tB_Password.TabIndex = 15;
            // 
            // tB_Email
            // 
            this.tB_Email.Location = new System.Drawing.Point(343, 153);
            this.tB_Email.Name = "tB_Email";
            this.tB_Email.Size = new System.Drawing.Size(276, 26);
            this.tB_Email.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(338, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Role";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "Login Page";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 535);
            this.panel1.TabIndex = 9;
            // 
            // cB_password
            // 
            this.cB_password.AutoSize = true;
            this.cB_password.Location = new System.Drawing.Point(343, 271);
            this.cB_password.Name = "cB_password";
            this.cB_password.Size = new System.Drawing.Size(148, 24);
            this.cB_password.TabIndex = 18;
            this.cB_password.Text = "Show Password";
            this.cB_password.UseVisualStyleBackColor = true;
            this.cB_password.CheckedChanged += new System.EventHandler(this.cB_password_CheckedChanged);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 536);
            this.Controls.Add(this.cB_password);
            this.Controls.Add(this.btn_simpanLogin);
            this.Controls.Add(this.cB_Role);
            this.Controls.Add(this.tB_Password);
            this.Controls.Add(this.tB_Email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_simpanLogin;
        private System.Windows.Forms.ComboBox cB_Role;
        private System.Windows.Forms.TextBox tB_Password;
        private System.Windows.Forms.TextBox tB_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cB_password;
    }
}

