using Dropcraft.Common.Package;
using Dropcraft.Common.Runtime;
using Dropcraft.WpfExample.Common;

namespace Dropcraft.WpfExample.Editor
{
    public class CommandHandler : IExtensibilityPointHandler
    {
        private RuntimeContext _runtimeContext;

        public void Initialize(ExtensibilityPointInfo extensibilityPointInfo, RuntimeContext context)
        {
            _runtimeContext = context;

        }

        public void RegisterExtension(ExtensionInfo extensionInfo)
        {
            var extension = _runtimeContext.EntityActivator.GetExtension<IEditorCommand>(extensionInfo);
            if (extension != null)
                CommandExtensionRegistry.Instance.RegisterExtension(extension);
        }
    }
}
