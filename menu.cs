using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektNebojša
{
    public partial class menu : Form
    {
        public menu()
        {   
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Artikli otvori = new Artikli();
            otvori.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Narudzba otvori = new Narudzba();
            otvori.Show();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Naplata otvori = new Naplata();
            otvori.Show();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            Promet otvori = new Promet();
            this.Hide();
            otvori.Show();
        }
    }
}
