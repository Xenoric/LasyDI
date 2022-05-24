using System;
using System.Reflection;
using LasyDI.DIContainer;

namespace LasyDI.Common
{
    internal static class ImplementationHandler
    {
        internal static bool TryGetConstructMethod<T>(out MethodBase constructMethod)
            where T : class
        {
            var methodInfos = typeof(T).GetMethods();
            constructMethod = default;

            for (var i = 0; i < methodInfos.Length - 1; ++i)
            {
                if (methodInfos[i].GetCustomAttribute<InjectAttribute>() != default)
                {
                    constructMethod = methodInfos[i];
                    break;
                }
            }

            if (constructMethod == default && !typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
            {
                var ctrs = typeof(T).GetConstructors();
                constructMethod = ctrs?[default];
            }

            return constructMethod != default;
        }        

        internal static void SetImplementationParameters<T>(ImplementationObjectDIContext<T> context, (Type type, object value)[] parameters, bool isWrited = true)
            where T : class
        {
            ImplementationParametersTypeBypass
                (
                    parameters.Length,
                    index =>
                    {
                        return parameters[index].type;
                    },
                    result =>
                    {
                        context.SetParameter
                            (
                                parameters[result.indexArray].type,
                                parameters[result.indexArray].value,
                                isWrited,
                                result.indexObject
                            );
                    }
                );
        }

        internal static void SetImplementationAbstaction<I, T>(ImplementationObjectDIContext<T> context, (Type type, object value)[] abstractions)
            where I : class
            where T : class
        {
            ImplementationParametersTypeBypass
                (
                    abstractions.Length,
                    index =>
                    {
                        return typeof(I);
                    },
                    result =>
                    {
                        context.SetAbstraction
                        (
                            typeof(I),
                            abstractions[result.indexArray].type,
                            abstractions[result.indexArray].value,
                            result.indexObject
                        );
                    }
                );
        }

        private static void ImplementationParametersTypeBypass(int length, Func<int, Type> getCallback, Action<(int indexArray, int indexObject)> setCallback)
        {
            int index = default;
            Type lastType = default;

            for (var i = 0; i < length; ++i)
            {
                var extructType = getCallback?.Invoke(i);

                if (lastType != null)
                {
                    if (!lastType.Equals(extructType))
                    {
                        index = default;
                    }
                    else
                    {
                        index++;
                    }
                }

                lastType = extructType;
                setCallback?.Invoke((i, index));
            }
        }
    }
}
