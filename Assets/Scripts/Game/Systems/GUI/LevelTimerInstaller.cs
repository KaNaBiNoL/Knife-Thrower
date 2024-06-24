using Zenject;

namespace KnifeThrower.Game
{
    public class LevelTimerInstaller : Installer<LevelTimerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ILevelTimer>().To<LevelTimer>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}