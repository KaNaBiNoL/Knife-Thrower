using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace KnifeThrower.Game
{
    public class Shuriken : MonoBehaviour
    {
        private IInputPosition _inputPosition;

        public void Construct(IInputPosition inputPosition)
        {
            _inputPosition = inputPosition;
        }

        public class Factory : PlaceholderFactory<Shuriken>
        {
            
        }
    }
}