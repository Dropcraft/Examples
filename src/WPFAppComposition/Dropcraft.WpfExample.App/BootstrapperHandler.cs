using Dropcraft.Common.Package;
using Dropcraft.Common.Runtime;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.App
{
    public class BootstrapperHandler : IExtensibilityPointHandler
    {
        private RuntimeContext _runtimeContext;

        public BootstrapperHandler(RuntimeContext runtimeContext)
        {
            _runtimeContext = runtimeContext;
        }

        public void Initialize(ExtensibilityPointInfo extensibilityPointInfo, RuntimeContext context)
        {
            _runtimeContext = context;
        }

        public void RegisterExtension(ExtensionInfo extensionInfo)
        {
            var bootstrapper = _runtimeContext.EntityActivator.GetExtension<IBootstrapper>(extensionInfo);
            bootstrapper?.Run();
        }
    }
}
