using KnifeThrower.Services;
using KnifeThrower.Systems;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class MenuLauncher : BaseLauncher
    {
        public const string SceneName = "MenuScene";
        
        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        public void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }
        protected override void Launch()
        {
            _sceneLoadingService.SetLauncher(this);




            IsReady = true;
        }
    }
}