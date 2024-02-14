using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Mapsui;

namespace MapsuiAvaloniaDemo.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

        [ObservableProperty]
        public ContentControl content;
        public Map BoundMap { get; set; } = new Map();

        public MainWindowViewModel()
        {
            content = new ContentControl();
        }
    }
}
