using System.Drawing;

namespace ReportGenerator.DocXCreation
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