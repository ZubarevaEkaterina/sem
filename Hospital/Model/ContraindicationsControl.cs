using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital
{
    class ContraindicationsControl
    {
        
        string idpat;
        contraindicationsData data;
        
        dataBase connector;

        public ContraindicationsControl(contraindicationsData dat, dataBase _connector, string _idpat)
        {
            data = dat;
            connector = new dataBase();
            idpat = _idpat;
            connector = _connector;

        }

        public void update(string allergy, string contr)
        {
            data.Allergy = allergy;
            data.Contraindications = contr;
            data.IdPatient = idpat;
            connector.updateContraindications(data);
         
        }

        public contraindicationsData load()
        {
            List<string> contr = new List<string>();
            contr = connector.contraindications_Load(idpat);
            data.Contraindications = contr[0];
            data.Allergy = contr[1];
            data.IdPatient = idpat;
            return data;
        }


        public void delete(string word)
        {
            data = load();
            connector.deleteContraindications(data, word);
        }

        
    }
}
