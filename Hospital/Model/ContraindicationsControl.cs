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
            List<string> contr = new List<string>();
            contr = connector.contraindications_Load(idpat);
            data.Contraindications = contr[0];
            data.Allergy = contr[1];
            data.IdPatient = idpat;
            return data;
        }


        public void delete(string idpat,  string word)
        {
            data = load(idpat);
            connector.deleteContraindications(data, word);
        }

        
    }
}
