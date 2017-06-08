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
            List<string> ord = new List<string>();
           // ord = connector.loadOrder(id);
            data.ID = id;
            data.IdDoctor = ord[3];
            data.IdPatient = ord[1];
            data.FioPatient = ord[0];
            data.FioDoctor = ord[2];
            data.DateVisit = ord[4];
            data.Correct = ord[5];
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
