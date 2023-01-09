using UnityEngine;

namespace KnifeThrower.Services
{
    public abstract class BaseScreen: MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}