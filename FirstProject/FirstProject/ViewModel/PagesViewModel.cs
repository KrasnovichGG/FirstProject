using FirstProject.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstProject.ViewModel
{
    public class PagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        public ICommand CreateprojectsCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        public ObservableCollection<TableOsnovaViewModel> Projects { get; set; }
        TableOsnovaViewModel selectedProject;

        public PagesViewModel()
        {
            Projects = new ObservableCollection<TableOsnovaViewModel>();
            foreach (var item in App.db.GetProjects())
            {
                Projects.Add(new TableOsnovaViewModel { ProjectModel = item });
            }
            CreateprojectsCommand = new Command(CreateProject);
            BackCommand = new Command(Back);
        }
        public async void Back()
        {
            await Navigation.PopAsync();
        }
        public async void CreateProject()
        {
            await Navigation.PushAsync(new CreateProject(new CreateProjectViewModel() { Navigation = this.Navigation}));
        }
        public TableOsnovaViewModel SelectedProject
        {
            get { return selectedProject; }
            set
            {
                if (selectedProject != value)
                {
                    TableOsnovaViewModel tempStudent = value;
                    tempStudent.Navigation = this.Navigation;
                    SelectedProject = null;
                    OnPropertyChanged("SelectedProject");
                    Navigation.PushAsync(new TableOsnova(tempStudent));
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
