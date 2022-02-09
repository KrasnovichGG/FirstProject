using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FirstProject.db;
using System.IO;

[assembly: ExportFont("MaterialIcons-Regular.ttf", Alias = "MaterialIconsFont")]
namespace FirstProject
{
    public partial class App : Application
    {
        public const string DB_NAME = "clientsProj.db";
        public static CRUDOperation db;
        public static CRUDOperation Db
        {
            get
            {
                if (db == null)
                {
                    db = new CRUDOperation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DB_NAME));
                }
                return db;
            }
        }
    
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage (new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
