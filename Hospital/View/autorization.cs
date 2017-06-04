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
    public partial class autorization : Form
    {
        dataBase connector;
        public autorization()
        {
            InitializeComponent();
        }
 
        void enter(string login)
        {
            List<string> data = connector.enter(login);
            this.Visible = false;
            switch (data[0])
            {
                case "0":
                    adminForm admin = new adminForm(connector);
                    admin.ShowDialog();
                    break;
                case "1":
                    doctor doctorShow = new doctor(data[1], connector);
                    doctorShow.ShowDialog();
                    break;
                case "2":
                    patient patientShow = new patient(data[1], connector);
                    patientShow.ShowDialog();
                    break;
            }
            this.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (connector.tryLogin(textBox1.Text, textBox2.Text))
                    enter(textBox1.Text);
                else
                    MessageBox.Show("Логин и пароль не найдены в базе данных");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        private void autorization_Load(object sender, EventArgs e)
        {
            connector = new dataBase();
        }
    }
}
