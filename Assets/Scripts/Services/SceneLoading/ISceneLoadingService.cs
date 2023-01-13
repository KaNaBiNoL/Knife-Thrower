using KnifeThrower.Infrastructure;

namespace KnifeThrower.Services
{
    public interface ISceneLoadingService
    {
        void Load(int buildIndex);
        void SetLauncher(BaseLauncher launcher);
    }
}