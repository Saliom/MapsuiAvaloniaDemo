using Avalonia.Controls;
using Mapsui.Projections;
using Mapsui;
using Mapsui.Tiling;
using Mapsui.UI.Avalonia;
using Mapsui.Extensions;
using Mapsui.Layers;
using Mapsui.Styles;
using System.Collections.Generic;
using Mapsui.Nts;
using NetTopologySuite.Geometries;
using System;



namespace MapsuiAvaloniaDemo.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            MapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer("wbl123"));

            var pinsLayer = new GenericCollectionLayer<List<IFeature>>
            {
                Style = SymbolStyles.CreatePinStyle(Color.Aqua)
            };
            MapControl.Map.Layers.Add(pinsLayer);

            MapControl.Map.Home = n =>
            {
                var centerOfLondonOntario = new MPoint(2.463585552484944, 46.60213318495561);
                // OSM uses spherical mercator coordinates. So transform the lon lat coordinates to spherical mercator
                MPoint sphericalMercatorCoordinate = SphericalMercator.FromLonLat(centerOfLondonOntario.X, centerOfLondonOntario.Y).ToMPoint();
                n.CenterOnAndZoomTo(sphericalMercatorCoordinate, MapControl.Map.Navigator.Resolutions[4]);
                //n.OverrideZoomBounds = new MMinMax(MapControl.Map.Navigator.Resolutions[4], MapControl.Map.Navigator.Resolutions[12]);
                //n.SetSize(10, 10);

                var min = SphericalMercator.FromLonLat(-180, -90);
                var max = SphericalMercator.FromLonLat(180, 90);
                //n.OverridePanBounds = new MRect(min.x, min.y, max.x, max.y);

                //Viewport vp = n.Viewport;

                //n.Limiter = new ViewportLimiter();

                //n.Limiter.Limit(vp, new MRect(min.x, min.y, max.x, max.y), null);

                //n.SetViewport(n.Viewport);
                IFeature feature = new PointFeature(SphericalMercator.FromLonLat(2.463585552484944, 46.60213318495561).ToMPoint());

                pinsLayer.Features.Add(feature);
                // To notify the map that a redraw is needed.
                //layer?.DataHasChanged();
                //n.PanLock = true;
            };

            //MapControl.Map.Navigator.ZoomLock = true;
        }

        //private void InitializeComponent()
        //{
        //    InitializeComponent(true);
        //    MapControl.Map.Layers.Add(OpenStreetMap.CreateTileLayer());
        //    MapControl.Map.Navigator.RotationLock = true;

        //}


    }

    //private async static Task<MemoryLayer> CreatePointLayer()
    //{
    //    return new MemoryLayer
    //    {
    //        Name = "Historical Places",
    //        IsMapInfoLayer = true,
    //        Features = new MemoryProvider(await LoadPins()).Features,
    //        //Style = SymbolStyles.CreatePinStyle(pinColor: Color.Blue, symbolScale: 0.7),
    //    };
    //}

    //private async static Task<IEnumerable<IFeature>> LoadPins()
    //{
    //    var bitmapIdRed = typeof(MapIcon).LoadBitmapId(@"RedPin.png");
    //    var bitmapIdBlue = typeof(MapIcon).LoadBitmapId(@"BluePin.png");

    //    List<IFeature> features = new List<IFeature>();
    //    int pinIndex = 0;
    //    pins = StackPins();
    //    foreach (MapIcon pin in pins)
    //    {
    //        await Task.Delay(0);

    //        IFeature feature = new PointFeature(SphericalMercator.FromLonLat(pin.Location.Longitude, pin.Location.Latitude).ToMPoint());
    //        //IFeature feature = new PointFeature(SphericalMercator.FromLonLat(uniquePoint.X, uniquePoint.Y).ToMPoint());
    //        var bitmapHeight = 180;
    //        pinIndex++;
    //        if (pin.IsOverriden)
    //        {
    //            feature.Styles.Add(new SymbolStyle
    //            {
    //                BitmapId = bitmapIdBlue,
    //                SymbolScale = 0.3,
    //                SymbolOffset = new Offset(40, bitmapHeight * 0.5),
    //                BlendModeColor = Color.Transparent,
    //                Opacity = 0.9f,
    //                SymbolType = SymbolType.Image,
    //            });
    //        }
    //        else
    //        {
    //            feature.Styles.Add(new SymbolStyle
    //            {
    //                BitmapId = bitmapIdRed,
    //                SymbolScale = 0.2,
    //                SymbolOffset = new Offset(40, bitmapHeight * 0.5),
    //                BlendModeColor = Color.Transparent,
    //                Opacity = 0.9f,
    //                SymbolType = SymbolType.Image,
    //            });
    //        }

    //        features.Add(feature);
    //    }
    //    features.Reverse();
    //    return features;
    //}

    //private static List<MapIcon> StackPins()
    //{
    //    List<MapIcon> tempPins = new();
    //    foreach (var pin in pins)
    //    {
    //        tempPins = ensureUniquePins();
    //    }
    //    return tempPins;
    //}

    //private static List<MapIcon> ensureUniquePins()
    //{
    //    List<MapIcon> tempPins = new();
    //    int pinIndex = 0;
    //    foreach (var pin in pins)
    //    {
    //        tempPins.Add(getUniquePoint(pin, pinIndex++));
    //    }

    //    return tempPins;
    //}

    //private static MapIcon getUniquePoint(MapIcon _pin, int index)
    //{
    //    int pinIndex = 0;
    //    foreach (var pin in pins)
    //    {
    //        if (index != pinIndex && pin.Location.Latitude == _pin.Location.Latitude && pin.Location.Longitude == _pin.Location.Longitude)
    //        {
    //            if (pin.Location.Longitude == pin.Location.Longitude) _pin.Location.Longitude -= 0.000005;
    //            if (pin.Location.Latitude == _pin.Location.Latitude) _pin.Location.Latitude -= 0.000005;
    //            //return _pin;
    //        }
    //        pinIndex++;
    //    }
    //    return _pin;
    //}

    //private void ClearMap()
    //{
    //    if (myMap.Map.Layers.Count > 1) myMap.Map.Layers.Remove(myMap.Map.Layers[1]);
    //    //myMap.MapElements.Clear();
    //    pins.Clear();
    //    LocationList.ItemsSource = null;
    //    ////myMap.Children.Clear();
    //    pois.Clear();
    //}

    //private async void MapIconLinkGrid_Tapped(object sender, TappedRoutedEventArgs e)
    //{
    //    try
    //    {
    //        MapIcon pin = ((TextBlock)e.OriginalSource).DataContext as MapIcon;
    //        var smc = SphericalMercator.FromLonLat(pin.Location.Longitude, pin.Location.Latitude);
    //        //myMap.Map.Home = n => n.CenterOnAndZoomTo(new MPoint(smc.x, smc.y), n.Resolutions[14], 2, Mapsui.Animations.Easing.BounceIn);
    //        myMap.Map.Navigator.CenterOnAndZoomTo(new MPoint(smc.x, smc.y), 16.0, 2, Mapsui.Animations.Easing.BounceIn);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //    }

    //}

    //public class PointOfInterest
    //{
    //    public PointOfInterest()
    //    {
    //    }
    //    public string DisplayName { get; set; }
    //    //public Maps.Coordinates Location { get; set; }
    //    public bool IsOverriden { get; set; }
    //    public Uri ImageSourceUri { get; set; }
    //    public string MoreInfo { get; set; }
    //}

    //public class MapIcon
    //{
    //    public MapIcon()
    //    {
    //    }
    //    //public Map.Coordinates Location { get; set; }
    //    public bool IsOverriden { get; set; }
    //    public Point NormalizedAnchorPoint { get; set; }
    //    public string Title { get; set; }
    //    public int ZIndex { get; set; }
    //}

    //public class Point
    //{
    //    public Point(double x, double y)
    //    {
    //        X = x; Y = y;
    //    }
    //    public double X { get; set; }
    //    public double Y { get; set; }
    //}
}
