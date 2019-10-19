using System.Drawing;

namespace ProtocolGenerator.DocXCreation
{
	public abstract class DocStyle : IDocStyle
	{
		public string StyleName { get; }

		public string FontName { get; protected set; } = FontNames.SEGOE_UI;

		public float FontSize { get; protected set; }

		public Color FontColor { get; protected set; } = Color.Black;

		public bool Bold { get; protected set; }

		public bool Italic { get; protected set; }

		public DocStyle(string styleName, float fontSize)
		{
			StyleName = styleName;
			FontSize = fontSize;
		}
	}
}
