using System;
using System.Reflection;
using LasyDI.Common;

namespace LasyDI.DIContainer
{
    public sealed partial class ImplementationObjectDIContext<T> : IImplementationContext
        where T : class
    {
        private MethodBase _implementationConstructMethod;

        private void SetupConstructMethod()
        {
            if(!ImplementationHandler.TryGetConstructMethod<T>(out _implementationConstructMethod))
            {
                ErrorHandler.SendImplementationConstructMethod<T>();
            }
            else
            {
                var parametersInfos = _implementationConstructMethod.GetParameters();
                var parameters = new (Type, object)[parametersInfos.Length];

                for(var i = 0; i < parametersInfos.Length; ++i)
                {
                    parameters[i] = (parametersInfos[i].ParameterType, default);
                }

                ImplementationHandler.SetImplementationParameters(this, parameters, false);
            }
        }

        private ImplementationObjectInfo GetObjectInfo()
        {
            return new ImplementationObjectInfo
                (
                    typeof(T),
                    GetParametersMap(),
                    _implementationConstructMethod,
                    _instanceType,
                    _implementationType,
                    () =>
                    {
                        if (_implementationType == ImplementationType.Mono)
                        {
                            var result = (_instanceType == InstanceType.ImplementedPrefab)
                                                    ? _prefab
                                                    : _implementationObject;

                                _instanceType = (_instanceType == InstanceType.ImplementedPrefab
                                                    & _bindType == BindType.Transit)
                                                                   ? InstanceType.ImplementedPrefab
                                                                   : InstanceType.Created;

                            return result;
                        }
                        else
                        {
                            _instanceType = InstanceType.Created;
                            return _implementationObject;
                        }
                    }
                );
        }
    }
}
