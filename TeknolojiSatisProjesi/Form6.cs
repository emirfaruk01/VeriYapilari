using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WinFormsApp3
{ 
    public partial class Form6 : Form
    {
        MySqlConnection con = null;
        MySqlConnection con_musteri = null;
        MySqlCommand cmd = null;
        MySqlCommand cmd_musteri = null;
        MySqlDataReader dr = null;
        MySqlDataReader dr_musteri = null;
        public Form6()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
            con_musteri = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");
        }

        private void Form6_Load(object sender, EventArgs e)
        {
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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM urunler where id='"+comboBox1.Text+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = (dr.GetString("adi"));
                textBox1.Text = (dr.GetString("fiyat"));
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM musteriler where id='"+comboBox3.Text+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox3.Text = (dr.GetString("adi"));
                textBox6.Text = (dr.GetString("soyadi"));
                textBox5.Text = (dr.GetString("tel_no"));
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kampanyalar where id='"+comboBox2.Text+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox8.Text = (dr.GetString("adi"));
                if (dr.GetString("taksit")!="")
                {
                    textBox7.Text = (dr.GetString("taksit")+" taksit");
                }
                else
                {
                    textBox7.Text = "%"+(dr.GetString("indirim")+" indirim");
                }
                
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM satislar";
            //dr = cmd.ExecuteReader();

            int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            Liste liste = new Liste();

            liste.DugumEkle(Convert.ToString(kayitSayisi+1),comboBox1.Text,textBox2.Text,textBox1.Text,comboBox3.Text,textBox3.Text,textBox6.Text,textBox5.Text,comboBox2.Text,textBox8.Text,textBox7.Text);
        }
    }
}
