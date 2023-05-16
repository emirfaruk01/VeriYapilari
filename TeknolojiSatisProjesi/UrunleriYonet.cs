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
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeknolojiSatisProjesi
{
    public partial class UrunleriYonet : Form
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        public UrunleriYonet()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
        }
        
       
        private void UrunleriYonet_Load(object sender, EventArgs e)
        {
            
        }
       
       
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //x'e basınca programı sonlandırır
        }

        private void unameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //ürünleri ekleme butonu
        {
            if (ProdIdTb.Text != null && ProdNameTb.Text != null && ProdPriceTb.Text != null)
            {
                string sorgu = "Insert into urunler (id,adi,fiyat) values (@id,@adi,@fiyat)";
                cmd = new MySqlCommand(sorgu, con);
                cmd.Parameters.AddWithValue("@id", ProdIdTb.Text);
                cmd.Parameters.AddWithValue("@adi", ProdNameTb.Text);
                cmd.Parameters.AddWithValue("@fiyat", ProdPriceTb.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ürün başarıyla eklendi!");
                con.Close();
                
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CatCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        { //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();

        }
    }
}
