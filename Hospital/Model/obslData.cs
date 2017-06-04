using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class obslData
    {
        string idVisit;
        string dateObsl;
        string nameObsl;
        string result;


        public string IdVisit
        {
            get { return idVisit; }
            set { idVisit = value; }
        }

        public string DateObsl
        {
            get { return dateObsl; }
            set { dateObsl = value; }
        }

        public string NameObsl
        {
            get { return nameObsl; }
            set { nameObsl = value; }
        }

        public string Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
