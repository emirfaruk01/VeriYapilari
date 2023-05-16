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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TeknolojiSatisProjesi
{

    public partial class SatislariYonet : Form
    {
        MySqlConnection con = null;
        MySqlConnection con_musteri = null;
        MySqlCommand cmd = null;
        MySqlCommand cmd_musteri = null;
        MySqlDataReader dr = null;
        MySqlDataReader dr_musteri = null;
        Liste2 liste = new Liste2();


        public SatislariYonet()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
            con_musteri = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //x tuşı sonlandırır
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void SearchCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            tablo.Text = "";
            string connectionString = "Server=127.0.0.1;Database=odev;user=root;Pwd=''";

            // MySqlConnection sınıfı kullanarak MySQL veritabanına bağlanma
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // INSERT INTO sorgusu oluşturma ve MySqlCommand sınıfı kullanarak veritabanına gönderme
                string query2 = "INSERT INTO satislar2 (urun_id, urun_adi, urun_fiyati, musteri_id, musteri_adi, musteri_soyadi, musteri_telefon, kampanya_id, kampanya_adi, kampanya) VALUES (@urun_id, @urun_adi, @urun_fiyati, @musteri_id, @musteri_adi, @musteri_soyadi, @musteri_telefon, @kampanya_id, @kampanya_adi, @kampanya)";

                using (MySqlCommand command = new MySqlCommand(query2, connection))
                {
                    // Parametreleri ekleyerek sorguyu hazırlama
                    //command.Parameters.AddWithValue("@satis_id", textBox4.Text);
                    command.Parameters.AddWithValue("@urun_id", comboBox1.Text);
                    command.Parameters.AddWithValue("@urun_adi", textBox2.Text);
                    command.Parameters.AddWithValue("@urun_fiyati", textBox1.Text);
                    command.Parameters.AddWithValue("@musteri_id", comboBox3.Text);
                    command.Parameters.AddWithValue("@musteri_adi", textBox3.Text);
                    command.Parameters.AddWithValue("@musteri_soyadi", textBox6.Text);
                    command.Parameters.AddWithValue("@musteri_telefon", textBox5.Text);
                    command.Parameters.AddWithValue("@kampanya_id", comboBox2.Text);
                    command.Parameters.AddWithValue("@kampanya_adi", textBox8.Text);
                    command.Parameters.AddWithValue("@kampanya", textBox7.Text);

                    // Sorguyu veritabanına gönderme
                    command.ExecuteNonQuery();

                    // İşlem başarılı ise kullanıcıya mesaj gösterme
                    //MessageBox.Show("Veri başarıyla eklendi.");
                }
            }

            con.Close();
            con.Open();

            //Liste liste = new Liste();

            liste.DugumEkle(textBox4.Text, comboBox1.Text, textBox2.Text, textBox1.Text, comboBox3.Text, textBox3.Text, textBox6.Text, textBox5.Text, comboBox2.Text, textBox8.Text, textBox7.Text);

            tablo.Text = liste.DugumleriGoster();

            connectionString = "Server=127.0.0.1;Database=odev;user=root;Pwd=''";


            cmd.CommandText = "SELECT * FROM satislar2";
            dr = cmd.ExecuteReader();

            comboBox4.Items.Clear();

            while (dr.Read())
            {
                //liste.DugumEkle((dr.GetString("satis_id")), (dr.GetString("urun_id")), (dr.GetString("urun_adi")), (dr.GetString("urun_fiyati")), (dr.GetString("musteri_id")), (dr.GetString("musteri_adi")), (dr.GetString("musteri_soyadi")), (dr.GetString("musteri_telefon")), (dr.GetString("kampanya_id")), (dr.GetString("kampanya_adi")), (dr.GetString("kampanya")));
                comboBox4.Items.Add(dr.GetString("satis_id"));
            }

            con.Close();








            con.Open();

            //richTextBox1.Text=liste.DugumleriGoster();

            string query = "SELECT MAX(satis_id) FROM satislar2";

            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                // Sorguyu veritabanından çalıştırarak en büyük değeri alın
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    // En büyük değer varsa kullanıcıya gösterme
                    int maxValue = Convert.ToInt32(result) + 1;
                    textBox4.Text = maxValue.ToString();
                }
            }
            con.Close();


        }

        private void SatislariYonet_Load(object sender, EventArgs e)
        {
            /////////////////////

            string veriler = tablo.Text;
            Form2 form2 = new Form2(veriler);

            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT id,adi FROM urunler";

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr.GetString("id"));
                //comboBox2.Items.Add(dr.GetString("adi"));
                if (comboBox1.Text != "")
                {
                    break;
                }
            }
            con.Close();
            con.Open();

            cmd.CommandText = "SELECT * FROM musteriler";
            dr_musteri = cmd.ExecuteReader();

            while (dr_musteri.Read())
            {
                comboBox3.Items.Add(dr_musteri.GetString("id"));
            }

            con.Close();
            con.Open();

            cmd.CommandText = "SELECT * FROM kampanyalar";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr.GetString("id"));
            }

            con.Close();

            con.Open();

            cmd.CommandText = "SELECT * FROM satislar2";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                liste.DugumEkle((dr.GetString("satis_id")), (dr.GetString("urun_id")), (dr.GetString("urun_adi")), (dr.GetString("urun_fiyati")), (dr.GetString("musteri_id")), (dr.GetString("musteri_adi")), (dr.GetString("musteri_soyadi")), (dr.GetString("musteri_telefon")), (dr.GetString("kampanya_id")), (dr.GetString("kampanya_adi")), (dr.GetString("kampanya")));
                comboBox4.Items.Add(dr.GetString("satis_id"));
            }

            con.Close();

            con.Open();

            tablo.Text = liste.DugumleriGoster();

            string query = "SELECT MAX(satis_id) FROM satislar2";

            using (MySqlCommand command = new MySqlCommand(query, con))
            {
                // Sorguyu veritabanından çalıştırarak en büyük değeri alın
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    // En büyük değer varsa kullanıcıya gösterme
                    int maxValue = Convert.ToInt32(result) + 1;
                    textBox4.Text = maxValue.ToString();
                }
            }
            con.Close();

            /////////////////////
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM urunler where id='" + comboBox1.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = (dr.GetString("adi"));
                textBox1.Text = (dr.GetString("fiyat"));
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //müşteri tablosundan
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM musteriler where id='" + comboBox3.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = (dr.GetString("adi"));
                textBox6.Text = (dr.GetString("soyadi"));
                textBox5.Text = (dr.GetString("tel_no"));
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Database=odev;user=root;Pwd=''";

            // MySqlConnection sınıfı kullanarak MySQL veritabanına bağlanma
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // DELETE sorgusu oluşturma ve MySqlCommand sınıfı kullanarak veritabanına gönderme
                string query = "DELETE FROM satislar2 WHERE satis_id = @value";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Parametre ekleyerek sorgunun güvenliğini sağlama
                    command.Parameters.AddWithValue("@value", comboBox4.Text);

                    // Sorguyu veritabanından çalıştırarak etkilenen kayıt sayısını alın
                    int rowsAffected = command.ExecuteNonQuery();

                    // Etkilenen kayıt sayısı kullanıcıya gösterme
                    MessageBox.Show(rowsAffected + " kayıt silindi.");
                }
                tablo.Text = "";

                liste.DugumSil(comboBox4.Text);




                tablo.Text = liste.DugumleriGoster();

                connectionString = "Server=127.0.0.1;Database=odev;user=root;Pwd=''";

                con.Open();
                cmd.CommandText = "SELECT * FROM satislar2";
                dr = cmd.ExecuteReader();

                comboBox4.Text = "";
                comboBox4.Items.Clear();

                while (dr.Read())
                {
                    liste.DugumEkle((dr.GetString("satis_id")), (dr.GetString("urun_id")), (dr.GetString("urun_adi")), (dr.GetString("urun_fiyati")), (dr.GetString("musteri_id")), (dr.GetString("musteri_adi")), (dr.GetString("musteri_soyadi")), (dr.GetString("musteri_telefon")), (dr.GetString("kampanya_id")), (dr.GetString("kampanya_adi")), (dr.GetString("kampanya")));
                    comboBox4.Items.Add(dr.GetString("satis_id"));
                }

                con.Close();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ana menü butonu
            AnaMenu home = new AnaMenu(tablo.Text);
            home.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kampanyalar where id='" + comboBox2.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox8.Text = (dr.GetString("adi"));
                if (dr.GetString("taksit") != "")
                {
                    textBox7.Text = (dr.GetString("taksit") + " taksit");
                }
                else
                {
                    textBox7.Text = "%" + (dr.GetString("indirim") + " indirim");
                }

            }
            con.Close();
        }

        private void tablo_TextChanged(object sender, EventArgs e)
        {
            string veriler = tablo.Text;

            AnaMenu form2 = new AnaMenu(veriler);
        }
    }

}