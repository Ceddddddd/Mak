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

namespace mak
{
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public static int voterid;
        public static string voteaddress;
        public static string votername;
        public static int year;
        public Form3()
        {
            InitializeComponent();
 
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            voterid = int.Parse(textBox1.Text);
            votername = textBox2.Text;
            voteaddress = textBox3.Text;
            year = int.Parse(textBox4.Text);
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "admin" && textBox6.Text == "admin")
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else if (textBox5.Text != "admin" && textBox6.Text == "admin")
            {
                MessageBox.Show("Wrong Username");
            }
            else if (textBox5.Text == "admin" && textBox6.Text != "admin")
            {
                MessageBox.Show("Wrong Password");
            }
            else {
                MessageBox.Show("Both Password and User are Wrong");
            }
        }
    }
}
