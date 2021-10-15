using System;
using System.Collections.Generic;
using System.Text;

namespace LasyDI.DIContainer
{
    internal sealed class AutoCreateBank
    {
        private Stack<Type> _autoCreadedObjectsType = new Stack<Type>();

        internal void Add(Type type)
        {
            _autoCreadedObjectsType.Push(type);
        }

        internal void CreateObjects()
        {
            while(_autoCreadedObjectsType.Count > 0)
            {
                LasyContainer.ContainerService.GetObject(_autoCreadedObjectsType.Pop());
            }
        }
    }
}
