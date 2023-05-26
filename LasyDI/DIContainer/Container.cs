using System;
using System.Collections.Generic;
using LasyDI.Common;

namespace LasyDI.DIContainer
{
    /// <summary>
    /// Контейнер класс по хранению зависимостей
    /// </summary>
    internal sealed class Container : IDisposable
    {
        private List<Type> _containsTypes;
        private List<IImplementationContext> _containerImplementationContext;
        private string _tag;

        internal Container(string tag)
        {
            _containsTypes = new List<Type>();
            _containerImplementationContext = new List<IImplementationContext>();
            _tag = tag;
        }

        internal string Tag => _tag;

        public void Dispose()
        {
            _containerImplementationContext.ForEach(x => x.Dispose());

            _containsTypes.Clear();
            _containerImplementationContext.Clear();

            GC.SuppressFinalize(this);
        }

        internal void SetContainerTag(string tag)
        {
            _tag = tag;
        }

        internal ImplementationObjectDIContext<T> Add<T>()
            where T : class
        {
            var implementationContext = new ImplementationObjectDIContext<T>();

            _containsTypes.Add(typeof(T));
            _containerImplementationContext.Add(implementationContext);

            return implementationContext;
        }

        internal void Remove(Type type)
        {
            _containsTypes.Remove(type);
            var foundImplementation = _containerImplementationContext.Find(x => x.ImplementationType.Equals(type));
            foundImplementation.Dispose();
            _containerImplementationContext.Remove(foundImplementation);
        }

        internal object Get(Type type, Func<ImplementationObjectInfo, object> CreateCallback)
        {
            var foundImplementation = _containerImplementationContext.Find(x => x.ImplementationType.Equals(type));
            object result = default;

            if(foundImplementation == null)
            {
                ErrorHandler.SendContainerNoImplamentation(type);
            }
            else
            {
                if (foundImplementation.BindType == BindType.Single)
                {
                    if (foundImplementation.ImplementationObject == null)
                    {
                        if (foundImplementation.InstanceType != InstanceType.Implemented
                            | foundImplementation.InstanceType != InstanceType.ImplementedPrefab)
                        {
                            result = CreateCallback.Invoke(foundImplementation.GetImplementationObjectInfo());
                            foundImplementation.SetImplementation(result);
                        }
                    }
                    else
                    {
                        if(foundImplementation.InstanceType == InstanceType.ImplementedSceneObject)
                        {
                            result = CreateCallback.Invoke(foundImplementation.GetImplementationObjectInfo());
                        }
                        else
                        {
                            result = foundImplementation.ImplementationObject;
                        }
                    }
                }
                else
                {
                    result = CreateCallback.Invoke(foundImplementation.GetImplementationObjectInfo());
                }
            }

            return result;
        }

        internal bool Contains(Type type)
        {
            return _containsTypes.Contains(type);
        }
    }
}
