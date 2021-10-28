using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    
    class Task
    {
       public String taskName = "";
       public String taskDescription = "";
       public bool finished = false;
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
    }
}
