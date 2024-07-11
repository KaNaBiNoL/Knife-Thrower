using Zenject;
using UnityEngine;

namespace KnifeThrower
{
    public class GUIControlInstaller : Installer<GUIControlInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGUIControl>().To<GUIControl>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}