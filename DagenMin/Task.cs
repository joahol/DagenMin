using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    
   public class Task : INotifyPropertyChanged
    {
        private String taskname;
        private String taskdescription;
        private DateTime datetime;

        public event PropertyChangedEventHandler PropertyChanged;
        public String taskName {
            get { return taskname; 
            }
            set {
                taskname = value;
                RaisePropertyChanged("taskName");
            }
        }
public DateTime schedueld {
            get;
            set;
        }

       public String taskDescription {
            get { return taskdescription; }


            set { taskdescription = value;
                RaisePropertyChanged("taskDescription");

            }
        
}
        public bool finished { get; set; }
        public int id = -1;

      

        public Task() { }
        public Task(String taskname, String taskdescription, bool finishe) {
            taskName = taskname;
            taskDescription = taskdescription;
            finished = finishe;
        }
        public Task(int iD, String taskname, String taskdescription, bool finishe)
        {
            id = iD;
            taskName = taskname;
            taskDescription = taskdescription;
            finished = finishe;
        }
        public Task(int ID, String taskname, String taskdescription, bool finishe, DateTime dta) {
            id = ID;
            taskName = taskname;
            taskDescription = taskdescription;
            finished = finishe;
            schedueld =dta;
        }
        public Task(String taskname, String taskdescription, bool finishe, DateTime dta)
        {
            taskName = taskname;
            taskDescription = taskdescription;
            finished = finishe;
            schedueld = dta;
        }

        private void RaisePropertyChanged(String property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
