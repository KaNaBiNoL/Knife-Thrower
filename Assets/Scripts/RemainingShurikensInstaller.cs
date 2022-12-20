using Zenject;

namespace KnifeThrower
{
    public class RemainingShurikensInstaller : Installer<RemainingShurikensInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IRemainingShurikens>()
                .To<RemainingShurikens>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}