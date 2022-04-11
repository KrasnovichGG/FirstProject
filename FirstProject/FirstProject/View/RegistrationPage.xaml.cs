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
            BindingContext = new RegistrationViewModel { Navigation = this.Navigation };
        }
    }
}