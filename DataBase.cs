using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;



namespace ToDoList2._0_GridForms_
{
    internal class DataBase
    {
   
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=Users.db;Version=3;");
        public SQLiteConnection getConnection() { return connection; }

        public void OpenConnection() // безопасное открытие БД с проверкой состояния
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
               
            }
        }
        public void CloseConnection() // безопасное закрытие БД с проверкой состояния
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
             
            }
        }

    }


}

