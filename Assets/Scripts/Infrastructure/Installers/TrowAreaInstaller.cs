using UnityEngine;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class TrowAreaInstaller : MonoInstaller
    {
        [SerializeField] private ThrowArea _throwArea;

        public override void InstallBindings()
        {
          Container.Bind<ThrowArea>().FromInstance(_throwArea).AsSingle().NonLazy();
        }
    }
}