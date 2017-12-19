using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using ModernHttpClient;
using NativePlatformApp.Models;
using NativePlatformApp.Services;
using Refit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace NativePlatformApp.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        
        private double _milliseconds;
        private readonly IUserService _userService;
        private readonly Stopwatch _stopwatch;

        public double Milliseconds
        {
            get => _milliseconds;
            set
            {
                _milliseconds = value;
                OnPropertyChanged(nameof(Milliseconds));
            }
        }
        
        public ICommand DeleteCommand { get; }
        public ICommand UpdateCommand { get; }

        public MainViewModel()
        {
            _userService = RestService
                .For<IUserService>(new HttpClient(new NativeMessageHandler())
                {
                    BaseAddress = new Uri("https://reqres.in/")
                });
            _stopwatch = new Stopwatch();
            UpdateCommand = new Command(UpdateUser);
            DeleteCommand = new Command<User>(DeleteUser);
        }

        private async void DeleteUser(User user)
        {
            var resp = await _userService.DeleteUser(user.id);

            await App.Current.MainPage
                .DisplayAlert("Delete",$"HTTP STATUS {resp.StatusCode}", "Ok");

        }

        private async void UpdateUser()
        {
            var request = new UpdateUserRequest()
            {
                job = "Xamarin Developer", name = "Jesus Angulo"
            };

            var resp = await _userService.UpdateUser(1, request);

            await App.Current.MainPage.DisplayAlert("Updated", 
                $"{resp.name} with job: {resp.job} updated at {resp.updatedAt}", 
                "Ok");
        }

        public async Task LoadData()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            var resp = await _userService.GetUsers();
            _stopwatch.Stop();
            Users.Clear();
            resp.data.ForEach(u => Users.Add(u));
            Milliseconds = _stopwatch.ElapsedMilliseconds;
        }
    }
}
