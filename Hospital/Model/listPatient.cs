using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class listPatient
    {
        List<patientData> patients;
        public listPatient()
        {
            patients = new List<patientData>();
        }

        public void Add(patientData pat)
        {
            patients.Add(pat);
        }

        public patientData GetValue(int number)
        {
            if (number >= 0 && number < patients.Count)
                return patients[number];
            else
                return null;
        }
        public int Size
        {
            get { return patients.Count; }
        }
    }
}
