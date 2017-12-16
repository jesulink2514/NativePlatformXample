using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace NativePlatformApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private readonly Stopwatch stopwatch;

        public MainPage()
        {
            InitializeComponent();
            this.stopwatch = new Stopwatch();
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            stopwatch.Reset();
            stopwatch.Start();



            stopwatch.Stop();
        }
    }
}
