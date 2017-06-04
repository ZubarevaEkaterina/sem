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
    public partial class patient : Form
    {
        dataBase connector;
        public patient(string _idUser, dataBase _connector)
        {
            InitializeComponent();
            connector = _connector;
            patientData patient = connector.loadPatientByID("", _idUser);
            textBox1.Text = patient.ToString();
            textBox2.Text = patient.Sex;
            textBox3.Text = patient.NumberP;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            medCard medCard = new medCard(textBox3.Text,connector,2);
            medCard.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            order addOrder = new order(textBox3.Text,"",connector,2);
            addOrder.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
