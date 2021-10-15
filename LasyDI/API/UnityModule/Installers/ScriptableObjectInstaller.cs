using UnityEngine;

namespace LasyDI
{
    public abstract class ScriptableObjectInstaller : ScriptableObject, IInstaller
    {
        public abstract void OnInstall();
    }
}
