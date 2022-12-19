using System.Collections;
using KnifeThrower.Infrastructure;
using KnifeThrower.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KnifeThrower.Systems
{
    public class SceneLoadingService : ISceneLoadingService
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private BaseLauncher _launcher;

        public SceneLoadingService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
        

        public void Load(string sceneName)
        {
            _coroutineRunner.StartCoroutine(LoadAsync(sceneName));
            
        }

        public void SetLauncher(BaseLauncher launcher)
        {
            _launcher = launcher;
        }

        public IEnumerator LoadAsync(string sceneName)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);

            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }

            yield return null;
        }
    }
}