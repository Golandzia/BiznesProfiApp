using BiznesProfiApp.dbEntities;
using BiznesProfiApp.View.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BiznesProfiApp.ViewModel
{
    public class CreateCustomerWindowVM : BaseVM
    {
        private string _fullName;
        private string _organizationName;
        private int _customerInn;
        private string _phoneNumber;
        private Customer _customer;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }
        public string OrganizationName
        {
            get { return _organizationName; }
            set
            {
                _organizationName = value;
                OnPropertyChanged(nameof(OrganizationName));
            }
        }
        public int CustomerInn
        {
            get { return _customerInn; }
            set
            {
                _customerInn = value;
                OnPropertyChanged(nameof(CustomerInn));
            }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        private StringBuilder ValidateEntity()
        {
            var errors = new StringBuilder();
            if (FullName == null || FullName == "") errors.AppendLine("Поле 'Полное имя' не заполнено");
            if (CustomerInn.ToString().Length< 1) errors.AppendLine("Поле 'Номер ИНН' заполнено некорректно");
            if (PhoneNumber == null || PhoneNumber == "") errors.AppendLine("Поле 'Номер телефона' не заполнено");
            return errors;
        }

        public void AddEntityToDB()
        {
            var ValidateEntityResult = ValidateEntity();

            if (ValidateEntityResult.Length > 0)
            {
                MessageBox.Show(ValidateEntityResult.ToString(), "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _customer = new Customer();
            _customer.Full_name = FullName;
            _customer.Individual_taxpayer_namber = CustomerInn;
            if(OrganizationName != null) _customer.Organization_name = OrganizationName;
            _customer.Phone_number = PhoneNumber;

            try
            {
                using (var db = new BiznesProfiAppDBEntities())
                {
                    db.Customer.AddOrUpdate(_customer);
                    db.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error of saving data\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            foreach(var elem in App.Current.Windows)
            {
                if(elem is CreateClientWindow) (elem as Window).Close();
            }


        }
    }
}
