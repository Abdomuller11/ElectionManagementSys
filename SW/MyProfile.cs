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
    public partial class MyProfile : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleDataAdapter adapter1;
        OracleCommandBuilder builder;
        DataSet ds;
        DataSet ds1;
        public string pass { get; set; }
        public MyProfile(string p3)
        {
            InitializeComponent();
            pass = p3;
           
        }
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select USERID ,USERNAME ,SSN ,GENDER ,AGE ,JOB1 from RIGESTERED_USERS where UserPassword = :pass and is_candidate is NOT NULL";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("pass", pass);

           
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox3.Text = dr[0].ToString();
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 home0 = new Form3("Hello");
            home0.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private int generate_Profile_Id()
        {
            int max_Profile_Id , new_Profile_Id;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "PROFID";
            cmd.CommandType = CommandType.StoredProcedure;

            //string constr = "Data source=orcl;User Id=scott; Password=tiger;";
            string cmdstr = $"select max((ProfileID) from Candidates_Profile;";
            cmd.Parameters.Add("profilr_id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            try
            {
                max_Profile_Id = Convert.ToInt32(cmd.Parameters["profilr_id"].Value.ToString());
                new_Profile_Id = max_Profile_Id + 1;
            }
            catch
            {
                new_Profile_Id = 1;
            }


            return new_Profile_Id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr = "Data source=orcl;User Id=scott; Password=tiger;";
            string cmdstr = "";
            string cmdstr1 = "";

            string ok = textBox1.Text;
            string okk = textBox3.Text;
            int okkk =int.Parse(textBox3.Text);

            int prodileId = generate_Profile_Id();
            cmdstr = $"insert into Candidates_Profile values ({prodileId},{okk},0)";
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            cmdstr1 = $"update Rigestered_Users set is_candidate='y' where UserID={okkk}";
            adapter1 = new OracleDataAdapter(cmdstr1, constr);
            ds1 = new DataSet();

            adapter1.Fill(ds1, "Rigestered_Users"); // Fill the dataset with data from the table


            if (ds1.Tables["Rigestered_Users"] != null) // Check if the table is not null
            {
                adapter1.Update(ds1.Tables["Rigestered_Users"]); // Update the table in the database
            }
            else
            {
                Console.WriteLine("No data found in the Rigestered_Users table.");
            }

            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
         OracleCommand cmd = new OracleCommand();
         cmd.Connection = conn;
         cmd.CommandText = "update Rigestered_Users set UserName = :temp1 where UserID= :temp2";
         cmd.CommandType = CommandType.Text;
         cmd.Parameters.Add("temp1", textBox1.Text);
         cmd.Parameters.Add("temp2", Convert.ToInt32(textBox3.Text));
         int d = cmd.ExecuteNonQuery();
        if (d != -1)
        {
         MessageBox.Show("Done !");
        }
            
           
        }
    }
}
