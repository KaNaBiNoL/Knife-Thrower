using Zenject;

namespace KnifeThrower
{
    public class ShurikenSpawnInstaller : Installer<ShurikenSpawnInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IShurikenSpawn>()
                .To<ShurikenSpawn>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}