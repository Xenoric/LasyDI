using System;
using UnityEngine;
using LasyDI;
using LasyDI.Common;
using LasyDI.DIContainer;

namespace LasyDI
{
    /// <summary>
    /// Класс расширения по настройке зависимости объекта-контекста <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/>
    /// </summary>
    public static class ExtentionImplementationObjectDI
    {
        /// <summary>
        /// Указать конкретную реализацию зависимости
        /// </summary>
        /// <typeparam name="I">Любой класс Mono или .Net - реализация</typeparam>
        /// <typeparam name="T">Любой класс Mono или .Net - зависимость</typeparam>
        /// <param name="context"></param>
        /// <param name="instance">Объект реализация зависимости</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> WhereInstance<I,T>(this ImplementationObjectDIContext<T> context, I instance)
            where T : class
            where I : class, T
        {
            context.SetImplementation(instance);
            context.SetInstanceType(InstanceType.Implemented);

            return context;
        }

        #region Bind Parameters
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I,T1>(this ImplementationObjectDIContext<I> context, T1 value1)
            where I : class
        {
            (Type type, object value)[] parameters =
            {
                (typeof(T1), value1)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T2">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I, T1, T2>(this ImplementationObjectDIContext<I> context, T1 value1, T2 value2)
            where I : class
        {
            (Type type, object value)[] parameters =
            {
                (typeof(T1), value1),
                (typeof(T2), value2)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T2">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T3">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I, T1, T2, T3>(this ImplementationObjectDIContext<I> context, T1 value1, T2 value2, T3 value3)
            where I : class
        {
            (Type type, object value)[] parameters =
            {
                (typeof(T1), value1),
                (typeof(T2), value2),
                (typeof(T3), value3)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T2">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T3">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T4">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I, T1, T2, T3, T4>(this ImplementationObjectDIContext<I> context, T1 value1, T2 value2, T3 value3, T4 value4)
            where I : class
        {
            (Type type, object value)[] parameters =
             {
                (typeof(T1), value1),
                (typeof(T2), value2),
                (typeof(T3), value3),
                (typeof(T4), value4)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T2">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T3">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T4">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T5">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I, T1, T2, T3, T4, T5>(this ImplementationObjectDIContext<I> context, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
            where I : class
        {
            (Type type, object value)[] parameters =
             {
                (typeof(T1), value1),
                (typeof(T2), value2),
                (typeof(T3), value3),
                (typeof(T4), value4),
                (typeof(T5), value5)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        /// <summary>
        /// Указать параметры для метода-конструктора
        /// </summary>
        /// <remarks>
        /// Порядок инициализации для повторяющихся типов аргументов метода-конструктора “Л ⇒ П”
        /// </remarks>
        /// <typeparam name="I">Любой класс Mono или .Net - зависимость</typeparam>
        /// <typeparam name="T1">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T2">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T3">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T4">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T5">Тип аргумента метода-конструктора</typeparam>
        /// <typeparam name="T6">Тип аргумента метода-конструктора</typeparam>
        /// <param name="context"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="value3"></param>
        /// <param name="value4"></param>
        /// <param name="value5"></param>
        /// <param name="value6"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<I> WithParameters<I, T1, T2, T3, T4, T5, T6>(this ImplementationObjectDIContext<I> context, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
            where I : class
        {
            (Type type, object value)[] parameters =
             {
                (typeof(T1), value1),
                (typeof(T2), value2),
                (typeof(T3), value3),
                (typeof(T4), value4),
                (typeof(T5), value5),
                (typeof(T6), value6)
            };

            ImplementationHandler.SetImplementationParameters(context, parameters);

            return context;
        }
        #endregion

        #region Unity
        /// <summary>
        /// Указать конкретную реализацию зависимости в Unity среде - префаб, задаем прямую ссылку
        /// </summary>
        /// <typeparam name="T">Любой класс Mono или наследник <see cref="T:UnityEngine.Component"/></typeparam>
        /// <param name="context"></param>
        /// <param name="prefab">Шаблон объекта среды Unity</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> FromPrefab<T>(this ImplementationObjectDIContext<T> context, T prefab)
            where T : Component
        {
            context.SetInstanceType(InstanceType.ImplementedPrefab);
            context.SetPrefab(prefab);

            return context;
        }
        /// <summary>
        /// Указать конкретную реализацию зависимости в Unity среде - префаб, загружаем из ресурсов
        /// </summary>
        /// <typeparam name="T">Любой класс Mono или наследник <see cref="T:UnityEngine.Component"/></typeparam>
        /// <param name="context"></param>
        /// <param name="parth">Путь к префабу в папке Resources</param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> FromPrefabInResources<T>(this ImplementationObjectDIContext<T> context, string parth)
           where T : Component
        {
            var foundObject = Resources.Load<T>(parth);

            if(foundObject == default)
            {
                ErrorHandler.SendNotFoundMonoObject<T>();
            }

            context.SetInstanceType(InstanceType.ImplementedPrefab);
            context.SetPrefab(foundObject);

            return context;
        }
        /// <summary>
        /// Указать конкретную реализацию зависимости в Unity среде - объект на текущей сцене
        /// </summary>
        /// <remarks>
        /// Внедрение зависимости происходит для найденного объекта и всех его следующих реализации, если тип связи - AsTransit()
        /// </remarks>
        /// <typeparam name="T">Любой класс Mono или наследник <see cref="T:UnityEngine.Component"/></typeparam>
        /// <param name="context"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> FromGameObjectOnScene<T>(this ImplementationObjectDIContext<T> context)
            where T : Component
        {
            var foundObject = GameObject.FindObjectOfType<T>();

            if(foundObject == default)
            {
                ErrorHandler.SendNotFoundMonoObject<T>();
            }

            context.SetInstanceType(InstanceType.Implemented);
            context.SetImplementation(foundObject);

            return context;
        }
        /// <summary>
        /// Указать конкретную реализацию зависимости в Unity среде - использовать объект на сцене, как префаб
        /// </summary>
        /// <remarks>
        /// Внедрение зависимости происходит для копий-реализаций объекта, кроме найденного объекта
        /// </remarks>
        /// <typeparam name="T">Любой класс Mono или наследник <see cref="T:UnityEngine.Component"/></typeparam>
        /// <param name="context"></param>
        /// <returns>Объект-контекст настройки зависимости <see cref="T:LasyDI.DIContainer.ImplementationObjectDIContext`1"/></returns>
        public static ImplementationObjectDIContext<T> FromGameObjectOnSceneLikePrefab<T>(this ImplementationObjectDIContext<T> context)
             where T : Component
        {
            var foundObject = GameObject.FindObjectOfType<T>();

            if(foundObject == default)
            {
                ErrorHandler.SendNotFoundMonoObject<T>();
            }

            context.SetInstanceType(InstanceType.ImplementedPrefab);
            context.SetPrefab(foundObject);

            return context;
        }

        #endregion

        /// <summary>
        /// Указать, что создаем объект сразу после связывания в контейнере
        /// </summary>
        /// <remarks>
        /// Создание происходит в Start во всех Контекст-классах <see cref="ProjectContext"/> и <see cref="SceneContext"/>
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ImplementationObjectDIContext<T> IsAutoCreated<T>(this ImplementationObjectDIContext<T> context)
            where T : class
        {
            LasyContainer.ContainerService.AddInAutoCreated<T>();

            return context;
        }

        /// <summary>
        /// Указать тип связи для зависимости
        /// </summary>
        /// <remarks>
        /// Реализация зависимости существует в одном экземпляре
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        public static void AsSingle<T>(this ImplementationObjectDIContext<T> context)
            where T : class
        {
            context.SetBindType(BindType.Single);
        }
        /// <summary>
        /// Указать тип связи для зависимости
        /// </summary>
        /// <remarks>
        /// Реализация зависимости происходит при вызове (по-умолчанию)
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        public static void AsTransit<T>(this ImplementationObjectDIContext<T> context)
            where T : class
        {
            context.SetBindType(BindType.Transit);
        }
    }
}
