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
    public partial class diagnose : Form
    {
        visitData idvisit;
        diagnoseControl cont;

        public diagnose(string _idVisit, diagnoseControl _cont)
        {
            InitializeComponent();
            idvisit = new visitData();
            cont = _cont;
            idvisit.Id = _idVisit;
           
        }

        private void diagnose_Load(object sender, EventArgs e)
        { 
            
            textBox1.Text = cont.load(idvisit.Id).Title;
            textBox2.Text = cont.load(idvisit.Id).Describe;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            cont.update(textBox1.Text, textBox2.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cont.update("", "");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
