using FirstProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstProject.ViewModel
{
    public class LoginModelView : INotifyPropertyChanged
    {
        public LoginModelView()
        {
            LoginCommand = new Command(LoginBtn);
            RegistrationCommand = new Command(RegistrationPageBtn);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { protected set; get; }
        public ICommand RegistrationCommand { protected set; get; }

        public INavigation Navigation { get; set; }
        public Client Client { get; private set; } = new Client("", "", "");
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Login
        {
            get { return Client.Login; }
            set
            {
                Client.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return Client.Password; }
            set
            {
                Client.Password = value;
                OnPropertyChanged("Password");
            }
        }

        private async void RegistrationPageBtn()
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        private async void LoginBtn()
        {
            var lst = App.Db.GetClients();
            bool state = false;

            foreach (var item in lst)
            {
                if (item.Login == Client.Login)
                {
                    if (item.Password == Client.Password && state == false)
                    {
                        state = true;
                        await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                    }
                }
            }

            if (!state)
                await App.Current.MainPage.DisplayAlert("Error", "Уведомление Не правилный логин или пароль","Ok");
        }
    }
}

