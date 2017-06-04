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
    public partial class showMedCard : Form
    {
        dataBase connector;
        public showMedCard(dataBase _connector)
        {
            InitializeComponent();
            connector = _connector;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.Visible = false;
                medCard showCard = new medCard(textBox1.Text, connector,1);
                showCard.ShowDialog();
                Close();
            }
            else
                MessageBox.Show("Введите номер полиса");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
