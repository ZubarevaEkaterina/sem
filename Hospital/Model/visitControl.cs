using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class visitControl
    {
        dataBase connector;
        string idvisit;

        public visitControl(string _idVisit)
         {
            connector = new dataBase();
            idvisit = _idVisit;
            
        }

        public visitData load()
        {
            visitData visit = connector.loadVisit(idvisit);
           
            return visit;
        }

    }
}
