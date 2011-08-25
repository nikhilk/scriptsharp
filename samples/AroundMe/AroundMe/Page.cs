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

        private static PageModel _model;
        private static Map _map;
        private static MapEntityCollection _mapEntities;

        private static Graph _graph;
        private static ImageElement _placeHolderPhoto;
        private static Dictionary<string, PhotoView> _photoViews;

        private static bool _viewChanging;
        private static int _zoomLevel;

        static Page() {
            string flickrKey = (string)Document.Body.GetAttribute("data-flickr-key");
            Debug.Assert(String.IsNullOrEmpty(flickrKey) == false);

            string bingMapsKey = (string)Document.Body.GetAttribute("data-bingmaps-key");
            Debug.Assert(String.IsNullOrEmpty(bingMapsKey) == false);

            _model = new PageModel(new FlickrService(flickrKey), new HtmlStorageService());
            _model.PropertyChanged += OnModelPropertyChanged;

            _zoomLevel = 2;

            MapOptions mapOptions = new MapOptions();
            mapOptions.Credentials = bingMapsKey;
            mapOptions.ShowMapTypeSelector = false;
            mapOptions.ShowDashboard = false;
            mapOptions.ShowScalebar = false;
            mapOptions.ShowCopyright = false;
            mapOptions.ShowLogo = false;
            mapOptions.MapType = MapType.Road;
            mapOptions.Zoom = 2;
            mapOptions.BackgroundColor = new MapColor(0, 0, 0, 0);
            _map = new Map(Utility.GetElement("mapContainer"), mapOptions);
            MapEvents.AddHandler(_map, "viewchangestart", OnMapViewChangeStart);
            MapEvents.AddThrottledHandler(_map, "viewchangeend", OnMapViewChangeEnd, 250);

            Utility.SubscribeClick("searchButton", OnSearchButtonClick);
            Utility.SubscribeClick("locateMeButton", OnLocateMeButtonClick);
            Utility.SubscribeClick("favButton", OnFavoritesButtonClick);

            Utility.SubscribeClick("photoAroundButton", OnPhotoAroundButtonClick);
            Utility.SubscribeClick("photoCloseButton", OnPhotoCloseButtonClick);
            Utility.SubscribeClick("photoSaveButton", OnPhotoSaveButtonClick);
            Utility.SubscribeClick("photoShareButton", OnPhotoShareButtonClick);
            Utility.SubscribeClick("photoSourceButton", OnPhotoShareButtonClick);

            _placeHolderPhoto = Document.CreateElement("img").As<ImageElement>();
            _placeHolderPhoto.Src = "/Content/PlaceHolder.png";
        }

        private static void OnFavoritesButtonClick(ElementEvent e) {
            _model.ShowFavorites();
        }

        private static void OnLocateMeButtonClick(ElementEvent e) {
            Window.Navigator.Geolocation.GetCurrentPosition(delegate(Geolocation location) {
                MapViewOptions viewOptions = new MapViewOptions();
                viewOptions.Center = new MapLocation(location.Coordinates.Latitude,
                                                     location.Coordinates.Longitude);
                viewOptions.Zoom = 10;
                viewOptions.Animate = true;

                _map.SetView(viewOptions);
            });
        }

        private static void OnMapPhotoInfoboxClick(MapEventArgs e) {
            MapInfobox photoInfobox = (MapInfobox)((MapMouseEventArgs)e).Target;
            Photo clickedPhoto = (Photo)photoInfobox.Data;

            if (clickedPhoto != null) {
                Window.SetTimeout(delegate() {
                    ShowPhoto(clickedPhoto);
                }, 0);
            }
        }

        private static void OnMapViewChangeEnd(MapEventArgs e) {
            _viewChanging = false;

            // if (_mapEntities != null) {
            //     _map.Entities.Push(_mapEntities);
            // }

            if (_zoomLevel != _map.GetZoom()) {
                ShowPhotoPushpins(/* newPhotos */ false);
            }
        }

        private static void OnMapViewChangeStart(MapEventArgs e) {
            _viewChanging = true;

            // if (_mapEntities != null) {
            //     _map.Entities.Remove(_mapEntities);
            // }

            _zoomLevel = _map.GetZoom();
        }

        private static void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e) {
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

                ShowPhotoPushpins(/* newPhotos */ true);
            }
        }

        private static void OnPhotoAroundButtonClick(ElementEvent e) {
            Debug.Assert(_model.SelectedPhoto != null);

            Photo selectedPhoto = _model.SelectedPhoto;
            _model.SearchLocation(selectedPhoto.tags, selectedPhoto.latitude, selectedPhoto.longitude);
            ShowPhoto(null);
        }

        private static void OnPhotoCloseButtonClick(ElementEvent e) {
            Debug.Assert(_model.SelectedPhoto != null);
            ShowPhoto(null);
        }

        private static void OnPhotoSaveButtonClick(ElementEvent e) {
            Debug.Assert(_model.SelectedPhoto != null);
            _model.AddFavorite();
            Script.Alert("This photo has been saved to your favorites.");
        }

        private static void OnPhotoShareButtonClick(ElementEvent e) {
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

        private static void OnPhotoSourceButtonClick(ElementEvent e) {
            Debug.Assert(_model.SelectedPhoto != null);
            Window.Open(_model.SelectedPhoto.url, "_blank");
        }

        private static void OnSearchButtonClick(ElementEvent e) {
            string text = Utility.GetElement("searchBox").As<InputElement>().Value;
            MapBounds bounds = _map.GetBounds();

            _model.SearchRegion(text, bounds.GetWest(), bounds.GetSouth(),
                                      bounds.GetEast(), bounds.GetNorth());
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

        private static void ShowPhotoPushpins(bool newPhotos) {
            if (newPhotos) {
                if (_mapEntities != null) {
                    _map.Entities.Remove(_mapEntities);
                }

                _mapEntities = new MapEntityCollection();
                _map.Entities.Push(_mapEntities);

                _photoViews = new Dictionary<string, PhotoView>();
            }

            if (_model.Photos.Count == 0) {
                return;
            }

            _graph = new Graph();
            _model.Photos.ForEach(delegate(Photo photo) {
                MapLocation location = new MapLocation(photo.latitude, photo.longitude);
                MapPoint point = _map.TryLocationToPixel(location, MapPointReference.Control);

                PhotoView photoView;
                if (newPhotos) {
                    MapPolylineOptions polylineOptions = new MapPolylineOptions();
                    polylineOptions.StrokeColor = new MapColor(255, 0x4E, 0xD3, 0x4E);
                    polylineOptions.StrokeThickness = 2;

                    MapInfoboxOptions photoInfoboxOptions = new MapInfoboxOptions();
                    photoInfoboxOptions.Width = 50;
                    photoInfoboxOptions.Height = 50;
                    photoInfoboxOptions.ShowPointer = false;
                    photoInfoboxOptions.ShowCloseButton = false;
                    photoInfoboxOptions.Offset = new MapPoint(-25, 25);
                    photoInfoboxOptions.HtmlContent = "<div class=\"photoInfobox\" style=\"background-image: url(" + photo.thumbnailUrl + ")\" title=\"" + photo.title.HtmlEncode() + "\"></div>";
                    photoInfoboxOptions.Visible = true;

                    MapPushpinOptions locationPushpinOptions = new MapPushpinOptions();
                    locationPushpinOptions.Icon = "/Content/Dot.png";
                    locationPushpinOptions.Width = 10;
                    locationPushpinOptions.Height = 10;
                    locationPushpinOptions.Anchor = new MapPoint(5, 5);
                    locationPushpinOptions.TypeName = "locationPushpin";

                    photoView = new PhotoView();
                    photoView.locationPushpin = new MapPushpin(location, locationPushpinOptions);
                    photoView.calloutLine = new MapPolyline(new MapLocation[] { location, location }, polylineOptions);
                    photoView.photoInfobox = new MapInfobox(location, photoInfoboxOptions);
                    photoView.photoInfobox.Data = photo;

                    _mapEntities.Insert(photoView.calloutLine, 0);
                    _mapEntities.Insert(photoView.photoInfobox, 0);
                    _mapEntities.Insert(photoView.locationPushpin, 0);
                    MapEvents.AddHandler(photoView.photoInfobox, "click", OnMapPhotoInfoboxClick);
                    _photoViews[photo.id] = photoView;
                }
                else {
                    photoView = _photoViews[photo.id];
                }

                photoView.locationNode = new GraphNode();
                photoView.locationNode.x = point.X;
                photoView.locationNode.y = point.Y;
                photoView.locationNode.moveable = false;

                photoView.photoNode = new GraphNode();
                photoView.photoNode.x = point.X;
                photoView.photoNode.y = point.Y;

                GraphEdge edge = new GraphEdge(photoView.locationNode, photoView.photoNode, 10 + Math.Random() * 15);

                _graph.AddNode(photoView.locationNode);
                _graph.AddNode(photoView.photoNode);
                _graph.AddEdge(edge);
            });

            Window.SetTimeout(OnLayoutTick, 30);
        }

        private static void OnLayoutTick() {
            if (_viewChanging) {
                return;
            }

            bool continueLayout = _graph.Layout.PerformLayout();

            _model.Photos.ForEach(delegate(Photo photo) {
                PhotoView photoView = _photoViews[photo.id];

                MapPoint photoPoint = new MapPoint(photoView.photoNode.x, photoView.photoNode.y);
                MapLocation photoLocation = _map.TryPixelToLocation(photoPoint, MapPointReference.Control);

                photoView.photoInfobox.SetLocation(photoLocation);
                photoView.calloutLine.SetLocations(new MapLocation[] { photoView.locationPushpin.GetLocation(), photoLocation });
            });

            if (continueLayout) {
                Window.SetTimeout(OnLayoutTick, 30);
            }
        }
    }
}
