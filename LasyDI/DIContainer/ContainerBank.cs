using System;
using System.Collections.Generic;
using LasyDI.DIContainer;

namespace LasyDI.Bank
{
    /// <summary>
    /// Класс хранилище по предоставлению ссылок на контейнер через типы зависимостей
    /// </summary>
    internal sealed class ContainerBank
    {
        private List<Container> _containers;
        private ContainerBankTable _nativeTable;
        private ContainerBankTable _monoTable;

        internal ContainerBank()
        {
            _nativeTable = new ContainerBankTable();
            _monoTable = new ContainerBankTable();
            _containers = new List<Container>();
        }

        internal Container CreateContainer(string tag)
        {
            var container = new Container(tag);
            _containers.Add(container);

            return container;
        }

        internal void SaveInBank<T>(Container container)
        {
            if (typeof(T).IsSubclassOf(typeof(UnityEngine.Object)))
            {
                _monoTable.Add(typeof(T), container);
            }
            else
            {
                _nativeTable.Add(typeof(T), container);
            }
        }
        
        internal bool TryGetContainer(Type type, out Container container)
        { 
            if (type.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                container = _monoTable.Read(type);
            }
            else
            {
                container = _nativeTable.Read(type);
            }

            return container != default;
        }

        internal bool TryGetContainer(string tag, out Container container)
        {
            container = _containers.Find(x => x.Tag.Equals(tag));

            return container != default;
        }

        internal void DeleteInBank(Type type)
        {
            if (type.IsSubclassOf(typeof(UnityEngine.Object)))
            {
                _monoTable.Remove(type);
            }
            else
            {
                _nativeTable.Remove(type);
            }
        }

        private sealed class ContainerBankTable
        {
            private IDictionary<int, Container> _containerTable;

            internal ContainerBankTable()
            {
                _containerTable = new Dictionary<int, Container>();
            }

            internal void Add(Type type, Container container)
            {
                _containerTable.Add(type.GetHashCode(), container);
            }

            internal Container Read(Type type)
            {
                return _containerTable?[type.GetHashCode()];
            }

            internal void Remove(Type type)
            {
                _containerTable.Remove(type.GetHashCode());
            }
        }
    }
}
