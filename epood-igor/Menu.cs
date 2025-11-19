using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace epood_igor
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();

            // проверяем роль
            if (LoginForm.AktiivneRoll == "Omanik")
            {
                btnTooted.Enabled = true;
                btnKassa.Enabled = true;
            }
            else if (LoginForm.AktiivneRoll == "Müüja")
            {
                btnTooted.Enabled = false; // запретить доступ к Form1
                btnKassa.Enabled = true;
            }
        }

        private void btnTooted_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1(); // Tooted
            f.ShowDialog();
        }

        private void btnKassa_Click(object sender, EventArgs e)
        {
            KassaForm k = new KassaForm();
            k.ShowDialog();
        }
    }
}