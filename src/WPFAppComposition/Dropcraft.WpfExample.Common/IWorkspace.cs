using System.Windows;

namespace Dropcraft.WpfExample.Common
{
    /// <summary>
    /// Shell workspace
    /// </summary>
    public interface IWorkspace
    {
        /// <summary>
        /// Returns visual representation of the workspace
        /// </summary>
        /// <returns>WPF control</returns>
        FrameworkElement GetView();
    }
}