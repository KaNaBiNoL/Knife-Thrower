using UnityEngine;

namespace KnifeThrower.Services
{
    public class AssetService : IAssetService
    {
        public T Load<T>(string path) where T : Object =>
            Resources.Load<T>(path);
    }
}