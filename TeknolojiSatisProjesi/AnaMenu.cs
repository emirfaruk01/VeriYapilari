using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknolojiSatisProjesi
{
    public partial class AnaMenu : Form
    {   
        public string veriler_load;
        public AnaMenu(string veriler)
        {
            InitializeComponent();
            veriler_load = veriler;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //uygulamayı x ile sonlandır
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UrunleriYonet prod = new UrunleriYonet();
            prod.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        { //kullanıcı butonu
            KampanyalariYonet users = new KampanyalariYonet();
            users.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { //kategori butonu
            KategorileriYonet Cat = new KategorileriYonet();
            Cat.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        { //musteri butonu
            MusterileriYonet Cust = new MusterileriYonet();
            Cust.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        { //sipariş butonu
            SatislariYonet Orders = new SatislariYonet();
            Orders.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        { //oturumu sonlandırma butonu
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void AnaMenu_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(veriler_load);
        }
    }
}
