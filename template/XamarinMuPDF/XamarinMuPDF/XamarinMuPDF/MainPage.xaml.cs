using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinMuPDF.ViewModel;

namespace XamarinMuPDF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            MainViewModel vm = new MainViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
    }
}
