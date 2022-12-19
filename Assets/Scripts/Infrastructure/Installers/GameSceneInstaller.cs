using KnifeThrower.Game;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
           PauseServiceInstaller.Install(Container);
        }
    }
}