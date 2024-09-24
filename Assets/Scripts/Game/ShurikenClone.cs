using UnityEngine;
using Zenject;

namespace KnifeThrower.Game
{
    public class ShurikenClone : MonoBehaviour
    {
        private IInputPosition _inputPosition;

        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
        }
        
        public class FactoryClone : PlaceholderFactory<ShurikenClone>
        {
            
        }
        

        
    }
}