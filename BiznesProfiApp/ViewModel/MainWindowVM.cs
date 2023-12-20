using BiznesProfiApp.dbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiznesProfiApp.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        private User _whoAuthorizated = null;
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
        }
    }
}
