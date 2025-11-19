using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epood_igor
{
    public partial class LoginForm : Form
    {
        SqlConnection connect = new SqlConnection(
            @"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\opilane\source\repos\SQL-C-\epood-igor\Toode_DB.mdf;
        Integrated Security=True;");

        public static string AktiivneRoll = "";

        public LoginForm() { InitializeComponent(); }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT Roll FROM Kasutajad WHERE Kasutajanimi=@u AND Parool=@p", connect);

            cmd.Parameters.AddWithValue("@u", tbUser.Text);
            cmd.Parameters.AddWithValue("@p", tbPass.Text);

            object rollObj = cmd.ExecuteScalar();
            connect.Close();

            if (rollObj == null)
            {
                MessageBox.Show("Vale kasutajanimi või parool!");
                return;
            }

            AktiivneRoll = rollObj.ToString();

            // Переходим в главное меню
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}