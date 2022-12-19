using Zenject;

namespace KnifeThrower.Services
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}