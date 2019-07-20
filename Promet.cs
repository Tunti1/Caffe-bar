using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjektNebojša
{
    public partial class Promet : Form
    {
        public Promet()
        {
            InitializeComponent();
        }
        List<Narudzba> sviracuni = new List<Narudzba>();
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu otvori = new menu();
            otvori.Show();
        }

        private void izracunaj_promet(object sender, EventArgs e)
        {
            int suma = 0;


            listView1.Items.Clear();
            sviracuni.Clear();
            var con = PozivBaze.konekcija();
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Narudzba where datum = '" + this.dateTimePicker1.Text + "' and oznaka= 'D'", con);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {

                Narudzba prijenos = new Narudzba();
                prijenos.artikl = (string)reader["Artikl"];
                prijenos.cijena = (int)reader["cijena"];

                prijenos.kolicina = (int)reader["kolicina"];


                suma = suma + prijenos.kolicina * prijenos.cijena;
                sviracuni.Add(prijenos);




            }


            foreach (var s in sviracuni)
            {

                string[] red = { s.artikl, s.cijena.ToString(), s.kolicina.ToString() };
                var prenosioc = new ListViewItem(red);
                listView1.Items.Add(prenosioc);

            }

            
                con.Close();
            
            textBox1.Text = suma.ToString();
                sviracuni.Clear();
                suma = 0;

            

        }

        
    }
}
