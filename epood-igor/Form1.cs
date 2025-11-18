using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Data.SqlClient;
using System.Numerics;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace epood_igor
{
    public partial class Form1 : Form
    {


        SqlCommand command;
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\SQL-C-\epood-igor\Toode_DB.mdf;Integrated Security=True;Integrated Security=True;");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        public Form1()
        {
            InitializeComponent();
            NaitaKategooriad();
            NaitaAndmed();
        }
        public void NaitaAndmed()
        {
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT ToodeTabel.Id,ToodeTabel.Toodenimetus,ToodeTabel.Kogus,"
                + "ToodeTabel.Hind, ToodeTabel.Pilt, ToodeTabel.Bpilt, KategooriaTabel.Kategooria_nimetus" +
                " as Kategooria_nimetus FROM Toodetabel INNER JOIN KategooriaTabel on Toodetabel.Kategooriad=KategooriaTabel.Id", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.DataPropertyName = "Kategooria_nimetus";
            HashSet<string> keys = new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string kat_n = item["Kategooria_nimetus"].ToString();
                if (!keys.Contains(kat_n))
                {
                    keys.Add(kat_n);
                    combo_kat.Items.Add(kat_n);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            Toode_pb.Image = Image.FromFile(Path.Combine(Path.GetFullPath(@"C:\Users\opilane\source\repos\SQL-C-\epood-igor\Pildid"), "goofy.jpg"));
            connect.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        Form popupForm;
        private void Loopilt(Image image, int r)
        {
            popupForm = new Form();
            popupForm.FormBorderStyle = FormBorderStyle.None;
            popupForm.StartPosition = FormStartPosition.Manual;
            popupForm.Size = new Size(200, 200);

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            popupForm.Controls.Add(pictureBox);

            System.Drawing.Rectangle cellRectangle = dataGridView1.GetCellDisplayRectangle(4, r, true);
            System.Drawing.Point popupLocation = dataGridView1.PointToScreen(cellRectangle.Location);

            popupForm.Location = new System.Drawing.Point(popupLocation.X + cellRectangle.Width, popupLocation.Y);
            popupForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Loopilt(image, e.RowIndex);
                    }
                }
            }
        }


        private void kustuta_btn_Click(object sender, EventArgs e)
        {
            if (Kat_Box.SelectedItem != null)
            {
                connect.Open();
                string kat_val = Kat_Box.SelectedItem.ToString();
                command = new SqlCommand("DELETE FROM KategooriaTabel where Kategooria_nimetus=@kat", connect);
                command.Parameters.AddWithValue("@kat", kat_val);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_Box.Items.Clear();
                NaitaKategooriad();
            }
        }
        private SaveFileDialog? _saveFileDialog;
        private OpenFileDialog? _openFileDialog;
        private void button6_Click(object sender, EventArgs e)
        {
            // Identify selected product (based on clicked row)
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vali vähemalt üks tooterida, mida uuendada!");
                return;
            }

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Id"].Value);
            if (id <= 0)
            {
                MessageBox.Show("Vale ID väärtus!");
                return;
            }

            try
            {
                if (connect.State != ConnectionState.Open)
                    connect.Open();

                // --- Build dynamic UPDATE statement ---
                List<string> updateFields = new List<string>();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;

                // Update only fields the user provided
                if (!string.IsNullOrWhiteSpace(Toode_txt.Text))
                {
                    updateFields.Add("Toodenimetus=@toode");
                    cmd.Parameters.AddWithValue("@toode", Toode_txt.Text.Trim());
                }

                if (!string.IsNullOrWhiteSpace(Kogus_txt.Text))
                {
                    if (int.TryParse(Kogus_txt.Text, out int kogus))
                    {
                        updateFields.Add("Kogus=@kogus");
                        cmd.Parameters.AddWithValue("@kogus", kogus);
                    }
                    else
                    {
                        MessageBox.Show("Kogus peab olema arv!");
                        connect.Close();
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(Hind_txt.Text))
                {
                    if (decimal.TryParse(
                            Hind_txt.Text.Replace(',', '.'),
                            System.Globalization.NumberStyles.Any,
                            System.Globalization.CultureInfo.InvariantCulture,
                            out decimal hind))
                    {
                        updateFields.Add("Hind=@hind");
                        cmd.Parameters.AddWithValue("@hind", hind);
                    }
                    else
                    {
                        MessageBox.Show("Hind peab olema number!");
                        connect.Close();
                        return;
                    }
                }

                if (Toode_pb.Image != null && _openFileDialog != null && !string.IsNullOrEmpty(_openFileDialog.FileName))
                {
                    if (File.Exists(_openFileDialog.FileName))
                    {
                        string ext = Path.GetExtension(_openFileDialog.FileName);
                        string fileName = Toode_txt.Text.Trim() + ext;

                        updateFields.Add("Pilt=@pilt, Bpilt=@bpilt");

                        byte[] imageBytes = File.ReadAllBytes(_openFileDialog.FileName);
                        cmd.Parameters.AddWithValue("@pilt", fileName);
                        cmd.Parameters.AddWithValue("@bpilt", imageBytes);
                    }
                }

                // Update category if selected
                if (Kat_Box.SelectedItem != null)
                {
                    updateFields.Add("Kategooriad=@kat");
                    SqlCommand getCatCmd = new SqlCommand("SELECT Id FROM KategooriaTabel WHERE Kategooria_nimetus=@nim", connect);
                    getCatCmd.Parameters.AddWithValue("@nim", Kat_Box.Text);
                    int katId = Convert.ToInt32(getCatCmd.ExecuteScalar());
                    cmd.Parameters.AddWithValue("@kat", katId);
                }

                // --- Execute update if there are any fields to modify ---
                if (updateFields.Count == 0)
                {
                    MessageBox.Show("Pole midagi uuendada! Täida vähemalt üks väli.");
                    connect.Close();
                    return;
                }

                string updateQuery =
                    "UPDATE ToodeTabel SET " +
                    string.Join(", ", updateFields) +
                    " WHERE Id=@id";

                cmd.CommandText = updateQuery;
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                connect.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Toote andmed on uuendatud!");
                    NaitaAndmed();
                }
                else
                {
                    MessageBox.Show("Uuendus ebaõnnestus — kontrolli andmeid!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Viga andmete uuendamisel: " + ex.Message);
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lisakat_btn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in Kat_Box.Items)
            {
                if (item.ToString() == Kat_Box.Text)
                {
                    on = true;
                }

            }
            if (on == false)
            {
                command = new SqlCommand("INSERT INTO KategooriaTabel (Kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", Kat_Box.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Kat_Box.Items.Clear();
                NaitaKategooriad();
            }
            else
            {
                MessageBox.Show("Selline kategooriat on juba olemas!");
            }
        }

        private void NaitaKategooriad()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, Kategooria_nimetus FROM KategooriaTabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!Kat_Box.Items.Contains(item["Kategooria_nimetus"]))
                {
                    Kat_Box.Items.Add(item["Kategooria_nimetus"]);
                }
                else
                {
                    command = new SqlCommand("DELETE FROM KategooriaTabel where Id=@id", connect);
                    command.Parameters.AddWithValue("@id", item["id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }

        SaveFileDialog save;
        OpenFileDialog open;
        string extension = null;
        private void otsi_fail_btn_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\source\repos\epood - igor\Pildid";
            open.Multiselect = true;
            open.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;)|*.jpg;*.jpeg;*.png;*.gif;";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\source\repos\epood - igor\Pildid\" + open.FileName);
            if (open.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\Pildid");
                save.FileName = Toode_txt.Text + Path.GetExtension(open.FileName);
                save.Filter = "Images" + Path.GetExtension(open.FileName) + "|*" + Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK && Toode_txt.Text != null)
                {
                    File.Copy(open.FileName, save.FileName);
                    Toode_pb.Image = Image.FromFile(save.FileName);

                }
            }
            else
            {
                MessageBox.Show("Palun sisesta toote nimi!");
            }
        }
        byte[] imageData;


        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {

        }
        int Id = 0;
        private void lisa_btn_Click(object sender, EventArgs e)
        {
            if (Toode_txt.Text.Trim() != string.Empty &&
                Kogus_txt.Text.Trim() != string.Empty &&
                Hind_txt.Text.Trim() != string.Empty && Kat_Box.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("SELECT Id FROM KategooriaTabel where Kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", Kat_Box.Text);
                    command.ExecuteNonQuery();
                    Id = Convert.ToInt32(command.ExecuteScalar());
                    command = new SqlCommand("INSERT INTO Toodetabel (Toodenimetus, Kogus, Hind, Pilt, Bpilt, Kategooriad) " +
                        "VALUES (@toode, @kogus, @hind, @pilt, @bpilt, @kat)", connect);
                    command.Parameters.AddWithValue("@toode", Toode_txt.Text);
                    command.Parameters.AddWithValue("@kogus", Kogus_txt.Text);
                    command.Parameters.AddWithValue("@hind", Hind_txt.Text);
                    extension = Path.GetExtension(open.FileName);
                    command.Parameters.AddWithValue("@pilt", Toode_txt.Text + extension);
                    imageData = File.ReadAllBytes(open.FileName);
                    command.Parameters.AddWithValue("@bpilt", imageData);
                    command.Parameters.AddWithValue("@kat", Id);
                    command.ExecuteNonQuery();
                    connect.Close();
                    NaitaAndmed();
                }
                catch (Exception)
                {
                    MessageBox.Show("Andmebaasiga viga");
                }
            }
        }

        private void dataGridView1_MouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                imageData = dataGridView1.Rows[e.RowIndex].Cells["Bpilt"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);
                        Loopilt(image, e.RowIndex);
                    }
                }
            }
        }

        private void kustuta_btn_Click_1(System.Object? sender, System.EventArgs e)

        {
            Id = Convert.ToInt32(dataGridView1.CurrentRow?.Cells["Id"].Value);
            MessageBox.Show(Id.ToString());
            if (Id != 0)
            {
                command = new SqlCommand("DELETE FROM ToodeTabel WHERE Id=@id", connect);
                connect.Open();
                command.Parameters.AddWithValue("@id", Id);
                command.ExecuteNonQuery();
                connect.Close();
                NaitaAndmed();
                MessageBox.Show("Toode on kustutatud!");
            }
            else
            {
                MessageBox.Show("Vali toode, mida kustutada soovid!");
            }
        }

        private void puhasta_btn_Click(object sender, EventArgs e)
        {
            Toode_txt.Text = "";
            Kogus_txt.Text = "";
            Hind_txt.Text = "";
            Kat_Box.SelectedItem = null;
            using (FileStream fs = new FileStream(Path.Combine(Path.GetFullPath(@"..\..\..\Pildid"), "epood.png"), FileMode.Open, FileAccess.Read))
            {
                Toode_pb.Image = Image.FromStream(fs);
            }
        }

        private void Toode_pb_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            KassaForm k = new KassaForm();
            k.ShowDialog();
        }
    }
}   

