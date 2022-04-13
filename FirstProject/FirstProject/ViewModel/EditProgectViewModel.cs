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
    public class EditProgectViewModel : INotifyPropertyChanged
    {
        public EditProgectViewModel()
        {
            ProjectModel = new ProjectModel();
            GetCommand = new Command(GetPhotoAsync); //галерея
            TakeCommand = new Command(TakePhotoAsync); //камера
            CancelCommand = new Command(CancelBTN_Clicked);
            EditCommand = new Command(AddBtn);

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ProjectModel ProjectModel { get; set; }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand GetCommand { get; protected set; }
        public ICommand TakeCommand { get; protected set; }
        public ICommand CancelCommand { get; protected set; }
        public ICommand EditCommand { get; protected set; }
        public INavigation Navigation { get; set; }
        public string NameProject { get => ProjectModel.Name; set { ProjectModel.Name = value; OnPropertyChanged("NameProject"); } }
        public string Opisanie { get => ProjectModel.Description; set { ProjectModel.Description = value; OnPropertyChanged("Opisanie"); } }
        public string Phone { get => ProjectModel.TeltphoneNumber; set { ProjectModel.TeltphoneNumber = value; OnPropertyChanged("Phone"); } }
        public string Email { get => ProjectModel.Email; set { ProjectModel.Email = value; OnPropertyChanged("Email"); } }
        public string Address { get => ProjectModel.Adress;set { ProjectModel.Adress = value; OnPropertyChanged("Address"); } }
        public string pizda { get => ProjectModel.ImagePath; set { ProjectModel.ImagePath = value; OnPropertyChanged("pizda"); } }
        async void CancelBTN_Clicked()
        {
            await Navigation.PopAsync();
        }

        async void GetPhotoAsync()
        {
            try
            {
                // выбираем фото
                var photo = await MediaPicker.PickPhotoAsync();
                pizda = photo.FullPath; 
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        async void TakePhotoAsync()
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
                pizda = photo.FullPath;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
        }
        public void AddBtn()
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
