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
                Task t = new Task(int.Parse(sqlread[0].ToString()), sqlread[1].ToString(), sqlread[2].ToString(), bool.Parse(sqlread[3].ToString()));
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
        public bool storeNewTask(Task task) {
            bool result = false;
            SQLiteConnection con = getSQLConnection();
            con.Open();
            String sqlString = "insert into tasks (taskname,description,finished) values('" + task.taskName + "','" + task.taskDescription + "','" + task.finished.ToString() + "')";
            SQLiteCommand sqlCom = new SQLiteCommand(sqlString, con);
            sqlCom.ExecuteNonQuery();
            con.Close();
           
            return result;
        }

        public bool updateTask() {
            return false;
        }
    }
}
