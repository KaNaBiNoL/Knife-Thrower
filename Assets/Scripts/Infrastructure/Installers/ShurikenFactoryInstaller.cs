using System;
using KnifeThrower.Game;
using UnityEngine;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class ShurikenFactoryInstaller : MonoInstaller<ShurikenFactoryInstaller>
    {
        [SerializeField] private GameObject _shuriken;
        
        public override void InstallBindings()
        {
            Container.BindFactory<Shuriken, Shuriken.Factory>().FromComponentInNewPrefab(_shuriken).AsSingle();
        }
    }
}