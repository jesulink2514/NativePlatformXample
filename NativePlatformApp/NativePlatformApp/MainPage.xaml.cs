using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace NativePlatformApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage
    {
        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("https://reqres.in/")
            };
            this.BindingContext = this;
        }

        public ObservableCollection<User> Users { get; } 
            = new ObservableCollection<User>();

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

            var json = await _httpClient.GetStringAsync("/api/users?page=1");

            var users = JsonConvert.DeserializeObject<Response>(json).data;

            users.ForEach(u=> Users.Add(u));

            stopwatch.Stop();
            Milliseconds = stopwatch.ElapsedMilliseconds;
        }
    }


    public class Response
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

}
