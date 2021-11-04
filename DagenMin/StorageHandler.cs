using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections.ObjectModel;

namespace DagenMin
{
    class StorageHandler
    {
        String sqlSelectString = "Select * from tasks";


        public ObservableCollection<Task> getAllDaysTasks() {
            SQLiteConnection con = getSQLConnection();
            con.Open();
            SQLiteCommand sqlcom = new SQLiteCommand(sqlSelectString,con);
            SQLiteDataReader sqlread = sqlcom.ExecuteReader();
            ObservableCollection<Task> tasks = new();
            while (sqlread.Read()) {
                Console.WriteLine(sqlread[1] + " " + sqlread[2] + " " + sqlread[3]);
                Task t = new Task(int.Parse(sqlread[0].ToString()), sqlread[1].ToString(), sqlread[2].ToString(), bool.Parse(sqlread[3].ToString()),DateTime.Parse(sqlread[4].ToString()));
                tasks.Add(t);
            }
         
            sqlread.Close();
            con.Close();
            return tasks;
        }
        private SQLiteConnection getSQLConnection() {
            SQLiteConnection con = new SQLiteConnection(@"Data source=C:\Users\Joakim\Documents\MyDay.db3");
            return con;
        }

        internal void updateTask(Task t)
        {
            SQLiteConnection con = getSQLConnection();
            con.Open();
            String deleteSQL = "UPDATE tasks SET taskname='" + t.taskName + "', description='" + t.taskDescription+ "', taskdate='" + t.schedueld.ToString() + "' WHERE taskid='" + t.id + "';";
            //get local path + "','" + task.schedueld.ToString() + "');";
            String localPath = System.IO.Directory.GetCurrentDirectory().ToString();

            SQLiteCommand com = new SQLiteCommand(con);

            com.CommandText = deleteSQL;
            com.ExecuteNonQuery();
            con.Close();

        }

        public bool storeNewTask(Task task) {
            bool result = false;
            SQLiteConnection con = getSQLConnection();
            con.Open();
            String sqlString = "insert into tasks (taskname,description,finished,taskdate) values('" + task.taskName + "','" + task.taskDescription + "','" + task.finished.ToString() + "','" + task.schedueld.ToString() + "');";
            SQLiteCommand sqlCom = new SQLiteCommand(sqlString, con);
            sqlCom.ExecuteNonQuery();
            con.Close();
           
            return result;
        }

        public bool updateTask() {
            return false;
        }

        #region DataBaseCreation
        //check if database exist
        public Boolean dataBaseExists() {
            Boolean exists = false;
            SQLiteConnection con = new SQLiteConnection();
            return exists;
        }


        //Creates a new database at the root path of the application
        public Boolean createDataBase() {
            Boolean success = false;

            String dbArchitectureSQL = "CREATE TABLE IF NOT EXISTS tasks (taskid INTEGER  PRIMARY KEY AUTOINCREMENT,taskname TEXT NOT NULL,description, finished BOOLEAN NOT NULL, taskdate DATETIME); ";
            //get local path
            String localPath = System.IO.Directory.GetCurrentDirectory().ToString();
            //create a database file at the root 
            SQLiteConnection.CreateFile("myDay.db3");
            SQLiteConnection con = new SQLiteConnection("data source=myDay.db3");
            con.Open();
            SQLiteCommand com = new SQLiteCommand(con);

            com.CommandText = dbArchitectureSQL;
            com.ExecuteNonQuery();
            con.Close();


            //commt file 

            //return successfull

            return success;
        }

        #endregion

#region DataBaseQuerries
        public void deleteRowById(int ID) {
            SQLiteConnection con = getSQLConnection();
            con.Open();
            String deleteSQL = "Delete FROM tasks WHERE taskid='"+ID+"'; ";
            //get local path
            String localPath = System.IO.Directory.GetCurrentDirectory().ToString();
          
            SQLiteCommand com = new SQLiteCommand(con);

            com.CommandText = deleteSQL;
            com.ExecuteNonQuery();
            con.Close();


        }
        #endregion
    }
}
