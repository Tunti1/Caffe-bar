using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjektNebojša
{
    public partial class Artikli : Form
    {
        public Artikli()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu otvori = new menu();
            otvori.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();
            con.Open();
            string zadatak = "INSERT INTO Artikli (Sifra, Naziv,Cijena)  VALUES( '" + this.textBox1.Text + "' ,'" + this.textBox2.Text + "',"+textBox3.Text+")";
            SqlCommand cmdnar = new SqlCommand(zadatak, con);

            cmdnar.ExecuteNonQuery();

           textBox2.Text = "";
            textBox1.Text = "";
           textBox3.Text = "";

            con.Close();

            MessageBox.Show("Artikl spremljen !");
        }
    }
}
