
namespace LasyDI.DIContainer
{
    public sealed partial class ImplementationObjectDIContext<T> : IImplementationContext
       where T : class
    {
        private BindType _bindType = BindType.Transit;
        private InstanceType _instanceType = InstanceType.Created;
        private ImplementationType _implementationType = ImplementationType.Native;

        BindType IImplementationContextOption.BindType => _bindType;
        InstanceType IImplementationContextOption.InstanceType => _instanceType;

        internal void SetBindType(BindType bindType)
        {
            _bindType = bindType;
        }

        internal void SetInstanceType(InstanceType instanceType)
        {
            _instanceType = instanceType;
        }

        private void SetupImplementationOption()
        {
            if (typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
            {
                _implementationType = ImplementationType.Mono;
            }
        }
    }
}
