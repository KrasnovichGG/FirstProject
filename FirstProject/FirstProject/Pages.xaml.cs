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
    }
}