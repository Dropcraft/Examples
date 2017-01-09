using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Shell
{
    public class Bootstrapper : IBootstrapper
    {
        public void Run()
        {
            var window = new ShellWindow();
            window.Show();
        }
    }
}