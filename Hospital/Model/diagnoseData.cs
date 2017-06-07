using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class diagnoseData
    {
        string idVisit;
        string title;
        string describe;

        public diagnoseData()
        {
           
        }
        public string IdVisit
        {
            get { return idVisit; }
            set { idVisit = value; }
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
