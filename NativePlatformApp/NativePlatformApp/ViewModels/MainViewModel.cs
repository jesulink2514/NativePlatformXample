using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace NativePlatformApp.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<object> Users { get; } = new ObservableCollection<object>()    
        {
            new {avatar="icon.png",first_name="Jesus",last_name="Angulo"}
        };
        
        private double _milliseconds;
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
        }
    }
}
