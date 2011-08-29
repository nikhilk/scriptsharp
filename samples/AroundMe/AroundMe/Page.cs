// Page.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Html.Media.Graphics;
using System.Html.Services;
using Microsoft.Maps;
using TwitterApi;
using AroundMe.Core;
using AroundMe.DataModel;
using AroundMe.Graphs;
using AroundMe.Services;

namespace AroundMe {

    internal static class Page {

        private const string MapModeClassName = "map";
        private const string PhotosModeClassName = "photos";

        private static PageModel _model;
        private static Map _map;
        private static MapEntityCollection _mapEntities;
        private static MapPushpin _currentPushpin;
        private static string _tileUrlFormat;

        private static Graph _graph;
        private static Dictionary<string, PhotoView> _photoViews;

        private static bool _viewChanging;
        private static int _zoomLevel;
        private static string _oldMode;

        static Page() {
            string flickrKey = (string)Document.Body.GetAttribute("data-flickr-key");
            Debug.Assert(String.IsNullOrEmpty(flickrKey) == false);

            string bingMapsKey = (string)Document.Body.GetAttribute("data-bingmaps-key");
            Debug.Assert(String.IsNullOrEmpty(bingMapsKey) == false);

            _tileUrlFormat = (string)Document.Body.GetAttribute("data-tile-url");
            Debug.Assert(String.IsNullOrEmpty(_tileUrlFormat) == false);

            _model = new PageModel(new FlickrService(flickrKey), new HtmlStorageService());
            _model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "Searching") {
                    Element progressElement = Utility.GetElement("searchProgress");
                    if (_model.Searching) {
                        progressElement.ClassName = "active";
                    }
                    else {
                        progressElement.ClassName = "";
                    }
                }
                else if (e.PropertyName == "Photos") {
                    if (_model.SelectedPhoto != null) {
                        ShowPhoto(null);
                    }

                    UpdatePhotos(/* newPhotos */ true);
                }
            };

            MapOptions mapOptions = new MapOptions();
            mapOptions.Credentials = bingMapsKey;
            mapOptions.ShowMapTypeSelector = false;
            mapOptions.ShowDashboard = false;
            mapOptions.ShowScalebar = false;
            mapOptions.ShowCopyright = false;
            mapOptions.ShowLogo = false;
            mapOptions.MapType = MapType.Custom;
            mapOptions.Zoom = 2;
            mapOptions.BackgroundColor = new MapColor(255, 255, 255, 255);
            _map = new Map(Utility.GetElement("mapContainer"), mapOptions);

            MapTileSourceOptions sourceOptions = new MapTileSourceOptions();
            sourceOptions.UriGenerator = CreateTileUrl;

            MapTileLayerOptions layerOptions = new MapTileLayerOptions();
            layerOptions.Mercator = new MapTileSource(sourceOptions);
            _map.Entities.Push(new MapTileLayer(layerOptions));

            MapEvents.AddHandler(_map, "viewchangestart", delegate(MapEventArgs e) {
                _viewChanging = true;
                _zoomLevel = _map.GetZoom();
            });
            MapEvents.AddThrottledHandler(_map, "viewchangeend", delegate(MapEventArgs e) {
                _viewChanging = false;

                if (_zoomLevel != _map.GetZoom()) {
                    UpdatePhotos(/* newPhotos */ false);
                }
            }, 250);
            MapEvents.AddHandler(_map, "mousedown", delegate(MapEventArgs e) {
                _oldMode = Document.Body.ClassName;
                Document.Body.ClassName = MapModeClassName;
            });
            MapEvents.AddHandler(_map, "mouseup", delegate(MapEventArgs e) {
                Document.Body.ClassName = _oldMode;
            });

            Utility.SubscribeKey("searchBox", delegate(ElementEvent e) {
                Window.SetTimeout(delegate() {
                    Document.GetElementById("searchButton").ClassName =
                        String.IsNullOrEmpty(Utility.GetElement("searchBox").As<InputElement>().Value) ? "reset" : "";
                }, 0);
            });
            Utility.SubscribeBlur("searchBox", delegate(ElementEvent e) {
                Window.SetTimeout(delegate() {
                    Document.GetElementById("searchButton").ClassName = "";
                }, 0);
            });
            Utility.SubscribeClick("searchButton", delegate(ElementEvent e) {
                Search(Utility.GetElement("searchBox").As<InputElement>().Value);
                Document.ActiveElement.Blur();
            });
            Utility.SubscribeClick("locateMeButton", delegate(ElementEvent e) {
                ShowLocation();
            });
            Utility.SubscribeClick("favButton", delegate(ElementEvent e) {
                ShowFavorites();
            });

            Utility.SubscribeClick("photoAroundButton", delegate(ElementEvent e) {
                SearchSimilar();
            });
            Utility.SubscribeClick("photoCloseButton", delegate(ElementEvent e) {
                HidePhoto();
            });
            Utility.SubscribeClick("photoSaveButton", delegate(ElementEvent e) {
                FavoritePhoto();
            });
            Utility.SubscribeClick("photoShareButton", delegate(ElementEvent e) {
                SharePhoto();
            });
            Utility.SubscribeClick("photoSourceButton", delegate(ElementEvent e) {
                ShowPhotoFlickrPage();
            });

