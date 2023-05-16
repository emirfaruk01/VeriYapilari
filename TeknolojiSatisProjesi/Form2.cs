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
    public partial class Form2 : Form
    {
        public string veriler_load;
        public Form2(string veriler)
        {
            InitializeComponent();
            richTextBox1.Text = veriler;
            veriler_load = veriler;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = veriler_load;
        }
    }
}
