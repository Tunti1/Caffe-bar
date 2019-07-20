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
    public partial class Registracija : Form
    {
        public Registracija()
        {
            InitializeComponent();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prijava otvori = new Prijava();
            otvori.Show();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
          
                var con = PozivBaze.konekcija();
                con.Open();
                string zadatak = "INSERT INTO Korisnik (Korisnicko_ime, Lozinka)  VALUES( '" + this.metroTextBox1.Text + "' ,'" + this.metroTextBox2.Text + "')"; 
                SqlCommand cmdnar = new SqlCommand(zadatak, con);

                cmdnar.ExecuteNonQuery();

                metroTextBox2.Text = "";
                metroTextBox1.Text = "";
                

                con.Close();

                MessageBox.Show("Korisnik spremljen !");
            
        }
    }
}
