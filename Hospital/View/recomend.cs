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
    public partial class recomend : Form
    {
        string idVisit;
        dataBase connector;
        public recomend(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            idVisit = _idVisit;
            connector = _connector;
        }

        private void recomend_Load(object sender, EventArgs e)
        {
            textBox1.Text = connector.loadRecomd(idVisit);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.updateRecomd(textBox1.Text, idVisit);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connector.updateRecomd("", idVisit);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            medicament med = new medicament(idVisit, connector);
            med.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
