using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    public class TaskViewModel
    {
        StorageHandler shandler;
        private ObservableCollection<Task> tasks;

        public void Initialize()
        {
            shandler = new StorageHandler();
            shandler.createDataBase();
            Tasks = shandler.getAllDaysTasks();
        }

        public ObservableCollection<Task> Tasks { get => tasks; set => tasks = value; }

        public TaskViewModel() { }
        public String taskName
        {
            get;
            set;
        }
        public String taskDescription
        {
            get;
            set;
        }
        public bool finished
        {
            get;
            set;
        }
        public void deleteRow(Task t) {
            shandler.deleteRowById(t.id);
            tasks.Remove(t);

        }
    }
}
