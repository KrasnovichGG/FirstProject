using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pages : ContentPage
    {
        public Pages()
        {
            InitializeComponent();
        }


        private void projectList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new TableOsnova());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new CreateProject());
        }

        //private void ImageButton_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new CreateProject());
        //}
    }
}