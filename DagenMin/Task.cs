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
       public String taskName { get; set; }
       public String taskDescription { get; set; }
        public bool finished { get; set; }
        public int id = -1;

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void RaisePropertyChanged(String property) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
