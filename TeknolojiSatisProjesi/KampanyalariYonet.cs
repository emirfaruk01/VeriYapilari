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
using MySql;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeknolojiSatisProjesi
{
    public partial class KampanyalariYonet : Form
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        public KampanyalariYonet()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //Veritabanına kullanıcı bilgilerini ekleme
            if (comboBox1.SelectedIndex == 0)//taksit
            {
                if (OfferNameTb.Text != null && textBox2.Text != null && OfferIdTb.Text != null)
                {
                    string sorgu = "Insert into kampanyalar (id,adi,taksit) values (@id,@adi,@taksit)";
                    cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@id", OfferIdTb.Text);
                    cmd.Parameters.AddWithValue("@adi", OfferNameTb.Text);
                    cmd.Parameters.AddWithValue("@taksit", textBox2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else if (comboBox1.SelectedIndex == 1)//indirim
            {
                if (OfferNameTb.Text != null && textBox2.Text != null && OfferIdTb.Text != null)
                {
                    string sorgu = "Insert into kampanyalar (id,adi,indirim) values (@id,@adi,@indirim)";
                    cmd = new MySqlCommand(sorgu, con);
                    cmd.Parameters.AddWithValue("@id",OfferIdTb.Text);
                    cmd.Parameters.AddWithValue("@adi", OfferNameTb.Text);
                    cmd.Parameters.AddWithValue("@indirim", textBox2.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //x'e basınca programı sonlandırır
        }

        private void KullanicilariYonet_Load(object sender, EventArgs e)
        {
            
        }

        

        private void UsersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label5.Text = "  " + comboBox1.Text + " :";
                label5.Visible = true;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label5.Text = comboBox1.Text + " :";
                label5.Visible = true;
            }
        }
    }
}
