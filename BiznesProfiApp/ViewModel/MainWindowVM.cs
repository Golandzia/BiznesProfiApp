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
        private string _search;


        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
            }
        }
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

        public void DisplayAllTasks()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));

        }
        public void DisplayOverduedTasks()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (var elem in Tasks)
            {
                if(elem.Task_status1.Value == "Просрочено")
                {
                    temp?.Add(elem);
                }
            }
            Tasks = temp;
        }
        public void DisplayTasksInProcess()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (var elem in Tasks)
            {
                if (elem.Task_status1.Value == "Выполняется")
                {
                    temp?.Add(elem);
                }
            }
            Tasks = temp;
        }
        public void DisplayCompleatedTasks()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (var elem in Tasks)
            {
                if (elem.Task_status1.Value == "Выполнено")
                {
                    temp?.Add(elem);
                }
            }
            Tasks = temp;
        }
        public void DisplayDelayedTasks()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (var elem in Tasks)
            {
                if (elem.Task_status1.Value == "Отложено")
                {
                    temp?.Add(elem);
                }
            }
            Tasks = temp;
        }
        public void Searching()
        {
            Tasks = new ObservableCollection<Task>();
            var result = DBStorrage.DB_s.Task.ToList();
            result.ForEach(elem => Tasks?.Add(elem));
            ObservableCollection<Task> temp = new ObservableCollection<Task>();
            foreach (var elem in Tasks)
            {
                if (elem.Short_description.Contains(Search) || elem.Type_of_task1.Type.Contains(Search) || elem.Deadline.ToString().Contains(Search) ||
                    elem.Task_status1.Value.Contains(Search) || elem.Customer1.Full_name.Contains(Search) || elem.User.Full_name.Contains(Search))
                {
                    temp?.Add(elem);
                }
            }
            Tasks = temp;
        }
    }
}
