using DevExpress.XtraSplashScreen;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReportGenerator.UIComponents.DXComponents.OverlayForm
{
	public class CancelableProgressOverlayFormManager
	{
		private CancelableOverlayWindowCompositePainter windowCompositePainter = null;
		readonly OverlayWindowOptions options = new OverlayWindowOptions(opacity: 100d / 255, foreColor: Color.Pink);

		public IOverlaySplashScreenHandle ShowOverlayForm(Control owner)
		{
			return ShowOverlayForm(owner, null);
		}

		public IOverlaySplashScreenHandle ShowOverlayForm(Control owner, Action onCancel)
		{
			windowCompositePainter = new CancelableOverlayWindowCompositePainter(onCancel);
			return SplashScreenManager.ShowOverlayForm(owner, customPainter: new OverlayWindowCompositePainter(windowCompositePainter.OverlayButtonDrawHelper, windowCompositePainter.OverlayLabelDrawHelper), opacity: 150);
		}

		public void UpdateProgressText(string text)
		{
			if(windowCompositePainter?.OverlayLabelDrawHelper == null)
			{
				return;
			}

			windowCompositePainter.OverlayLabelDrawHelper.Text = text; 
		}

		public void CloseOverlayForm(IOverlaySplashScreenHandle handle)
		{
			if (handle != null)
			{
				windowCompositePainter = null;
				SplashScreenManager.CloseOverlayForm(handle);
			}
		}

	}
}
