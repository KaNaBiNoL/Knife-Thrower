using KnifeThrower.Game;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class CloneShurikenFactoryInstaller : MonoInstaller<CloneShurikenFactoryInstaller>
    {
        [SerializeField] private GameObject _shuriken;
        
        public override void InstallBindings()
        {
            Container.BindFactory<ShurikenClone, ShurikenClone.FactoryClone>().FromComponentInNewPrefab(_shuriken).AsSingle();
        }
    }
}