using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class orderControl
    {
        orderData data;
        dataBase connector;

        public orderControl()
        {
            data = new orderData();
            connector = new dataBase();
        }

        public orderData load(string id)
        {

            orderData ord = connector.loadOrder(id);
            return data;
        }

        public List<string> loadList(int _type)
        {
            List<string> data = new  List<string>();
           
            data = connector.loadListOrder(_type);

            return data;
        }

        public List<string> loadList(string _id)
        {
            List<string> data = new List<string>();

            data = connector.loadListOrder(_id); 

            return data;
        }

    }
}
