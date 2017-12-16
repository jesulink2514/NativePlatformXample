using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace NativePlatformApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public ObservableCollection<object> Users { get; } 
            = new ObservableCollection<object>()
            {
                new {avatar="icon.png",first_name="Jesus",last_name="Angulo"}
            };

        public double Milliseconds
        {
            get { return _milliseconds; }
            set { _milliseconds = value;OnPropertyChanged(nameof(Milliseconds)); }
        }
        private double _milliseconds;

        protected override async void OnAppearing()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();



            stopwatch.Stop();
            Milliseconds = stopwatch.ElapsedMilliseconds;
        }
    }
}
