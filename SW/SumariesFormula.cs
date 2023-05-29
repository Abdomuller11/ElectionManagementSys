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
    public partial class SumariesFormula : Form
    {
        SummriesFormula WE;
        public SumariesFormula()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void SumariesFormula_Load(object sender, EventArgs e)
        {
            WE = new SummriesFormula();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 sal = new Form3("");
            sal.Show();
            this.Hide();
        }

        private void crystalReportViewer5_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            crystalReportViewer5.ReportSource = WE;
        }
    }
}
