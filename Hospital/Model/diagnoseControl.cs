using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
   public class diagnoseControl
    {
        diagnoseData data;
        dataBase connector;

       public diagnoseControl(diagnoseData dat, dataBase _connector)
        {
            
            data = dat;
            connector = _connector;
        }


        public diagnoseData load(string idvisit )
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
