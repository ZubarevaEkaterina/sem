using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital
{
    class ContraindicationsControl
    {
        contraindicationsData data;
        dataBase connector;

        public ContraindicationsControl ()
        {
            data = new contraindicationsData();
            connector = new dataBase();
        }
        public void update(string allergy, string idpat, string contr)
        {
            data.Allergy = allergy;
            data.Contraindications = contr;
            data.IdPatient = idpat;
            connector.updateContraindications(data);
        }

        public contraindicationsData load(string idpat)
        {
            data = connector.contraindications_Load(idpat);
            return data;
        }
    }
}
