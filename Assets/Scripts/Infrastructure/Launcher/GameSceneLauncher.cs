using KnifeThrower.Game;
using KnifeThrower.Services;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class GameSceneLauncher : BaseLauncher
    {
        public const string SceneName = "SampleScene";
    
        private IActiveShurikenController _activeShurikenController;
        private IRemainingShurikens _remainingShurikens;
        private IInputPosition _inputPosition;
        private IShurikenSpawn _shurikenSpawn;
        private IRemainingTargetsService _remainingTargetsService;

        [Inject]
        public void Construct(IActiveShurikenController
            activeShurikenController, IRemainingShurikens remainingShurikens, IInputPosition inputPosition,
            IShurikenSpawn shurikenSpawn, IRemainingTargetsService remainingTargetsService)
        {
            _remainingTargetsService = remainingTargetsService;
            _shurikenSpawn = shurikenSpawn;
            _inputPosition = inputPosition;
            _activeShurikenController = activeShurikenController;
            _remainingShurikens = remainingShurikens;
        }

        protected override void Launch()
        {
            _remainingTargetsService.Init();
            _shurikenSpawn.Init();
            _inputPosition.Init();
            _activeShurikenController.Init();
            _remainingShurikens.Init();
            
        }
    }
}