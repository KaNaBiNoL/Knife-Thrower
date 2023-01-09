using UnityEngine;

namespace KnifeThrower.Services
{
    public interface IAssetService
    {
        T Load<T>(string path) where T : Object;
    }
}