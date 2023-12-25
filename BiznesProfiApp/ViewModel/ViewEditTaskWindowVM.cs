using BiznesProfiApp.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiznesProfiApp.ViewModel
{
    public class ViewEditTaskWindowVM : BaseVM
    {
        private string _shortDescription;
        private string _fullDescription;
        private Customer _selectedCustomer;
        private List<Customer> _allCustomers;
        private DateTime _sqlDateTimeDeadline;
        private Task_status _SelectedTaskStatus; 
        private List<Task_status> _allTaskStatuses;
        private Type_of_task _selectedtypeOfTask;
        private List<Type_of_task> _allTypesOfTask;
        private User _selectedResponsible;
        private List<User> _allResponsibleUsers;

        public string ShortDescription
        {
            get => _shortDescription;
            set
            {
                _shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }
        public string FullDescription
        {
            get => _fullDescription;
            set
            {
                _fullDescription = value;
                OnPropertyChanged(nameof(FullDescription));
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public List<Customer> AllCustomers
        {
            get => _allCustomers;
            set
            {
                _allCustomers = value;
                OnPropertyChanged(nameof(AllCustomers));
            }
        }
        public DateTime SqlDateTimeDeadline
        {
            get => _sqlDateTimeDeadline;
            set
            {
                _sqlDateTimeDeadline = value;
                OnPropertyChanged(nameof(SqlDateTimeDeadline));
            }
        }
        public Task_status SelectedTaskStatus
        {
            get => _SelectedTaskStatus;
            set
            {
                _SelectedTaskStatus = value;
                OnPropertyChanged(nameof(TaskStatus));
            }
        }
        public List<Task_status> AllTaskStatuses
        {
            get => _allTaskStatuses;
            set
            {
                _allTaskStatuses = value;
                OnPropertyChanged(nameof(AllTaskStatuses));
            }
        }
        public Type_of_task SelectedTypeOfTask
        {
            get => _selectedtypeOfTask;
            set
            {
                _selectedtypeOfTask = value;
                OnPropertyChanged(nameof(_selectedtypeOfTask));
            }
        }
        public List<Type_of_task> AllTypesOfTask
        {
            get => _allTypesOfTask;
            set
            {
                _allTypesOfTask = value;
                OnPropertyChanged(nameof(AllTypesOfTask));
            }
        }
        public User SelectedResponsible
        {
            get => _selectedResponsible;
            set
            {
                _selectedResponsible = value;
                OnPropertyChanged(nameof(_selectedResponsible));
            }
        }
        public List<User> AllResponsibleUsers
        {
            get => _allResponsibleUsers;
            set
            {
                _allResponsibleUsers = value;
                OnPropertyChanged(nameof(AllResponsibleUsers));
            }
        }

        public dbEntities.Task _task = new dbEntities.Task();
        public ViewEditTaskWindowVM(dbEntities.Task task)
        {
            FillingComboBoxes();
            if(task is null)
            {
                //Добавление новой задачи
                _task = new dbEntities.Task();
            }
            else
            {
                _task = task;
                ShortDescription = task.Short_description;
                SqlDateTimeDeadline = task.Deadline;
                FullDescription = task.Full_task;

                Type_of_task type_Of_Task = new Type_of_task();
                type_Of_Task.Type = task.Type_of_task1.Type;
                SelectedTypeOfTask = AllTypesOfTask.Where(elem => type_Of_Task.Type == elem.Type).FirstOrDefault();

                Customer customer = new Customer();
                customer.Full_name = task.Customer1.Full_name;
                SelectedCustomer = AllCustomers.Where(elem => customer.Full_name == elem.Full_name).FirstOrDefault();

                User user = new User();
                user.Full_name = task.User.Full_name;
                SelectedResponsible = AllResponsibleUsers.Where(elem => user.Full_name == elem.Full_name).FirstOrDefault();

                Task_status task_Status = new Task_status();
                task_Status.Value = task.Task_status1.Value;
                SelectedTaskStatus = AllTaskStatuses.Where(elem => task_Status.Value == elem.Value).FirstOrDefault();
            }
        }
        public void AddOrEditTask()
        {
            var ValidateEntityResult = ValidateEntity();

            if (ValidateEntityResult.Length > 0) 
            {
                MessageBox.Show(ValidateEntityResult.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _task.Short_description = ShortDescription;
            _task.Full_task = FullDescription;
            _task.Deadline = SqlDateTimeDeadline;
            _task.Type_of_task = SelectedTypeOfTask.ID;
            _task.Task_status = SelectedTaskStatus.ID;
            _task.Responsible = SelectedResponsible.ID;
            _task.Customer = SelectedCustomer.ID;

            try
            {
                using(var db = new BiznesProfiAppDBEntities())
                {
                    db.Task.AddOrUpdate(_task);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error of saving data\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();

            if (ShortDescription == null || ShortDescription == "") errors.AppendLine("Поле 'Краткое описание' не заполнено");
            if (FullDescription == null || FullDescription == "") errors.AppendLine("Поле 'Полное описание' не заполнено");
            if(SqlDateTimeDeadline == null) errors.AppendLine("Поле 'Дэдлайн' не заполнено");
            if(SelectedTypeOfTask == null) errors.AppendLine("Поле 'Тип задачи' не заполнено");
            if(SelectedTaskStatus == null) errors.AppendLine("Поле 'Статус задачи' не заполнено");
            if(SelectedResponsible == null) errors.AppendLine("Поле 'Ответственный' не заполнено");
            if(SelectedCustomer == null) errors.AppendLine("Поле 'Заказчик' не заполнено");

            return errors;
        }

        private void FillingComboBoxes()
        {
            AllCustomers = DBStorrage.DB_s.Customer.ToList();
            AllResponsibleUsers = DBStorrage.DB_s.User.ToList();
            AllTaskStatuses = DBStorrage.DB_s.Task_status.ToList();
            AllTypesOfTask = DBStorrage.DB_s.Type_of_task.ToList();
        }

    }
}
