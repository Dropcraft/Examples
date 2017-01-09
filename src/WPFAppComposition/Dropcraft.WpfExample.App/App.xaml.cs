using System.IO;
using System.Reflection;
using System.Windows;
using Dropcraft.Runtime;

namespace Dropcraft.WpfExample.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var executionPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var engine = new RuntimeConfiguration().CreateEngine(executionPath);
            engine.RuntimeContext.RegisterExtensibilityPoint("bootstrapper", new BootstrapperHandler(engine.RuntimeContext));
            engine.Start().GetAwaiter().GetResult();
        }
    }
}
