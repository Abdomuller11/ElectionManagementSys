using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW
{
    public partial class Report2 : Form
    {
        CrystalReport3 CR;
        public Report2()
        {
            InitializeComponent();
        }

        private void Report2_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport3();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            crystalReportViewer2.ReportSource = CR;
        }

        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            Form3 youssef = new Form3("");
            youssef.Show();
            this.Hide();
        }
    }
}
