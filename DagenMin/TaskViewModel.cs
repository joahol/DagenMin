using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    class TaskViewModel
    {
        StorageHandler shandler;

        public void Initialize() {
             shandler = new StorageHandler(); ;
            Tasks = shandler.getAllDaysTasks();
        }

        public ObservableCollection<Task> Tasks 
        { 
            get;
            set;
        }
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

    }
}
