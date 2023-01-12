using Zenject;

namespace KnifeThrower.Game
{
    public class RemainingTargetsServiceInstaller : Installer<RemainingTargetsServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IRemainingTargetsService>().
                To<RemainingTargetsService>().
                FromNewComponentOnNewGameObject()
                .AsSingle().
                NonLazy();
        }
    }
}