﻿using System;
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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {
            var con = PozivBaze.konekcija();
            con.Open();
            SqlDataAdapter prijava = new SqlDataAdapter("select count(*) from Korisnik where korisnicko_ime='"+ metroTextBox1.Text+"'and lozinka = '"+metroTextBox2.Text+"'",con);
            DataTable dt = new DataTable();
            prijava.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                menu otvori = new menu();
                this.Hide();
                otvori.Show();

            }
            else MessageBox.Show("Pogresno korisnicko ime ili lozinka");
        }

        

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registracija otvori = new Registracija();
            otvori.Show();
        }
    }
}
