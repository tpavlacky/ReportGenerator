using ReportGenerator.Properties;
using System;
using System.Drawing;

namespace ReportGenerator.UIComponents.DXComponents.OverlayForm
{
	internal class CancelableOverlayWindowCompositePainter
	{
		private readonly Image _buttonImage;
		private readonly Image _hotButtonImage;

		internal OverlayLabelDrawHelper OverlayLabelDrawHelper { get; }
		internal OverlaButtonDrawHelper OverlayButtonDrawHelper { get; }

		public CancelableOverlayWindowCompositePainter(Action onCancelClick)
		{
			this._buttonImage = CreateButtonImage();
			this._hotButtonImage = CreateHotButtonImage();

			this.OverlayLabelDrawHelper = new OverlayLabelDrawHelper();
			this.OverlayButtonDrawHelper = new OverlaButtonDrawHelper(_hotButtonImage, _buttonImage, onCancelClick);
		}

		private Image CreateButtonImage()
		{
			return ImageHelper.CreateImage(Resources.cancel_normal);
		}

		private Image CreateHotButtonImage()
		{
			return ImageHelper.CreateImage(Resources.cancel_active);
		}
	}
}
