using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Commands
{
    public class BoldCommand : IEditorCommand
    {
        public string Name { get; } = "Bold";

        public void Execute(RichTextBox editor)
        {
            if (editor.Selection.IsEmpty)
                return;

            editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeight.FromOpenTypeWeight(700));
        }
    }
}