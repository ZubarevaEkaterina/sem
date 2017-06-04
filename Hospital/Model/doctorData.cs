using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class doctorData:user
    {
        string position;

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

    }
}
