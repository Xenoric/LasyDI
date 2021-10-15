using UnityEngine;

namespace LasyDI.DIContainer
{
    public sealed partial class ImplementationObjectDIContext<T> : IImplementationContext
        where T : class
    {
        private Object _prefab;

        internal void SetPrefab(Object prefab) => _prefab = prefab;
    }
}
