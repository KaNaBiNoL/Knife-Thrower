using Zenject;

namespace KnifeThrower.Game
{
    public class GoldForLevelInstaller : Installer<GoldForLevelInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGoldForLevel>().To<GoldForLevel>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}