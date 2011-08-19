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

        private static Graph _graph;
        private static ImageElement _placeHolderPhoto;
        private static CanvasElement _canvas;
        private static Dictionary<string, PhotoView> _photoViews;

        private static bool _viewChanging;

        static Page() {
            if (Document.Body.ClassName != "app") {
                return;
            }

            string flickrKey = (string)Document.Body.GetAttribute("data-flickr-key");
            Debug.Assert(String.IsNullOrEmpty(flickrKey) == false);

            string bingMapsKey = (string)Document.Body.GetAttribute("data-bingmaps-key");
            Debug.Assert(String.IsNullOrEmpty(bingMapsKey) == false);

            _model = new PageModel(new FlickrService(flickrKey), new HtmlStorageService());
            _model.PropertyChanged += OnModelPropertyChanged;

            MapOptions mapOptions = new MapOptions();
            mapOptions.Credentials = bingMapsKey;
            mapOptions.ShowMapTypeSelector = false;
            mapOptions.ShowDashboard = false;
            mapOptions.ShowScalebar = false;
            mapOptions.ShowCopyright = false;
            mapOptions.ShowLogo = false;
            mapOptions.MapType = MapType.Road;
            mapOptions.Zoom = 2;
            _map = new Map(Utility.GetElement("mapContainer"), mapOptions);
            MapEvents.AddHandler(_map, "viewchangestart", OnMapViewChangeStart);
            MapEvents.AddHandler(_map, "viewchangeend", OnMapViewChangeEnd);

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

        private static void OnMapPushpinClick(MapEventArgs e) {
            MapMouseEventArgs mouseEvent = (MapMouseEventArgs)e;
            Photo photo = (Photo)((MapPushpin)mouseEvent.Target).Data;

            ShowPhoto(photo);
        }

        private static void OnMapViewChangeEnd(MapEventArgs e) {
            _viewChanging = false;
            if (_canvas != null) {
                _canvas.Style.Display = "";
                ShowPhotoPushpins(false);
            }
        }

        private static void OnMapViewChangeStart(MapEventArgs e) {
            _viewChanging = true;
            if (_canvas != null) {
                _canvas.Style.Display = "none";
            }
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

                ShowPhotoPushpins(true);
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
            if (_model.Photos.Count == 0) {
                if (_canvas != null) {
                    _canvas.Style.Display = "none";
                }
                return;
            }

            if (_canvas == null) {
                _canvas = Document.CreateElement("canvas").As<CanvasElement>();
                _canvas.Style.Width = "100%";
                _canvas.Style.Height = "100%";
                _canvas.Style.ZIndex = 100;
                _canvas.Style.Position = "absolute";
                _canvas.Style.Left = "0px";
                _canvas.Style.Top = "0px";
                _canvas.Style.Display = "";
                Document.QuerySelector(".MicrosoftMap").AppendChild(_canvas);
                _canvas.AddEventListener("click", OnCanvasClick, false);
            }

            _graph = new Graph();
            if (newPhotos) {
                _photoViews = new Dictionary<string, PhotoView>();
            }

            int width = _canvas.OffsetWidth;
            int height = _canvas.OffsetHeight;

            _model.Photos.ForEach(delegate(Photo photo) {
                PhotoView photoView;

                if (newPhotos) {
                    photoView = new PhotoView();

                    photoView.image = Document.CreateElement("img").As<ImageElement>();
                    photoView.image.Src = photo.thumbnailUrl;

                    _photoViews[photo.id] = photoView;
                }
                else {
                    photoView = _photoViews[photo.id];
                }

                MapLocation location = new MapLocation(photo.latitude, photo.longitude);
                MapPoint point = _map.TryLocationToPixel(location, MapPointReference.Control);

                photoView.hidden = (point.X < 0) || (point.X > width) ||
                                   (point.Y < 0) || (point.Y > height);
                if (photoView.hidden == false) {
                    photoView.pushpin = new GraphNode();
                    photoView.pushpin.x = point.X;
                    photoView.pushpin.y = point.Y;
                    photoView.pushpin.moveable = false;

                    photoView.photo = new GraphNode();
                    photoView.photo.x = point.X;
                    photoView.photo.y = point.Y;

                    GraphEdge edge = new GraphEdge(photoView.pushpin, photoView.photo, 10 + Math.Random() * 15);

                    _graph.AddNode(photoView.pushpin);
                    _graph.AddNode(photoView.photo);
                    _graph.AddEdge(edge);
                }
            });

            Window.SetTimeout(OnLayoutTick, 30);
        }

        private static void OnCanvasClick(ElementEvent e) {
            Photo clickedPhoto = null;

            int x = e.OffsetX;
            int y = e.OffsetY;
            foreach (Photo photo in _model.Photos) {
                PhotoView photoView = _photoViews[photo.id];

                if ((photoView.photo.x - 25 < x) && (photoView.photo.x + 25 > x) &&
                    (photoView.photo.y - 25 < y) && (photoView.photo.y + 25 > y)) {
                    clickedPhoto = photo;
                    break;
                }
            }

            if (clickedPhoto != null) {
                e.StopPropagation();

                Window.SetTimeout(delegate() {
                    ShowPhoto(clickedPhoto);
                }, 0);
            }
        }

        private static void OnLayoutTick() {
            if (_viewChanging) {
                Window.SetTimeout(OnLayoutTick, 30);
            }

            int width = _canvas.OffsetWidth;
            int height = _canvas.OffsetHeight;

            bool continueLayout = _graph.Layout.PerformLayout(width, height);

            _canvas.Width = width;
            _canvas.Height = height;

            CanvasContext2D ctx = (CanvasContext2D)_canvas.GetContext(Rendering.Render2D);

            ctx.ClearRect(0, 0, width, height);
            ctx.Save();

            ctx.FillStyle = "#4ED34E";
            ctx.StrokeStyle = "#4ED34E";
            ctx.LineWidth = 2;

            ctx.BeginPath();
            _model.Photos.ForEach(delegate(Photo photo) {
                PhotoView photoView = _photoViews[photo.id];
                if (photoView.hidden) {
                    return;
                }

                ctx.MoveTo(photoView.pushpin.x, photoView.pushpin.y);
                ctx.Arc(photoView.pushpin.x, photoView.pushpin.y, 4, 0, Math.PI * 2, true);

                ctx.MoveTo(photoView.pushpin.x, photoView.pushpin.y);
                ctx.LineTo(photoView.photo.x, photoView.photo.y);
            });
            ctx.ClosePath();
            ctx.Fill();
            ctx.Stroke();

            ctx.FillStyle = "white";
            ctx.ShadowBlur = 10;
            ctx.ShadowColor = "black";
            _model.Photos.ForEach(delegate(Photo photo) {
                PhotoView photoView = _photoViews[photo.id];
                if (photoView.hidden) {
                    return;
                }

                ImageElement img = (ImageElement)photoView.image;
                if ((bool)Type.GetField(img, "complete")) {
                    ctx.FillRect(photoView.photo.x - 25, photoView.photo.y - 25, 50, 50);
                    ctx.DrawImage(img, 0, 0, 75, 75, photoView.photo.x - 25, photoView.photo.y - 25, 50, 50);
                }
                else {
                    ctx.DrawImage(_placeHolderPhoto, 0, 0, 20, 20, photoView.photo.x - 10, photoView.photo.y - 10, 20, 20);
                }
            });

            ctx.Restore();

            if (continueLayout) {
                Window.SetTimeout(OnLayoutTick, 30);
            }
        }
    }
}
