using FirstProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstProject.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        public Client Client { get; private set; } = new Client("","","");
        string passwordCompleteTxt="";
        public RegistrationViewModel()
        {
            RegisCommand = new Command(RegBtn_Clicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand RegisCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        protected  void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private async void RegBtn_Clicked()
        {
            try
            {
                if (PasswordTxt == PasswordCompleteTxt)
                    App.Db.SaveClient(new Client(EmailTxt, LoginTxt, PasswordTxt));
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Уведомление", "Не удалось зарегистрироваться", "Ok");
            }
        }
        public string PasswordTxt { get => Client.Password; set{ Client.Password = value; OnPropertyChanged("PasswordTxt");} }
        public string LoginTxt { get => Client.Login; set { Client.Login = value; OnPropertyChanged("LoginTxt");} }
        public string PasswordCompleteTxt { get => passwordCompleteTxt; set { passwordCompleteTxt = value;OnPropertyChanged("PasswordCompleteTxt");}}
        public string EmailTxt { get => EmailTxt; set { EmailTxt = value;OnPropertyChanged("EmailTxt");} }
    }
}
