namespace epood_igor
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
            dataGridView1 = new DataGridView();
            Toode_pb = new PictureBox();
            Toode_txt = new TextBox();
            Kat_Box = new ComboBox();
            Kogus_txt = new TextBox();
            Hind_txt = new TextBox();
            lisakat_btn = new Button();
            kustutakat_btn = new Button();
            puhasta_btn = new Button();
            otsi_fail_btn = new Button();
            kustuta_btn = new Button();
            uuenda_btn = new Button();
            lisa_btn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Toode_pb).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(150, 296);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(616, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.MouseLeave += dataGridView1_MouseLeave;
            // 
            // Toode_pb
            // 
            Toode_pb.BackColor = SystemColors.ButtonFace;
            Toode_pb.Location = new Point(312, 40);
            Toode_pb.Name = "Toode_pb";
            Toode_pb.Size = new Size(454, 173);
            Toode_pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Toode_pb.TabIndex = 1;
            Toode_pb.TabStop = false;
            // 
            // Toode_txt
            // 
            Toode_txt.Location = new Point(150, 45);
            Toode_txt.Name = "Toode_txt";
            Toode_txt.Size = new Size(156, 23);
            Toode_txt.TabIndex = 2;
            // 
            // Kat_Box
            // 
            Kat_Box.FormattingEnabled = true;
            Kat_Box.Location = new Point(150, 190);
            Kat_Box.Name = "Kat_Box";
            Kat_Box.Size = new Size(156, 23);
            Kat_Box.TabIndex = 3;
            // 
            // Kogus_txt
            // 
            Kogus_txt.Location = new Point(150, 95);
            Kogus_txt.Name = "Kogus_txt";
            Kogus_txt.Size = new Size(156, 23);
            Kogus_txt.TabIndex = 4;
            // 
            // Hind_txt
            // 
            Hind_txt.Location = new Point(150, 147);
            Hind_txt.Name = "Hind_txt";
            Hind_txt.Size = new Size(156, 23);
            Hind_txt.TabIndex = 5;
            // 
            // lisakat_btn
            // 
            lisakat_btn.Location = new Point(150, 238);
            lisakat_btn.Name = "lisakat_btn";
            lisakat_btn.Size = new Size(156, 23);
            lisakat_btn.TabIndex = 6;
            lisakat_btn.Text = "Lisa kategooriad";
            lisakat_btn.UseVisualStyleBackColor = true;
            lisakat_btn.Click += lisakat_btn_Click;
            // 
            // kustutakat_btn
            // 
            kustutakat_btn.Location = new Point(312, 238);
            kustutakat_btn.Name = "kustutakat_btn";
            kustutakat_btn.Size = new Size(156, 23);
            kustutakat_btn.TabIndex = 7;
            kustutakat_btn.Text = "Kustuta kategooriad";
            kustutakat_btn.UseVisualStyleBackColor = true;
            kustutakat_btn.Click += kustuta_btn_Click;
            // 
            // puhasta_btn
            // 
            puhasta_btn.Location = new Point(393, 267);
            puhasta_btn.Name = "puhasta_btn";
            puhasta_btn.Size = new Size(75, 23);
            puhasta_btn.TabIndex = 8;
            puhasta_btn.Text = "Puhasta";
            puhasta_btn.UseVisualStyleBackColor = true;
            // 
            // otsi_fail_btn
            // 
            otsi_fail_btn.Location = new Point(691, 238);
            otsi_fail_btn.Name = "otsi_fail_btn";
            otsi_fail_btn.Size = new Size(75, 23);
            otsi_fail_btn.TabIndex = 9;
            otsi_fail_btn.Text = "Otsi fail";
            otsi_fail_btn.UseVisualStyleBackColor = true;
            otsi_fail_btn.Click += otsi_fail_btn_Click;
            // 
            // kustuta_btn
            // 
            kustuta_btn.Location = new Point(312, 267);
            kustuta_btn.Name = "kustuta_btn";
            kustuta_btn.Size = new Size(75, 23);
            kustuta_btn.TabIndex = 12;
            kustuta_btn.Text = "Kustuta";
            kustuta_btn.UseVisualStyleBackColor = true;
            // 
            // uuenda_btn
            // 
            uuenda_btn.Location = new Point(231, 267);
            uuenda_btn.Name = "uuenda_btn";
            uuenda_btn.Size = new Size(75, 23);
            uuenda_btn.TabIndex = 11;
            uuenda_btn.Text = "Uuenda";
            uuenda_btn.UseVisualStyleBackColor = true;
            uuenda_btn.Click += button6_Click;
            // 
            // lisa_btn
            // 
            lisa_btn.Location = new Point(150, 267);
            lisa_btn.Name = "lisa_btn";
            lisa_btn.Size = new Size(75, 23);
            lisa_btn.TabIndex = 10;
            lisa_btn.Text = "Lisa";
            lisa_btn.UseVisualStyleBackColor = true;
            lisa_btn.Click += lisa_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(62, 40);
            label1.Name = "label1";
            label1.Size = new Size(70, 28);
            label1.TabIndex = 13;
            label1.Text = "Toode:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(62, 87);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 14;
            label2.Text = "Kogus:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(74, 144);
            label3.Name = "label3";
            label3.Size = new Size(58, 28);
            label3.TabIndex = 15;
            label3.Text = "Hind:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(8, 185);
            label4.Name = "label4";
            label4.Size = new Size(125, 28);
            label4.TabIndex = 16;
            label4.Text = "Kategooriad:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(kustuta_btn);
            Controls.Add(uuenda_btn);
            Controls.Add(lisa_btn);
            Controls.Add(otsi_fail_btn);
            Controls.Add(puhasta_btn);
            Controls.Add(kustutakat_btn);
            Controls.Add(lisakat_btn);
            Controls.Add(Hind_txt);
            Controls.Add(Kogus_txt);
            Controls.Add(Kat_Box);
            Controls.Add(Toode_txt);
            Controls.Add(Toode_pb);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Toode_pb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private PictureBox Toode_pb;
        private TextBox Toode_txt;
        private ComboBox Kat_Box;
        private TextBox Kogus_txt;
        private TextBox Hind_txt;
        private Button lisakat_btn;
        private Button kustutakat_btn;
        private Button puhasta_btn;
        private Button otsi_fail_btn;
        private Button kustuta_btn;
        private Button uuenda_btn;
        private Button lisa_btn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
