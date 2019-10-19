using System;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using System.Drawing;
using DevExpress.Utils.Drawing.Helpers;

namespace ReportGenerator
{
	internal class OverlaButtonDrawHelper : OverlayElementDrawHelperBase
	{
		readonly Image hotImage;
		readonly Image image;
		readonly Action clickAction;
		Rectangle imageRect;
		Point mousePos;
		Image currentImage;

		public OverlaButtonDrawHelper(Image hotImage, Image image, Action clickAction)
		{
			this.imageRect = Rectangle.Empty;
			this.hotImage = hotImage;
			this.image = image;
			this.clickAction = clickAction;
		}
		protected override bool ProcessMessage(ref Message msg)
		{
			if (msg.Msg == MSG.WM_NCHITTEST)
			{
				msg.Result = new IntPtr(NativeMethods.HT.HTCLIENT);
				return true;
			}
			if (msg.Msg == MSG.WM_LBUTTONDOWN)
			{
				if (imageRect.Contains(mousePos))
				{
					if (clickAction != null)
					{
						clickAction();
					}
					return true;
				}
			}
			return base.ProcessMessage(ref msg);
		}
		protected override void DrawCore(OverlayWindowCustomDrawContext context)
		{
			context.DrawArgs.Cache.DrawImage(currentImage, imageRect);
		}

		protected override void CalculateLayout(OverlayLayeredWindowObjectInfoArgs drawArgs)
		{
			this.imageRect = CalcButtonRect(drawArgs);
			this.mousePos = CalcMousePosition(drawArgs.ViewInfo.Owner);
			this.currentImage = imageRect.Contains(mousePos) ? hotImage : image;
		}
		Rectangle CalcButtonRect(OverlayLayeredWindowObjectInfoArgs drawArgs)
		{
			Point loc = new Point((drawArgs.Bounds.Width - image.Width) / 2, drawArgs.Bounds.Height - 2 * image.Height);
			return new Rectangle(loc, image.Size);
		}
		Point CalcMousePosition(OverlayLayeredWindow window)
		{
			NativeMethods.POINT point = new NativeMethods.POINT(Control.MousePosition);
			NativeAPI.ScreenToClient(window.Handle, ref point);
			return point.ToPoint();
		}
	}
}