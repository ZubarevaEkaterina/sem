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
    public partial class contraindications : Form
    {
        
        patientData idPatient;
      
        ContraindicationsControl cont;

        public contraindications(string _idPatient,  int type)
        {
           
            InitializeComponent();
            idPatient = new patientData();
            idPatient.Id = _idPatient;
            cont = new ContraindicationsControl();
      
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
            textBox1.Text = cont.load(idPatient.Id).Contraindications;
            textBox2.Text = cont.load(idPatient.Id).Allergy;
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cont.update(textBox2.Text, idPatient.Id, textBox1.Text);
         
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cont.delete(idPatient.Id, "allergia");
            Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            cont.delete(idPatient.Id, "protivo");
            Close();
        }
    }
}
