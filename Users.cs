using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList2._0_GridForms_
{
    enum Roles
    {
        Administrator,
        User

    }


    internal class Users
    {
        private string name;
        private int password;
        private Roles role;
      


        public string Name { get { return name; } }
        public int Password { get { return password; } }
        public Roles Role
        {
            get { return role; }
            set { role = value; }
        }
       
        public Users(string name, int password, Roles role = Roles.User)
        {
            this.name = name;
            this.password = password;
            this.role = role;
          

        }
    }
}
