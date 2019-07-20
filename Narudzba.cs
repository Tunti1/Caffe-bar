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
    public partial class Narudzba : Form
    {

        public string stol;
        public string artikl;
        public int cijena;
        public int kolicina;

        public Narudzba()
        {
            
            InitializeComponent();
            popuni_combo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();
            con.Open();
            string izvadi = "select cijena from  Artikli where naziv = '"+comboBox1.Text+"';";
            SqlCommand izvadi_cmd1 = new SqlCommand(izvadi, con);
            SqlDataReader citac1;
            citac1 = izvadi_cmd1.ExecuteReader();


            while (citac1.Read())
            {

                textBox1.Text = (citac1["cijena"].ToString());

                
            }
            con.Close();


        }
        private void popuni_combo()
        {

            var con = PozivBaze.konekcija();
            con.Open();
            string izvadi = "select * from  Artikli;";
            SqlCommand izvadi_cmd1 = new SqlCommand(izvadi, con);
            SqlDataReader citac1;
            citac1 = izvadi_cmd1.ExecuteReader();


            while (citac1.Read())
            {

                string Sifra = citac1.GetString(1);

                comboBox1.Items.Add(Sifra);
            }
            con.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
           
            
                var con = PozivBaze.konekcija();
                con.Open();
                string zadatak = "INSERT INTO Narudzba (Artikl,kolicina,cijena,stol,datum,oznaka)  VALUES( '" + this.comboBox1.Text + "','" + this.textBox2.Text + "','" + this.textBox1.Text + "','"+comboBox2.Text+"','"+dateTimePicker1.Text+"','N')";
                SqlCommand cmdnar = new SqlCommand(zadatak, con);

                cmdnar.ExecuteNonQuery();

                textBox2.Text = "";
                textBox1.Text = "";


                con.Close();
            

          
          

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu otvori = new menu();
            otvori.Show();
            
        }
    }
}
