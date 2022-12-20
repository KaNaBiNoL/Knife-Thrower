using KnifeThrower.Infrastructure;

namespace KnifeThrower.Services
{
    public interface ISceneLoadingService
    {
        void Load(string sceneName);
        void SetLauncher(BaseLauncher launcher);
    }
}