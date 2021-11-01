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
    /// <summary>
    /// Interaction logic for NyOppgave.xaml
    /// </summary>
    public partial class NyOppgave : Window
    {
        private StorageHandler storeHandler;
        TaskViewModel tVM;        
        public NyOppgave(TaskViewModel tvm)
        {
            InitializeComponent();
            storeHandler = new StorageHandler();
            tVM = tvm;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
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
            Task t = new Task(taskName, description, false);
            storeHandler.storeNewTask(t);

            tVM.Tasks.Add(t);
                
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
