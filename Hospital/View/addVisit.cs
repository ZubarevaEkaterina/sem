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
    public partial class addVisit : Form
    {
        visitData visit;
        dataBase connector;
        public addVisit(visitData _visit, dataBase _connector)
        {
            InitializeComponent();
            visit = _visit;
            connector = _connector;
        }

        private void addVisit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            simp showSimp = new simp(visit.Id, connector);
            showSimp.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            obsl showObsl = new obsl(visit.Id, connector);
            showObsl.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            recomend showRecomd = new recomend(visit.Id, connector);
            showRecomd.ShowDialog();
            this.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            diagnose showDiagnose = new diagnose(visit.Id, connector);
            showDiagnose.ShowDialog();
            this.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            string numberP = connector.loadPatientByID(visit.IdPatient, "").NumberOfPolicy;
            medCard showCard = new medCard(numberP, connector, 1);
            showCard.ShowDialog();
            this.Visible = true;
        }
    }
}
