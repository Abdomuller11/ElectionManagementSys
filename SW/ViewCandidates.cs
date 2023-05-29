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
    public partial class ViewCandidates : Form
    {
        string ordb = "Data source=orcl;User Id=scott; Password=tiger;";
        OracleConnection conn;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        public ViewCandidates()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 home = new Form3("Hello");
            home.Show();
            this.Hide();
        }

        private void ViewCandidates_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "All_Cand";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("x", OracleDbType.RefCursor, ParameterDirection.Output);
            //cmd.Parameters.Add("x",comboBox1.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //"select UserName from Rigestered_Users where UserName like @:usrname";
        private void button1_Click(object sender, EventArgs e)
        {
            

            string constr = "Data source=orcl;User Id=scott; Password=tiger;";
            string ok = textBox1.Text;
            string cmdstr = $"select UserName from Rigestered_Users where UserName like '{ok}%' and is_candidate = 'y' ";

          
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CandidateProfile tmp = new CandidateProfile(comboBox1.SelectedItem.ToString());
            tmp.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
