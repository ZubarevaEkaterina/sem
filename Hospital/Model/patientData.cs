using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class patientData: user
    {
        string numberP;
        public string NumberP
        {   
        get { return numberP; }
            set { numberP = value; }
        }
    }
}
