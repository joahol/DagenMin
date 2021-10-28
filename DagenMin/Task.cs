using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DagenMin
{
    
    class Task
    {
       public String taskName { get; set; }
       public String taskDescription { get; set; }
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
    }
}
