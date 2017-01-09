using System.Windows.Controls;

namespace Dropcraft.WpfExample.Common
{
    /// <summary>
    /// Represents an individual editor comment
    /// </summary>
    public interface IEditorCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="editor">Target text editor</param>
        void Execute(RichTextBox editor);
    }
}