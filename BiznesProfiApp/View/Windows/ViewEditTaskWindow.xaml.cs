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
using System.Windows.Shapes;

namespace BiznesProfiApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ViewEditTaskWindow.xaml
    /// </summary>
    public partial class ViewEditTaskWindow : Window
    {
        public ViewEditTaskWindow(dbEntities.Task task)
        {
            InitializeComponent();

            this.DataContext = new ViewEditTaskWindowVM(task);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as ViewEditTaskWindowVM).AddOrEditTask();
        }
    }
}
