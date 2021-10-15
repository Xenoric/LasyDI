using UnityEngine;
using LasyDI.Common;

namespace LasyDI
{
    /// <summary>
    /// Контекст-класс для реализации запуска внедрения зависимостей DI контейнера использует реализации инсталлеров <see cref="T:LasyDI.MonoInstaller"/> и <see cref="T:LasyDI.ScriptableObjectInstaller"/>
    /// </summary>
    /// <remarks>
    /// Автоматическое создание при старте сессии.
    /// Создает зависимость для всего проекта в рамках одной сессии.
    /// В папке ресурсы должен быть префаб с данным классом.
    /// </remarks>
    public sealed class ProjectContext : Context
    {
        private void Reset() => gameObject.name = nameof(ProjectContext);

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void Initialization()
        {
            var projectContextPrefab = Resources.Load<ProjectContext>(nameof(ProjectContext));

            if(projectContextPrefab == default)
            {
                ErrorHandler.SendNotFoundProjectContext();
            }

            Instantiate(projectContextPrefab);
        }

        protected override void OnStart()
        {
            base.OnStart();
            DontDestroyOnLoad(gameObject);
        }
    }
}
