using KnifeThrower.Services.Screen;
using Zenject;

namespace KnifeThrower.Services
{
    public class UIServiceInstaller : Installer<UIServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<IUIService>().To<UIService>().AsSingle();
            subContainer.Bind<UIFactory>().AsSingle();
        }
    }
}