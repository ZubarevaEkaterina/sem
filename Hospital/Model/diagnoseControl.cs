using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class diagnoseControl
    {
        diagnoseData data;
        dataBase connector;

        public diagnoseControl()
        {
            data = new diagnoseData();
            connector = new dataBase();
        }


        public diagnoseData load(string idvisit)
        {
            List<string> contr = new List<string>();
            contr = connector.loadDiagnose(idvisit);
            data.Title = contr[0];
            data.Describe= contr[1];
            data.IdVisit = idvisit;
            return data;
        }

       public void update(string diagnos, string diagnoseDescribe)
        {
            data.Title = diagnos;
            data.Describe = diagnoseDescribe;
            connector.updateDiagnose(data);
        }
    }
}
