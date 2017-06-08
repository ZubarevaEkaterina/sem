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
        string idUser;
        doctorControl doc;
       
        public doctor(string _idUser)
        {
            InitializeComponent();
            idUser = _idUser;
            doc = new doctorControl();
           
        }

        private void doctor_Load(object sender, EventArgs e)
        {
            
            textBox1.Text = doc.load(idUser).Surname + " " + doc.load(idUser).Name +" " + doc.load(idUser).MiddleName;
            textBox2.Text = doc.load(idUser).Position;
            textBox4.Text = doc.load(idUser).Sex;
            textBox3.Text = doc.load(idUser).BirthDay;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            
            order addOrder = new order("", doc.load(idUser).Id,1);
            addOrder.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            orders listOrders = new orders(doc.load(idUser).Id, 1);
            listOrders.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
