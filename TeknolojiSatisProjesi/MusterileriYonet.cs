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
using MySql;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeknolojiSatisProjesi
{
    public partial class MusterileriYonet : Form
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        public MusterileriYonet()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");

        }
  
        private void MusterileriYonet_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //x uygulamayı sonandırır
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Veritabanına müşteri bilgilerini ekleme
            if (CustomerIdTb.Text != null && CustomerNameTb.Text != null && CustomerSurnameTb.Text != null && CustomerPhoneTb.Text != null)
            {
                string sorgu = "Insert into musteriler (id,adi,soyadi,tel_no) values (@id,@adi,@soyadi,@tel_no)";
                cmd = new MySqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@id", CustomerIdTb.Text);
                cmd.Parameters.AddWithValue("@adi", CustomerNameTb.Text);
                cmd.Parameters.AddWithValue("@soyadi", CustomerSurnameTb.Text);
                cmd.Parameters.AddWithValue("@tel_no", CustomerPhoneTb.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Müşteriler Başarıyla Eklendi.");
                con.Close();
            }
        }

        private void CustomersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
