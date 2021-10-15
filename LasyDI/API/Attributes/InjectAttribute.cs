using System;

namespace LasyDI
{
    /// <summary>
    ///  Атрибут по создания метода-конструктора для Mono или .Net класса
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
    }
}
