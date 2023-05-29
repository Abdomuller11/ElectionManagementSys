using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace SW
{
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select UserName,UserPassword from Rigestered_Users where UserName=:name and UserPassword=:pwd";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("pwd", textBox2.Text.ToString());
            //int r = cmd.ExecuteNonQuery();
            OracleDataReader dr = cmd.ExecuteReader();
            // if (txtpassword.Text != string.Empty || txtusername.Text != string.Empty)

            //if (dr.Read())
            //{
            //    if (dr[0] != null)
            //    {

            //    }

            //}


            //last
            //if (textBox1.Text != string.Empty && textBox2.Text.ToString() != string.Empty)
            //{
            //    if (dr.Read())
            //    {
            //        Form3 muller = new Form3();
            //        this.Hide();
            //        muller.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid, try again");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Invalid, try again");
            //}
            
            if (textBox1.Text != string.Empty && textBox2.Text.ToString() != string.Empty)
            {
                if (dr.Read())
                {
                    Form3 muller = new Form3(textBox2.Text);
                    this.Hide();
                    muller.Show();
                }
                else
                {
                    MessageBox.Show("Invalid, try again");
                }
            }
            else
            {
                MessageBox.Show("Invalid, try again");
            }






        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 reg = new Form2();
            this.Hide();
            reg.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
