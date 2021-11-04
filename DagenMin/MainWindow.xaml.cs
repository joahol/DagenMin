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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DagenMin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NyOppgave nyOppg;

        TaskViewModel tvm;
        public MainWindow()
        {
            InitializeComponent();
           
            //Task testTask = new Task("Save the day", "Get a Job", true);
            //shandler.storeNewTask(testTask);
            tvm = new TaskViewModel();
            tvm.Initialize();
            lstVTasks.DataContext = tvm;
            lblDescription.DataContext = tvm;


        }

        private void OnPropertyChanged() {
            Task t = (Task)lstVTasks.SelectedItem;
            if (t != null) {
                lblDescription.Text = t.taskDescription;
            }
           
        }

        private void listViewOnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            Console.WriteLine("Selection changed");
            if (e.AddedItems.Count > 0)
            {
                Task t = (Task)e.AddedItems[0];
                lblDescription.Text = t.taskDescription;
            }
        }
        private void onBtnAdd(object sender, RoutedEventArgs rea) {
            
            nyOppg = new NyOppgave(tvm);
            nyOppg.Show();
        }
        private void onBtnDelete(object sender, RoutedEventArgs args) {
            Task t = (Task)lstVTasks.SelectedItem;
            tvm.deleteRow(t);
        }

        private void onBtnEdit(object sender, RoutedEventArgs args) {
            Task t = (Task)lstVTasks.SelectedItem;
            if (t != null) {
                EditOppgave et = new EditOppgave(tvm,t);
                et.Show();
            }
        }


   
        private void lblDescription_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Task t = (Task)lstVTasks.SelectedItem;
            if (t != null)
            {
                lblDescription.Text = t.taskDescription;
            }
        }
    
    }
}
