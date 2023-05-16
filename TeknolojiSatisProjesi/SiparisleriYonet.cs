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
using System.Data.SqlClient;

namespace TeknolojiSatisProjesi
{
    public partial class SiparisleriYonet : Form
    {
        public SiparisleriYonet()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emirf\OneDrive\Documents\Otomasyondb.mdf;Integrated Security=True;Connect Timeout=30");

        void populate() //müşterileri ızgarada göster
        {
            try
            {
                Con.Open();
                string Myquery = "select * from CustomerTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                CustomersGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }

        }
        void populateproducts() //Ürünleri ızgarada göster
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ProductTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductsGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
        void fillcategory() //Kategori tablosundan ürün kategorisi çekme
        {
            string query = "select * from CategoryTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            try
            {
                Con.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("KategoriAdi", typeof(string));
                rdr = cmd.ExecuteReader();
                dt.Load(rdr);
               // CatCombo.ValueMember = "KategoriAdi";
               // CatCombo.DataSource = dt;
                SearchCombo.ValueMember = "KategoriAdi";
                SearchCombo.DataSource = dt;
                Con.Close();
            }
            catch { }
        }
        
        int num = 0;
        int uprice, totprice, qty;
        string product;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SiparisleriYonet_Load(object sender, EventArgs e)
        {
            populate();
            populateproducts();
            fillcategory();
        }
        int flag = 0;
        

        private void ProductsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { //kategori ızgarasındaki degerleri göster
            //product = ProductsGV.SelectedRows[0].Cells[1].Value.ToString();
            //qty = Convert.ToInt32(QtyTb.Text);
            //uprice = Convert.ToInt32(ProductsGV.SelectedRows[0].Cells[3].Value.ToString());
            //totprice = qty * uprice;
            flag = 1;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            //bu kısımda sipariş ekleme olacaktı fakat hatalar nedeniyle sorgula olarak değiştirdim
            populate();    
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();
        }

        private void CustomersGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // x ' e basınca pencereyi kapat
        }

        private void SearchCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ProductTbl where UrunKategorisi='" + SearchCombo.SelectedValue.ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                ProductsGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }
        }
    }
}
