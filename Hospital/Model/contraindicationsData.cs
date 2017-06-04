using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class contraindicationsData
    {
        string contraindications;
        string allergy;
        string idPatient;
        bool haveRecord;

        public bool HaveRecord
        {
            get { return haveRecord; }
            set { haveRecord = value; }
        }

        public string Contraindications
        {
            get { return contraindications; }
            set { contraindications = value; }
        }

        public string Allergy
        {
            get { return allergy; }
            set { allergy = value; }
        }

        public string IdPatient
        {
            get { return idPatient; }
            set { idPatient = value; }
        }
    }
}
