using System.Collections.Generic;

namespace LasyDI.Pool
{
    /// <summary>
    /// Класс по реализации пула объектов с использование DI или IoC для объектов
    /// </summary>
    /// <typeparam name="T">Любой класс Mono или .Net</typeparam>
    public abstract class BasePoolObjectDI<T> : IPoolObjectDI
        where T : class
    {
        private LinkedList<T> _poolObjects = new LinkedList<T>();
        /// <summary>
        /// Получить объект из пула
        /// </summary>
        /// <returns>Реализация объекта с зависимостями</returns>
        public T Spawn()
        {
            T result = default;

            if (_poolObjects.Count != 0)
            {
                result = _poolObjects.First.Value;
                _poolObjects.RemoveFirst();
            }
            else
            {
                result = LasyContainer.GetObject<T>();
            }

            OnSpawn(result);

            return result;
        }
        /// <summary>
        /// Возвращение объекта в пул
        /// </summary>
        /// <param name="currentObject">Любой объект реализации класса Mono или .Net</param>
        public void Despawn(T currentObject)
        {
            _poolObjects.AddFirst(currentObject);
            OnDespawn(currentObject);
        }
        /// <summary>
        /// Метод дополнительной настройки объекта при получение из пула
        /// </summary>
        /// <param name="currentObject"></param>
        public virtual void OnSpawn(T currentObject) { }
        /// <summary>
        /// Метод дополнительной настройки объекта при возвращение в пул
        /// </summary>
        /// <param name="currentObject"></param>
        public virtual void OnDespawn(T currentObject) { }
    }
}
