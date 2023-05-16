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
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TeknolojiSatisProjesi
{
    public partial class KategorileriYonet : Form
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        MySqlDataReader dr = null;
        public KategorileriYonet()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=odev;user=root;Pwd=''");

        }
       
        private void KategorileriYonet_Load(object sender, EventArgs e)
        {
          // string 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit(); //x uygulamayı sonandırır
        }

       

        private void button4_Click(object sender, EventArgs e)
        { //ana menü butonu
            AnaMenu home = new AnaMenu("");
            home.Show();
            this.Hide();
            
        }

        private void CatNameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
