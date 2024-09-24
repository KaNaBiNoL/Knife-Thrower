using UnityEngine;

namespace KnifeThrower
{
    public interface IInputPosition
    {
        public Vector3 MousePoint { get; }
        public Vector3 MouseYPoint { get; }

        public Vector3 ClonesMousePoint0
        {
            get;
            set;
        }
        
        public Vector3 ClonesMousePoint1
        {
            get;
            set;
        }
        
        public Vector3 ClonesMousePoint2
        {
            get;
            set;
        }
        
        public Vector3 ClonesMousePoint3
        {
            get;
            set;
        }
        
        public bool IsPowerShotUsed
        {
            get;
            set;
        }
        
        

        public void Init()
        {
            
        }

        private void GetMouseCoordinates()
        {
            
        }
    }
}