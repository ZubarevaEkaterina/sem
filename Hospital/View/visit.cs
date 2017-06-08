using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Hospital
{
    public partial class visit : Form
    {
        dataBase connector;
        public visit(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            connector = _connector;
            visitControl visit = new visitControl(_idVisit) ;
            textBox1.Text = visit.load().DateVisit;
            textBox2.Text = visit.load().DoctorInfo;
            textBox3.Text = visit.load().Obsl;
            textBox4.Text = visit.load().Symp;
            textBox5.Text = visit.load().Recomd;
            textBox6.Text = visit.load().Medicament;
            textBox7.Text = visit.load().Diagnose;
        }

        private void visit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

 
    }
}
