using System.Windows.Controls;
using System.Windows.Documents;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Commands
{
    public class ClearCommand : IEditorCommand
    {
        public string Name { get; } = "Clear";

        public void Execute(RichTextBox editor)
        {
            var allText = new TextRange(editor.Document.ContentStart, editor.Document.ContentEnd) { Text = string.Empty };
            allText.Text = string.Empty;
        }
    }
}