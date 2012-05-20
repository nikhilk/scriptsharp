// BingMapsShell.cs
//

using System;
using System.Collections;
using System.Html;
using Microsoft.Maps;
using Microsoft.Maps.Location;
using Microsoft.Maps.Traffic;
using Microsoft.Maps.VenueMaps;

namespace BingMapsApp {

    internal sealed class BingMapsShell {

        private Map _map;
        private MapPushpin _pushpin;
        private MapInfobox _infobox;

        public void Run() {
            Element rootElement = Document.GetElementById("map");
            
            MapOptions mapOptions = new MapOptions();
            mapOptions.Credentials = (string)rootElement.GetAttribute("data-credentials");
            mapOptions.Width = 640;
            mapOptions.Height = 480;
            mapOptions.ShowCopyright = false;
            mapOptions.ShowMapTypeSelector = false;
            mapOptions.ShowLogo = false;
            mapOptions.ShowScalebar = false;
            mapOptions.ShowNavControl = false;
            mapOptions.ShowDashboard = false;
            mapOptions.Center = new MapLocation(47.610377, -122.2006786);
            mapOptions.Zoom = 10;
            mapOptions.MapType = MapType.Road;

            MapPushpinOptions pushpinOptions = new MapPushpinOptions();
            _pushpin = new MapPushpin(mapOptions.Center, pushpinOptions);

            MapInfoboxOptions infoboxOptions = new MapInfoboxOptions();
            infoboxOptions.Title = "Bellevue";
            infoboxOptions.Visible = false;
            infoboxOptions.Offset = new MapPoint(0, 20);
            infoboxOptions.Height = 48;
            infoboxOptions.Width = 80;
            infoboxOptions.ShowCloseButton = false;
            _infobox = new MapInfobox(mapOptions.Center, infoboxOptions);

            _map = new Map(rootElement, mapOptions);
            _map.Entities.Push(_pushpin);
            _map.Entities.Push(_infobox);

            MapEvents.AddHandler(_pushpin, "click", OnPushpinClick);
            MapEvents.AddHandler(_map, "viewchange", OnViewChanged);

            MapModuleOptions trafficOptions = new MapModuleOptions();
            trafficOptions.Callback = delegate() {
                TrafficLayer trafficLayer = new TrafficLayer(_map);
                trafficLayer.Show();
            };
            Map.LoadModule(MapModule.Traffic, trafficOptions);

            MapModuleOptions venueMapOptions = new MapModuleOptions();
            venueMapOptions.Callback = delegate() {
                VenueMapFactory venueMapFactory = new VenueMapFactory(_map);

                VenueMapSearchOptions searchOptions = new VenueMapSearchOptions();
                searchOptions.Map = _map;
                searchOptions.Location = mapOptions.Center;
                searchOptions.Radius = 1000;
                searchOptions.Callback = delegate(Venue[] venues) {
                    if (venues.Length != 0) {
                        VenueMapOptions venueOptions = new VenueMapOptions();
                        venueOptions.VenueMapID = venues[0].Metadata.ID;
                        venueOptions.SuccessCallback = delegate(VenueMap venueMap, VenueMapOptions options) {

                            venueMap.Show();
                            if (Script.Confirm("Zoom to " + venueMap.Name + "?")) {
                                _map.SetView(venueMap.BestMapView);
                            }
                        };

                        venueMapFactory.Create(venueOptions);
                    }
                };

                venueMapFactory.Search(searchOptions);
            };
            Map.LoadModule(MapModule.VenueMaps, venueMapOptions);

            Element locateMeButton = Document.GetElementById("locateMeButton");
            locateMeButton.AddEventListener("click", OnLocateMeClick, false);
        }

        private void OnLocateMeClick(ElementEvent e) {
            GeoLocationProvider geoLocationProvider = new GeoLocationProvider(_map);

            GeoLocationOptions options = new GeoLocationOptions();
            options.UpdateMapView = true;

            geoLocationProvider.GetCurrentPosition(options);
        }

        private void OnPushpinClick(EventArgs e) {
            MapInfoboxOptions options = new MapInfoboxOptions();
            options.Visible = true;

            _infobox.SetOptions(options);
        }

        private void OnViewChanged(EventArgs e) {
            MapInfoboxOptions options = new MapInfoboxOptions();
            options.Visible = false;

            _infobox.SetOptions(options);
        }
    }
}
