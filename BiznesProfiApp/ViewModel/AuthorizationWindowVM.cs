using BiznesProfiApp.dbEntities;
using BiznesProfiApp.View.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiznesProfiApp.ViewModel
{
    public class AuthorizationWindowVM : BaseVM
    {
        private string _btnDescription = "Войти";

        private string _login;
        private string _password;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string BtnDescription
        {
            get => _btnDescription; 
            set
            {
                _btnDescription = value;
                OnPropertyChanged(nameof(BtnDescription));
            }
        }


        public User _user;

        public async Task<User> Authorizate(string login, string password)
        {
            try
            {
                var result = await DBStorrage.DB_s.User.FirstOrDefaultAsync(_user => _user.Login == login && _user.Password == password);
                _user = result;

                if (result != null)
                {
                    return _user;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка аутентификации",
                        MessageBoxButton.OK, MessageBoxImage.Stop);

                return null;
            }
        }
        public async void AuthInApp()
        {
            BtnDescription = "Авторизация...";
            if(await Authorizate(Login, Password) != null)
            {
                var appWindow = new MainWindow(_user);
                appWindow.Show();
                foreach (var item in App.Current.Windows)
                {
                    if (item is Authorization)
                    {
                        (item as Window).Hide();
                    }
                }
                BtnDescription = "Войти";
                return;
            }
            MessageBox.Show("Неправильный логин или пароль", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Error);
            BtnDescription = "Войти";
        }
    }
}