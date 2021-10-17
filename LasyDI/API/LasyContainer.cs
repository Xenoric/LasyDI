using System;
using LasyDI.Pool;
using LasyDI.DIContainer;

namespace LasyDI
{
    /// <summary>
    /// Класс предоставляет точку доступа к основным функциям DI контейнера.
    /// </summary>
    public static class LasyContainer
    {
        private static ContainerService _containerService;

        static LasyContainer()
        {
            _containerService = new ContainerService();
        }

        internal static ContainerService ContainerService => _containerService;

#region API
        /// <summary>
        /// Метод создания зависимости для любого класса
        /// </summary>
        /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> Bind<T>()
            where T : class
        {
            return _containerService.Bind<T>();
        }
        /// <summary>
        /// Метод создания зависимости для любого класса реализации интерфейса или абстракции
        /// </summary>
        /// <typeparam name="I">Интерфейс или абстракция</typeparam>
        /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> Bind<I, T>()
            where I : class
            where T : class, I
        {
            return _containerService.Bind<I, T>();
        }
        /// <summary>
        /// Метод создания зависимости для пула с реализацией любого класса
        /// </summary>
        /// <typeparam name="P">Класс реализации пула <see cref="T:LasyDI.Pool.BasePoolObjectDI`1"/></typeparam>
        /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
        /// <returns>Объект-контекст настройки зависимости класса, что реализует текущий пул <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> BindPool<P, T>()
            where P : class, IPoolObjectDI
            where T : class
        {
            _containerService.Bind<P>("pool").AsSingle();
            return _containerService.Bind<T>();
        }

        #endregion
    }
}
