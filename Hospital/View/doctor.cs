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
    public partial class doctor : Form
    {
        doctorData doct;
        dataBase connector;
        string idUser;
        public doctor(string _idUser, dataBase _connector)
        {
            InitializeComponent();
            idUser = _idUser;
            connector = _connector;
        }

        private void doctor_Load(object sender, EventArgs e)
        {
            doct = connector.loadDoctorData(idUser);
            textBox1.Text = doct.ToString();
            textBox2.Text = doct.Position;
            textBox4.Text = doct.Sex;
            textBox3.Text = doct.BirthDay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            order addOrder = new order("", doct.Id,connector,1);
            addOrder.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            orders listOrders = new orders(doct.Id,connector,1);
            listOrders.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
