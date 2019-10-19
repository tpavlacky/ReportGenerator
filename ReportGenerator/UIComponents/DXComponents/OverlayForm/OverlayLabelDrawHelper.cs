using DevExpress.XtraSplashScreen;
using System.Drawing;
using DevExpress.Utils.Drawing;
using System.Drawing.Text;

namespace ReportGenerator
{
	internal class OverlayLabelDrawHelper : OverlayElementDrawHelperBase
	{
		string text;
		Color color;
		Point textPos;

		static readonly Font font = new Font("Tahoma", 18);

		public OverlayLabelDrawHelper()
		{
			this.textPos = Point.Empty;
			this.color = Color.Black;
			this.text = string.Empty;
		}
		public string Text
		{
			get { return text; }
			set { text = value; }
		}
		public Color Color
		{
			get { return color; }
			set { color = value; }
		}

		protected override bool CanDraw
		{
			get
			{
				if (string.IsNullOrEmpty(Text)) return false;
				return true;
			}
		}
		protected override void DrawCore(OverlayWindowCustomDrawContext context)
		{
			GraphicsCache cache = context.DrawArgs.Cache;
			TextRenderingHint prev = cache.TextRenderingHint;
			cache.TextRenderingHint = TextRenderingHint.AntiAlias;
			try
			{
				cache.DrawString(Text, font, cache.GetSolidBrush(Color), textPos);
			}
			finally
			{
				cache.TextRenderingHint = prev;
			}
		}

		protected override void CalculateLayout(OverlayLayeredWindowObjectInfoArgs drawArgs)
		{
			this.textPos = CalcTextPosition(drawArgs);
		}
		Point CalcTextPosition(OverlayLayeredWindowObjectInfoArgs drawArgs)
		{
			if (!CanDraw) return Point.Empty;
			Size textSize = drawArgs.Cache.CalcTextSize(Text, font).ToSize();
			return new Point((drawArgs.Bounds.Width - textSize.Width) / 2, drawArgs.ViewInfo.ImageBounds.Bottom + textSize.Height);
		}
	}
}