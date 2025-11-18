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
            if (ostuTabel.Rows.Count == 0)
            {
                MessageBox.Show("Tšekk on tühi!");
                return;
            }

            // ПОЛНЫЙ путь к папке, куда сохранять PDF
            string folder = @"C:\Users\opilane\source\repos\SQL-C-\epood-igor/Arved";

            // Создаём, если нет
            Directory.CreateDirectory(folder);

            // Имя файла
            string filePath = Path.Combine(folder, $"arve_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            // Создание PDF
            iTextSharp.text.Document pdf = new iTextSharp.text.Document();
            PdfWriter.GetInstance(pdf, new FileStream(filePath, FileMode.Create));
            pdf.Open();

            pdf.Add(new Paragraph("TŠEKK"));
            pdf.Add(new Paragraph("Kuupäev: " + DateTime.Now));
            pdf.Add(new Paragraph(" "));

            PdfPTable tabel = new PdfPTable(4);
            tabel.AddCell("Toode");
            tabel.AddCell("Kogus");
            tabel.AddCell("Hind");
            tabel.AddCell("Summa");

            decimal kokku = 0;

            foreach (DataRow r in ostuTabel.Rows)
            {
                tabel.AddCell(r["Toode"].ToString());
                tabel.AddCell(r["Kogus"].ToString());
                tabel.AddCell(r["Hind"].ToString());
                tabel.AddCell(r["Summa"].ToString());

                kokku += Convert.ToDecimal(r["Summa"]);
            }

            pdf.Add(tabel);
            pdf.Add(new Paragraph(" "));
            pdf.Add(new Paragraph("KOKKU: " + kokku + " €"));
            pdf.Close();

            MessageBox.Show($"Tšekk salvestatud:\n{filePath}");
        }
    }
}