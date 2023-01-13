using KnifeThrower.Services;
using KnifeThrower.Systems;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class BootstrapLauncher : BaseLauncher
    {
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }
        protected override void Launch()
        {
            _sceneLoadingService.Load(1);
        }
    }
}