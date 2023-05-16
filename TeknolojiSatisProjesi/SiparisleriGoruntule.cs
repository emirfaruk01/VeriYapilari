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


namespace TeknolojiSatisProjesi
{
    public partial class SiparisleriGoruntule : Form
    {
        public SiparisleriGoruntule()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emirf\OneDrive\Documents\Otomasyondb.mdf;Integrated Security=True;Connect Timeout=30");

        void populate() //müşterileri ızgarada göster
        {
            try
            {
                Con.Open();
                string Myquery = "select * from ShowTbl";
                SqlDataAdapter da = new SqlDataAdapter(Myquery, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                satisYonetGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch
            {

            }

        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); // x sonlandırır
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();
        }

        private void OrderGv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SiparisleriGoruntule_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}
