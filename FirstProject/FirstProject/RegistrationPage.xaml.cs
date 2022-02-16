using System;
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
        
        private void BtnREG_Clicked(object sender, EventArgs e)
        {
            //App.Db.SaveItem(new ProjectModel("Борщ","Вкусный","89655335567","Borsh@mail.com","Адрес кастрюля"));
        }
    }
}