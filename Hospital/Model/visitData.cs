using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class visitData
    {
        string id;
        string idOrder;
        string dateVisit;
        string doctorInfo;
        obslData obsl;
        symptoms symptom;
        recommendation recomendation;
        diagnoseData diagnose;
        string idPatient;
        string idDoctor;


        public visitData()
        {
            recomendation = new recommendation();
            obsl = new obslData();
            diagnose = new diagnoseData();
            symptom = new symptoms();
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string IdPatient
        {
            get { return idPatient; }
            set { idPatient = value; }
        }
        public string IdDoctor
        {
            get { return idDoctor; }
            set { idDoctor = value; }
        }
        public string DateVisit
        {
            get { return dateVisit; }
            set { dateVisit = value; }
        }
        public string DoctorInfo
        {
            get { return doctorInfo; }
            set { doctorInfo = value; }
        }
        public string Obsl
        {
            get { return obsl.NameObsl; }
            set { obsl.NameObsl = value; }
        }
        public string Symp
        {
            get { return symptom.Symptom; }
            set { symptom.Symptom = value; }
        }
        public string Recomd
        {
            get { return recomendation.recommend; }
            set { recomendation.recommend = value; }
        }
        public string Medicament
        {
            get { return recomendation.meds.Title; }
            set { recomendation.meds.Title = value; }
        }
        public string Diagnose
        {
            get { return diagnose.Title; }
            set { diagnose.Title = value; }
        }
        public string IdOrder
        {
            get { return idOrder; }
            set { idOrder = value; }
        }
    }
}
