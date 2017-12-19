using System.Collections.ObjectModel;
using System.Diagnostics;
using NativePlatformApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace NativePlatformApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

        }

        protected override async void OnAppearing()
        {
            var vm = this.BindingContext as MainViewModel;
            await vm.LoadData();
        }
    }
}
