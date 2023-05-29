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
    public partial class Form2 : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public int usrid { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Rigestered_Users values(:id,:ssn,:name,:pwd,:gender,:age,:job,'n')";
            cmd.CommandType = CommandType.Text;
            usrid=int.Parse(textBox4.Text);
            
            cmd.Parameters.Add("id", textBox4.Text.ToString());
            cmd.Parameters.Add("ssn", textBox3.Text.ToString());
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("pwd", textBox2.Text);
            if (radioButton1.Checked) { cmd.Parameters.Add("gender", radioButton1.Text); }
            else { cmd.Parameters.Add("gender", radioButton2.Text); }
            cmd.Parameters.Add("age", textBox6.Text.ToString());
            cmd.Parameters.Add("job", textBox5.Text);


            int r = cmd.ExecuteNonQuery();
            if (textBox4.Text.ToString() != string.Empty && textBox3.Text.ToString() != string.Empty && textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox6.Text.ToString() != string.Empty && textBox5.Text != string.Empty)
            {
                if (r != -1)
                {
                    MessageBox.Show("Successed");
                    Form2 reg = new Form2();
                    this.Hide();
                    reg.Show();
                }
                else
                {
                    MessageBox.Show("failed");
                }
            }
            else
            {
                MessageBox.Show("failed");
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
