using System.Collections;

namespace KnifeThrower.Services
{
    public interface ICoroutineRunner
    {
        UnityEngine.Coroutine StartCoroutine(IEnumerator enumerator);
    }
}