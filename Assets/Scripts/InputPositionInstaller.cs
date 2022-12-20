using Zenject;

namespace KnifeThrower
{
    public class InputPositionInstaller : Installer<InputPositionInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputPosition>()
                .To<InputPosition>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}