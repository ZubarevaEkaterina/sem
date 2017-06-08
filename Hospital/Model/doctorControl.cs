using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class doctorControl
    {
       public doctorData data;
        dataBase connector;
        listDoctor docs;

        public doctorControl(dataBase _connector, listDoctor _list)
        {
           
            connector = _connector;
            docs = _list;
        }

        public doctorControl(dataBase _connector, doctorData _data)
        {
            data = _data;
            connector = _connector;
          
        }

        public doctorData load(string idUser )
        {
            List<string> doc = new List<string>();
            doc = connector.loadDoctorData(idUser);
            data.Id = doc[0];
            data.IdUser = idUser;
            data.Surname = doc[1];
            data.Name = doc[2];
            data.MiddleName = doc[3];
            data.Position = doc[4];
            data.Sex = doc[5];
            data.BirthDay = doc[6];
           
           
            return data;
        }


        public listDoctor loadlist(string idDoctor)
        {
            docs = connector.loadListDoctor(idDoctor);
            
            return docs ;
        }

        

        
        }


}
