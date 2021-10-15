using System;
using LasyDI.Common;
using LasyDI.DIContainer;

namespace LasyDI
{
    /// <summary>
    ///  Расширение для внедрения зависимости типа - интерфейса или абстракции <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/>
    /// </summary>
    /// <typeparam name="I">Интерфейс или абстракции, что используется в зависимости текущего класса</typeparam>
    /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
    public readonly struct AbstractImplementationOption<I, T>
        where I : class
        where T : class
    {
        public readonly ImplementationObjectDIContext<T> context;

        public AbstractImplementationOption(ImplementationObjectDIContext<T> context)
        {
            this.context = context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1>(T1 implementation1)
            where T1 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <param name="implementation2">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1,T2>(T1 implementation1, T2 implementation2)
            where T1 : class, I
            where T2 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1),
                (typeof(T2), implementation2)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <param name="implementation2">Реализация интерфейса или абстракции</param>
        /// <param name="implementation3">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1, T2, T3>(T1 implementation1, T2 implementation2, T3 implementation3)
            where T1 : class, I
            where T2 : class, I
            where T3 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1),
                (typeof(T2), implementation2),
                (typeof(T3), implementation3)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <param name="implementation2">Реализация интерфейса или абстракции</param>
        /// <param name="implementation3">Реализация интерфейса или абстракции</param>
        /// <param name="implementation4">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1, T2, T3, T4>(T1 implementation1, T2 implementation2, T3 implementation3, T4 implementation4)
            where T2 : class, I
            where T1 : class, I
            where T3 : class, I
            where T4 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1),
                (typeof(T2), implementation2),
                (typeof(T3), implementation3),
                (typeof(T4), implementation4)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T5">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <param name="implementation2">Реализация интерфейса или абстракции</param>
        /// <param name="implementation3">Реализация интерфейса или абстракции</param>
        /// <param name="implementation4">Реализация интерфейса или абстракции</param>
        /// <param name="implementation5">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1, T2, T3, T4, T5>(T1 implementation1, T2 implementation2, T3 implementation3, T4 implementation4, T5 implementation5)
            where T2 : class, I
            where T1 : class, I
            where T3 : class, I
            where T4 : class, I
            where T5 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1),
                (typeof(T2), implementation2),
                (typeof(T3), implementation3),
                (typeof(T4), implementation4),
                (typeof(T5), implementation5)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через реализацию
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T5">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T6">Тип интерфейса или абстракции</typeparam>
        /// <param name="implementation1">Реализация интерфейса или абстракции</param>
        /// <param name="implementation2">Реализация интерфейса или абстракции</param>
        /// <param name="implementation3">Реализация интерфейса или абстракции</param>
        /// <param name="implementation4">Реализация интерфейса или абстракции</param>
        /// <param name="implementation5">Реализация интерфейса или абстракции</param>
        /// <param name="implementation6">Реализация интерфейса или абстракции</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromImplementation<T1, T2, T3, T4, T5, T6>(T1 implementation1, T2 implementation2, T3 implementation3, T4 implementation4, T5 implementation5, T6 implementation6)
            where T2 : class, I
            where T1 : class, I
            where T3 : class, I
            where T4 : class, I
            where T5 : class, I
            where T6 : class, I
        {
            (Type, object)[] abstractions =
            {
                (typeof(T1), implementation1),
                (typeof(T2), implementation2),
                (typeof(T3), implementation3),
                (typeof(T4), implementation4),
                (typeof(T5), implementation5),
                (typeof(T6), implementation6)
            };

            ImplementationHandler.SetImplementationAbstaction<I, T>(context, abstractions);

            return context;
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1>()
            where T1 : class, I
        {
            return FromImplementation<T1>(default);
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1, T2>()
            where T1 : class, I
            where T2 : class, I
        {
            return FromImplementation<T1, T2>(default, default);
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1, T2, T3>()
            where T1 : class, I
            where T2 : class, I
            where T3 : class, I
        {
            return FromImplementation<T1, T2, T3>(default, default, default);
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1, T2, T3, T4>()
            where T1 : class, I
            where T2 : class, I
            where T3 : class, I
            where T4 : class, I
        {
            return FromImplementation<T1, T2, T3, T4>(default, default, default, default);
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T5">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1, T2, T3, T4, T5>()
            where T1 : class, I
            where T2 : class, I
            where T3 : class, I
            where T4 : class, I
            where T5 : class, I
        {
            return FromImplementation<T1, T2, T3, T4, T5>(default, default, default, default, default);
        }
        /// <summary>
        /// Указать интерфейс или абстракцию для метода-конструктора, через зависимость DI-контейнера
        /// </summary>
        /// <typeparam name="T1">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T2">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T3">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T4">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T5">Тип интерфейса или абстракции</typeparam>
        /// <typeparam name="T6">Тип интерфейса или абстракции</typeparam>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public ImplementationObjectDIContext<T> FromContainer<T1, T2, T3, T4, T5, T6>()
            where T1 : class, I
            where T2 : class, I
            where T3 : class, I
            where T4 : class, I
            where T5 : class, I
            where T6 : class, I
        {
            return FromImplementation<T1, T2, T3, T4, T5, T6>(default, default, default, default, default, default);
        }
    }
}
