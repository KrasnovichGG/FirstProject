using FirstProject.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FirstProject.ViewModel
{
    public class CreateProjectViewModel : INotifyPropertyChanged
    {
        public CreateProjectViewModel()
        {
            ProjectModel = new ProjectModel();
            GetCommandCreate = new Command(GetPhotoAsyncCreate);
            TakeCommandCreate = new Command(TakePhotoAsyncCreate);
            CancelCommandCreate = new Command(CancelBTN_Clicked);
            AddCommand = new Command(AddBTN_Clicked);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ProjectModel ProjectModel { get; set; }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand GetCommandCreate { protected set; get; }
        public ICommand TakeCommandCreate { protected set; get; }
        public ICommand CancelCommandCreate { protected set; get; }
        public ICommand AddCommand { protected set; get; }
        public string NameProject { get => ProjectModel.Name; set { ProjectModel.Name = value; OnPropertyChanged("NameProject"); } }
        public string Opisanie { get => ProjectModel.Description; set { ProjectModel.Description = value; OnPropertyChanged("Opisanie"); } }
        public string Phone { get => ProjectModel.TeltphoneNumber; set { ProjectModel.TeltphoneNumber = value; OnPropertyChanged("Phone"); } }
        public string Email { get => ProjectModel.Email; set { ProjectModel.Email = value; OnPropertyChanged("Email"); } }
        public string Address { get => ProjectModel.Adress; set { ProjectModel.Adress = value; OnPropertyChanged("Address"); } }
        public string pizda { get => ProjectModel.ImagePath; set { ProjectModel.ImagePath = value; OnPropertyChanged("pizda"); } }
        async void CancelBTN_Clicked()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
        async void GetPhotoAsyncCreate()
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                ProjectModel.ImagePath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        async void TakePhotoAsyncCreate()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });
                // для примера сохраняем файл в локальном хранилище
                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
                ProjectModel.ImagePath = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        private void AddBTN_Clicked()
        {
            try
            {
                App.Db.SaveItem(ProjectModel);
            }
            catch (Exception ex)
            {
               App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
