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
    public partial class orders : Form
    {
        
            dataBase connector;
            int type;

            public orders(dataBase _connector, int _type)
            {
                InitializeComponent();
                connector = _connector;
                comboBox1.Items.AddRange(connector.loadListOrder(_type).ToArray());
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                type = _type;
            }

            public orders(string idDoctor, dataBase _connector, int _type)
            {
                InitializeComponent();
                connector = _connector;
                comboBox1.Items.AddRange(connector.loadListOrder(idDoctor).ToArray());
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
                type = _type;
            }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
            {
                this.Visible = false;
                order showOrder = new order(comboBox1.SelectedItem.ToString(), connector, type);
                showOrder.ShowDialog();
                Close();
            }
        }

        private void orders_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