            ShowLocation();
        }

        private static string CreateTileUrl(MapTile tile) {
            int index = Math.Floor(Math.Random() * 3 + 1);
            string domain = (index == 1) ? "a" : (index == 2) ? "b" : "c";

            return String.Format(_tileUrlFormat, domain, tile.LevelOfDetail, tile.X, tile.Y);
        }

        private static void FavoritePhoto() {
            Debug.Assert(_model.SelectedPhoto != null);
            _model.AddFavorite();
            Script.Alert("This photo has been saved to your favorites.");
        }

        private static void HidePhoto() {
            Debug.Assert(_model.SelectedPhoto != null);
            ShowPhoto(null);
        }

        private static void Search(string text) {
            if (String.IsNullOrEmpty(text)) {
                _model.ResetSearch();
                return;
            }

            MapBounds bounds = _map.GetBounds();
            _model.SearchRegion(text, bounds.GetWest(), bounds.GetSouth(),
                                      bounds.GetEast(), bounds.GetNorth());
        }

        private static void SearchSimilar() {
            Debug.Assert(_model.SelectedPhoto != null);

            Photo selectedPhoto = _model.SelectedPhoto;
            _model.SearchLocation(selectedPhoto.tags, selectedPhoto.latitude, selectedPhoto.longitude);
            ShowPhoto(null);
        }

        private static void SharePhoto() {
            Debug.Assert(_model.SelectedPhoto != null);

            Twitter.Anywhere(delegate(TwitterObject t) {
                Photo photo = _model.SelectedPhoto;

                TweetBoxOptions options = new TweetBoxOptions();
                options.Callback = delegate(string tweet, string htmlTweet) {
                    Utility.GetElement("photoTweet").InnerHTML = String.Empty;
                    Script.Alert("This photo has been shared with your followers on Twitter.");
                };
                options.Data = new TweetBoxData();
                options.Data.Latitude = photo.latitude;
                options.Data.Longitude = photo.longitude;
                options.Label = "";
                options.DefaultContent = photo.title + " " + photo.url;
                options.Width = photo.width;

                t.Select("#photoTweet").TweetBox(options);
            });
        }

        private static void ShowFavorites() {
            _model.ShowFavorites();

            int favoriteCount = _model.Photos.Count;
            if (favoriteCount != 0) {
                MapLocation[] locations = new MapLocation[favoriteCount];

                for (int i = 0; i < favoriteCount; i++) {
                    locations[i] = new MapLocation(_model.Photos[i].latitude, _model.Photos[i].longitude);
                }

                MapViewOptions viewOptions = new MapViewOptions();
                viewOptions.Bounds = MapBounds.FromLocations(locations);
                viewOptions.Animate = true;

                _map.SetView(viewOptions);
                UpdatePhotos(/* newPhotos */ false);
            }
        }

        private static void ShowLocation() {
            Window.Navigator.Geolocation.GetCurrentPosition(delegate(Geolocation location) {
                MapViewOptions viewOptions = new MapViewOptions();
                viewOptions.Center = new MapLocation(location.Coordinates.Latitude,
                                                     location.Coordinates.Longitude);
                viewOptions.Zoom = 10;
                viewOptions.Animate = true;

                _map.SetView(viewOptions);
                UpdatePhotos(/* newPhotos */ false);

                if (_currentPushpin == null) {
                    MapPushpinOptions pushpinOptions = new MapPushpinOptions();
                    pushpinOptions.Icon = "/Content/Pushpin.png";
                    pushpinOptions.Anchor = new MapPoint(12, 14);
                    pushpinOptions.Width = 25;
                    pushpinOptions.Height = 28;
                    pushpinOptions.TypeName = "currentPushpin";

                    _currentPushpin = new MapPushpin(viewOptions.Center, pushpinOptions);
                    _map.Entities.Push(_currentPushpin);
                }
                else {
                    _currentPushpin.SetLocation(viewOptions.Center);
                }
            });
        }

        private static void ShowPhoto(Photo photo) {
            Element photoOverlay = Utility.GetElement("photoOverlay");
            Element photoWrapper = Utility.GetElement("photo");
            Element photoTitle = Utility.GetElement("photoTitle");
            Element photoTweet = Utility.GetElement("photoTweet");

            if (photo != null) {
                ImageElement photoImage = Document.CreateElement("img").As<ImageElement>();
                photoImage.Width = photo.width;
                photoImage.Height = photo.height;
                photoImage.Src = photo.imageUrl;

                photoTitle.TextContent = photo.title;
                photoTitle.Style.Width = photo.width + "px";
                photoWrapper.AppendChild(photoImage);
                photoOverlay.Style.Display = "block";

                Element photoContainer = Utility.GetElement("photoContainer");
                photoContainer.Style.MarginTop = Math.Max(20, Math.Truncate((Document.Body.OffsetHeight - photoContainer.OffsetHeight) / 2f) - 100) + "px";
            }
            else {
                photoTitle.TextContent = String.Empty;
                photoWrapper.InnerHTML = String.Empty;
                photoTweet.InnerHTML = String.Empty;
                photoOverlay.Style.Display = "none";
            }

            _model.SelectedPhoto = photo;
        }

        private static void ShowPhotoFlickrPage() {
            Debug.Assert(_model.SelectedPhoto != null);
            Window.Open(_model.SelectedPhoto.url, "_blank");
        }

        private static void UpdateLayout() {
            if (_viewChanging) {
                return;
            }

            bool continueLayout = _graph.Layout.PerformLayout();

            _model.Photos.ForEach(delegate(Photo photo) {
                PhotoView photoView = _photoViews[photo.id];

                MapLocation pushpinLocation = photoView.pushpin.GetLocation();
                MapLocation calloutLocation =
                    _map.TryPixelToLocation(new MapPoint(photoView.calloutNode.x, photoView.calloutNode.y),
                                            MapPointReference.Control);

                photoView.callout.SetLocation(calloutLocation);
                photoView.connector.SetLocations(new MapLocation[] { pushpinLocation, calloutLocation });
            });

            if (continueLayout) {
                Window.SetTimeout(UpdateLayout, 30);
            }
        }

        private static void UpdatePhotos(bool newPhotos) {
            if (newPhotos) {
                if (_mapEntities != null) {
                    _map.Entities.Remove(_mapEntities);
                }

                _mapEntities = new MapEntityCollection();
                _map.Entities.Push(_mapEntities);

                _photoViews = new Dictionary<string, PhotoView>();
            }

            if (_model.Photos.Count == 0) {
                Document.Body.ClassName = MapModeClassName;
                return;
            }

            Document.Body.ClassName = PhotosModeClassName;

            _graph = new Graph();
            _model.Photos.ForEach(delegate(Photo photo) {
                MapLocation location = new MapLocation(photo.latitude, photo.longitude);
                MapPoint point = _map.TryLocationToPixel(location, MapPointReference.Control);

                PhotoView photoView;
                if (newPhotos) {
                    MapPolylineOptions connectorOptions = new MapPolylineOptions();
                    connectorOptions.StrokeColor = new MapColor(255, 0x4E, 0xD3, 0x4E);
                    connectorOptions.StrokeThickness = 2;

                    MapInfoboxOptions calloutOptions = new MapInfoboxOptions();
                    calloutOptions.Width = 50;
                    calloutOptions.Height = 50;
                    calloutOptions.ShowPointer = false;
                    calloutOptions.ShowCloseButton = false;
                    calloutOptions.Offset = new MapPoint(-25, 25);
                    calloutOptions.HtmlContent =
                        "<div class=\"photoInfobox\" style=\"background-image: url(" + photo.thumbnailUrl + ")\"" +
                        " title=\"" + photo.title.HtmlEncode() + "\"></div>";
                    calloutOptions.Visible = true;

                    MapPushpinOptions pushpinOptions = new MapPushpinOptions();
                    pushpinOptions.Icon = "/Content/Dot.png";
                    pushpinOptions.Width = 10;
                    pushpinOptions.Height = 10;
                    pushpinOptions.Anchor = new MapPoint(5, 5);
                    pushpinOptions.TypeName = "locationPushpin";

                    photoView = new PhotoView();
                    photoView.pushpin = new MapPushpin(location, pushpinOptions);
                    photoView.connector = new MapPolyline(new MapLocation[] { location, location }, connectorOptions);
                    photoView.callout = new MapInfobox(location, calloutOptions);
                    photoView.callout.Data = photo;
                    _photoViews[photo.id] = photoView;

                    _mapEntities.Insert(photoView.connector, 0);
                    _mapEntities.Insert(photoView.callout, 0);
                    _mapEntities.Insert(photoView.pushpin, 0);
                    MapEvents.AddHandler(photoView.callout, "click", delegate(MapEventArgs e) {
                        ShowPhoto(photo);
                    });
                }
                else {
                    photoView = _photoViews[photo.id];
                }

                photoView.pushpinNode = new GraphNode();
                photoView.pushpinNode.x = point.X;
                photoView.pushpinNode.y = point.Y;
                photoView.pushpinNode.moveable = false;

                photoView.calloutNode = new GraphNode();
                photoView.calloutNode.x = point.X;
                photoView.calloutNode.y = point.Y;

                GraphEdge connectorEdge = new GraphEdge(photoView.pushpinNode,
                                                        photoView.calloutNode,
                                                        10 + Math.Random() * 15);

                _graph.AddNode(photoView.pushpinNode);
                _graph.AddNode(photoView.calloutNode);
                _graph.AddEdge(connectorEdge);
            });

            Window.SetTimeout(UpdateLayout, 30);
        }
    }
}
