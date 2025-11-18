namespace epood_igor
{
    partial class KassaForm
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
            dataGridProducts = new DataGridView();
            numKogus = new NumericUpDown();
            btnLisa = new Button();
            dataGridCheck = new DataGridView();
            btnLooCheck = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numKogus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridCheck).BeginInit();
            SuspendLayout();
            // 
            // dataGridProducts
            // 
            dataGridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProducts.Location = new Point(33, 62);
            dataGridProducts.Name = "dataGridProducts";
            dataGridProducts.Size = new Size(334, 150);
            dataGridProducts.TabIndex = 0;
            // 
            // numKogus
            // 
            numKogus.Location = new Point(247, 244);
            numKogus.Name = "numKogus";
            numKogus.Size = new Size(120, 23);
            numKogus.TabIndex = 1;
            // 
            // btnLisa
            // 
            btnLisa.Location = new Point(713, 218);
            btnLisa.Name = "btnLisa";
            btnLisa.Size = new Size(75, 23);
            btnLisa.TabIndex = 2;
            btnLisa.Text = "Salvesta";
            btnLisa.UseVisualStyleBackColor = true;
            btnLisa.Click += btnLooCheck_Click;
            // 
            // dataGridCheck
            // 
            dataGridCheck.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCheck.Location = new Point(441, 62);
            dataGridCheck.Name = "dataGridCheck";
            dataGridCheck.Size = new Size(347, 150);
            dataGridCheck.TabIndex = 3;
            // 
            // btnLooCheck
            // 
            btnLooCheck.Location = new Point(33, 242);
            btnLooCheck.Name = "btnLooCheck";
            btnLooCheck.Size = new Size(75, 23);
            btnLooCheck.TabIndex = 4;
            btnLooCheck.Text = "Loo tšekki";
            btnLooCheck.UseVisualStyleBackColor = true;
            btnLooCheck.Click += btnLisa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(33, 22);
            label1.Name = "label1";
            label1.Size = new Size(161, 37);
            label1.TabIndex = 5;
            label1.Text = "Toiduained :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F);
            label2.Location = new Point(441, 22);
            label2.Name = "label2";
            label2.Size = new Size(116, 37);
            label2.TabIndex = 6;
            label2.Text = "Tšekkid :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(177, 246);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 7;
            label3.Text = "Kogus:";
            // 
            // KassaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLooCheck);
            Controls.Add(dataGridCheck);
            Controls.Add(btnLisa);
            Controls.Add(numKogus);
            Controls.Add(dataGridProducts);
            Name = "KassaForm";
            Text = "KassaForm";
            ((System.ComponentModel.ISupportInitialize)dataGridProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)numKogus).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridCheck).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridProducts;
        private NumericUpDown numKogus;
        private Button btnLisa;
        private DataGridView dataGridCheck;
        private Button btnLooCheck;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}