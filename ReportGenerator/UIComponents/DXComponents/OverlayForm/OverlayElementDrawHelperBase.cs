using DevExpress.XtraSplashScreen;

namespace ReportGenerator
{
	internal abstract class OverlayElementDrawHelperBase : OverlayWindowPainterBase
	{
		public OverlayElementDrawHelperBase()
		{
		}
		protected sealed override void Draw(OverlayWindowCustomDrawContext context)
		{
			CalculateLayout(context.DrawArgs);
			context.DefaultDraw();
			if (CanDraw)
			{
				DrawCore(context);
			}
			context.Handled = true;
		}
		protected virtual void CalculateLayout(OverlayLayeredWindowObjectInfoArgs drawArgs)
		{
		}
		protected virtual bool CanDraw { get { return true; } }
		protected abstract void DrawCore(OverlayWindowCustomDrawContext context);
	}
}