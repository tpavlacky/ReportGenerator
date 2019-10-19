using System.Drawing;

namespace ProtocolGenerator.DocXCreation
{
	public class SpireDocFontStyles : ITestReportStyles
	{
		public IDocStyle Default => new DefaultDocStyle(nameof(Default));

		public IDocStyle TestSuiteHeader => new TestSuiteHeaderDocStyle(nameof(TestSuiteHeader));

		public IDocStyle TestCaseHeader => new TestCaseHeaderDocStyle(nameof(TestCaseHeader));

		public IDocStyle SummaryHeader => new SummaryHeaderDocStyle(nameof(SummaryHeader));

		public IDocStyle PassedTestCase => new PassedTestCaseDocStyle(nameof(PassedTestCase));

		public IDocStyle FailedTestCase => new FailedTestCaseDocStyle(nameof(FailedTestCase));
	}

	public class DefaultDocStyle : DocStyle
	{
		public DefaultDocStyle(string styleName) : base(styleName, 10)
		{
		}
	}

	public abstract class TestCaseDocStyle : DocStyle
	{
		protected TestCaseDocStyle(string styleName, Color fontColor) : base(styleName, 10)
		{
			FontColor = fontColor;
		}
	}

	public sealed class PassedTestCaseDocStyle : TestCaseDocStyle
	{
		public PassedTestCaseDocStyle(string styleName) : base(styleName, Color.Green)
		{
		}
	}

	public sealed class FailedTestCaseDocStyle : TestCaseDocStyle
	{
		public FailedTestCaseDocStyle(string styleName) : base(styleName, Color.Red)
		{
		}
	}

	public sealed class TestSuiteHeaderDocStyle : DocStyle
	{
		public TestSuiteHeaderDocStyle(string styleName) : base(styleName, 16)
		{
		}
	}

	public sealed class TestCaseHeaderDocStyle : DocStyle
	{
		public TestCaseHeaderDocStyle(string styleName) : base(styleName, 11)
		{
			Italic = true;
		}
	}

	public sealed class SummaryHeaderDocStyle : DocStyle
	{
		public SummaryHeaderDocStyle(string styleName) : base(styleName, 11)
		{
			Bold = true;
		}
	}
}
