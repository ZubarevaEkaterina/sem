using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class diagnoseData
    {
        visitData idVisit;
        string title;
        string describe;

        public diagnoseData()
        {
            idVisit = new visitData();
        }
        public string IdVisit
        {
            get { return idVisit.Id; }
            set { idVisit.Id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Describe
        {
            get { return describe; }
            set { describe = value; }
        }
    }
}
