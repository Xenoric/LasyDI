using System;

namespace LasyDI.DIContainer
{
    internal interface IImplementationContext : IImplementationContextOption, IDisposable
    {
        Type ImplementationType { get; }
        object ImplementationObject { get; }

        ImplementationObjectInfo GetImplementationObjectInfo();
        void SetImplementation(object implementationObject);
    }
}
