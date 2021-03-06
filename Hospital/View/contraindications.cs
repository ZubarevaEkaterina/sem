﻿using System;
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
    public partial class contraindications : Form
    {
        
        patientData idPatient;
      
        ContraindicationsControl cont;
        contraindicationsData data;
        dataBase d;
        

        public contraindications(string _idPatient,  int type, dataBase _d, contraindicationsData _dat)
        {
           
            InitializeComponent();
            idPatient = new patientData();
            idPatient.Id = _idPatient;
            d = _d;
            data = _dat;
           
            cont = new ContraindicationsControl(data, d, _idPatient);
            if (type == 2)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                button1.Visible = false;
                button2.Visible = false;
            }
        }

        private void contraindications_Load(object sender, EventArgs e)
        {
            textBox1.Text = cont.load().Contraindications;
            textBox2.Text = cont.load().Allergy;
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cont.update(textBox2.Text, textBox1.Text);
         
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cont.delete( "allergia");
            Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            cont.delete( "protivo");
            Close();
        }
    }
}
