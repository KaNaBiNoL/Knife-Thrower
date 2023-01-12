using Zenject;

namespace KnifeThrower.Game
{
    public class LevelLostServiceInstaller : Installer<LevelLostServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelLostService>()
                .To<LevelLostService>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}