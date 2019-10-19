using System;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ProtocolGenerator.DocXCreation
{
  internal abstract class BlockBuilderBase
  {
    protected readonly Section _section;

		protected BlockBuilderBase(Section section)
    {
      _section = section ?? throw new ArgumentNullException(nameof(section));
		}

    protected void AppendHyperlink(Paragraph par, WorkItemHyperlink workItemHyperlink)
    {
      par.AppendHyperlink(workItemHyperlink.Link, workItemHyperlink.Text, HyperlinkType.WebLink);
    }

    protected struct WorkItemHyperlink
    {
      public string Link { get; }

      public string Text { get; }

      public WorkItemHyperlink(string text, string link)
      {
        Link = link;
        Text = text;
      }
    }
  }
}