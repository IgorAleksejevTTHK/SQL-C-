namespace epood_igor
{
    partial class LoginForm
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
            btnLogin = new Button();
            tbUser = new TextBox();
            tbPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(343, 241);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 23);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbUser
            // 
            tbUser.Location = new Point(320, 169);
            tbUser.Name = "tbUser";
            tbUser.Size = new Size(124, 23);
            tbUser.TabIndex = 1;
            // 
            // tbPass
            // 
            tbPass.Location = new Point(320, 198);
            tbPass.Name = "tbPass";
            tbPass.Size = new Size(124, 23);
            tbPass.TabIndex = 2;
            tbPass.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 172);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 3;
            label1.Text = "Kasutaja:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(255, 206);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "Parool:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 50F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(143, 45);
            label3.Name = "label3";
            label3.Size = new Size(475, 82);
            label3.TabIndex = 5;
            label3.Text = "LOGIN FORM";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Webdings", 110F);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(-240, 314);
            label4.Name = "label4";
            label4.Size = new Size(1459, 147);
            label4.TabIndex = 6;
            label4.Text = "LOGIN FORM";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPass);
            Controls.Add(tbUser);
            Controls.Add(btnLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private TextBox tbUser;
        private TextBox tbPass;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}