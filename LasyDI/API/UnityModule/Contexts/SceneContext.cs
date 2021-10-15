using System;
using System.Collections.Generic;
using UnityEngine;

namespace LasyDI
{
    /// <summary>
    /// Контекст-класс для реализации запуска внедрения зависимостей DI контейнера использует реализации инсталлеров <see cref="T:LasyDI.MonoInstaller"/> и <see cref="T:LasyDI.ScriptableObjectInstaller"/>
    /// </summary>
    /// <remarks>
    /// Создается и настраивается в ручную на сцене.
    /// Создает зависимости в для проекта в рамках текущей сцены.
    /// ВНИМАНИЕ! При уничтожение контекст-объекта зависимости будут удалены из DI контейнера.
    /// </remarks>
    public sealed class SceneContext : Context
    {
        private Stack<Type> _usedBindedTypes = new Stack<Type>();
        private void Reset() => gameObject.name = nameof(SceneContext);

        private void OnDestroy()
        {
            Debug.Log("Scene context is destroy!");

            while(_usedBindedTypes.Count > 0)
            {
                LasyContainer.ContainerService.Remove(_usedBindedTypes.Pop());
            }
        }

        protected override void OnAwake()
        {
            LasyContainer.ContainerService.InternalBindedEvent += RegisterBindType;
            base.OnAwake();
            LasyContainer.ContainerService.InternalBindedEvent -= RegisterBindType;
        }

        private void RegisterBindType(Type type) => _usedBindedTypes.Push(type);
    }
}
