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
    public partial class Naplata : Form
    {
        int kolicina_, cijena_;
        float suma=0;
        public Naplata()
        {
            InitializeComponent();
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            menu otvori = new menu();
            this.Hide();
            otvori.Show();
        }

        List<Narudzba> racuni = new List<Narudzba>();

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();
            con.Open();
            SqlCommand sqlCommand1 = new SqlCommand("Update Narudzba set oznaka = 'D' FROM Narudzba where stol ='" + comboBox1.Text + "' and datum = '" + this.dateTimePicker1.Text + "' and oznaka='N'", con);
            SqlDataReader reader1 = sqlCommand1.ExecuteReader();
            con.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            racuni.Clear();
            var con = PozivBaze.konekcija();
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Narudzba where stol ='"+comboBox1.Text+"' and datum = '"+this.dateTimePicker1.Text+"' and oznaka='N'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
             
            while (reader.Read())
                {
                
                    Narudzba prijenos = new Narudzba();
                    prijenos.artikl = (string)reader["Artikl"];
                    prijenos.cijena = (int)reader["cijena"];
                
                   prijenos.kolicina = (int)reader["kolicina"];
               
              
                suma = suma + prijenos.kolicina * prijenos.cijena;
                    racuni.Add(prijenos);
                



             }
            
            
            foreach (var s in racuni )
            {
                
                string[] red = { s.artikl, s.cijena.ToString(), s.kolicina.ToString() };
                var prenosioc = new ListViewItem(red);
                listView1.Items.Add(prenosioc);
                
            }

            textBox1.Text = suma.ToString();
            con.Close();
            racuni.Clear();
            suma = 0;

        }


    }
}
