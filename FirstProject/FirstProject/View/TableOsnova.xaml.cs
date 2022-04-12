using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstProject.models;
using FirstProject.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableOsnova : TabbedPage
    {
        public TableOsnova(TableOsnovaViewModel tableOsnovaViewModel)
        {
            InitializeComponent();
            BindingContext = tableOsnovaViewModel;
        }
    }
}