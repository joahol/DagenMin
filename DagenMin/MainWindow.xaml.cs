﻿using System;
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
          
        }
        private void listViewOnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            Console.WriteLine("Selection changed");
            Task t = (Task)e.AddedItems[0];
            lbldebug.Content = t.taskDescription;
        }
        private void onBtnAdd(object sender, RoutedEventArgs rea) {
            
            nyOppg = new NyOppgave();
            nyOppg.Show();
        }

    }
}
