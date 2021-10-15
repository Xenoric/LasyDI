using System;
using System.Reflection;

namespace LasyDI.DIContainer
{
    /// <summary>
    /// Данные по созданию объекта из DI контейнера
    /// </summary>
    public readonly struct ImplementationObjectInfo
    {
        internal readonly (Type type, object value)[] parametersMap;
        internal readonly Type objectType;
        internal readonly MethodBase constructMethod;

        internal readonly InstanceType instanceType;
        internal readonly ImplementationType implementationType;

        internal readonly Func<object> UsedImplementationCallback;

        public ImplementationObjectInfo(
            Type objectType,
            (Type, object)[] parametersMap,
            MethodBase constructMethod,
            InstanceType instanceType,
            ImplementationType implementationType,
            Func<object> UsedImplementationCallback)
        {
            this.objectType = objectType;
            this.parametersMap = parametersMap;
            this.constructMethod = constructMethod;
            this.instanceType = instanceType;
            this.implementationType = implementationType;
            this.UsedImplementationCallback = UsedImplementationCallback;
        }
    }
}
