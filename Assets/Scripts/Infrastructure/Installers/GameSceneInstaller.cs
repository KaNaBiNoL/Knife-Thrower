using KnifeThrower.Game;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GUIControlInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            ActiveShurikenControllerInstaller.Install(Container);
            RemainingShurikensInstaller.Install(Container);
            InputPositionInstaller.Install(Container);
            ShurikenSpawnInstaller.Install(Container);
            ScoreServiceInstaller.Install(Container);
            RemainingTargetsServiceInstaller.Install(Container);
            LevelLostServiceInstaller.Install(Container);
            LevelTimerInstaller.Install(Container);
            GoldForLevelInstaller.Install(Container);
        }
    }
}