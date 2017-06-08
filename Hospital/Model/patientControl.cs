using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class patientControl
    {
        patientData data;
        dataBase connector;
        listPatient pats;

        public patientControl()
        {
            data = new patientData();
            connector = new dataBase();
            pats = new listPatient();
        }


        public listPatient loadlist(string idPat)

        { 

            pats = connector.loadListPatient(idPat);

            return pats;
        }
    }

}
