using DevExpress.Utils.Extensions;
using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;

namespace ReportGenerator
{
    class OverlayImagePainterEx : OverlayImagePainter
    {
        public OverlayImagePainterEx(Image image, Image hoverImage = null, Action clickAction = null) : base(image, hoverImage, clickAction) { }
        protected override Rectangle CalcImageBounds(OverlayLayeredWindowObjectInfoArgs drawArgs)
        {
            int indent = 10;
            return Image.Size.AlignWith(drawArgs.Bounds).WithY(indent).WithX(drawArgs.Bounds.Width - Image.Height - indent);
        }
    }

    class OverlayTextPainterEx : OverlayTextPainter
    {
        protected override Rectangle CalcTextBounds(OverlayLayeredWindowObjectInfoArgs drawArgs)
        {
            Size textSz = CalcTextSize(drawArgs);
            return textSz.AlignWith(drawArgs.Bounds).WithY(drawArgs.ImageBounds.Top - textSz.Height);
        }
    }

}
