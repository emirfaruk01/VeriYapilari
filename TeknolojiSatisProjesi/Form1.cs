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

namespace TeknolojiSatisProjesi
{
    public partial class Form1 : Form
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            //Temizle butonu girilen adı ve parolayı siler
            UsernameTb.Text = "";
            PasswordTb.Text = "";

        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            //Parolayı göster işaretliyse göster, değilse gizle
            if (showPasswordCheckBox.Checked == true)
                PasswordTb.isPassword = false;
            else
                PasswordTb.isPassword = true;
        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //çarpı uygulamayı sonlandırır
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = UsernameTb.Text;
            string pass = PasswordTb.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanicilar where id='" + UsernameTb.Text + "' and password='" + PasswordTb.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //MessageBox.Show("Giriş Başarılı.");
                AnaMenu form2 = new AnaMenu("");
                Form1 form1 = new Form1();

                form1.Visible = false;
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");

            }
            con.Close();
        }

        private void UsernameTb_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
