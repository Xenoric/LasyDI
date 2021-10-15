using System;
using System.Collections.Generic;
using System.Text;

namespace LasyDI.Common
{
    internal static class ErrorHandler
    {
        internal static void VerificationImplementationParameter<T>((Type type, object value)[] parameters)
            where T : class
        {
            for(var i = 0; i < parameters.Length; ++i)
            {
                if (parameters[i].value == default)
                {
                    if (parameters[i].type.IsValueType)
                    {
                        throw new ArgumentNullException($"In implementation of type {typeof(T).Name} construct argument ValueType {parameters[i].type.Name} has null or empty!");
                    }

                    if (parameters[i].type.IsAbstract)
                    {
                        throw new NotImplementedException($"In implementation of type {typeof(T).Name} construct argument Abstaract Class or Interface {parameters[i].type.Name} has null implementation!");
                    }
                }
            }
        }

        internal static void VereficationAbstractionImplementattion<I,T>()
        {
            if (!typeof(I).IsAbstract && !typeof(I).IsInterface)
            {
                throw new Exception($"An object of type {typeof(I).Name} is not an abstract class or interface. Linking an object {typeof(T).Name} is not possible.");
            }
        }

        internal static void VereficationImplementation<T>()
        {
            if (typeof(T).IsAbstract || typeof(T).IsInterface)
            {
                throw new Exception($"Type - {typeof(T).Name} can't bind abstract or interface implementation!");
            }
        }

        internal static void SendImplementationConstructMethod<T>()
        {
            throw new NotImplementedException($"The {typeof(T).Name} implementation does not contain a constructor or method indicated by the Innject attribute.");
        }

        internal static void SendImplementationConstructMethodParament<T>(Type parameterType)
            where T : class
        {
            throw new ArgumentException($"Constructor method of type - {typeof(T).Name} not contain argument with type - {parameterType.Name}!");
        }

        internal static void SendContainerErrorByDoubleImplementation<T>(string containerTag)
        {
            if (string.IsNullOrEmpty(containerTag))
            {
                throw new Exception($"In container the implementation - {typeof(T).Name} was binded!");
            }
            else
            {
                throw new Exception($"In container with tag - {containerTag} the implementation - {typeof(T).Name} was binded!");
            }
        }

        internal static void SendContainerNoImplamentation(Type type)
        {
            throw new NotImplementedException($"In DI container not contain implementation for class of type - {type.Name}");
        }

        internal static void SendNotFoundMonoObject<T>()
        {
            throw new NotImplementedException($"The implamentation of type - {typeof(T)} not found on GameScene or Resources!");
        }

        internal static void SendNotFoundProjectContext()
        {
            throw new NullReferenceException("No prefab found ProjectContext in Resources folder!");
        }
    }
}
