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
    public partial class medCard : Form
    {
        dataBase connector;
        patientData pat;
        int type;
        public medCard(string _numberP, dataBase _connector,int _type)
        {
            InitializeComponent();
            connector = _connector;
            pat = connector.loadPatient(_numberP);
            textBox1.Text = pat.ToString();
            textBox2.Text = pat.Sex;
            textBox3.Text = pat.BirthDay;
            type = _type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            visits showVisits = new visits(pat.Id, connector);
            showVisits.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            contraindications showCon = new contraindications(pat.Id, connector,type);
            showCon.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
