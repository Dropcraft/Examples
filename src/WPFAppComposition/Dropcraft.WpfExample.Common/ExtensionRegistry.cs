using System;
using System.Collections.Generic;

namespace Dropcraft.WpfExample.Common
{
    public class ExtensionRegistry<T>
    {
        private readonly List<T> _extensions = new List<T>();
        private static ExtensionRegistry<T> _instance;

        public static ExtensionRegistry<T> Instance => _instance ?? (_instance = new ExtensionRegistry<T>());
        public IReadOnlyCollection<T> Extensions => _extensions.AsReadOnly();

        public event Action<T> ExtensionRegistered;

        public void RegisterExtension(T extension)
        {
            _extensions.Add(extension);
            OnExtensionRegistered(extension);
        }

        protected virtual void OnExtensionRegistered(T extension)
        {
            ExtensionRegistered?.Invoke(extension);
        }
    }
}