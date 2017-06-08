﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class doctorControl
    {
        doctorData data;
        dataBase connector;

        public doctorControl()
        {
            data = new doctorData();
            connector = new dataBase();
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

        
        }


}
