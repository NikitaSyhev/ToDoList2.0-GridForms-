using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToDoList2._0_GridForms_
{
    internal class DataBase
    {
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=user_database.db;Version=3;");
        public void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
                MessageBox.Show("Открыто");
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Закрыто");
            }
        }
        public SQLiteConnection getConnection() { return connection; }


    }
}

