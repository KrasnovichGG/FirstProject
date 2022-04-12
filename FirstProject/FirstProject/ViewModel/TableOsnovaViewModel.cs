using FirstProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstProject.ViewModel
{
    public class TableOsnovaViewModel : INotifyPropertyChanged
    {
        public TableOsnovaViewModel()
        {
            TapGestureRecognizerCommand = new Command(TapGestureRecognizer_Tapped);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ProjectModel ProjectModel { get; set; }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand TapGestureRecognizerCommand { protected set; get; }
        public INavigation Navigation { get; set; }
        async void TapGestureRecognizer_Tapped()
        {
            await Navigation.PushAsync(new EditProjectPage(new EditProgectViewModel() { ProjectModel = ProjectModel,Navigation = this.Navigation }));
        }
        public string NameProject { get => ProjectModel.Name; set { ProjectModel.Name = value; OnPropertyChanged("NameProject"); } }
        public string Opisanie { get => ProjectModel.Description; set { ProjectModel.Description = value; OnPropertyChanged("Opisanie"); } }
        public string Phone { get => ProjectModel.TeltphoneNumber; set { ProjectModel.TeltphoneNumber = value; OnPropertyChanged("Phone"); } }
        public string Email { get => ProjectModel.Email; set { ProjectModel.Email = value; OnPropertyChanged("Email"); } }
        public string Address { get => ProjectModel.Adress; set { ProjectModel.Adress = value; OnPropertyChanged("Address"); } }
        public string pizda { get => ProjectModel.ImagePath; set { ProjectModel.ImagePath = value; OnPropertyChanged("pizda"); } }
    }
}
