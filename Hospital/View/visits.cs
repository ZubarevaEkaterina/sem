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
    public partial class visits : Form
    {
        
        string idPatient;
        dataBase connector;
        public visits(dataBase _connector)
        {
            InitializeComponent();
            idPatient = "";
            connector = _connector;
        }

        public visits(string _idPatient, dataBase _connector)
        {
            InitializeComponent();
            idPatient = _idPatient;
            connector = _connector;
        }


        private void visits_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(connector.loadListVisit(idPatient).ToArray());
            if(comboBox1.Items.Count>0)
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                this.Visible = false;
                visit showVisit = new visit(comboBox1.SelectedItem.ToString(), connector);
                showVisit.ShowDialog();
                this.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
