using BiznesProfiApp.dbEntities;
using BiznesProfiApp.ViewModel;
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

namespace BiznesProfiApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();

            this.DataContext = new MainWindowVM(user);
        }

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DisplayAllTasks();
        }

        private void btnOverdued_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DisplayOverduedTasks();
        }

        private void btnTasksInProcess_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DisplayTasksInProcess();
        }

        private void btnTasksComplited_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DisplayCompleatedTasks();
        }

        private void btnTasksDelayed_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).DisplayDelayedTasks();
        }

        private void imgFilter_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).Searching();
        }

        private void btnCreateTask_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainWindowVM).OpenElement(null);
        }

        private void MainDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            (DataContext as MainWindowVM).OpenElement((DataContext as MainWindowVM).SelectedTask);
        }
    }
}
