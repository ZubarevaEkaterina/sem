using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class user
    {
        string type;
        string login;
        string password;
        string numberP;
        string idUser;
        string id;
        string surname;
        string name;
        string middleName;
        string sex;
        string birthDay;
        string post;

        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        
        public string NumberP
        {
            get { return numberP; }
            set { numberP = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

      
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string IdUser
        {
            get { return id; }
            set { id = value; }
        }


        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }
        public override string ToString()
        {
            return surname + " " + name + " " + middleName;
        }
    }
}

