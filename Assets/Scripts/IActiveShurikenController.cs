using UnityEngine;

namespace KnifeThrower
{
    public interface IActiveShurikenController
    {
        public MeshRenderer PlayerMesh { get; }

        
        private void ThrowImpossible()
        {
            
        }
        
        private void ThrowPossible()
        {
            
        }
    }
}