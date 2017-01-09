using Dropcraft.Common.Package;
using Dropcraft.Common.Runtime;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Shell
{
    public class WorkspaceHandler : IExtensibilityPointHandler
    {
        private RuntimeContext _runtimeContext;

        public void Initialize(ExtensibilityPointInfo extensibilityPointInfo, RuntimeContext context)
        {
            _runtimeContext = context;
        }

        public void RegisterExtension(ExtensionInfo extensionInfo)
        {
            var extension = _runtimeContext.EntityActivator.GetExtension<IWorkspace>(extensionInfo);

            if (extension != null)
                WorkspaceExtensionRegistry.Instance.RegisterExtension(extension);
        }
    }
}