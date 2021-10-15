using System;
using System.Collections.Generic;
using LasyDI.Common;

namespace LasyDI.DIContainer
{
    public sealed partial class ImplementationObjectDIContext<T> : IImplementationContext
        where T : class
    {
        private IDictionary<int, (Type type, object value)> _implementationParameters;

        internal void SetParameter(Type paramterType, object value, bool isWrited, int index = default)
        {
            var hash = ConvertHashType(paramterType, index);

            if (isWrited && !_implementationParameters.ContainsKey(hash))
            {
                ErrorHandler.SendImplementationConstructMethodParament<T>(paramterType);
            }
            else
            {
                _implementationParameters[hash] = (paramterType, value);
            }
        }

        internal void SetAbstraction(Type abstractionType, Type implementationType, object implementationObject = default, int index = default)
        {
            var hash = ConvertHashType(abstractionType, index);

            if (implementationObject == default)
            {
                _implementationParameters.Remove(hash);

                SetParameter(implementationType, implementationObject, false, index);
            }
            else
            {
                _implementationParameters[hash] = (implementationType, implementationObject);
            }

        }

        private (Type, object)[] GetParametersMap()
        {
            var parameters = new (Type type, object value)[_implementationParameters.Count];
            _implementationParameters.Values.CopyTo(parameters, default);

            ErrorHandler.VerificationImplementationParameter<T>(parameters);

            return parameters;
        }

        private int ConvertHashType(Type type, int index = default)
        {
            return typeof(T).GetHashCode() + type.GetHashCode() + index;
        }

        private void SetupConstructParameters()
        {
            _implementationParameters = new Dictionary<int, (Type, object)>();
        }
    }
}
