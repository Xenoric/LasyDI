using System;
using UnityEngine;

using Object = UnityEngine.Object;

namespace LasyDI.DIContainer
{
    internal sealed class ObjectFactory
    {
        private event Func<Type, object> GetImplamentationEvent;

        internal ObjectFactory(Func<Type, object> implamentationCallback)
        {
            GetImplamentationEvent += implamentationCallback;
        }

        internal object Create(ImplementationObjectInfo objectInfo)
        {
            object newObject = default;

            object[] paramters = new object[objectInfo.parametersMap.Length];

            for (var i = 0; i < paramters.Length; ++i)
            {
                if (objectInfo.parametersMap[i].value == null)
                {
                    paramters[i] = GetImplamentationEvent?.Invoke(objectInfo.parametersMap[i].type);
                }
                else
                {
                    paramters[i] = objectInfo.parametersMap[i].value;
                }
            }

            if (objectInfo.constructMethod.IsConstructor)
            {
                newObject = Activator.CreateInstance(objectInfo.objectType, paramters);
            }
            else
            {
                newObject = objectInfo.UsedImplementationCallback.Invoke();

                if (objectInfo.implementationType == ImplementationType.Mono)
                {
                    if(objectInfo.instanceType != InstanceType.Implemented
                        & objectInfo.instanceType != InstanceType.ImplementedSceneObject)
                    {
                        newObject = CreateMonoObject(objectInfo.objectType, (Object)newObject);
                    }
                }
                else
                {
                    if (newObject == default)
                    {
                        newObject = Activator.CreateInstance(objectInfo.objectType);
                    }
                }

                objectInfo.constructMethod.Invoke(newObject, paramters);
            }

            return newObject;
        }

        private Object CreateMonoObject(Type objectType, Object prefab)
        {
            return (prefab == default)
                            ? new GameObject(objectType.Name).AddComponent(objectType)
                            : Object.Instantiate(prefab);
        }
    }
}
