﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies_Timetabel
{
    class Admin
    {

        static public bool registered { get; set; }

        static public List<Admin> admin = new List<Admin>();

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Admin(string login, string password)
        {

            this.login = login;
            this.password = password;

        }

        static public void GetLoginPass(string doc)
        {

            string[] data = File.ReadAllLines(doc);

            if (data.Length == 0)
            {

                Admin.registered = false;
                return;

            }
            else
            {

                Admin.registered = true;
                Admin.admin.Add(new Admin(data[0], data[1]));

            }

        }

        static public bool CheckAndCorrect(string login, string password)
        {

            if (admin.Count == 0) { return false; }

            if (admin[0].login == login && admin[0].password == password)
            {

                return true;

            }
            return false;

        }

    }
}
