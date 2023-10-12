using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ToDoList2._0_GridForms_
{
    public partial class Form1 : Form
    {
        private List<Users> users;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != string.Empty && maskedTextBoxPassword.Text != string.Empty)
            {

                Users user = new Users(
                    textBoxLogin.Text,
                    maskedTextBoxPassword.Text.GetHashCode());
                users.Add(user);
              
                foreach (var item in users)
                {
                    addUserToDB(item.Name, item.Password);
                    updateGridFromDB();
                    
                }
            }
        }
    }
}
