// BingMapsShell.cs
//

using System;
using System.Collections;
using System.Html;
using Microsoft.Maps;

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
            mapOptions.Center = new MapLocation(47.6062095, -122.3320708);
            mapOptions.Zoom = 10;
            mapOptions.MapType = MapType.Road;

            MapPushpinOptions pushpinOptions = new MapPushpinOptions();
            _pushpin = new MapPushpin(mapOptions.Center, pushpinOptions);

            MapInfoboxOptions infoboxOptions = new MapInfoboxOptions();
            infoboxOptions.Title = "Seattle";
            infoboxOptions.Visible = false;
            infoboxOptions.offset = new MapPoint(0, 20);
            infoboxOptions.Height = 48;
            infoboxOptions.Width = 80;
            infoboxOptions.ShowCloseButton = false;
            _infobox = new MapInfobox(mapOptions.Center, infoboxOptions);

            _map = new Map(rootElement, mapOptions);
            _map.Entities.Push(_pushpin);
            _map.Entities.Push(_infobox);

            MapEvents.AddHandler(_pushpin, "click", OnPushpinClick);
            MapEvents.AddHandler(_map, "viewchange", OnViewChanged);
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
