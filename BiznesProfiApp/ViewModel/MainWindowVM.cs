using BiznesProfiApp.dbEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = BiznesProfiApp.dbEntities.Task;

namespace BiznesProfiApp.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        private User _whoAuthorizated = null;
        private Task _selectedTask;
        private ObservableCollection<Task> _tasks;


        public Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }
        public User WhoAuthorizated
        {
            get => _whoAuthorizated;
            set
            {
                _whoAuthorizated = value;
                OnPropertyChanged(nameof(WhoAuthorizated));
            }
        }
        public MainWindowVM(User user) 
        {
            WhoAuthorizated = user;

            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));

        }
    }
}
