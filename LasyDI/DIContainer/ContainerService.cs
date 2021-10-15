using System;
using LasyDI.Bank;
using LasyDI.Common;

namespace LasyDI.DIContainer
{
    /// <summary>
    /// Сервис класс с реализаций основных функций по созданию, использованию и удалению зависимостей в DI контейнере
    /// </summary>
    internal sealed class ContainerService
    {
        private readonly ContainerBank _containerBank;
        private readonly AutoCreateBank _autoCreateBank;
        private readonly ObjectFactory _objectFactory;

        private Container _container;

        internal event Action<Type> InternalBindedEvent;

        internal ContainerService()
        {
            _containerBank = new ContainerBank();
            _autoCreateBank = new AutoCreateBank();
            _objectFactory = new ObjectFactory(GetObject);
        }

        internal ImplementationObjectDIContext<T> Bind<T>(string containerTag = "common")
            where T : class
        {
            ImplementationObjectDIContext<T> result = default;
            ErrorHandler.VereficationImplementation<T>();
            SwithContainerProxy(containerTag);

            if (CheckCurrentProxy<T>())
            {
                ErrorHandler.SendContainerErrorByDoubleImplementation<T>(_container.Tag);
            }
            else
            {
                _containerBank.SaveInBank<T>(_container);
                result = _container.Add<T>();
            }

            InternalBindedEvent?.Invoke(typeof(T));

            return result;
        }

        internal ImplementationObjectDIContext<T> Bind<I, T>()
            where I : class
            where T : class, I
        {
            ErrorHandler.VereficationAbstractionImplementattion<I, T>();
            SwithContainerProxy(nameof(I));

            return Bind<T>();
        }

        internal void Remove(Type type)
        {
            if(_containerBank.TryGetContainer(type, out var continer))
            {
                continer.Remove(type);
                _containerBank.DeleteInBank(type);
            }
        }

        internal object GetObject(Type type)
        {
            if (type.IsClass)
            {
                if (_containerBank.TryGetContainer(type, out var container))
                {
                    return container.Get(type, _objectFactory.Create);
                }
            }
            else
            {
                throw new NotImplementedException("Not complite DI for Value type or External class!");
            }

            ErrorHandler.SendContainerNoImplamentation(type);
            throw new Exception();
        }

        internal void AddInAutoCreated<T>()
        {
            _autoCreateBank.Add(typeof(T));
        }

        internal void ExecuteAutoCreated()
        {
            _autoCreateBank.CreateObjects();
        }

        private bool CheckCurrentProxy<T>()
        {
            return _container != null && _container.Contains(typeof(T));
        }

        private void SwithContainerProxy(string containerTag)
        {
            if (!_containerBank.TryGetContainer(containerTag, out var container))
            {
                 _container = _containerBank.CreateContainer(containerTag);
            }
            else
            {
                _container = container;
            }
        }
    }
}
