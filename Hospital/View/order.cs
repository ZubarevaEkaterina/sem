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
    public partial class order : Form
    {
        List<string> idPatients;
        List<string> idDoctors;
        dataBase connector;
        bool needAdd;
        int type;
        string idOrder;
        public order(string numberP, string idDoctor, int _type)
        {
            InitializeComponent();
            idPatients = new List<string>();
            idDoctors = new List<string>();
            
            listDoctor doctors;
            listPatient patients;
            patients = connector.loadListPatient(numberP);
            for (int i = 0; i < patients.Size; i++)
            {
                comboBox2.Items.Add(patients.GetValue(i).ToString());
                idPatients.Add(patients.GetValue(i).Id);
            }
            doctors = connector.loadListDoctor(idDoctor);
            for (int i = 0; i < doctors.Size; i++)
            {
                comboBox1.Items.Add(doctors.GetValue(i).ToString());
                idDoctors.Add(doctors.GetValue(i).Id);
            }
            needAdd = true;
            type = _type;
            if (type == 0)
            {
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = true;
            }
        }
        public order(string id, int _type)
        {
            InitializeComponent();
            idPatients = new List<string>();
            idDoctors = new List<string>();

            List<string> orders = new List<string>();

            orderData ord = connector.loadOrder(id);
            idOrder = id;
            comboBox2.Items.Add(ord.FioPatient);
            comboBox1.Items.Add(ord.FioDoctor);
            idDoctors.Add(ord.IdDoctor);
            idPatients.Add(ord.IdPatient);
            dateTimePicker1.Value = System.Convert.ToDateTime(ord.DateVisit);

            needAdd = false;
            type = _type;
            if (type == 0)
            {
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = true;
            }
            else
            {
                dateTimePicker1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button1.Visible = false;
            }
        }

        private void order_Load(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
        }
        void save()
        {
            if (comboBox1.Items.Count > 0 && comboBox2.Items.Count > 0)
            {
                orderData order = new orderData();
                order.IdDoctor = idDoctors[comboBox1.SelectedIndex];
                order.IdPatient = idPatients[comboBox1.SelectedIndex];
                order.DateVisit = dateTimePicker1.Value.ToShortDateString();
                if (needAdd)
                    idOrder = connector.addOrder(order);
                else
                    if (type == 0)
                        connector.updateOrder(order);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            save();
            Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            patientData pat = connector.loadPatientByID(idPatients[comboBox2.SelectedIndex], "");
            textBox2.Text = pat.NumberOfPolicy;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            doctorData doct = connector.loadDoctorDataByID(idDoctors[comboBox1.SelectedIndex]);
            textBox4.Text = doct.Position;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            save();
            if (comboBox1.Items.Count > 0 && comboBox2.Items.Count > 0)
            {
                visitData visit = new visitData();
                visit.DateVisit = dateTimePicker1.Value.ToShortDateString();
                visit.IdDoctor = idDoctors[comboBox1.SelectedIndex];
                visit.IdPatient = idPatients[comboBox2.SelectedIndex];
                visit.IdOrder = idOrder;
                visit.Id = connector.addVisit(visit);
                this.Visible = false;
                addVisit showVisit = new addVisit(visit, connector);
                showVisit.ShowDialog();
                this.Visible = true;
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connector.correctOrder(idOrder);
            Close();
        }
    }
}
