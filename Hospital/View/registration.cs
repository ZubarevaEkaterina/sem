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
    public partial class registration : Form
    {
        dataBase connector;
        public registration(dataBase _connector)
        {
            InitializeComponent();
            connector = _connector;
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox4.Checked = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                checkBox2.Checked = false;
                label6.Visible = false;
                textBox6.Visible = false;
                label7.Visible = true;
                textBox7.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                checkBox1.Checked = false;
                label7.Visible = false;
                textBox7.Visible = false;
                label6.Visible = true;
                textBox6.Visible = true;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked && checkBox4.Checked)
            {
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked && checkBox4.Checked)
            {
                checkBox4.Checked = false;
            }
        }



        bool regNewUser()
        {
            user newUser = new user();
            newUser.Sex = checkBox4.Checked == true ? "0" : "1";
            newUser.Type = checkBox1.Checked == true ? "1" : "2";
            newUser.Surname = textBox1.Text;
            newUser.Name = textBox2.Text;
            newUser.MiddleName = textBox3.Text;
            newUser.BirthDay = dateTimePicker1.Value.ToShortDateString();
            newUser.Post = textBox7.Text;
            newUser.Login = textBox5.Text;
            newUser.Password = textBox4.Text;
            return connector.regNewUser(newUser);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dopInfo = checkBox1.Checked == true ? textBox7.Text : textBox6.Text;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && dopInfo != "" && textBox4.Text != "" && textBox5.Text != "" && textBox8.Text != "")
            {
                if (textBox4.Text == textBox8.Text)
                {
                    if (regNewUser())
                    {
                        MessageBox.Show("Пользователь добавлен!");
                        Close();
                    }
                    else
                        MessageBox.Show("Введенный логин уже занят!");
                }
                else
                    MessageBox.Show("Пароли не совпадают!");
            }
            else
                MessageBox.Show("Заполнены не все поля!");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
