using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
namespace Hospital
{
    public class dataBase
    {
       public  OleDbConnection connection;
        OleDbCommand command;
        public dataBase()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bd.accdb");
            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
        }
        ~dataBase()
        {
            try
            {
                connection.Close();
            }
            catch { }
        }
        string getDate(string date)
        {
            DateTime dateTime = System.Convert.ToDateTime(date);
            return getDate(dateTime);
        }
        string getDate(DateTime date)
        {
            return date.Day + "/" + date.Month + "/" + date.Year;
        }
        public List<string>  loadDoctorData(string idUser)
        {
            List<string> data = new List<string>();
            
            try
            {
                command.CommandText = "Select * from [doctor] where [idUser] = " + idUser;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    data.Add(reader.GetValue(0).ToString().Trim());//id
                    data.Add(reader.GetValue(2).ToString().Trim());//sur
                    data.Add(reader.GetValue(3).ToString().Trim());//name
                    data.Add(reader.GetValue(4).ToString().Trim());//middle
                    data.Add(reader.GetValue(5).ToString().Trim());//pos
                    data.Add(reader.GetValue(6).ToString().Trim() == "0" ? "Муж" : "Жен");//sex
                    data.Add(System.Convert.ToDateTime(reader.GetValue(7).ToString().Trim()).ToShortDateString());//birth
                 
                }
            }
            catch { }
            return data;
        }
        public doctorData loadDoctorDataByID(string idDoctor)
        {
            doctorData doct = new doctorData();
            try
            {
                command.CommandText = "Select [Post] from [doctor] where [Код] = " + idDoctor;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    doct.Position = reader.GetValue(0).ToString().Trim();
                }
            }
            catch { }
            return doct;
        }
        public bool tryLogin(string login, string password)
        {
            bool success = false;
            try
            {
                command.CommandText = "Select count(*) from [users] where [login] = '" + login + "' and [password] = '" + password + "';";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.GetValue(0).ToString().Trim() != "0")
                        success = true;
                    else
                        success = false;
                }
            }
            catch { return false; }
            return success;
        }
        public List<string> enter(string login)
        {
            List<string> data = new List<string>();
            try
            {
                command.CommandText = "Select [type],[Код] from [users] where [login] = '" + login + "';";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    data.Add(reader.GetValue(0).ToString().Trim());
                    data.Add(reader.GetValue(1).ToString().Trim());
                }
            }
            catch { }
            return data;
        }
      
            
        public List<string> contraindications_Load(string idPatient)
        { 
            bool HaveRecord = false;
            List<string> data = new List<string>();
            try
            { 
                command.CommandText = "Select count(*) from [protivopokazaniya] where [idPatient] = " + idPatient;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.GetValue(0).ToString().Trim() != "0")
                        HaveRecord = true;
                    

                }
            }
              
            catch { }
            
            if (HaveRecord)
            {
                try
                {
                    command.CommandText = "Select * from [protivopokazaniya] where [idPatient] = " + idPatient;
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        data.Add(reader.GetValue(2).ToString());
                        data.Add(reader.GetValue(3).ToString());


                    }
                }
                catch { }
                }
            return data;
           

        }
        public void updateContraindications(contraindicationsData cont)
        {
            if (cont.HaveRecord)
            {
                try
                {
                    command.CommandText = "Update [protivopokazaniya] set [protivo] = '" + cont.Contraindications + "', [allergiya] = '" + cont.Allergy + "' where [idPatient] = " + cont.IdPatient;
                    command.ExecuteNonQuery();
                }
                catch { }
            }
            else
            {
                try
                {
                    command.CommandText = "Insert into [protivopokazaniya] ([protivo],[allergiya],[idPatient]) values ('" + cont.Contraindications + "', '" + cont.Allergy + "'," + cont.IdPatient + ")";
                    command.ExecuteNonQuery();
                }
                catch { }
            }
        }

        public void deleteContraindications(contraindicationsData cont, string atr)
        {
           
               try
                {
                    command.CommandText = "Update [protivopokazaniya] set ["+atr+"] = '' where [idPatient] = " + cont.IdPatient;
                    command.ExecuteNonQuery();
               }
               catch {
                command.CommandText = "delete from [protivopokazaniya]  where [idPatient] = " + cont.IdPatient;
                command.ExecuteNonQuery();
            }
            
        }
        public List<string> loadDiagnose(string idVisit)
        {
            List<string> data = new List<string>();
             
            try
            {
                command.CommandText = "Select [diagnose],[diagnoseDescribe] from [visit] where [Код] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    data.Add(reader.GetValue(0).ToString());
                    data.Add(reader.GetValue(1).ToString());
                }
            }
            catch { }
            return data;
        }
        public void updateDiagnose(diagnoseData diag)
        {
            try
            {
                command.CommandText = "Update [visit] set [diagnose] = '" + diag.Title + "', [diagnoseDescribe] = '" + diag.Describe + "' where [Код] = " + diag.IdVisit;
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public List<string> loadPatient(string numberP)
       
        {
            List<string> data = new List<string>();
          
            try
            {
                command.CommandText = "Select * from [patient] where [NumberP] = '" + numberP + "';";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    data.Add(reader.GetValue(0).ToString().Trim());//id
                    data.Add(reader.GetValue(2).ToString().Trim());//surn
                    data.Add(reader.GetValue(3).ToString().Trim());//name
                    data.Add(reader.GetValue(4).ToString().Trim());//middle
                    data.Add(reader.GetValue(6).ToString().Trim() == "0" ? "Муж" : "Жен");//sex
                    data.Add(reader.GetValue(5).ToString().Trim());//birth
                    data.Add(numberP);//polic
                  
                }
            }
            catch { }
            return data;
        }
        public patientData loadPatientByID(string idPatient, string idUser)
        {
            patientData pat = new patientData();
            try
            {
                command.CommandText = "Select * from [patient]";
                
                if(idPatient!="")
                    command.CommandText+=" where [Код] = " + idPatient + ";";
                else
                    command.CommandText += " where [idUser] = " + idUser;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    pat.Id = reader.GetValue(0).ToString().Trim();
                    pat.Surname = reader.GetValue(2).ToString().Trim();
                    pat.Name = reader.GetValue(3).ToString().Trim();
                    pat.MiddleName = reader.GetValue(4).ToString().Trim();
                    pat.Sex = reader.GetValue(6).ToString().Trim() == "0" ? "Муж" : "Жен";
                    pat.BirthDay = reader.GetValue(5).ToString().Trim();
                    pat.NumberOfPolicy = reader.GetValue(7).ToString().Trim();
                }
            }
            catch { }
            return pat;
        }
        public string addOrder(orderData order)
        {
            string idOrder = "";
            command.CommandText = "Insert into [order] ([idPatient],[idDoctor],[dateOrder],[correct]) Values (" + order.IdPatient + "," + order.IdDoctor + ",#" + getDate(order.DateVisit) + "#,0)";
            command.ExecuteNonQuery();
            command.CommandText = "Select max(Код) from [order]";
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                idOrder = reader.GetValue(0).ToString().Trim();
            }
            return idOrder;
        }
        public orderData loadOrder(string idOrder)
        {
            string tmp;
            orderData ord = new orderData();
            command.CommandText = "Select * from [order Запрос] where [order_Код] = " + idOrder;
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                tmp = "";
                for (int i = 0; i < 3; i++)
                    tmp += reader.GetValue(i + 2).ToString().Trim() + " ";
                ord.FioPatient = tmp;
                ord.IdPatient = reader.GetValue(1).ToString().Trim();

                tmp = "";
                for (int i = 0; i < 3; i++)
                    tmp += reader.GetValue(i + 6).ToString().Trim() + " ";
                ord.FioDoctor = tmp;
                ord.IdDoctor = reader.GetValue(5).ToString().Trim();
                ord.DateVisit = reader.GetValue(10).ToString().Trim();
            }
            return ord;
        }
        public listDoctor loadListDoctor(string idDoctor)
        {
            listDoctor doctors = new listDoctor();
            if (idDoctor != "")
                command.CommandText = "Select * from [doctor] where [Код] = " + idDoctor;
            else
                command.CommandText = "Select * from [doctor]";

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    doctorData doct = new doctorData();
                    doct.Id = reader.GetValue(0).ToString().Trim();
                    doct.Surname = reader.GetValue(2).ToString().Trim();
                    doct.Name = reader.GetValue(3).ToString().Trim();
                    doct.MiddleName = reader.GetValue(4).ToString().Trim();
                    doctors.Add(doct);
                }
            }
            return doctors;
        }
        public listPatient loadListPatient(string numberP)
        {
            listPatient patients = new listPatient();
            if (numberP != "")
                command.CommandText = "Select * from [patient] where [NumberP] = '" + numberP + "'";
            else
                command.CommandText = "Select * from [patient]";

            using (OleDbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    patientData pat = new patientData();
                    pat.Id = reader.GetValue(0).ToString().Trim();
                    pat.Surname = reader.GetValue(2).ToString().Trim();
                    pat.Name = reader.GetValue(3).ToString().Trim();
                    pat.MiddleName = reader.GetValue(4).ToString().Trim();
                    patients.Add(pat);
                }
            }
            return patients;
        }
        public List<string> loadListOrder(int type)
        {
            List<string> orders = new List<string>();
            try
            {
                command.CommandText = "Select [Код] from [order]";
                if (type < 2)
                    command.CommandText += "where [correct]=0";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        orders.Add(reader.GetValue(0).ToString().Trim());
                }
            }
            catch { }
            return orders;
        }
        public List<string> loadListOrder(string idDoctor)
        {
            List<string> orders = new List<string>();
            try
            {
                command.CommandText = "Select [Код] from [order] where idDoctor = " + idDoctor +" and [correct] = 1";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        orders.Add(reader.GetValue(0).ToString().Trim());
                }
            }
            catch { }
            return orders;
        }
        public bool regNewUser(user newUser)
        {
            string idUser;
            bool success = true;
            try
            {
                command.CommandText = "Select count(*) from [users] where [login] = '" + newUser.Login + "';";
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (reader.GetValue(0).ToString().Trim() != "0")
                        success = false;
                }

                if (success)
                {
                    command.CommandText = "Insert into [users] ([login],[password],[type]) values ('" + newUser.Login + "','" + newUser.Password + "'," + newUser.Type + ")";
                    command.ExecuteNonQuery();
                    command.CommandText = "Select max(Код) from users";
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        idUser = reader.GetValue(0).ToString().Trim();
                    }
                    if (newUser.Type == "1")
                        command.CommandText = "Insert into doctor ([idUser],[Surname],[Name],[Middlename],[Post],[Sex],[BirthDay]) values (" + idUser + ",'"
                            + newUser.Surname + "','"
                            + newUser.Name + "','"
                            + newUser.MiddleName + "','"
                            + newUser.Post + "',"
                            + newUser.Sex + ", #"
                            + getDate(newUser.BirthDay) + "#)";
                    else
                        command.CommandText = "Insert into patient ([idUser], [Surname], [Name], [Middlename], [BirthDay], [Sex], [NumberP]) values (" + idUser + ",'"
                            + newUser.Surname + "','"
                            + newUser.Name + "','"
                            + newUser.MiddleName + "',#"
                            + getDate(newUser.BirthDay) + "#,"
                            + newUser.Sex + ",'"
                            + newUser.NumberP + "')";
                    command.ExecuteNonQuery();

                    success = true;
                }
            }
            catch
            {
                return false;
            }
            return success;
        }
        public visitData loadVisit(string idVisit)
        {
            visitData visit = new visitData();
            try
            {
                command.CommandText = "Select * from [visit_Запрос] where [Код] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();

                    visit.DateVisit = reader.GetValue(0).ToString().Trim();
                    visit.DoctorInfo = "";
                    for (int i = 0; i < 4; i++)
                        visit.DoctorInfo += reader.GetValue(i + 1).ToString().Trim() + " ";
                    visit.Obsl = reader.GetValue(5).ToString().Trim();
                    visit.Symp = reader.GetValue(6).ToString().Trim();
                    visit.Recomd = reader.GetValue(7).ToString().Trim();
                    visit.Medicament = reader.GetValue(8).ToString().Trim();
                    visit.Diagnose = reader.GetValue(9).ToString().Trim();
                }
            }
            catch { }
            return visit;
        }
        public List<string> loadListVisit(string idPatient)
        {
            List<string> visits = new List<string>();
            try
            {
                command.CommandText = "Select [Код] from [visit]";
                if (idPatient != "")
                    command.CommandText += "where [idPatient] = " + idPatient;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        visits.Add(reader.GetValue(0).ToString().Trim());
                }
            }
            catch { }
            return visits;
        }
        public obslData loadObls(string idVisit)
        {
            obslData obsl = new obslData();
            try
            {
                command.CommandText = "select * from [obsl] where [idVisit] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        obsl.DateObsl = reader.GetValue(2).ToString().Trim();
                        obsl.NameObsl = reader.GetValue(3).ToString().Trim();
                        obsl.Result = reader.GetValue(4).ToString().Trim();
                    }
                    else
                        obsl = null;
                }
            }
            catch { }
            return obsl;
        }
        public void deleteObsl(string idVisit)
        {
            try
            {
                command.CommandText = "Delete from [obsl] where [idVisit] = " + idVisit;
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public void addObsl(obslData newObsl)
        {
            try
            {
                command.CommandText = "Insert into [obsl] ([idVisit],[dateObsl],[nameObsl],[result]) values (" + newObsl.IdVisit + ",#" + getDate(newObsl.DateObsl) + "#,'" + newObsl.NameObsl + "','" + newObsl.Result + "')";
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public string addVisit(visitData visit)
        {
            string idVisit = "";
            try
            {
                command.CommandText = "Select [Код] from [visit] where [idOrder] = " + visit.IdOrder;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        idVisit = reader.GetValue(0).ToString().Trim();
                    }
                }
                if (idVisit == "")
                {
                    command.CommandText = "Insert into [visit] ([idDoctor],[idPatient],[dateVisit],[idOrder]) values (" + visit.IdDoctor + "," + visit.IdPatient + ",#" + getDate(visit.DateVisit) + "#," + visit.IdOrder + ")";
                    command.ExecuteNonQuery();
                    command.CommandText = "select max([Код]) from [visit]";
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        idVisit = reader.GetValue(0).ToString().Trim();
                    }
                }
            }
            catch { }
            return idVisit;
        }
        public string loadSimp(string idVisit)
        {
            string simp = "";
            try
            {
                command.CommandText = "select [simp] from [visit] where [Код] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    simp = reader.GetValue(0).ToString().Trim();
                }
            }
            catch { }
            return simp;
        }
        public void updateSimp(string simp, string idVisit)
        {
            try
            {
                command.CommandText = "update [visit] set [simp] = '" + simp + "' where [Код] = " + idVisit;
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public string loadRecomd(string idVisit)
        {
            string recomd = "";
            try
            {
                command.CommandText = "select [recomend] from [visit] where [Код] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    recomd = reader.GetValue(0).ToString().Trim();
                }
            }
            catch { }
            return recomd;
        }
        public void updateRecomd(string recomd, string idVisit)
        {
            try
            {
                command.CommandText = "update [visit] set [recomend] = '" + recomd + "' where [Код] = " + idVisit;
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public medicine loadMed(string idVisit)
        {
            medicine med = new medicine();
            try
            {
                command.CommandText = "select [medicament],[medicamentUsing] from [visit] where [Код] = " + idVisit;
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    med.Title = reader.GetValue(0).ToString().Trim();
                    med.Way_to_use = reader.GetValue(1).ToString().Trim();
                }
            }
            catch { }
            return med;
        }
        public void updateMed(string med, string medicamentUsing, string idVisit)
        {
            try
            {
                command.CommandText = "update [visit] set [medicament] = '" + med + "', [medicamentUsing] = '" + medicamentUsing + "' where [Код]= " + idVisit;
                command.ExecuteNonQuery();
            }
            catch { }
        }
        public void correctOrder(string idOrder)
        {
            try
            {
                command.CommandText = "Update [order] set [correct] = 1 where Код = " + idOrder;
                command.ExecuteNonQuery();
            } 
            catch
            { }
        }
        public void updateOrder(orderData update)
        {
            command.CommandText = "Update  [order] set [idPatient] = "+update.IdPatient+", [idDoctor] = "+update.IdDoctor+",[dateOrder] = #" + getDate(update.DateVisit) + "# where Код = "+update.ID;
            command.ExecuteNonQuery();
            
        }
    }
}
