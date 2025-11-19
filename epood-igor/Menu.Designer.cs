namespace epood_igor
{
    partial class Menu
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
            btnTooted = new Button();
            btnKassa = new Button();
            SuspendLayout();
            // 
            // btnTooted
            // 
            btnTooted.Font = new Font("Palatino Linotype", 39.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTooted.Location = new Point(110, 156);
            btnTooted.Name = "btnTooted";
            btnTooted.Size = new Size(238, 109);
            btnTooted.TabIndex = 3;
            btnTooted.Text = "TOODE";
            btnTooted.UseVisualStyleBackColor = true;
            btnTooted.Click += btnTooted_Click;
            // 
            // btnKassa
            // 
            btnKassa.Font = new Font("Palatino Linotype", 39.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnKassa.Location = new Point(483, 156);
            btnKassa.Name = "btnKassa";
            btnKassa.Size = new Size(238, 109);
            btnKassa.TabIndex = 4;
            btnKassa.Text = "KASSA";
            btnKassa.UseVisualStyleBackColor = true;
            btnKassa.Click += btnKassa_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKassa);
            Controls.Add(btnTooted);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTooted;
        private Button btnKassa;
    }
}