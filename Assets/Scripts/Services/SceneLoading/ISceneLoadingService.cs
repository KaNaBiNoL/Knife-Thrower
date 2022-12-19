using KnifeThrower.Infrastructure;

namespace KnifeThrower.Systems
{
    public interface ISceneLoadingService
    {
        void Load(string sceneName);
        void SetLauncher(BaseLauncher launcher);
    }
}