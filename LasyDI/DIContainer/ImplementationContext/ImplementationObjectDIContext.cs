using System;

namespace LasyDI.DIContainer
{
    /// <summary>
    /// Контекс класс настройки реализации зависимости DI-контейнера с рабочим расширением <see cref="T:LasyDI.ExtentionImplementationObjectDI"/>
    /// </summary>
    /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
    public sealed partial class ImplementationObjectDIContext<T> : IImplementationContext
        where T : class
    {
        private object _implementationObject;

        internal ImplementationObjectDIContext()
        {
            SetupConstructParameters();
            SetupConstructMethod();
            SetupImplementationOption();
        }

        Type IImplementationContext.ImplementationType => typeof(T);

        object IImplementationContext.ImplementationObject => _implementationObject;

        ImplementationObjectInfo IImplementationContext.GetImplementationObjectInfo() => GetObjectInfo();
        /// <summary>
        /// Задаем реализацию при работе через интерфейс
        /// </summary>
        /// <param name="implementationObject"></param>
        void IImplementationContext.SetImplementation(object implementationObject)
        {
            _implementationObject = implementationObject;
        }

        void IDisposable.Dispose()
        {
            _implementationParameters.Clear();

            _implementationConstructMethod = default;
            _implementationParameters = default;
            _implementationObject = default;

            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Метод по работе с зависимостью типа - интерфейс или абстракция
        /// </summary>
        /// <typeparam name="I">Интерфейс или абстракция</typeparam>
        /// <returns>Расширение для внедрения зависимости типа - интерфейса или абстракции<see cref="T:LasyDI.AbstractImplementationOption`2"/></returns>
        public AbstractImplementationOption<I, T> WhereAbstraction<I>()
            where I : class
        {
            return new AbstractImplementationOption<I, T>(this);
        }
        /// <summary>
        /// Задаем реализацию при работе через расширение
        /// </summary>
        /// <param name="implementationObject"></param>
        internal void SetImplementation(object implementationObject)
        {
            _implementationObject = implementationObject;
        }
    }
}
