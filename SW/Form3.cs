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
    public partial class Form3 : Form
    {
        public string Data { get; set; }
        public Form3(string p)
        {
            InitializeComponent();
            Data = p;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 youssef = new Form1();
            youssef.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewCandidates view = new ViewCandidates();
            view.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyProfile profile = new MyProfile(Data);
            profile.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report rep = new Report();
            rep.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report2 rep = new Report2();
            rep.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SumariesFormula rep = new SumariesFormula();
            rep.Show();
            this.Hide();
        }
    }
}
