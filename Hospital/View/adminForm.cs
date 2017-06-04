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
    public partial class adminForm : Form
    {
        dataBase connector;
        public adminForm(dataBase _connector)
        {
            InitializeComponent();
            connector = _connector;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            registration reg = new registration(connector);
            reg.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            orders listOrders = new orders(connector,0);
            listOrders.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            order newOrder = new order("", "", connector,0);
            newOrder.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
