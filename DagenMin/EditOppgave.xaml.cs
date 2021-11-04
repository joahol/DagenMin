using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DagenMin
{

    public partial class EditOppgave : Window
    {
        private StorageHandler storeHandler;
        TaskViewModel tVM;
        private Task editTask;
        public EditOppgave(TaskViewModel tvm, Task editTask)
        {
            InitializeComponent();
            storeHandler = new StorageHandler();
            tVM = tvm;
            this.editTask = editTask;
            txbName.Text = editTask.taskName;
            txbDescription.Text = editTask.taskDescription;
            if (editTask.schedueld != null) { }
            cal.SelectedDate = editTask.schedueld;
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            String taskName = txbName.Text;
            String description = txbDescription.Text;
            DateTime date;
            if (cal.SelectedDate.HasValue)
            {
                date = cal.SelectedDate.Value;
            }
            else {
                date = System.DateTime.Today;
                cal.SelectedDate = date;
                
            }
            editTask.taskDescription = description;
            editTask.taskName = taskName;
            editTask.taskDescription = description;
            tVM.updateRow(editTask);

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
