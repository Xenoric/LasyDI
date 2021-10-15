using System.Collections.Generic;
using UnityEngine;

namespace LasyDI
{
    /// <summary>
    /// Контекст-класс для реализации запуска внедрения зависимостей DI контейнера использует реализации инсталлеров <see cref="T:LasyDI.MonoInstaller"/> и <see cref="T:LasyDI.ScriptableObjectInstaller"/>
    /// </summary>
    public abstract class Context : MonoBehaviour
    {
        [Header(nameof(MonoInstaller))]
        [SerializeField] private List<MonoInstaller> _monoInstallers;
        [Space]
        [Header(nameof(ScriptableObjectInstaller))]
        [SerializeField] private List<ScriptableObjectInstaller> _scriptableObjectInstallers;

        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnAwake()
        {
            _monoInstallers.ForEach(x => x.OnInstall());
            _scriptableObjectInstallers.ForEach(x => x.OnInstall());
        }

        protected virtual void OnStart()
        {
            LasyContainer.ContainerService.ExecuteAutoCreated();
        }
    }
}
