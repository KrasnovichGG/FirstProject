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
    public partial class TableOsnova : TabbedPage
    {
        public TableOsnova(ProjectModel poj)
        {

            InitializeComponent();
            projectModel1 = poj;
            Fill();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProjectPage());
        }
        ProjectModel projectModel1;
        public void Fill()
        {
            Phonetxt.Text = projectModel1.TeltphoneNumber;   
            Emailtxt2.Text = projectModel1.Email;   
            Adresstxt.Text = projectModel1.Adress;
            Phonetxt.Text = projectModel1.TeltphoneNumber;
            Page11Photo.Source = projectModel1.ImagePath;
        }
    }
}