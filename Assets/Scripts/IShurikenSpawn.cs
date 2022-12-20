using UnityEngine.Events;

namespace KnifeThrower
{
    public interface IShurikenSpawn
    {
        public static UnityEvent OnShurikenThrowed = new UnityEvent();
        
        public void Init()
        {
            
        }

        private void SpawnToThrow()
        {
            
        }
    }
}