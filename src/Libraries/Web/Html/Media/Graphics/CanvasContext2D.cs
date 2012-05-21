// CanvasContext2D.cs
// Script#/Libraries/Web
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using System;
using System.Runtime.CompilerServices;
using System.Html;

namespace System.Html.Media.Graphics {

    [IgnoreNamespace]
    [Imported]
    public sealed class CanvasContext2D : CanvasContext {

        private CanvasContext2D() {
        }

        [ScriptName("globalAlpha")]
        [IntrinsicProperty]
        public double Alpha {
            get;
            set;
        }

        [ScriptName("globalCompositeOperation")]
        [IntrinsicProperty]
        public CompositeOperation CompositeOperation {
            get;
            set;
        }

        [IntrinsicProperty]
        public object FillStyle {
            get;
            set;
        }

        [IntrinsicProperty]
        public string Font {
            get;
            set;
        }

        [IntrinsicProperty]
        public LineCap LineCap {
            get;
            set;
        }

        [IntrinsicProperty]
        public LineJoin LineJoin {
            get;
            set;
        }

        [IntrinsicProperty]
        public double LineWidth {
            get;
            set;
        }

        [IntrinsicProperty]
        public int MiterLimit {
            get;
            set;
        }

        [IntrinsicProperty]
        public double ShadowBlur {
            get;
            set;
        }

        [IntrinsicProperty]
        public string ShadowColor {
            get;
            set;
        }

        [IntrinsicProperty]
        public double ShadowOffsetX {
            get;
            set;
        }

        [IntrinsicProperty]
        public double ShadowOffsetY {
            get;
            set;
        }

        [IntrinsicProperty]
        public object StrokeStyle {
            get;
            set;
        }

        [IntrinsicProperty]
        public TextAlign TextAlign {
            get;
            set;
        }

        [IntrinsicProperty]
        public TextBaseline TextBaseline {
            get;
            set;
        }

        public void Arc(double x, double y, double radius, double startAngle, double endAngle, bool anticlockwise) {
        }

        public void ArcTo(double x1, double y1, double x2, double y2, double radius) {
        }

        public void BeginPath() {
        }

        public void BezierCurveTo(double cp1x, double cp1y, double cp2x, double cp2y, double x, double y) {
        }

        public void ClearRect(double x, double y, double w, double h) {
        }

        public void Clip() {
        }

        public void ClosePath() {
        }

        public Gradient CreateLinearGradient(double x0, double y0, double x1, double y1) {
            return null;
        }

        public Gradient CreateRadialGradient(double x0, double y0, double r0, double x1, double y1, double r1) {
            return null;
        }

        public ImageData CreateImageData(double sw, double sh) {
            return null;
        }

        public ImageData CreateImageData(ImageData imagedata) {
            return null;
        }

        public Pattern CreatePattern(CanvasElement canvas, string repetition) {
            return null;
        }

        public Pattern CreatePattern(ImageElement image, string repetition) {
            return null;
        }

        public void DrawImage(ImageElement image, double dx, double dy) {
        }

        public void DrawImage(ImageElement image, double dx, double dy, double dw, double dh) {
        }

        public void DrawImage(ImageElement image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh) {
        }

        public void DrawImage(CanvasElement image, double dx, double dy) {
        }

        public void DrawImage(CanvasElement image, double dx, double dy, double dw, double dh) {
        }

        public void DrawImage(CanvasElement image, double sx, double sy, double sw, double sh, double dx, double dy, double dw, double dh) {
        }

        public void Fill() {
        }

        public void FillRect(double x, double y, double w, double h) {
        }

        public void FillText(string text, double x, double y) {
        }

        public void FillText(string text, double x, double y, double maxWidth) {
        }

        public ImageData GetImageData(double sx, double sy, double sw, double sh) {
            return null;
        }

        public bool IsPointInPath(double x, double y) {
            return false;
        }

        public void LineTo(double x, double y) {
        }

        public TextMetrics MeasureText(string text) {
            return null;
        }

        public void MoveTo(double x, double y) {
        }

        public void PutImageData(ImageData imagedata, double dx, double dy) {
        }

        public void PutImageData(ImageData imagedata, double dx, double dy, double dirtyX, double dirtyY, double dirtyWidth, double dirtyHeight) {
        }

        public void QuadraticCurveTo(double cpx, double cpy, double x, double y) {
        }

        public void Rect(double x, double y, double w, double h) {
        }

        public void Restore() {
        }

        public void Rotate(double angle) {
        }

        public void Save() {
        }

        public void Scale(double x, double y) {
        }

        public void SetTransform(double m11, double m12, double m21, double m22, double dx, double dy) {
        }

        public void Stroke() {
        }

        public void StrokeRect(double x, double y, double w, double h) {
        }

        public void StrokeText(string text, double x, double y) {
        }

        public void StrokeText(string text, double x, double y, double maxWidth) {
        }

        public void Transform(double m11, double m12, double m21, double m22, double dx, double dy) {
        }

        public void Translate(double x, double y) {
        }
    }
}
