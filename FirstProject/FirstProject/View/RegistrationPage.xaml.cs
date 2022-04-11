using System;
using FirstProject.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (PasswordTxt.Text == PasswordCompleteTxt.Text)
                    App.Db.SaveClient(new Client(EmailTxt.Text, LoginTxt.Text, PasswordTxt.Text));
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            catch
            {
                await DisplayAlert("Уведомление", "Не удалось зарегистрироваться", "Ok");
            }
        }
    }
}