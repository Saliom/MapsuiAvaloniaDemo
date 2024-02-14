using Avalonia.Controls;
using Mapsui.Tiling;

namespace MapsuiAvaloniaDemo.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        }
    }
}