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
    public partial class medicament : Form
    {
        string idVisit;
        dataBase connector;
        public medicament(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            idVisit = _idVisit;
            connector = _connector;
        }

        private void medicament_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = connector.loadMed(idVisit).Title;
            textBox2.Text = connector.loadMed(idVisit).Way_to_use;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connector.updateMed(textBox1.Text, textBox2.Text, idVisit);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.updateMed("", "", idVisit);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
