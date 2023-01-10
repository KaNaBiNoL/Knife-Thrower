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

        [Inject]
        public void Construct(IActiveShurikenController
            activeShurikenController, IRemainingShurikens remainingShurikens, IInputPosition inputPosition,
            IShurikenSpawn shurikenSpawn)
        {
            _shurikenSpawn = shurikenSpawn;
            _inputPosition = inputPosition;
            _activeShurikenController = activeShurikenController;
            _remainingShurikens = remainingShurikens;
        }

        protected override void Launch()
        {
            _shurikenSpawn.Init();
            _inputPosition.Init();
            _activeShurikenController.Init();
            _remainingShurikens.Init();
        }
    }
}