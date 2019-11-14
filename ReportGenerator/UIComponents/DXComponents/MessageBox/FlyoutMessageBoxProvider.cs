using DevExpress.XtraBars;
using System.Windows.Forms;

namespace ReportGenerator.UIComponents.DXComponents.MessageBox
{
	public class FlyoutMessageBoxProvider : IMessageBoxProvider
	{
		public DialogResult ShowErrorMessage(Control owner, string text, string caption)
		{
			return ShowMessage(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public DialogResult ShowInformation(Control owner, string text, string caption)
		{
			return ShowMessage(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public DialogResult ShowQuestion(Control owner, string question, string caption)
		{
			return ShowMessage(owner, question, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public DialogResult ShowMessage(Control owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
		{
			return FlyoutMessageBox.Show(owner, text, caption, buttons, icon, defaultButton);
		}
	}
}
