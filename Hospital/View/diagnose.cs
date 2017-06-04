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
        string idVisit;
        dataBase connector;
        diagnoseData diag;
        public diagnose(string _idVisit, dataBase _connector)
        {
            InitializeComponent();
            idVisit = _idVisit;
            connector = _connector;
        }

        private void diagnose_Load(object sender, EventArgs e)
        {
            diag = connector.loadDiagnose(idVisit);
            textBox1.Text = diag.Title;
            textBox2.Text = diag.Describe;
        }

        void update(string diagnos, string diagnoseDescribe)
        {
            diag.Title = diagnos;
            diag.Describe = diagnoseDescribe;
            connector.updateDiagnose(diag);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update(textBox1.Text, textBox2.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update("", "");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
