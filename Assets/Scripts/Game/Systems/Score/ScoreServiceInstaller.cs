using Zenject;

namespace KnifeThrower.Game
{
    public class ScoreServiceInstaller : Installer<ScoreServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IScoreService>().To<ScoreService>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }
    }
}