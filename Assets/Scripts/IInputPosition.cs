using UnityEngine;

namespace KnifeThrower
{
    public interface IInputPosition
    {
        public Vector3 MousePoint { get; }
        public Vector3 MouseYPoint { get; }
        

        public void Init()
        {
            
        }

        private void GetMouseCoordinates()
        {
            
        }
    }
}