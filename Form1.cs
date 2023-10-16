using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace ToDoList2._0_GridForms_
{
    public partial class Form1 : Form
    {
        private List<Users> users;
        private string findUsers = $"SELECT * FROM USER";
        private string dbName = "Users.db";
      

        public Form1()
        {
            InitializeComponent();
            users = new List<Users>();

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Roles _role = Roles.User;
           
            string selectedRoles = cbRoles.SelectedItem.ToString();
            
            foreach (Roles item in Enum.GetValues(typeof(Roles)))
            {
                if (item.ToString() == selectedRoles)
                {
                    _role = item;
                }
            }

            if (textBoxLogin.Text != string.Empty && maskedTextBoxPassword.Text != string.Empty)
            {
                Users user = new Users(
                    textBoxLogin.Text,
                    maskedTextBoxPassword.Text.GetHashCode(),
                    _role);
                users.Add(user);
                
                
                foreach (var item in users)
                {
                    addUserToDB(item.Name, item.Password,item.Role);               
                }
            }
        }
        private void addUserToDB(string name, int password, Roles role)
        {

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(@"Data Source=Users.db;Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = "INSERT INTO User (NAME, PASSWORD, ROLE) VALUES (@Name, @Password, @Role)";
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Role", role.ToString());

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Пользователь добавлен");
                        }
                        else
                        {
                            MessageBox.Show("Ошибка");
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

     


        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string Login = textBoxLogin.Text;
            int Pass = maskedTextBoxPassword.Text.GetHashCode();

            DataBase dBWork = new DataBase();
            try
            {
                dBWork.OpenConnection();
                DataTable table = new DataTable();
                SQLiteCommand sqlCommand = new SQLiteCommand(findUsers, dBWork.getConnection());
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlCommand);
                sqlCommand.Parameters.Add("@NAME", DbType.String).Value = Login;
                sqlCommand.Parameters.Add("@PASSWORD", DbType.String).Value = Pass;
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(table);


                foreach (DataRow row in table.Rows)
                {
                   // MessageBox.Show("Пошли по циклу");
                    string username = row["NAME"].ToString();
                    int hashedPassword = Convert.ToInt32(row["PASSWORD"]);

                    if (Login == username && Pass == hashedPassword)
                    {
                        MessageBox.Show("Вход успешный");
                        ToDoList newForm = new ToDoList();
                        newForm.Show();
                        Hide();
                        return; 
                    }
                }

                MessageBox.Show("У вас нет доступа");
                dBWork.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
