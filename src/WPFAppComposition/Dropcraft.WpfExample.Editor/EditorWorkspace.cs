using System.Windows;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Editor
{
    public class EditorWorkspace : IWorkspace
    {
        private EditorControl _control;

        public FrameworkElement GetView()
        {
            return _control ?? (_control = new EditorControl());
        }
    }
}