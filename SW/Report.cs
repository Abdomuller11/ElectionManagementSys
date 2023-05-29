using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SW
{
    public partial class Report : Form
    {
        CrystalReport2 CR;

        public Report()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
          CR = new CrystalReport2();
          foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
          comboBox1.Items.Add(v.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
          CR.SetParameterValue(0, comboBox1.Text);
           //CR.SetParameterValue(1, textBox2.Text);
           //CR.SetParameterValue(2, textBox1.Text);
           crystalReportViewer1.ReportSource = CR;
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 youssef = new Form3("");
            youssef.Show();
            this.Hide();
        }
    }
}
