using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Metadata;
using System.Windows.Forms;

namespace epood_igor
{
    public partial class KassaForm : Form
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=C:\Users\opilane\source\repos\SQL-C-\epood-igor\Toode_DB.mdf;
            Integrated Security=True;");

        DataTable ostuTabel = new DataTable();

        public KassaForm()
        {
            InitializeComponent();

            ostuTabel.Columns.Add("Toode");
            ostuTabel.Columns.Add("Kogus", typeof(int));
            ostuTabel.Columns.Add("Hind", typeof(decimal));
            ostuTabel.Columns.Add("Summa", typeof(decimal));

            dataGridCheck.DataSource = ostuTabel;

            LaeTooted();
        }

        private void LaeTooted()
        {
            connect.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT Id, Toodenimetus, Hind FROM ToodeTabel", connect);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connect.Close();

            dataGridProducts.DataSource = dt;
        }

        private void btnLisa_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Vali toode!");
                return;
            }

            string toode = dataGridProducts.CurrentRow.Cells["Toodenimetus"].Value.ToString();
            decimal hind = Convert.ToDecimal(dataGridProducts.CurrentRow.Cells["Hind"].Value);
            int kogus = (int)numKogus.Value;

            ostuTabel.Rows.Add(toode, kogus, hind, hind * kogus);
        }

        private void btnLooCheck_Click(object sender, EventArgs e)
        {
            if (dataGridProducts.CurrentRow == null)
            {
                MessageBox.Show("Vali toode!");
                return;
            }

            int tooteId = Convert.ToInt32(dataGridProducts.CurrentRow.Cells["Id"].Value);
            int kogus = (int)numKogus.Value; // количество, которое выбрал клиент

            if (kogus <= 0)
            {
                MessageBox.Show("Kogus peab olema vähemalt 1!");
                return;
            }

            // Проверяем наличие на складе
            connect.Open();
            SqlCommand c = new SqlCommand("SELECT Kogus FROM ToodeTabel WHERE Id=@id", connect);
            c.Parameters.AddWithValue("@id", tooteId);
            int laos = Convert.ToInt32(c.ExecuteScalar());
            connect.Close();

            if (kogus > laos)
            {
                MessageBox.Show($"Laos on ainult {laos} tk seda toodet!");
                return;
            }

            string nimetus = dataGridProducts.CurrentRow.Cells["Toodenimetus"].Value.ToString();
            decimal hind = Convert.ToDecimal(dataGridProducts.CurrentRow.Cells["Hind"].Value);

            ostuTabel.Rows.Add(nimetus, kogus, hind, hind * kogus);
        }
    }
}