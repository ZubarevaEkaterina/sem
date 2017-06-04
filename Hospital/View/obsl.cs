using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class obsl : Form
    {
        string idVisit;
        dataBase connector;
        public obsl(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            idVisit = _idVisit;
            connector = _connector;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                obslData data = new obslData();
                data.DateObsl = dateTimePicker1.Value.ToShortDateString();
                data.NameObsl = textBox1.Text;
                data.Result = textBox2.Text;
                data.IdVisit = idVisit;
                connector.addObsl(data);
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.deleteObsl(idVisit);
            Close();
        }

        private void obsl_Load(object sender, EventArgs e)
        {
            obslData obs = connector.loadObls(idVisit);
            if (obs != null)
            {
                textBox1.Text = obs.NameObsl;
                textBox2.Text = obs.Result;
                dateTimePicker1.Value = System.Convert.ToDateTime(obs.DateObsl);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
