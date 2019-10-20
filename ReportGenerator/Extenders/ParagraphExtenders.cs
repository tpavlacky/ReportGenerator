using System;
using Spire.Doc.Documents;

namespace ReportGenerator.Extenders
{
  public static class ParagraphExtenders
  {
    public static void ApplyStyleSafe(this Paragraph par, string styleName)
    {
      try
      {
        par.ApplyStyle(styleName);
      }
      catch (ArgumentException)
      {
        par.ApplyStyle("Normal");
      }
    }
  }
}