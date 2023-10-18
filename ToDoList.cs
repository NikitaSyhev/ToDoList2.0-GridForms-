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
using System.Data.SqlClient;

namespace ToDoList2._0_GridForms_
{




    public partial class ToDoList : Form
    {
        string task = "SELECT * FROM ToDoList";
        
        string addTask = "INSERT INTO ToDoList(Name, Task, DeadLine) VALUES(@name, " +
        "@task, @deadline);";
        DataBase dBtasks;
        SQLiteDataAdapter adapter;
        SQLiteCommandBuilder commandBuilder;
        SQLiteCommand command;
        DataTable table = new DataTable();
        DataSet dateSet;


        public ToDoList()
        {
            InitializeComponent();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
            dBtasks = new DataBase();
            dBtasks.OpenConnection();
            command = new SQLiteCommand(task, dBtasks.getConnection());
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            dateSet = new DataSet();
            adapter.Fill(dateSet);
            dataGridView.DataSource = dateSet.Tables[0];
          //dataGridView.Columns["ID"].ReadOnly = true;
            dBtasks.CloseConnection();



        }

        private void buttonAdd_Click(object sender, EventArgs e) // метод с Metanit
        {
            DataRow row = dateSet.Tables[0].NewRow(); // добавляем новую строку в DataTable
            dateSet.Tables[0].Rows.Add(row);
        }

        private void buttonDelete_Click(object sender, EventArgs e)// метод с Metanit
        {
            // удаляем выделенные строки из dataGridView
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                dataGridView.Rows.Remove(row);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)// метод с Metanit
        {
            dBtasks.OpenConnection();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(task, dBtasks.getConnection());
            commandBuilder = new SQLiteCommandBuilder(adapter);
            adapter.InsertCommand = new SQLiteCommand(addTask, dBtasks.getConnection());
            adapter.InsertCommand.Parameters.Add(new SQLiteParameter("@name", DbType.String, 100, "Name"));
            adapter.InsertCommand.Parameters.Add(new SQLiteParameter("@task", DbType.String, 100, "Task"));
            adapter.InsertCommand.Parameters.Add(new SQLiteParameter("@deadline", DbType.Int32, 100, "DeadLine"));
         //   SQLiteParameter parameter = adapter.InsertCommand.Parameters.Add("@ID", DbType.Int64, 0, "ID");
            adapter.Update(dateSet);
            dBtasks.CloseConnection();
        }
    }
}
