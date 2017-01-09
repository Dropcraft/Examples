using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Editor
{
    /// <summary>
    /// Interaction logic for EditorControl.xaml
    /// </summary>
    public partial class EditorControl
    {
        public ObservableCollection<IEditorCommand> Commands { get; } = new ObservableCollection<IEditorCommand>();

        public EditorControl()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += EditorControlLoaded;
        }

        private void EditorControlLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var ext in CommandExtensionRegistry.Instance.Extensions)
            {
                ExtensionRegistered(ext);
            }

            CommandExtensionRegistry.Instance.ExtensionRegistered += ExtensionRegistered;
        }

        private void ExtensionRegistered(IEditorCommand command)
        {
            Commands.Add(command);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = e.Source as Button;
            if (button == null)
                return;

            var command = Commands.FirstOrDefault(x => x.Name == (string) button.Content);
            command?.Execute(RichTextBox);
        }
    }
}
