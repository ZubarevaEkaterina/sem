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
        
        string idPatient;
        dataBase connector;
        contraindicationsData cont;
        public contraindications(string _idPatient, dataBase _connector, int type)
        {
            InitializeComponent();
            idPatient = _idPatient;
            connector = _connector;
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
            cont = connector.contraindications_Load(idPatient);
            textBox1.Text = cont.Contraindications;
            textBox2.Text = cont.Allergy;
            cont.IdPatient = idPatient;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cont.Contraindications = textBox1.Text;
            cont.Allergy = textBox2.Text;
            connector.updateContraindications(cont);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connector.deleteContraindications(cont, "alg");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            connector.deleteContraindications(cont, "protivo");
            Close();
        }
    }
}
