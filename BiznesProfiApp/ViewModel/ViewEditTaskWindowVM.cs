using BiznesProfiApp.dbEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesProfiApp.ViewModel
{
    public class ViewEditTaskWindowVM : BaseVM
    {
        private string _shortDescription;
        private string _fullDescription;
        private Customer _customer;
        private SqlDateTime _sqlDateTimeDeadline;
        private TaskStatus _taskStatus;
        private Type_of_task _typeOfTask;
        private User _responsible;

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
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public SqlDateTime SqlDateTimeDeadline
        {
            get => _sqlDateTimeDeadline;
            set
            {
                _sqlDateTimeDeadline = value;
                OnPropertyChanged(nameof(SqlDateTimeDeadline));
            }
        }
        public TaskStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                _taskStatus = value;
                OnPropertyChanged(nameof(TaskStatus));
            }
        }
        public Type_of_task TypeOfTask
        {
            get => _typeOfTask;
            set
            {
                _typeOfTask = value;
                OnPropertyChanged(nameof(TypeOfTask));
            }
        }
        public User Responsible
        {
            get => _responsible;
            set
            {
                _responsible = value;
                OnPropertyChanged(nameof(Responsible));
            }
        }
    }
}
