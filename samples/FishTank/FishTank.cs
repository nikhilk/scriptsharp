// FishTank.cs
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Html;
using System.Html.Media.Graphics;

namespace FishTankApp {

    internal sealed class FishTank {

        public const int RefreshInterval = 60;
        public const int BackgroundImageWidth = 981;
        public const int BackgroundImageHeight = 767;
        public const int FishWidth = 307;
        public const int FishHeight = 313;
        public const int FishCount = 20;
        public const int FishSpecies = 3;
        public const int CellsInFishStrip = 16;

        public const int FramesPerSecond = 60;
        public const double TimeDelta = 1.0 / FramesPerSecond;
        public const double ZFar = 100;
        public const double ZNear = 1;
        public const double ZClose = 1;


        private ImageElement _backgroundImageElement;
        private ImageElement _imageStripElement;

        private CanvasElement _tankCanvas;
        private CanvasElement _fishesCanvas;

        private CanvasContext2D _tankCanvasContext;
        private CanvasContext2D _fishesCanvasContext;

        private List<Fish> _fishes;

        private int _width;
        private int _height;

        private Action _tickHandler;

        public int Height {
            get {
                return _height;
            }
        }

        public int Width {
            get {
                return _width;
            }
        }

        public void Run() {
            _backgroundImageElement = Document.GetElementById("backgroundImage").As<ImageElement>();
            _imageStripElement = Document.GetElementById("imageStrip").As<ImageElement>();
            _tankCanvas = Document.GetElementById("fishTankCanvas").As<CanvasElement>();
            _fishesCanvas = Document.GetElementById("fishesCanvas").As<CanvasElement>();

            Debug.Assert(_backgroundImageElement != null);
            Debug.Assert(_imageStripElement != null);
            Debug.Assert(_tankCanvas != null);
            Debug.Assert(_fishesCanvas != null);

            _tankCanvasContext = (CanvasContext2D)_tankCanvas.GetContext(Rendering.Render2D);
            _fishesCanvasContext = (CanvasContext2D)_fishesCanvas.GetContext(Rendering.Render2D);

            _fishes = new List<Fish>();
            for (int i = 0; i < FishTank.FishCount; i++) {
                double x = Math.Floor(Math.Random() * (_width - FishTank.FishWidth) + FishTank.FishWidth / 2);
                double y = Math.Floor(Math.Random() * (_height - FishTank.FishHeight) + FishTank.FishHeight / 2);
                double z = Math.Floor(Math.Random() * (FishTank.ZFar - FishTank.ZNear));

                _fishes.Add(new Fish(this, x, y, z, _imageStripElement, _fishesCanvasContext));
            }

            OnWindowResize(null);
            Window.AddEventListener("resize", OnWindowResize, false);

            _tickHandler = OnTick;
            QueueUpdate();
        }

        private void Draw() {
            if (_width < FishTank.BackgroundImageWidth) {
                // Show just a portion of the background image, since the window is
                // smaller than the background
                _tankCanvasContext.DrawImage(_backgroundImageElement, 0, 0, FishTank.BackgroundImageWidth, _height);
            }
            else {
                // Tile the background image horizontally if the window is wider than
                // the background

                int tileCount = (int)(_width / FishTank.BackgroundImageWidth);
                double flip = 1;

                for (int i = 0; i <= tileCount; i++) {
                    _tankCanvasContext.Save();
                    _tankCanvasContext.Transform(flip, 0, 0, 1, 0, 0);
                    _tankCanvasContext.DrawImage(_backgroundImageElement,
                                                 (flip - 1) * FishTank.BackgroundImageWidth / 2 + flip * FishTank.BackgroundImageWidth * i,
                                                 0, FishTank.BackgroundImageWidth, _height);
                    _tankCanvasContext.Restore();
                    flip = -flip;
                }
            }
        }

        private void OnTick() {
            _fishesCanvasContext.ClearRect(0, 0, _width, _height);
            foreach (Fish fish in _fishes) {
                fish.Update();
            }

            QueueUpdate();
        }

        private void OnWindowResize(ElementEvent e) {
            _width = Document.Body.OffsetWidth;
            _height = Document.Body.OffsetHeight;

            _tankCanvas.Width = _width;
            _tankCanvas.Height = _height;
            _fishesCanvas.Width = _width;
            _fishesCanvas.Height = _height;

            Draw();
        }

        private void QueueUpdate() {
            Window.SetTimeout(_tickHandler, (int)(1000 / FramesPerSecond));
        }
    }
}
