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
    public partial class simp : Form
    {
        string idVisit;
        dataBase connector;
        public simp(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            idVisit = _idVisit;
            connector = _connector;
        }

        private void simp_Load(object sender, EventArgs e)
        {
            textBox1.Text = connector.loadSimp(idVisit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connector.updateSimp(textBox1.Text, idVisit);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.updateSimp("", idVisit);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
