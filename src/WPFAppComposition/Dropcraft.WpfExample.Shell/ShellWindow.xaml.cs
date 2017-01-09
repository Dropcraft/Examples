using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Shell
{
    /// <summary>
    /// Interaction logic for ShellWindow.xaml
    /// </summary>
    public partial class ShellWindow : Window, INotifyPropertyChanged
    {
        private FrameworkElement _workspace;

        public FrameworkElement Workspace
        {
            get { return _workspace; }
            set
            {
                _workspace = value;
                OnPropertyChanged();
            }
        }

        public ShellWindow()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var workspace = WorkspaceExtensionRegistry.Instance.Extensions.FirstOrDefault();
            if (workspace != null)
            {
                ExtensionRegistered(workspace);
            }

            WorkspaceExtensionRegistry.Instance.ExtensionRegistered += ExtensionRegistered;
        }

        private void ExtensionRegistered(IWorkspace workspace)
        {
            Workspace = workspace.GetView();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
