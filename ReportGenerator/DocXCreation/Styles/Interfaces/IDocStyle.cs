using System.Drawing;

namespace ProtocolGenerator.DocXCreation
{
	public interface IDocStyle
	{
		string StyleName { get; }
		bool Bold { get; }
		bool Italic { get; }
		Color FontColor { get; }
		string FontName { get; }
		float FontSize { get; }
	}
}