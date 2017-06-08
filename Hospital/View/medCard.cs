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
        //   patientData pat;
        List<string> pat = new List<string>();
        int type;
        public medCard(string _numberP, dataBase _connector,int _type)
        {
            InitializeComponent();
            connector = _connector;

            pat = connector.loadPatient(_numberP);
            textBox1.Text = pat[1] + " " + pat [2] + " " + pat [3];
            textBox2.Text = pat[4];
            textBox3.Text = pat[5];
            type = _type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            visits showVisits = new visits(pat[0], connector);
            showVisits.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            contraindicationsData data = new contraindicationsData();
            contraindications showCon = new contraindications(pat[0],type, connector, data);
            showCon.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
