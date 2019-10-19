using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Svg;
using System.Drawing;

namespace ReportGenerator
{
    public static class ImageHelper
    {
        public static Image CreateImage(byte[] data, ISkinProvider skinProvider = null)
        {
            SvgBitmap svgBitmap = new SvgBitmap(data);
            return svgBitmap.Render(SvgPaletteHelper.GetSvgPalette(skinProvider ?? UserLookAndFeel.Default, ObjectState.Normal), ScaleUtils.GetScaleFactor().Height);
        }
    }
}
