using System.Windows.Forms;

namespace ReportGenerator.UIComponents.DXComponents.MessageBox
{
	public interface IMessageBoxProvider
	{
		DialogResult ShowErrorMessage(Control owner, string text, string caption);
		DialogResult ShowInformation(Control owner, string text, string caption);
		DialogResult ShowMessage(Control owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1);
		DialogResult ShowQuestion(Control owner, string question, string caption);
	}
}