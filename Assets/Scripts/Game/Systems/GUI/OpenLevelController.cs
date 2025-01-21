using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace KnifeThrower
{
    public class OpenLevelController : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;

        void Awake()
        {
            
            int unlockedLevel = YandexGame.savesData.UnlockedLevels;
            if (unlockedLevel < 32)
            {
                Debug.Log($"{unlockedLevel}");
                for (int i = 0; i < _buttons.Length; i++)
                {
                    _buttons[i].interactable = false;
                }

                for (int i = 0; i < unlockedLevel; i++)
                {
                    Debug.Log($"{_buttons[i]}");
                    _buttons[i].interactable = true;
                }

                Debug.Log($"Unlocked level int = {unlockedLevel}");
            }
            else
            {
                YandexGame.savesData.UnlockedLevels = 32;
                unlockedLevel = YandexGame.savesData.UnlockedLevels;
            }
        }

        
    }
}