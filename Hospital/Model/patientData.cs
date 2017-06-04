using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class patientData: user
    {
        string numberofP;
        public string NumberOfPolicy
        {   
        get { return numberofP; }
            set { numberofP = value; }
        }
    }
}
