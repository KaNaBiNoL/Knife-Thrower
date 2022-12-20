using Zenject;

namespace KnifeThrower
{
    public class ActiveShurikenControllerInstaller : Installer<ActiveShurikenControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IActiveShurikenController>()
                .To<ActiveShurikenController>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}