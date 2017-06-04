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
        string idPatient;
        string idDoctor;
        string dateVisit;
        string fioPatient;
        string fioDoctor;
        string postDoctor;
        string numberP;
        string correct;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string IdPatient
        {
            get { return idPatient; }
            set { idPatient = value; }
        }

        public string IdDoctor
        {
            get { return idDoctor; }
            set { idDoctor = value; }
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
            get { return postDoctor; }
            set { postDoctor = value; }
        }

        public string NumberP
        {
            get { return numberP; }
            set { numberP = value; }
        }

        public string Correct
        {
            get { return correct; }
            set { correct = value; }
        }



    }
}
