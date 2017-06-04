using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class listDoctor
    {
         List<doctorData> doctors;
         public listDoctor()
        {
            doctors = new List<doctorData>();
        }

        public void Add(doctorData pat)
        {
            doctors.Add(pat);
        }

        public doctorData GetValue(int number)
        {
            if (number >= 0 && number < doctors.Count)
                return doctors[number];
            else
                return null;
        }
        public int Size
        {
            get { return doctors.Count; }
        }
    }
}
