// Fish.cs
//

using System;
using System.Collections;
using System.Diagnostics;
using System.Html;
using System.Html.Media.Graphics;

namespace FishTankApp {

    internal sealed class Fish {

        private FishTank _tank;

        private double _angle;
        private double _xAngle;
        private double _yAngle;
        private double _zAngle;
        private double _scale;
        private double _velocity;
        private int _flip;
        private int _cellReverse;

        private int _cellIndex;
        private int _species;

        private double _x;
        private double _y;
        private double _z;
        private double _zFactor;

        private ImageElement _fishStrip;
        private CanvasContext2D _context;

        public Fish(FishTank tank, double x, double y, double z, ImageElement fishStrip, CanvasContext2D context) {
            _tank = tank;

            _x = x;
            _y = y;
            _z = z;
            _zFactor = 1;
            _species = Math.Floor(Math.Random() * FishTank.FishSpecies);
            _cellIndex = Math.Floor(Math.Random() * (FishTank.CellsInFishStrip - 1));
            _cellReverse = -1;

            _angle = 2 * Math.PI * Math.Random();
            _xAngle = Math.Cos(_angle);
            _yAngle = Math.Sin(_angle);
            _zAngle = 1 - 2 * Math.Round(Math.Random());
            _scale = 0.1;
            _flip = 1;
            _velocity = 100;

            // Stop fish from swimming straight up or down
            if ((_angle > Math.PI * 4 / 3) && (_angle < Math.PI * 5 / 3) ||
                (_angle > Math.PI * 1 / 3) && (_angle < Math.PI * 2 / 3)) {
                _angle = Math.PI * 1 / 3 * Math.Random();
                _xAngle = Math.Cos(_angle);
                _yAngle = Math.Sin(_angle);
            }

            // Face the fish the right way if angle is between 6 o'clock and 12 o'clock
            if ((_angle > Math.PI / 2) && (_angle < Math.PI / 2 * 3)) {
                _flip = -1;
            }

            _fishStrip = fishStrip;
            _context = context;
        }

        public void Update() {
            // Calculate next position of fish
            double fps = FishTank.FramesPerSecond;
            _velocity = Math.Max(Math.Floor(fps * fps * .5 / 3), 1);

            double nextX = _x + _xAngle * _velocity * FishTank.TimeDelta;
            double nextY = _y + _yAngle * _velocity * FishTank.TimeDelta;
            double nextZ = _z + _zAngle * .1 * _velocity * FishTank.TimeDelta;
            double nextScale = Math.Abs(nextZ) / (FishTank.ZFar - FishTank.ZNear);

            // If fish is going to move off right side of screen
            if (nextX + FishTank.FishWidth / 2 * _scale > _tank.Width) {
                // If angle is between 3 o'clock and 6 o'clock
                if ((_angle >= 0 && _angle < Math.PI / 2)) {
                    _angle = Math.PI - _angle;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle) * Math.Random();
                    _flip = -_flip;
                }
                else if (_angle > Math.PI / 2 * 3) {
                    // If angle is between 12 o'clock and 3 o'clock
                    _angle = _angle - (_angle - Math.PI / 2 * 3) * 2;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle) * Math.Random();
                    _flip = -_flip;
                }
            }

            // If fish is going to move off left side of screen
            if (nextX - FishTank.FishWidth / 2 * _scale < 0) {
                if ((_angle > Math.PI / 2 && _angle < Math.PI)) {
                    // If angle is between 6 o'clock and 9 o'clock
                    _angle = Math.PI - _angle;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle) * Math.Random();
                    _flip = -_flip;
                }
                else if (_angle > Math.PI && _angle < Math.PI / 2 * 3) {
                    // If angle is between 9 o'clock and 12 o'clock
                    _angle = _angle + (Math.PI / 2 * 3 - _angle) * 2;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle) * Math.Random();
                    _flip = -_flip;
                }
            }

            // If fish is going to move off bottom side of screen
            if (nextY + FishTank.FishHeight / 2 * _scale > _tank.Height) {
                // If angle is between 3 o'clock and 9 o'clock
                if ((_angle > 0 && _angle < Math.PI)) {
                    _angle = Math.PI * 2 - _angle;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle) * Math.Random();
                }
            }

            // If fish is going to move off top side of screen
            if (nextY - FishTank.FishHeight / 2 * _scale < 0) {
                // If angle is between 9 o'clock and 3 o'clock
                if ((_angle > Math.PI && _angle < Math.PI * 2)) {
                    _angle = _angle - (_angle - Math.PI) * 2;
                    _xAngle = Math.Cos(_angle);
                    _yAngle = Math.Sin(_angle);
                }
            }

            // If fish is going too far (getting too small)
            if (nextZ <= FishTank.ZNear && _zAngle < 0) {
                _zAngle = -_zAngle;
            }

            // If fish is getting to close (getting too large)
            if (((_tank.Width / FishTank.FishWidth) * 10) < ((FishTank.FishWidth * FishTank.FishCount) / _tank.Width)) {
                _zFactor = .3;
            }
            else if (((_tank.Width / FishTank.FishWidth) * 2) < ((FishTank.FishWidth * FishTank.FishCount) / _tank.Width)) {
                _zFactor = .5;
            }
            else {
                _zFactor = 1;
            }

            if (nextZ >= FishTank.ZFar * _zFactor && _zAngle > 0) {
                _zAngle = -_zAngle;
            }

            if (_scale < .1) {
                // Don't let fish get too tiny
                _scale = .1;
            }

            // Draw the fish
            _context.Save();

            // Move the fish to where it is within the fish tank
            _context.Translate(_x, _y);

            // Make the fish bigger or smaller depending on how far away it is.
            _context.Scale(_scale, _scale);

            // Make the fish face the way it is swimming.
            _context.Transform(_flip, 0, 0, 1, 0, 0);

            _context.DrawImage(_fishStrip,
                               FishTank.FishWidth * _cellIndex, FishTank.FishHeight * _species,
                               FishTank.FishWidth, FishTank.FishHeight,
                               -FishTank.FishWidth / 2, -FishTank.FishHeight / 2,
                               FishTank.FishWidth, FishTank.FishHeight);
            _context.Restore();

            // Increment to next state
            _x = nextX;
            _y = nextY;
            _z = nextZ;
            _scale = nextScale;

            if ((_cellIndex >= FishTank.CellsInFishStrip - 1) || (_cellIndex <= 0)) {
                // Go through each cell in the animation
                _cellReverse = -_cellReverse;
            }

            // Go back down once we hit the end of the animation
            _cellIndex = _cellIndex + _cellReverse;
        }
    }
}
