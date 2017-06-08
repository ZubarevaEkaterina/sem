using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class medicine
    {
        string title;
        string way_to_use;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Way_to_use
        {
            get { return way_to_use; }
            set { way_to_use = value; }
        }
    }
}