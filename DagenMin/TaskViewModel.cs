using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    class TaskViewModel : System.ComponentModel.INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
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

        private void NotifyPropertyChanged(String obj) {
            if (PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(obj));
            } 
        }
    }
}
