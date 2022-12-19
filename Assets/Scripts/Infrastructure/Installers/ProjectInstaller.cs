using KnifeThrower.Services;
using KnifeThrower.Systems;
using Zenject;

namespace KnifeThrower.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            CoroutineRunnerInstaller.Install(Container);
            SceneLoadingServiceInstaller.Install(Container);
        }
    }
}