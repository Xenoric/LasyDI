using UnityEngine;

namespace LasyDI
{
    public abstract class MonoInstaller : MonoBehaviour, IInstaller
    {
        public abstract void OnInstall();
    }
}
