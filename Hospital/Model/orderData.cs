using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class orderData
    {
        string id;
        patientData Patient;
        doctorData Doctor;
        string dateVisit;
        string fioPatient;
        string fioDoctor;
        string correct;

        public orderData()
        {
            Patient = new patientData();
            Doctor = new doctorData();
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string IdPatient
        {
            get { return Patient.Id; }
            set { Patient.Id = value; }
        }

        public string IdDoctor
        {
            get { return Doctor.Id; }
            set { Doctor.Id = value; }
        }

        public string DateVisit
        {
            get { return dateVisit; }
            set { dateVisit = value; }
        }

        public string FioPatient
        {
            get { return fioPatient; }
            set { fioPatient = value; }
        }

        public string FioDoctor
        {
            get { return fioDoctor; }
            set { fioDoctor = value; }
        }

        public string PostDoctor
        {
            get { return Doctor.Position; }
            set { Doctor.Position = value; }
        }

        public string NumberP
        {
            get { return Patient.NumberOfPolicy; }
            set { Patient.NumberOfPolicy = value; }
        }

        public string Correct
        {
            get { return correct; }
            set { correct = value; }
        }



    }
}
