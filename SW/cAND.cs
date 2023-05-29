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
    public partial class CandidateProfile : Form
    {
        
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        public string name { get; set; }
        int count = 0;
        public CandidateProfile(string p)
        {
            InitializeComponent();
            name = p;
        }
        
        private void CandidateProfile_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select USERID ,SSN ,GENDER ,AGE ,JOB1 , VOTERS from RIGESTERED_USERS , Candidates_Profile  where UserName  = :tmp1 and CandidateID = UserID";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("tmp1", name);


            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
               
                textBox2.Text = dr[1].ToString();
                textBox4.Text = dr[2].ToString();
                textBox5.Text = dr[3].ToString();
                textBox6.Text = dr[4].ToString();
                textBox7.Text = dr[5].ToString();
               
            }
            textBox3.Text = name;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 home1 = new Form3("Hello");
            home1.Show();
            this.Hide();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = Convert.ToInt32(textBox7.Text.ToString());
            int r2 = r + 1;
            if (count < 1) 
            {
                textBox7.Text = r2.ToString();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update Candidates_Profile set voters = :temp1 where CandidateID = :temp2";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("temp1", r2);
                cmd.Parameters.Add("temp2", Convert.ToInt32(textBox1.Text));
                int d = cmd.ExecuteNonQuery();
                if (d != -1)
                {
                MessageBox.Show("Done !");
                }
            }
            count++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
