using System;
using System.Text.RegularExpressions;

namespace ProtocolGenerator.Extenders
{
  public static class TextExtenders
  {
    public static string HtmlToPlainText(this string text)
    {
      const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";
      const string stripFormatting = @"<[^>]*(>|$)";
      const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";
      var lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
      var stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
      var tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

      text = System.Net.WebUtility.HtmlDecode(text);
      text = tagWhiteSpaceRegex.Replace(text, "><");
      text = lineBreakRegex.Replace(text, Environment.NewLine);
      text = stripFormattingRegex.Replace(text, string.Empty);
      text = Regex.Replace(text, "[\r\n]{3,}", "\r\n");

      return text;
    }
  }
}